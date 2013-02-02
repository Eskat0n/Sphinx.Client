using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Sphinx.Client.IO;
using Sphinx.Client.Network;

namespace Sphinx.Client.UnitTests.Mock.IO
{
    public class ArrayListFormatterFactoryMock : IBinaryFormatterFactory
    {
    	private readonly ArrayList _list;

		public ArrayListFormatterFactoryMock(ArrayList list)
		{
			_list = list;
		}
        #region Implementation of IBinaryFormatterFactory

        public IBinaryReader CreateReader(IStreamAdapter stream)
        {
			return new ArrayListReaderMock(_list);
        }

		public IBinaryWriter CreateWriter(IStreamAdapter stream)
        {
			return new ArrayListWriterMock(_list);
        }

        #endregion
    }
}
