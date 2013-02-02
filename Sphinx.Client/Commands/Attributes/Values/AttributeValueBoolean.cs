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
    /// Represents boolean attribute value in matched document.
    /// </summary>
    public class AttributeValueBoolean : AttributeValueBase, IAttributeValue<bool>
    {
        #region Fields
        private bool _value;

        #endregion

        #region Constructors
        internal AttributeValueBoolean()
        {
        }

        public AttributeValueBoolean(string name, bool value): base(name)
        {
            _value = value;
        } 
        #endregion

        #region Properties
        public override AttributeType AttributeType
        {
            get { return AttributeType.Boolean; }
        }

        #region Implementation of IAttributeValue
        public bool Value
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
            _value = reader.ReadBoolean();
        }

        #endregion
    }
}
