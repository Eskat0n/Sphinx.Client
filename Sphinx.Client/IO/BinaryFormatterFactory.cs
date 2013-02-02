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
using Sphinx.Client.Common;
using Sphinx.Client.Helpers;
using Sphinx.Client.Network;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.IO
{
    /// <summary>
    /// Factory to create binary formatters (serializers/deserializers).
    /// </summary>
    public class BinaryFormatterFactory : IBinaryFormatterFactory
    {
        #region Fields
        private readonly BinaryFormatType _formatType;
        private readonly Encoding _encoding;
        #endregion

        #region Constructor
        public BinaryFormatterFactory(BinaryFormatType formatType, Encoding encoding)
        {
            ArgumentAssert.IsDefinedInEnum(typeof(BinaryFormatType), formatType, "formatType");
            ArgumentAssert.IsNotNull(encoding, "encoding");
            _formatType = formatType;
            _encoding = encoding;
        }
        
        #endregion

        #region Methods
		public IBinaryReader CreateReader(IStreamAdapter stream)
        {
            switch (_formatType)
            {
                case BinaryFormatType.BigEndian:
                    return new BigEndianBinaryReader(stream, _encoding);
            }
            throw new NotSupportedException(String.Format(Messages.Exception_BinaryFormatNotSupported, Enum.GetName(typeof(BinaryFormatType), _formatType)));
        }

		public IBinaryWriter CreateWriter(IStreamAdapter stream)
        {
            switch (_formatType)
            {
                case BinaryFormatType.BigEndian:
                    return new BigEndianBinaryWriter(stream, _encoding);
            }
            throw new NotSupportedException(String.Format(Messages.Exception_BinaryFormatNotSupported, Enum.GetName(typeof(BinaryFormatType), _formatType)));
        }
 
	    #endregion
    }
}
