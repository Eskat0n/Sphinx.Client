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
    /// Represents base class for MVA values and document IDs set to update.
    /// </summary>
    public abstract class AttributeUpdateMultiPerDocumentBase<T> : AttributeUpdateBase, IAttributeValuesPerDocument<IList<T>>
    {
        #region Fields
        private readonly Dictionary<long, IList<T>> _values = new Dictionary<long, IList<T>>();
        
        #endregion

        #region Constructors
        internal AttributeUpdateMultiPerDocumentBase()
        {
        }

		public AttributeUpdateMultiPerDocumentBase(string name, IDictionary<long, IEnumerable<T>> values): base(name)
        {
            ArgumentAssert.IsNotEmpty(values, "values");
			CollectionUtil.UnionDictionaries(_values, values);
        }
        
        #endregion

        #region Properties

        #region Implementation of IAttributeValuesPerDocument
        public IDictionary<long, IList<T>> Values
        {
            get { return _values; }
        }
        
        #endregion

        #endregion

        #region Methods
        internal override IEnumerable<long> GetDocumentsIdSet()
        {
            return Values.Keys;
        }

		#endregion

    }
}
