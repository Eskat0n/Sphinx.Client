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
using System.Net.Sockets;
using Sphinx.Client.Helpers;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.Network
{
	public class TcpSocketAdapter : ISocketAdapter, IDisposable
    {
    	private const int DEFAULT_TIMEOUT_VALUE = 0;

		#region Fields
		private int _connectionTimeout = DEFAULT_TIMEOUT_VALUE;
		private string _host;
		private int _port;
		private IStreamAdapter _streamAdapter;
		private TcpClient _socket;

		#endregion

		#region Constructors
		public TcpSocketAdapter()
        {
        }

        public TcpSocketAdapter( string host, int port ): this()
        {
            Host = host;
            Port = port;
        }
        
		~TcpSocketAdapter()
		{
			Dispose(false);
		}
        #endregion

        #region Properties

    	public int ConnectionTimeout
    	{
    		get { return _connectionTimeout; }
    		set { _connectionTimeout = value; }
    	}

		public string Host
		{
			get { return _host; }
			set { _host = value; }
		}

		public int Port
		{
			get { return _port; }
			set { _port = value; }
		}

		public bool Connected
        {
			get { return Socket != null && Socket.Connected; }
        }

		public IStreamAdapter DataStream
        {
			get
			{
				if (!Connected)
				{
					throw new InvalidOperationException(Messages.Exception_ClientSocketNotConnected);
				}
				if (_streamAdapter == null)
				{
					Stream networkStream = Socket.GetStream();
					_streamAdapter = new TcpStreamAdapter(networkStream);
					_streamAdapter.OperationTimeout = ConnectionTimeout;
				}
				return _streamAdapter;
			}
        }

		protected TcpClient Socket
		{
			get { return _socket; }
			set { _socket = value; }
		}

		#endregion

        #region Methods
		public void Open()
        {
            ArgumentAssert.IsNotEmpty(Host, "Host");
            ArgumentAssert.IsInRange(Port, 1, UInt16.MaxValue, "Port");

			if (Connected)
			{
				Close();
			}
			if (Socket == null)
			{
				Socket = CreateSocket();
			}
			Socket.Connect(Host, Port);
        }

        public void Close()
        {
        	if (Socket != null)
			{
				Socket.Close();
				Socket = null;
			}
        }

		protected TcpClient CreateSocket()
		{
			TcpClient socket = new TcpClient();
			if (ConnectionTimeout != DEFAULT_TIMEOUT_VALUE)
			{
				socket.ReceiveTimeout = socket.SendTimeout = ConnectionTimeout;
			}
			return socket;
		}

        /// <summary>
        /// Disposes this object and closes underlying socket.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
			if (disposing)
			{
				Close();
			}
        }

	    #endregion    
    }
}
