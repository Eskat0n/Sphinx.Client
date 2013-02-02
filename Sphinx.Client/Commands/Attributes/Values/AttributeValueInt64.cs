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

using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Values
{
    /// <summary>
    /// Represents long attribute value in matched document.
    /// </summary>
    public class AttributeValueInt64 : AttributeValueBase, IAttributeValue<long>
    {
        #region Fields
        private long _value;
        
        #endregion

        #region Constructors
        internal AttributeValueInt64()
        {

        }

        public AttributeValueInt64(string name, int value): base(name)
        {
            _value = value;
        }
        
        #endregion

        #region Overrides of AbstractAttribute
        public override AttributeType AttributeType
        {
            get { return AttributeType.Bigint; }
        }

        #region Implementation of IAttributeValuesPerDocument
        public long Value
        {
            get { return _value; }
            protected set { _value = value; }
        }
        
        #endregion

        #endregion

        #region Methods
        public override object GetValue()
        {
            return Value;
        }

        internal override void Deserialize(IBinaryReader reader, AttributeInfo attributeInfo)
        {
            base.Deserialize(reader, attributeInfo);
            _value = reader.ReadInt64();
        }

        #endregion

    }
}
