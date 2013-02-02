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
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Values
{
    /// <summary>
    /// Represents DateTime attribute value in matched document.
    /// </summary>
    public class AttributeValueDateTime : AttributeValueBase, IAttributeValue<DateTime>
    {
        #region Fields
        private DateTime _value;
        #endregion

        #region Constructors
        internal AttributeValueDateTime()
        {
        }

        public AttributeValueDateTime(string name, DateTime value): base(name)
        {
            _value = value;
        }
        
        #endregion

        #region Properties
        public override AttributeType AttributeType
        {
            get { return AttributeType.Timestamp; }
            protected set { throw new NotImplementedException(); }
        }

        #region Implementation of IAttributeValue
        public DateTime Value
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
            _value = reader.ReadDateTime();
        }

        #endregion

    }
}
