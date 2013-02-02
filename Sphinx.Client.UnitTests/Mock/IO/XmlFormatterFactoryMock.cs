using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sphinx.Client.IO;
using Sphinx.Client.Network;

namespace Sphinx.Client.UnitTests.Mock.IO
{
    public class XmlFormatterFactoryMock : IBinaryFormatterFactory
    {
        #region Implementation of IBinaryFormatterFactory

        public IBinaryReader CreateReader(IStreamAdapter stream)
        {
            return new XmlReaderMock(stream);
        }

		public IBinaryWriter CreateWriter(IStreamAdapter stream)
        {
            return new XmlWriterMock(stream);
        }

        #endregion
    }
}
