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
    /// Represents temprorary attribute long values and document IDs set to override.
    /// </summary>
    public class AttributeOverrideInt64 : AttributeOverrideBase, IAttributeValuesPerDocument<long>
    {
        #region Fields
        private readonly Dictionary<long, long> _values = new Dictionary<long, long>();
        
        #endregion

        #region Constructors
        internal AttributeOverrideInt64()
        {
        }

        public AttributeOverrideInt64(string name, IDictionary<long, long> values): base(name)
        {
            ArgumentAssert.IsNotEmpty(values, "values");
            CollectionUtil.UnionDictionaries(_values, values);
        }
        
        #endregion

        #region Properties
        public override AttributeType AttributeType
        {
            get { return AttributeType.Bigint; }
        }

        #region Implementation of IAttributeValuesPerDocument
        public IDictionary<long, long> Values
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
            foreach (KeyValuePair<long, long> value in Values)
            {
                writer.Write(value.Key);
                writer.Write(value.Value);
            }
        }

        #endregion

    }
}
