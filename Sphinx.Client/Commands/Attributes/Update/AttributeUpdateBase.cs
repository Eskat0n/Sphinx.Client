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
using System.Collections.Generic;
using Sphinx.Client.IO;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.Commands.Attributes.Update
{
    /// <summary>
    /// Base class represent for type-specific attribute update classes.
    /// An abstract class, it cannot be instantiated.
    /// </summary>
    public abstract class AttributeUpdateBase : AttributeBase
    {
        #region Constructors
		protected AttributeUpdateBase(string name): base(name)
        {
        }

        protected AttributeUpdateBase()
        {
        }

	    #endregion

        #region Properties
        public virtual bool IsMultiValue
        {
            get { return ((int)AttributeType & (int)MultiValueAttribute.MultiFlag) > 0; }
        }
        
        #endregion

        #region Methods

        #region Static
        public static AttributeUpdateBase CreateByType(AttributeType type)
        {
            switch (type)
            {
                case AttributeType.Integer:
                    return new AttributeUpdateInt32();
                case AttributeType.Float:
                    return new AttributeUpdateFloat();
                case AttributeType.Timestamp:
                    return new AttributeUpdateDateTime();
                case AttributeType.Boolean:
                    return new AttributeUpdateBoolean();
                case AttributeType.Ordinal:
                    return new AttributeUpdateOrdinal();
                case AttributeType.MultiBoolean:
                    return new AttributeUpdateMultiBoolean();
                case AttributeType.MultiFloat:
                    return new AttributeUpdateMultiFloat();
                case AttributeType.MultiInteger:
                    return new AttributeUpdateMultiInt32();
                case AttributeType.MultiOrdinal:
                    return new AttributeUpdateMultiOrdinal();
                case AttributeType.MultiTimestamp:
                    return new AttributeUpdateMultiDateTime();
                // NOTE: Bigint (64-bit) attribute type currently is not supported by Sphinx server (0.9.9-rc2)
            }
            throw new NotSupportedException(String.Format(Messages.Exception_UnsupportedAttributeType, Enum.GetName(typeof(AttributeType), type)));
        }
        
        #endregion

        #region Abstract
        internal abstract IEnumerable<long> GetDocumentsIdSet();
        internal abstract void Serialize(IBinaryWriter writer, long id);
        
        #endregion

        #endregion

    }
}
