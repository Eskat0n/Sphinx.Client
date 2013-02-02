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

#endregion

namespace Sphinx.Client.Commands.Attributes.Update
{
	/// <summary>
	/// Represents base class for attribute values and document IDs set to update.
	/// </summary>
    public abstract class AttributeUpdateSinglePerDocumentBase<T> : AttributeUpdateBase, IAttributeValuesPerDocument<T>
    {
        #region Fields
        private readonly Dictionary<long, T> _values = new Dictionary<long, T>();
        
        #endregion

        #region Constructors
		protected AttributeUpdateSinglePerDocumentBase()
        {
        }

    	protected AttributeUpdateSinglePerDocumentBase(string name, IDictionary<long, T> values): base(name)
        {
            ArgumentAssert.IsNotEmpty(values, "values");
            CollectionUtil.UnionDictionaries(_values, values);
        }
        
        #endregion

        #region Properties
        #region Implementation of IAttributeValuesPerDocument
        public IDictionary<long, T> Values
        {
            get { return _values; }
        }

        #endregion

        #endregion

        #region Methods
		#region Implementation of AttributeUpdateBase
        internal override IEnumerable<long> GetDocumentsIdSet()
        {
            return Values.Keys;
        }

        #endregion
 
	    #endregion    
    }
}
