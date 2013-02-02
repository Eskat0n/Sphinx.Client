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
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Collections
{
    /// <summary>
    /// Binds per-field weights by unique field name
    /// </summary>
    public class FieldWeightMap : Dictionary<string, int>
    {
        #region Methods
        public void UnionWith(IDictionary<string, int> indexes)
        {
            CollectionUtil.UnionDictionaries(this, indexes);
        }

        /// <summary>
        /// Serialize object to stream using specified binary writer.
        /// </summary>
        /// <param name="writer">Binary writer (output formatter) object</param>
        internal void Serialize(IBinaryWriter writer)
        {
            writer.Write(Count);
            foreach (KeyValuePair<string, int> field in this)
            {
                writer.Write(field.Key);
                writer.Write(field.Value);
            }
        }

        #endregion
    }
}
