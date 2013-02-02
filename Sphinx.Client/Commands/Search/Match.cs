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

using Sphinx.Client.Commands.Collections;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Search
{
    public class Match 
    {
        #region Fields
        private long _docId;
        private int _weight;

        private readonly AttributeValueList _attributesValues = new AttributeValueList();
        
        #endregion

        #region Properties
        /// <summary>
        /// Matched document ID.
        /// </summary>
        public long DocumentId
        {
            get { return _docId; }
        }

        /// <summary>
        /// Matched document weight.
        /// </summary>
        public int Weight
        {
            get { return _weight; }
        }

        /// <summary>
        /// Matched document attribute values.
        /// </summary>
        public AttributeValueList AttributesValues
        {
            get { return _attributesValues; }
        }
        
        #endregion

        #region Methods
        internal void Deserialize(IBinaryReader reader, MatchParseContext context)
        {
            _docId = (context.LongIdentifiers) ? reader.ReadInt64() : reader.ReadInt32();
            _weight = reader.ReadInt32();

            AttributesValues.Deserialize(reader, context);
        }

        #endregion
    }
}
