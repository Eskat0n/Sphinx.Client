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

namespace Sphinx.Client.Commands.Attributes.Update
{
    /// <summary>
    /// Represents attribute multi-int values and document IDs set to update.
    /// </summary>
	public class AttributeUpdateMultiInt32 : AttributeUpdateMultiPerDocumentBase<int>
    {

        #region Constructors
        internal AttributeUpdateMultiInt32()
        {

        }

		public AttributeUpdateMultiInt32(string name, IDictionary<long, IEnumerable<int>> values): base(name, values)
        {
        }
        
        #endregion

        #region Properties
        public override AttributeType AttributeType
        {
            get { return AttributeType.MultiInteger; }
        }

        
        #endregion

        #region Methods
        internal override void Serialize(IBinaryWriter writer, long id)
        {
			IList<int> values = Values[id];
            writer.Write(values.Count);
            foreach (int val in values)
            {
                writer.Write(val);
            }
        }

        #endregion
    }
}
