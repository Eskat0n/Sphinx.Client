using System;
using System.Text;
using Sphinx.Client.Network;

namespace Sphinx.Client.IO
{
	public interface IBinaryReader
	{
		/// <summary>
		/// Exposes access to the underlying input stream adapter.
		/// </summary>
		IStreamAdapter InputStream { get; }

		/// <summary>
		/// The character encoding used to decode string from underlying input stream.
		/// <remarks>Default value is <see cref="UTF8Encoding"/>.</remarks>
		/// </summary>
		Encoding Encoding { get; }

		/// <summary>
		/// Reads specified count of bytes from the stream as the byte array and advances the current position by count bytes.
		/// </summary>
		/// <param name="count">The number of bytes to read.</param>
		/// <returns>Array of bytes being read from stream. This might be less than the number of bytes requested if that many bytes are not available, or it might be zero if the end of the stream is reached.</returns>
		byte[] ReadBytes(int count);

		/// <summary>
		/// Reads the next byte from the current stream and advances the current position of the stream by 1 byte.
		/// </summary>
		/// <returns>The next byte read from the current stream.</returns>
		byte ReadByte();

		/// <summary>
		/// Reads a 2-byte signed integer from the current stream and advances the current position of the stream by 2 bytes.
		/// </summary>
		/// <returns>A 2-byte signed integer read from the current stream.</returns>
		short ReadInt16();

		/// <summary>
		/// Reads a 4-byte signed integer from the current stream and advances the current position of the stream by 4 bytes.
		/// </summary>
		/// <returns>A 4-byte signed integer read from the current stream.</returns>
		int ReadInt32();

		/// <summary>
		/// Reads an 8-byte signed integer from the current stream and advances the current position of the stream by 8 bytes.
		/// </summary>
		/// <returns>An 8-byte signed integer read from the current stream.</returns>
		long ReadInt64();

		/// <summary>
		/// Reads a 4-byte floating point value from the current stream and advances the current position of the stream by 4 bytes.
		/// </summary>
		/// <returns>A 4-byte floating point value read from the current stream.</returns>
		float ReadSingle();

		/// <summary>
		/// Reads an 8-byte floating point value from the current stream and advances the current position of the stream by 8 bytes.
		/// </summary>
		/// <returns>An 8-byte floating point value read from the current stream.</returns>
		double ReadDouble();

		/// <summary>
		/// Reads a string from the current stream.
		/// </summary>
		/// <returns>The string being read.</returns>
		string ReadString();

		/// <summary>
		/// Reads a Boolean value from the current stream.
		/// </summary>
		/// <returns>Boolean value being read.</returns>
		bool ReadBoolean();

		/// <summary>
		/// Reads a DateTime value from the current stream.
		/// </summary>
		/// <returns>DateTime object being read.</returns>
		DateTime ReadDateTime();
	}
}