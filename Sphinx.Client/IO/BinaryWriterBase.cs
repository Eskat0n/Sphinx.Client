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
    /// Writes primitive types in binary to a stream and supports writing strings in a specific encoding. Provides a base class for more specific classes.
    /// An abstract class, it cannot be instantiated.
    /// </summary>
    public abstract class BinaryWriterBase : IBinaryWriter
    {
        #region Fields
        private static readonly Encoding _defaultEncoding = new UTF8Encoding(false, true);

		private readonly IStreamAdapter _outputStream;
        private readonly Encoding _encoding;
        
        #endregion

        #region Constructors
		protected BinaryWriterBase(IStreamAdapter output): this(output, _defaultEncoding)
        {
        }

		protected BinaryWriterBase(IStreamAdapter output, Encoding encoding)
        {
            ArgumentAssert.IsNotNull(output, "output");
            ArgumentAssert.IsNotNull(encoding, "encoding");
            if (!output.CanWrite)
            {
                throw new IOException(Messages.Exception_CantWriteToStream);
            }

            _outputStream = output;
            _encoding = encoding;
        }
        #endregion

        #region Properties
		public virtual IStreamAdapter OutputStream
        {
            get
            {
                return _outputStream;
            }
        }

        public Encoding Encoding
        {
            get { return _encoding; }
        }

        #endregion

        #region Methods
        #region Abstract methods
        /// <summary>
        /// Writes a byte array to the underlying stream.
        /// </summary>
        /// <param name="data">A byte array containing the data to write.</param>
        public abstract void Write(byte[] data);

        /// <summary>
        /// Writes an unsigned byte to the current stream and advances the stream position by 1 byte.
        /// </summary>
        /// <param name="data">The unsigned byte to write. </param>
        public abstract void Write(byte data);

        /// <summary>
        /// Writes a 2 byte signed integer to the current stream and advances the stream position by 2 bytes.
        /// </summary>
        /// <param name="data">The 2 byte signed integer to write.</param>
        public abstract void Write(short data);

        /// <summary>
        /// Writes a 4 byte signed integer to the current stream and advances the stream position by 4 bytes.
        /// </summary>
        /// <param name="data">The 4 byte signed integer to write.</param>
        public abstract void Write(int data);

        /// <summary>
        /// Writes an 8 byte signed integer to the current stream and advances the stream position by 8 bytes.
        /// </summary>
        /// <param name="data">The 8 byte signed integer to write.</param>
        public abstract void Write(long data);

        /// <summary>
        /// Writes an 4 byte floating-point value to the current stream and advances the stream position by 4 bytes.
        /// </summary>
        /// <param name="data">The 4 byte floating-point value to write.</param>
        public abstract void Write(float data);

        /// <summary>
        /// Writes an 8 byte floating-point value to the current stream and advances the stream position by 8 bytes.
        /// </summary>
        /// <param name="data">The 8 byte floating-point value to write.</param>
        public abstract void Write(double data);

        /// <summary>
        /// Writes a length-prefixed string to this stream in the current encoding of the BinaryWriterBase, and advances the current position of the stream in accordance with the encoding used and the specific characters being written to the stream.
        /// </summary>
        /// <param name="data">The value to write.</param>
        public abstract void Write(string data);

        /// <summary>
        /// Writes a one-byte Boolean value to the current stream, with 0 representing false and 1 representing true.
        /// </summary>
        /// <param name="data">The Boolean value to write.</param>
        public abstract void Write(bool data);

        /// <summary>
        /// Writes DateTime value to the current stream
        /// </summary>
        /// <param name="data">The value to write.</param>
        public abstract void Write(DateTime data);

        #endregion

        #region Imlemented
        public virtual void Flush()
        {
            OutputStream.Flush();
        }

        #endregion
        #endregion


    }
}
