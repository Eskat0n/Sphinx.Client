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

namespace Sphinx.Client.Commands.Attributes
{
    /// <summary>
    /// Represents basic information about document attribute (name and type).
    /// </summary>
    public class AttributeInfo : AttributeBase
    {
        #region Methods
        internal void Deserialize(IBinaryReader reader)
        {
            Name = reader.ReadString();
            AttributeType = (AttributeType)reader.ReadInt32();
        }
        
        #endregion
    }

}
