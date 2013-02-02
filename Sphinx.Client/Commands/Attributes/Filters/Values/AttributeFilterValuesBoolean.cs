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
using Sphinx.Client.Commands.Search;

#endregion

namespace Sphinx.Client.Commands.Attributes.Filters.Values
{
    /// <summary>
    /// Represents boolen values set to filter matches by attributes in search results. 
    /// </summary>
    public class AttributeFilterValuesBoolean : AttributeFilterValuesBase<bool>
    {
        #region Constructors
        public AttributeFilterValuesBoolean(string name, bool value, bool exclude): base(name, value, exclude)
        {
        }

        public AttributeFilterValuesBoolean(string name, IEnumerable<bool> values, bool exclude): base(name, values, exclude)
        {
        }

        #endregion

		#region Properties
		/// <summary>
		/// Attribute filter type.
		/// </summary>
		public override AttributeFilterType FilterType
		{
			get { return AttributeFilterType.ValuesBoolean; }
		}

		#endregion

		#region Methods
		protected override long ConvertToInt64(bool value)
        {
            return (value) ? 1 : 0;
        }

        #endregion


    }
}
