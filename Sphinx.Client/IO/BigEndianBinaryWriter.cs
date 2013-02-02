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
using System.Text;
using Sphinx.Client.Helpers;
using Sphinx.Client.Network;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.IO
{
	/// <summary>
	/// Writes primitive types to a stream, in Big Endian binary representation. Supports writing strings in a specific encoding (default encoding is UTF-8).
	/// </summary>
	public class BigEndianBinaryWriter : BinaryWriterBase
	{
		#region Constructors
		public BigEndianBinaryWriter(IStreamAdapter output): base(output)
		{
		}

		public BigEndianBinaryWriter(IStreamAdapter output, Encoding encoding): base(output, encoding)
		{
		}
		#endregion

		#region Implementation of abstract methods
		public override void Write(byte[] data)
		{
			ArgumentAssert.IsNotNull(data, "bytes");
			if (OutputStream == null)
			{
				throw new ObjectDisposedException(null, Messages.Exception_IOStreamDisposed);
			}
			OutputStream.WriteBytes(data, data.Length);
		}

		public override void Write(byte data)
		{
			byte[] buffer = new byte[] { data };
			Write(buffer);
		}

		public override void Write(short data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			Write(bytes);
		}

		public override void Write(int data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			Write(bytes);
		}

		public override void Write(long data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			Write(bytes);
		}

		public override void Write(float data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			Write(bytes);
		}

		public override void Write(double data)
		{
			byte[] bytes = BitConverter.GetBytes(data);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			Write(bytes);
		}

		public override void Write(string data)
		{
			if (String.IsNullOrEmpty(data))
			{
				Write(0);
				return;
			}
			byte[] bytes = Encoding.GetBytes(data);
			Write(bytes.Length);
			Write(bytes);
		}

		public override void Write(bool data)
		{
			int integer = (data) ? 1 : 0;
			Write(integer);
		}

		public override void Write(DateTime data)
		{
			int integer = DateTimeHelper.ConvertToUnixTimestamp(data);
			Write(integer);
		}
		
		#endregion

	}
}
