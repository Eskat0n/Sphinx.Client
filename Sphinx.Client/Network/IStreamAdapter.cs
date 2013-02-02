using System;
using System.Collections.Generic;
using System.Text;

namespace Sphinx.Client.Network
{
	public interface IStreamAdapter
	{
		int OperationTimeout { get; set; }
		bool CanRead { get; }
		bool CanWrite { get; }

		int ReadBytes(byte[] buffer, int count);
		void WriteBytes(byte[] buffer, int count);

		void Flush();
	}
}
