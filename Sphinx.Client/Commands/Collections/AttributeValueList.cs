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

using System.Collections.ObjectModel;
using Sphinx.Client.Commands.Attributes;
using Sphinx.Client.Commands.Attributes.Values;
using Sphinx.Client.Commands.Search;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Collections
{
    public class AttributeValueList : KeyedCollection<string, AttributeValueBase>
    {
        #region Constructors
        public AttributeValueList() : base(null, 0) { }
        
        #endregion

        #region Methods

        #region Overrides of KeyedCollection<string,AbstractAttributeValue>
        /// <summary>Extracts the key from the specified <see cref="AttributeValueBase"/> object.</summary>
        /// <returns>The string key for the specified element (Name property value).</returns>
        /// <param name="item">The <see cref="AttributeValueBase"/> object from which to extract the key.</param>
        protected override string GetKeyForItem(AttributeValueBase item)
        {
            return item.Name;
        }
        #endregion

        /// <summary>
        /// Deserialize object state from stream using specified binary stream reader.
        /// </summary>
        /// <param name="reader">Binary stream reader object</param>
        /// <param name="context">Match parse context object</param>
        internal void Deserialize(IBinaryReader reader, MatchParseContext context)
        {
            foreach (AttributeInfo attributeInfo in context.Attributes)
            {
                AttributeValueBase attribute = AttributeValueBase.CreateByType(attributeInfo.AttributeType);
                attribute.Deserialize(reader, attributeInfo);
                Add(attribute);
            }
        }

        #endregion

    }
}
