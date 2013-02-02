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
	/// Reads primitive data types as binary values represented in big endian byte order with specific character encoding. Unicode (UTF-8) encoding used by default to decode strings.
	/// </summary>
	public class BigEndianBinaryReader : BinaryReaderBase
	{
		#region Constants 
		private const int MAX_LENGTH = 8 * 1024 * 1024; // 8MB (hardcoded in sphinxd)
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BigEndianBinaryReader"/> class based on the supplied stream and using default encoding <see cref="UTF8Encoding"/>.
		/// </summary>
		/// <param name="input">Input stream</param>
		public BigEndianBinaryReader(IStreamAdapter input): base(input)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BinaryReaderBase"/> class based on the supplied stream and a specific character encoding.
		/// </summary>
		/// <param name="input">Input stream</param>
		/// <param name="encoding">The character encoding object used to decode strings from stream</param>
		public BigEndianBinaryReader(IStreamAdapter input, Encoding encoding): base(input, encoding)
		{
		}

		#endregion

		#region Methods
		/// <summary>
		/// Reads specified count of bytes from the stream as the byte array and advances the current position by count bytes.
		/// </summary>
		/// <param name="count">The number of bytes to read.</param>
		/// <returns>Array of bytes being read from stream.</returns>
		/// <exception cref="ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="EndOfStreamException">Could not read specified count of bytes from stream (reading is attempted past the end of a stream).</exception>
		/// <exception cref="ArgumentOutOfRangeException">Count is out of range.</exception>
		public override byte[] ReadBytes(int count)
		{
			ArgumentAssert.IsInRange(count, 0, MAX_LENGTH, "count");
			if (InputStream == null)
			{
				throw new ObjectDisposedException(null, Messages.Exception_IOStreamDisposed);
			}
			byte[] data = new byte[count];
			int actuallyRead = InputStream.ReadBytes(data, count);
			if (actuallyRead != count)
			{
				throw new EndOfStreamException(String.Format(Messages.Exception_CouldNotReadFromStream, count, data.Length));
			}
			return data;
		}

		/// <summary>
		/// Reads the next byte from the current stream and advances the current position of the stream by 1 byte.
		/// </summary>
		/// <returns>The next byte read from the current stream.</returns>
		/// <exception cref="ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="EndOfStreamException">Could not read specified count of bytes from stream (reading is attempted past the end of a stream).</exception>
		public override byte ReadByte()
		{
			byte[] bytes = ReadBytes(1);
			return bytes[0];
		}

		/// <summary>
		/// Reads a 2-byte signed integer in big endian representation from the current stream and advances the current position of the stream by 2 bytes.
		/// </summary>
		/// <returns>A 2-byte signed integer in current host representation read from the current stream.</returns>
		/// <exception cref="ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="EndOfStreamException">Could not read specified count of bytes from stream (reading is attempted past the end of a stream).</exception>
		public override short ReadInt16()
		{
			byte[] bytes = ReadBytes(2);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return BitConverter.ToInt16(bytes, 0);
		}

		/// <summary>
		/// Reads a 4-byte signed integer in big endian representation from the current stream and advances the current position of the stream by 4 bytes.
		/// </summary>
		/// <returns>A 4-byte signed integer in current host representation read from the current stream.</returns>
		/// <exception cref="ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="EndOfStreamException">Could not read specified count of bytes from stream (reading is attempted past the end of a stream).</exception>
		public override int ReadInt32()
		{
			byte[] bytes = ReadBytes(4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return BitConverter.ToInt32(bytes, 0);
		}

		/// <summary>
		/// Reads an 8-byte signed integer in big endian representation from the current stream and advances the current position of the stream by 8 bytes.
		/// </summary>
		/// <returns>An 8-byte signed integer in current host representation read from the current stream.</returns>
		/// <exception cref="ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="EndOfStreamException">Could not read specified count of bytes from stream (reading is attempted past the end of a stream).</exception>
		public override long ReadInt64()
		{
			byte[] bytes = ReadBytes(8);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return BitConverter.ToInt64(bytes, 0);
		}

		/// <summary>
		/// Reads a 4-byte floating point value in big endian representation from the current stream and advances the current position of the stream by four bytes.
		/// </summary>
		/// <returns>A 4-byte floating point value in current host representation read from the current stream.</returns>
		/// <exception cref="ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="EndOfStreamException">Could not read specified count of bytes from stream (reading is attempted past the end of a stream).</exception>
		public override float ReadSingle()
		{
			byte[] bytes = ReadBytes(4);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return BitConverter.ToSingle(bytes, 0);
		}

		/// <summary>
		/// Reads an 8-byte floating point value in big endian representation from the current stream and advances the current position of the stream by 8 bytes.
		/// </summary>
		/// <returns>An 8-byte floating point value in current host representation read from the current stream.</returns>
		/// <exception cref="ObjectDisposedException">The stream is closed.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		/// <exception cref="EndOfStreamException">Could not read specified count of bytes from stream (reading is attempted past the end of a stream).</exception>
		public override double ReadDouble()
		{
			byte[] bytes = ReadBytes(8);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return BitConverter.ToDouble(bytes, 0);
		}

		/// <summary>
		/// Reads a string from the current stream. The string is prefixed with the int length and decoded using the character encoding specified by <see cref="Encoding"/>. Advances the current position by string length + 4 bytes.
		/// </summary>
		/// <returns>The string being read.</returns>
		public override string ReadString()
		{
			int length = ReadInt32();
			if (length <= 0)
			{
				return String.Empty;
			}
			byte[] bytes = ReadBytes(length);
			return Encoding.GetString(bytes);
		}

		/// <summary>
		/// Reads a Boolean value from the current stream and int in big-endian representation and advances the current position of the stream by 4 byte.
		/// </summary>
		/// <returns>true if the byte is nonzero; otherwise, false.</returns>
		public override bool ReadBoolean()
		{
			int value = ReadInt32();
			return (value != 0);
		}

		/// <summary>
		/// Reads a DateTime value from the current stream. DateTime value read as Unix timestamp (4 bytes int value) and converted to DateTime object.
		/// </summary>
		/// <returns>DateTime object being read.</returns>
		public override DateTime ReadDateTime()
		{
			int value = ReadInt32();
			return DateTimeHelper.ConvertFromUnixTimestamp(value);
		}

		#endregion

	}
}
