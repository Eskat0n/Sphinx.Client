using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Commands;
using Sphinx.Client.Connections;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;
using Sphinx.Client.Network;
using Sphinx.Client.UnitTests.Mock.IO;
using Sphinx.Client.UnitTests.Mock.Network;

namespace Sphinx.Client.UnitTests.Mock.Connections
{
    public class ConnectionMock : TcpConnection
    {
        #region Fields
        private ISocketAdapter _socket;
        private IBinaryFormatterFactory _factory = new XmlFormatterFactoryMock();
        
        #endregion

        #region Constructors
		public ConnectionMock()
        {
        }

        public ConnectionMock(string host): base(host)
        {
        }

        public ConnectionMock(string host, int port): base(host, port)
        {
        }

 
	    #endregion        

        #region Properties
		protected override ISocketAdapter Socket
        {
            get
            {
                if (_socket == null)
                {
                    _socket = new ClientSocketMock();
                }
                return _socket;
            }

            set
            {
                _socket = value;
            }
        }

        internal protected override IBinaryFormatterFactory FormatterFactory
        {
            get { return _factory; }
        }

        public bool SkipHandshake { get; set; }
        public bool SkipSerializeCommand { get; set; }
        public bool SkipDeserializeCommand { get; set; }


        public Stream BaseStream
        {
            get
            {
				return GetStream(DataStream);
            }
        }
        #endregion

        #region Methods
		public void SetFormatterFactory(IBinaryFormatterFactory factory)
		{
			_factory = factory;
		}

        internal override void PerformCommand(CommandBase command)
        {
            ArgumentAssert.IsNotNull(command, "command");
            Open();
            try 
            {
                if (!SkipHandshake) 
                    base.SendHandshake();
                if (!SkipSerializeCommand) 
                    command.Serialize(DataStream);
                DataStream.Flush();
                if (!SkipDeserializeCommand) 
                    command.Deserialize(DataStream);
            }
            finally {
                Close();
            }
            
        }

		protected Stream GetStream(IStreamAdapter adapter)
		{
			PrivateObject po = new PrivateObject(adapter);
			StreamAdapter_Accessor accessor = new StreamAdapter_Accessor(po);
			return accessor.Stream;
		}         
	    #endregion    
    }
}
