using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sphinx.Client.Commands;
using Sphinx.Client.Connections;
using Sphinx.Client.IO;
using Sphinx.Client.Network;

namespace Sphinx.Client.UnitTests.Mock.Commands
{
    public class MockCommand : CommandBase
    {
        private ServerCommand _id;
        private short _ver;

        public MockCommand(ConnectionBase connection) : base(connection)
        {
        }

        public MockCommand(ConnectionBase connection, ServerCommand id, short ver) : this(connection)
        {
            _id = id;
            _ver = ver;   
        }

        #region Overrides of CommandBase

        protected override CommandInfo CommandInfo
        {
            get { return new CommandInfo(_id, _ver); }
        }

    	protected override void ValidateParameters()
    	{
    	}

    	protected internal override void Serialize(IStreamAdapter stream)
        {
            IBinaryWriter writer = Connection.FormatterFactory.CreateWriter(stream);
            CommandInfo.Serialize(writer);
        }

		protected internal override void Deserialize(IStreamAdapter stream)
        {
            // do nothing
        }

        #endregion
    }
}
