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

using System.Collections.Generic;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Values
{
    /// <summary>
    /// Represents int attribute values in matched document.
    /// </summary>
    public class AttributeValuesInt32 : AttributeValueBase, IAttributeValues<int>
    {
        #region Fields
        private readonly List<int> _values;
        
        #endregion

        #region Constructors
        internal AttributeValuesInt32()
        {
			_values = new List<int>();
        }

        public AttributeValuesInt32(string name, IEnumerable<int> values): base(name)
        {
            _values.AddRange(values);
        }
        
        #endregion

        #region Overrides of AbstractAttribute
        public override AttributeType AttributeType
        {
            get { return AttributeType.MultiInteger; }
        }

        #region Implementation of IAttributeValuesPerDocument
        public IList<int> Values
        {
            get { return _values; }
        }
        
        #endregion

        #endregion

        #region Methods
        public override object GetValue()
        {
            return Values;
        }

        internal override void Deserialize(IBinaryReader reader, AttributeInfo attributeInfo)
        {
            base.Deserialize(reader, attributeInfo);
            int count = reader.ReadInt32();
            for (int i=0; i < count; i++)
            {
                _values.Add(reader.ReadInt32());
            }
        }

        #endregion

    }
}
