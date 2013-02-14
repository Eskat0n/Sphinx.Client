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
using System.IO;
using System.Net;
using System.Text;
using Sphinx.Client.Commands;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;
using Sphinx.Client.Network;

#endregion

namespace Sphinx.Client.Connections
{
	public abstract class ConnectionBase: IDisposable
	{
		#region Fields
		private string _host;
		private int _port;

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the class. <see cref="Host"/> property must be specified before invoking <see cref="Open()"/> method.
		/// </summary>
		protected ConnectionBase()
		{
		}

		/// <summary>
		/// Initializes a new instance of the class and binds it to the specified host. Default port value remains.
		/// </summary>
		/// <param name="host">Remote Sphinx server host address to which you intend to connect. Default port number value will be used to establish connection.</param>
		protected ConnectionBase(string host): this()
		{
			Host = host;
		}

		/// <summary>
		/// Initializes a new instance of the class and binds it to the specified port on the specified host.
		/// </summary>
		/// <param name="host">Remote Sphinx server host address to which you intend to connect.</param>
		/// <param name="port">The port number of the Sphinx server host to which you intend to connect.</param>
		protected ConnectionBase(string host, int port): this(host)
		{
			Port = port;
		}

		/// <summary>
		/// Initializes a new instance of the class and binds it to the specified local endpoint.
		/// </summary>
		/// <param name="address">The <see cref="IPEndPoint"/> of remote Sphinx server containing host address and port to which you intend to connect.</param>
		protected ConnectionBase(IPEndPoint address)
		{
			ArgumentAssert.IsNotNull(address, "address");
			Host = address.Address.ToString();
			Port = address.Port;
		}

		~ConnectionBase()
		{
			Dispose(false);
		}
		#endregion

		#region Properties

		/// <summary>
		/// Sphinx server host address.
		/// </summary>
		public string Host
		{
			get { return _host; }
			set
			{
				ArgumentAssert.IsNotEmpty(value, "Host");
				_host = value;
			}
		}

		/// <summary>
		/// Sphinx server port number.
		/// </summary>
		public int Port
		{
			get { return _port; }
			set
			{
				ArgumentAssert.IsInRange(value, 1, 65535, "Port");
				_port = value;
			}
		}

		#region Abstract
		/// <summary>
		/// Gets or sets the socket connection timeout. Specified in milliseconds.
		/// </summary>
		public abstract int ConnectionTimeout { get; set; }

		/// <summary>
		/// Gets a value indicating whether the underlying socket is connected to a remote host.
		/// </summary>
		public abstract bool IsConnected { get; }

		/// <summary>
		/// Character encoding used to encode and decode strings
		/// </summary>
		public abstract Encoding Encoding { get; set; }
		
		/// <summary>
		/// Returns network client socket object
		/// </summary>
		protected abstract ISocketAdapter Socket { get; set; }

		/// <summary>
		/// Get underlying network data stream object
		/// </summary>
		protected abstract IStreamAdapter DataStream { get; }

		/// <summary>
		/// Returns <see cref="BinaryFormatterFactory"/> object to create binary formmater to (de)serialize data
		/// </summary>
		internal protected abstract IBinaryFormatterFactory FormatterFactory { get; }

		#endregion

		#endregion

		#region Methods

		#region Implemented

		/// <summary>
		/// Disposes this ñonnection and closes underlying socket.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Internal overloaded virtual version of Dispose method. Used to allow derived classes release allocated resources.
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				Close();
			}
		}

		#endregion

		#region Abstract
		/// <summary>
		/// Opens new connection to Sphinx server.
		/// </summary>
		public abstract void Open();

		/// <summary>
		/// Closes opened connection to Sphinx server.
		/// </summary>
		public abstract void Close();

		/// <summary>
		/// Performs specified command against this connection. Inetrnal method, called from command.
		/// </summary>
		/// <param name="command"></param>
		internal abstract void PerformCommand(CommandBase command);
		#endregion

		#endregion
	}
}