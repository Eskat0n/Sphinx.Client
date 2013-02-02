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

namespace Sphinx.Client.Commands.Attributes.Override
{

    /// <summary>
    /// Represents temprorary attribute ordinal values and document IDs set to override.
    /// </summary>
    public class AttributeOverrideOrdinal : AttributeOverrideBase, IAttributeValuesPerDocument<int>
    {
        #region Fields
        private readonly Dictionary<long, int> _values = new Dictionary<long, int>();
        
        #endregion

        #region Constructors
        internal AttributeOverrideOrdinal()
        {

        }

        public AttributeOverrideOrdinal(string name, IDictionary<long, int> values): base(name)
        {
            ArgumentAssert.IsNotEmpty(values, "values");
            CollectionUtil.UnionDictionaries(_values, values);
        }
        
        #endregion

        #region Properties
        public override AttributeType AttributeType
        {
            get { return AttributeType.Ordinal; }
        }

        #region Implementation of IAttributeValuesPerDocument
        public IDictionary<long, int> Values
        {
            get { return _values; }
        }
        
        #endregion

        #endregion

        #region Methods
        internal override void Serialize(IBinaryWriter writer)
        {
            base.Serialize(writer);
            // filter type
            writer.Write((int)AttributeType);
            // values count
            writer.Write(Values.Count);
            // value pairs
            foreach (KeyValuePair<long, int> value in Values)
            {
                writer.Write(value.Key);
                writer.Write(value.Value);
            }
        }

        #endregion

    }
}
