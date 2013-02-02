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

namespace Sphinx.Client.Commands.Attributes.Override
{
    /// <summary>
    /// Base class for attribute override classes.
    /// </summary>
    public abstract class AttributeOverrideBase : AttributeBase
    {
        #region Constructors
		protected AttributeOverrideBase(string name): base(name)
        {
        }

        protected AttributeOverrideBase()
        {
        }

	    #endregion

        #region Methods

        #region Static
        public static AttributeOverrideBase CreateByType(AttributeType type)
        {
            switch (type)
            {
                case AttributeType.Integer:
                    return new AttributeOverrideInt32();
                case AttributeType.Bigint:
                    return new AttributeOverrideInt64();
                case AttributeType.Float:
                    return new AttributeOverrideFloat();
                case AttributeType.Timestamp:
                    return new AttributeOverrideDateTime();
                case AttributeType.Boolean:
                    return new AttributeOverrideBoolean();
                case AttributeType.Ordinal:
                    return new AttributeOverrideOrdinal();
            }
            /// TODO: MVA support?
            throw new NotSupportedException(String.Format(Messages.Exception_UnsupportedAttributeType, Enum.GetName(typeof(AttributeType), type)));
        }
        
        #endregion

        #region Implemented
        internal virtual void Serialize(IBinaryWriter writer)
        {
            // attribute name
            writer.Write(Name);
        }
        
        #endregion

        #endregion

    }
}
