using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using Sphinx.Client.Network;

namespace Sphinx.Client.UnitTests.Mock.Network
{
    /// <summary>
    /// Mock class for connection classes testing
    /// </summary>
    public class ClientSocketMock : ISocketAdapter, IDisposable
    {
        private bool _connected = false;
        private MemoryStream _dummyStream = new MemoryStream();
        private Timer _timer;

        #region Implementation of IClientSocket

        /// <summary>
        /// Server socket host network address
        /// </summary>
        public string Host
        {
            get; set; 
        }

        /// <summary>
        /// Server socket port number
        /// </summary>
        public int Port
        {
            get; set;
        }

        /// <summary>
        /// Is client socket is connected to server socket
        /// </summary>
        public bool Connected
        {
            get { return _connected; }
        }

        /// <summary>
        /// Connection timeout
        /// </summary>
        public int ConnectionTimeout
        {
            get; set;
        }

        /// <summary>
        /// Network data stream object
        /// </summary>
        public IStreamAdapter DataStream
        {
            get { return _connected ? new StreamAdapter(_dummyStream) : null; }
        }

        /// <summary>
        /// Establish new connection to specified <see cref="IClientSocket.Host"/> and <see cref="IClientSocket.Port"/>
        /// </summary>
        public void Open()
        {
            _connected = true;
            if (ConnectionTimeout > 0)
            {
                _timer = new Timer();
                _timer.Elapsed += OnTimedEvent;
                _timer.Interval = ConnectionTimeout;
                _timer.Enabled = true;
            }
        }

        /// <summary>
        /// Close opened connection socket
        /// </summary>
        public void Close()
        {
            _connected = false;
        }

        #endregion

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Close();
            _timer = null;
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            _dummyStream.Close();
        }

        #endregion
    }
}
