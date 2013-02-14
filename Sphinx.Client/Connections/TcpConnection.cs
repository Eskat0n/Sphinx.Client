#region Copyright
// 
// Copyright (c) 2009-2011, Rustam Babadjanov <theplacefordev [at] gmail [dot] com>
// 
// This program is free software; you can redistribute it and/or modify it
// under the terms of the GNU Lesser General Public License version 2.1 as published
// by the Free Software Foundation.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
#endregion
#region Usings

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using Sphinx.Client.Commands;
using Sphinx.Client.Common;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;
using Sphinx.Client.Network;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.Connections
{
	public class TcpConnection: ConnectionBase
	{
		#region Constants
		protected const int MAJOR_PROTOCOL_VERSION = 1;
		protected const int DEFAULT_CLIENT_TIMEOUT_MS = 0;
		protected const int DEFAULT_PORT = 9312;

		#endregion

		#region Fields
		private IBinaryFormatterFactory _formatterFactory;
		private int _connectionTimeout = DEFAULT_CLIENT_TIMEOUT_MS;
		private Encoding _encoding = Encoding.UTF8;
		private ISocketAdapter _socket;
		#endregion

		#region Constructors
		public TcpConnection()
		{
		}

		public TcpConnection(string host): base(host, DEFAULT_PORT)
		{
		}

		public TcpConnection(string host, int port): base(host, port)
		{
		}
		
		public TcpConnection(IPEndPoint address): base(address)
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the connection timeout. Specified in milliseconds. Default is 0.
		/// </summary>
		public override int ConnectionTimeout
		{
			get { return _connectionTimeout; }
			set
			{
				_connectionTimeout = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the underlying socket is connected to a remote host.
		/// </summary>
		public override bool IsConnected
		{
			get { return Socket.Connected; }
		}

		/// <summary>
		/// Character encoding used to encode and decode strings. Default value is UTF-8.
		/// </summary>
		public override Encoding Encoding
		{
			get { return _encoding; }
			set
			{
				ArgumentAssert.IsNotNull(value, "Encoding");
				_encoding = value;
			}
		}

		/// <summary>
		/// Returns network client socket object
		/// </summary>
		protected override ISocketAdapter Socket
		{
			get 
			{ 
				if (_socket == null)
				{
					_socket = new TcpSocketAdapter();
				}
				return _socket;
			}

			set { _socket = value; }
		}

		/// <summary>
		/// Underlying network data stream object
		/// </summary>
		protected override IStreamAdapter DataStream
		{
			get
			{
				if (IsConnected)
				{
					return Socket.DataStream;
				}
				return null;
			}
		}

		/// <summary>
		/// Returns <see cref="BinaryFormatterFactory"/> object to create binary formmater to create stream (de)serializers.
		/// TcpConnection is strictly binded to big-engian byte-order and UTF-8 character encoding (as defined by binary Sphinx protocol).
		/// </summary>
		internal protected override IBinaryFormatterFactory FormatterFactory
		{
			get
			{
				if (_formatterFactory == null)
				{
					_formatterFactory = new BinaryFormatterFactory(BinaryFormatType.BigEndian, Encoding);
				}
				return _formatterFactory;
			}
		}

		#endregion

		#region Methods
		/// <summary>
		/// Open connection to Sphinx server
		/// </summary>
		public override void Open()
		{
			ArgumentAssert.IsNotEmpty(Host, "Host");
			// close existing connection, before opening new one
			Close();
			// reassign server endpoint address arguments
			Socket.Host = Host;
			Socket.Port = Port;
			Socket.ConnectionTimeout = ConnectionTimeout;
			Socket.Open();
		}

		/// <summary>
		/// Close existing connection
		/// </summary>
		public override void Close()
		{
			if (IsConnected) {
				Socket.Close();
				// NOTE: Formatter factory should be reinitialized only after current connection are closed
				_formatterFactory = null; 
			}
		}

		/// <summary>
		/// Send request to Sphinx server using underlying data stream and process server response.
		/// </summary>
		/// <param name="command">Command extending <see cref="CommandBase"/> class.</param>
		internal override void PerformCommand(CommandBase command)
		{
			ArgumentAssert.IsNotNull(command, "command");
			Open();
			try 
			{
				SendHandshake();
				command.Serialize(DataStream);
				DataStream.Flush();
				command.Deserialize(DataStream);
			}
			finally {
				Close();
			}
		}

		/// <summary>
		/// Sends client protocol version and checks protocol version supported by server.
		/// </summary>
		/// <exception cref="SphinxException">Throws exception if server protocol version is not supported</exception>
		protected virtual void SendHandshake()
		{
			// check protocol version supported by remote Sphinx server
			IBinaryReader reader = FormatterFactory.CreateReader(DataStream);
			int protocolVersion = reader.ReadInt32();
			if (protocolVersion < MAJOR_PROTOCOL_VERSION) 
			{
				throw new SphinxException(String.Format(Messages.Exception_ProtocolVersionNotSupported, MAJOR_PROTOCOL_VERSION, protocolVersion));
			}

			// send protocol version supported by client
			IBinaryWriter writer = FormatterFactory.CreateWriter(DataStream);
			writer.Write(MAJOR_PROTOCOL_VERSION);
			DataStream.Flush();
		}

		#endregion

	}
}
