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
using Sphinx.Client.Commands.Search;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Filters.Range
{
    /// <summary>
    /// Represents DateTime values range to filter matches by attributes in search results.
    /// </summary>
    public class AttributeFilterRangeDateTime : AttributeFilterRangeBase<DateTime> 
    {
        #region Constructors
        public AttributeFilterRangeDateTime(string name, DateTime minValue, DateTime maxValue, bool exclude): base(name, minValue, maxValue, exclude)
        {
        }
        
        #endregion

		#region Properties
		/// <summary>
		/// Attribute filter type.
		/// </summary>
		public override AttributeFilterType FilterType
		{
			get { return AttributeFilterType.RangeTimestamp; }
		}

		#endregion

        #region Methods
        protected override void WriteBody(IBinaryWriter writer)
        {
			// NOTE: padding to long, because timestamps sent as Int64
			writer.Write(0);
			writer.Write(MinValue);
			writer.Write(0);
			writer.Write(MaxValue);
        }

        #endregion
    }
}
