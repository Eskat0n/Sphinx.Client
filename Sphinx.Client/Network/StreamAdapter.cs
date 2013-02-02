using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Sphinx.Client.Helpers;

namespace Sphinx.Client.Network
{
	public class StreamAdapter : IStreamAdapter
	{
		#region Consts
		protected const int DEFAULT_TIMEOUT = Timeout.Infinite; 

		#endregion

		#region Fields
		private readonly Stream _stream;
		private int _timeout = DEFAULT_TIMEOUT; 

		#endregion

		#region Constructors
		public StreamAdapter(Stream stream)
		{
			ArgumentAssert.IsNotNull(stream, "stream");
			_stream = stream;
		}
		
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the amount of time a TcpStreamAdapter will wait for a send or receive operation to complete successfully.
		/// </summary>
		public virtual int OperationTimeout
		{
			get { return _timeout; }
			set { _timeout = value; }
		}

		/// <summary>
		/// Gets a value indicating whether the underlying stream supports reading.
		/// </summary>
		public virtual bool CanRead
		{
			get { return Stream.CanRead; }
		}

		/// <summary>
		/// Gets a value indicating whether the underlying stream supports writing.
		/// </summary>
		public virtual bool CanWrite
		{
			get { return Stream.CanWrite; }
		}

		/// <summary>
		/// Underlying stream object
		/// </summary>
		protected virtual Stream Stream
		{
			get { return _stream; }
		}

		
		#endregion		
		
		#region Methods
		/// <summary>
		/// Read requested bytes from response stream. 
		/// </summary>
		/// <param name="buffer">An array of type Byte that is the location in memory to store data read from the NetworkStream.</param>
		/// <param name="length">Number of bytes to be read from the source stream.</param>
		public virtual int ReadBytes(byte[] buffer, int length)
		{
			return Stream.Read(buffer, 0, length);
		}

		/// <summary>
		/// Writes sequence of bytes to to the underlying stream
		/// </summary>
		/// <param name="buffer">Array of bytes. Method copies count bytes from buffer to stream.</param>
		/// <param name="count">The number of to be written to underlying stream</param>
		public virtual void WriteBytes(byte[] buffer, int count)
		{
			Stream.Write(buffer, 0, count);
		}

		/// <summary>
		/// Clears all buffers for underlying stream and causes any buffered data to be written to the underlying stream.
		/// </summary>
		public void Flush()
		{
			Stream.Flush();
		}

 		#endregion	
	}
}
