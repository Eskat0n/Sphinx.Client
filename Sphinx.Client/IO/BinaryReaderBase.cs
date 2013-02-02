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
    /// Reads primitive data types as binary values in a specific encoding. Provides a base class for more specific classes.
    /// An abstract class, it cannot be instantiated.
    /// </summary>
    public abstract class BinaryReaderBase : IBinaryReader
    {
        #region Fields
        private static readonly Encoding _defaultEncoding = new UTF8Encoding(false, true);
		private readonly IStreamAdapter _inputStream;
        private readonly Encoding _encoding;
        
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryReaderBase"/> class based on the supplied stream and using default encoding <see cref="UTF8Encoding"/>.
        /// </summary>
        /// <param name="input">Input stream</param>
		protected BinaryReaderBase(IStreamAdapter input): this(input, _defaultEncoding)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryReaderBase"/> class based on the supplied stream and a specific character encoding.
        /// </summary>
        /// <param name="input">Input stream</param>
        /// <param name="encoding">The character encoding object used to decode strings from stream</param>
		protected BinaryReaderBase(IStreamAdapter input, Encoding encoding)
        {
            ArgumentAssert.IsNotNull(input, "input");
            ArgumentAssert.IsNotNull(encoding, "encoding");
            if (!input.CanRead)
            {
                throw new IOException(Messages.Exception_CantReadFromStream);
            }

            _inputStream = input;
            _encoding = encoding;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Exposes access to the underlying input stream.
        /// </summary>
		public IStreamAdapter InputStream
        {
            get { return _inputStream; }
        }

        /// <summary>
        /// The character encoding used to decode string from underlying input stream.
        /// <remarks>Default value is <see cref="UTF8Encoding"/>.</remarks>
        /// </summary>
        public Encoding Encoding
        {
            get { return _encoding; }
        }

        #endregion

        #region Methods

        #region Abstract
        /// <summary>
        /// Reads specified count of bytes from the stream as the byte array and advances the current position by count bytes.
        /// </summary>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>Array of bytes being read from stream. This might be less than the number of bytes requested if that many bytes are not available, or it might be zero if the end of the stream is reached.</returns>
        public abstract byte[] ReadBytes(int count);

        /// <summary>
        /// Reads the next byte from the current stream and advances the current position of the stream by 1 byte.
        /// </summary>
        /// <returns>The next byte read from the current stream.</returns>
        public abstract byte ReadByte();

        /// <summary>
        /// Reads a 2-byte signed integer from the current stream and advances the current position of the stream by 2 bytes.
        /// </summary>
        /// <returns>A 2-byte signed integer read from the current stream.</returns>
        public abstract short ReadInt16();

        /// <summary>
        /// Reads a 4-byte signed integer from the current stream and advances the current position of the stream by 4 bytes.
        /// </summary>
        /// <returns>A 4-byte signed integer read from the current stream.</returns>
        public abstract int ReadInt32();

        /// <summary>
        /// Reads an 8-byte signed integer from the current stream and advances the current position of the stream by 8 bytes.
        /// </summary>
        /// <returns>An 8-byte signed integer read from the current stream.</returns>
        public abstract long ReadInt64();

        /// <summary>
        /// Reads a 4-byte floating point value from the current stream and advances the current position of the stream by 4 bytes.
        /// </summary>
        /// <returns>A 4-byte floating point value read from the current stream.</returns>
        public abstract float ReadSingle();

        /// <summary>
        /// Reads an 8-byte floating point value from the current stream and advances the current position of the stream by 8 bytes.
        /// </summary>
        /// <returns>An 8-byte floating point value read from the current stream.</returns>
        public abstract double ReadDouble();

        /// <summary>
        /// Reads a string from the current stream.
        /// </summary>
        /// <returns>The string being read.</returns>
        public abstract string ReadString();

        /// <summary>
        /// Reads a Boolean value from the current stream.
        /// </summary>
        /// <returns>Boolean value being read.</returns>
        public abstract bool ReadBoolean();

        /// <summary>
        /// Reads a DateTime value from the current stream.
        /// </summary>
        /// <returns>DateTime object being read.</returns>
        public abstract DateTime ReadDateTime();
        #endregion    

        #endregion
    }
}