using System;
using System.Text;
using Sphinx.Client.Network;

namespace Sphinx.Client.IO
{
	public interface IBinaryWriter
	{
		/// <summary>
		/// Exposes access to the underlying output stream adapter.
		/// </summary>
		IStreamAdapter OutputStream { get; }

		/// <summary>
		/// The character encoding used to encode string from underlying input stream.
		/// <remarks>Default value is <see cref="UTF8Encoding"/>.</remarks>
		/// </summary>
		Encoding Encoding { get; }

		/// <summary>
		/// Writes a byte array to the underlying stream.
		/// </summary>
		/// <param name="data">A byte array containing the data to write.</param>
		void Write(byte[] data);

		/// <summary>
		/// Writes an unsigned byte to the current stream and advances the stream position by 1 byte.
		/// </summary>
		/// <param name="data">The unsigned byte to write. </param>
		void Write(byte data);

		/// <summary>
		/// Writes a 2 byte signed integer to the current stream and advances the stream position by 2 bytes.
		/// </summary>
		/// <param name="data">The 2 byte signed integer to write.</param>
		void Write(short data);

		/// <summary>
		/// Writes a 4 byte signed integer to the current stream and advances the stream position by 4 bytes.
		/// </summary>
		/// <param name="data">The 4 byte signed integer to write.</param>
		void Write(int data);

		/// <summary>
		/// Writes an 8 byte signed integer to the current stream and advances the stream position by 8 bytes.
		/// </summary>
		/// <param name="data">The 8 byte signed integer to write.</param>
		void Write(long data);

		/// <summary>
		/// Writes an 4 byte floating-point value to the current stream and advances the stream position by 4 bytes.
		/// </summary>
		/// <param name="data">The 4 byte floating-point value to write.</param>
		void Write(float data);

		/// <summary>
		/// Writes an 8 byte floating-point value to the current stream and advances the stream position by 8 bytes.
		/// </summary>
		/// <param name="data">The 8 byte floating-point value to write.</param>
		void Write(double data);

		/// <summary>
		/// Writes a length-prefixed string to this stream in the current encoding of the BinaryWriterBase, and advances the current position of the stream in accordance with the encoding used and the specific characters being written to the stream.
		/// </summary>
		/// <param name="data">The value to write.</param>
		void Write(string data);

		/// <summary>
		/// Writes a one-byte Boolean value to the current stream, with 0 representing false and 1 representing true.
		/// </summary>
		/// <param name="data">The Boolean value to write.</param>
		void Write(bool data);

		/// <summary>
		/// Writes DateTime value to the current stream.
		/// </summary>
		/// <param name="data">The value to write.</param>
		void Write(DateTime data);

		/// <summary>
		/// Clears all buffers for this stream and causes any buffered data to be written to the underlying stream.
		/// </summary>
		void Flush();
	}
}