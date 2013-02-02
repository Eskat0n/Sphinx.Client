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
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.Commands.Attributes.Values
{
    /// <summary>
    /// Base class for represents attribute values.
    /// An abstract class, it cannot be instantiated.
    /// </summary>
    public abstract class AttributeValueBase : AttributeBase
    {
        #region Constructors
        protected AttributeValueBase()
        {
        }

        protected AttributeValueBase(string name): base(name)
        {
        }
        
        #endregion

        #region Properties
        /// <summary>
        /// Factory method to create <see cref="AttributeValueBase"/> based class by specified <see cref="AttributeType"/> value.
        /// </summary>
        /// <param name="type">Attribute type</param>
        /// <returns><see cref="AttributeValueBase"/> based class</returns>
        public static AttributeValueBase CreateByType(AttributeType type)
        {
            switch (type)
            {
                case AttributeType.Integer:
                    return new AttributeValueInt32();
                case AttributeType.Bigint:
                    return new AttributeValueInt64();
                case AttributeType.Ordinal:
                    return new AttributeValueOrdinal();
                case AttributeType.Float:
                    return new AttributeValueFloat();
                case AttributeType.Timestamp:
                    return new AttributeValueDateTime();
                case AttributeType.Boolean:
                    return new AttributeValueBoolean();
				case AttributeType.String:
            		return new AttributeValueString();
                case AttributeType.MultiInteger:
                    return new AttributeValuesInt32();
                case AttributeType.MultiFloat:
                    return new AttributeValuesFloat();
                case AttributeType.MultiTimestamp:
                    return new AttributeValuesDateTime();
                case AttributeType.MultiBoolean:
                    return new AttributeValuesBoolean();
            }
            throw new NotSupportedException(String.Format(Messages.Exception_UnsupportedAttributeType, Enum.GetName(typeof(AttributeType), type)));
        }
        
        #endregion

        #region Methods
        #region Implemented
        internal virtual void Deserialize(IBinaryReader reader, AttributeInfo attributeInfo)
        {
            Name = attributeInfo.Name;
        }
        
        #endregion

        #region Abstract
        public abstract object GetValue();
        
        #endregion
        
        #endregion
    }
}
