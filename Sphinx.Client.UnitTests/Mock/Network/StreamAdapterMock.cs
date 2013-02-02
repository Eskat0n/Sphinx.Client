using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sphinx.Client.Network;

namespace Sphinx.Client.UnitTests.Mock.Network
{
	public class StreamAdapterMock : IStreamAdapter
	{
		public int OperationTimeout
		{
			get { return 0; }
			set { throw new NotImplementedException(); }
		}

		public bool CanRead
		{
			get { return true; }
		}

		public bool CanWrite
		{
			get { return true; }
		}

		public int ReadBytes(byte[] buffer, int count)
		{
			throw new NotImplementedException();
		}

		public void WriteBytes(byte[] buffer, int count)
		{
			throw new NotImplementedException();
		}

		public void Flush()
		{
			throw new NotImplementedException();
		}
	}
}
