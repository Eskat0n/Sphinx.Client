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
using Sphinx.Client.Commands.Attributes.Filters;
using Sphinx.Client.Commands.Attributes.Filters.Range;
using Sphinx.Client.Commands.Attributes.Filters.Values;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Search
{
    /// <summary>
    /// Represents attribute filters list.
    /// </summary>
    public class AttributeFilterList : List<AttributeFilterBase>
	{
		#region Fields 
    	private int _maxFiltersCount;
    	private int _maxValuesCount;
		#endregion

		#region Constructors
		internal AttributeFilterList(int maxFiltersCount, int maxValuesCount)
		{
			_maxFiltersCount = maxFiltersCount;
			_maxValuesCount = maxValuesCount;
		}
		#endregion

		#region Methods
		#region Add methods overloads
		/// <summary>
        /// Add new values filter with a long values array
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Values array to filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterValuesInt64 Add(string name, IEnumerable<long> values, bool exclude)
        {
            AttributeFilterValuesInt64 item = new AttributeFilterValuesInt64(name, values, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new values filter with a single long value
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="value">Value to filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterValuesInt64 Add(string name, long value, bool exclude)
        {
            AttributeFilterValuesInt64 item = new AttributeFilterValuesInt64(name, value, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add values filter with a integer values array
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Values array to filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterValuesInt32 Add(string name, IEnumerable<int> values, bool exclude)
        {
            AttributeFilterValuesInt32 item = new AttributeFilterValuesInt32(name, values, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new values filter with a single integer value
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="value">Value to filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterValuesInt32 Add(string name, int value, bool exclude)
        {
            AttributeFilterValuesInt32 item = new AttributeFilterValuesInt32(name, value, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add values filter with a DateTime values array
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Values array to filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterValuesDateTime Add(string name, IEnumerable<DateTime> values, bool exclude)
        {
            AttributeFilterValuesDateTime item = new AttributeFilterValuesDateTime(name, values, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new values filter with a single DateTime value
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="value">Value to filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterValuesDateTime Add(string name, DateTime value, bool exclude)
        {
            AttributeFilterValuesDateTime item = new AttributeFilterValuesDateTime(name, value, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new values filter with a single boolean value
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="value">Value to filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterValuesBoolean Add(string name, bool value, bool exclude)
        {
            AttributeFilterValuesBoolean item = new AttributeFilterValuesBoolean(name, value, exclude);
            Add(item);
            return item;
        }

        #endregion

        #region Range
        /// <summary>
        /// Add new range filter only match records if attribute long value is beetwen min. and max. (inclusive)
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="minValue">Minimal value to match filter</param>
        /// <param name="maxValue">Maximal value to match filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterRangeInt64 Add(string name, long minValue, long maxValue, bool exclude)
        {
            AttributeFilterRangeInt64 item = new AttributeFilterRangeInt64(name, minValue, maxValue, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new range filter only match records if attribute int value is beetwen min. and max. (inclusive)
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="minValue">Minimal value to match filter</param>
        /// <param name="maxValue">Maximal value to match filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterRangeInt32 Add(string name, int minValue, int maxValue, bool exclude)
        {
            AttributeFilterRangeInt32 item = new AttributeFilterRangeInt32(name, minValue, maxValue, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new range filter only match records if attribute DateTime value is beetwen min. and max. (inclusive)
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="minValue">Minimal value to match filter</param>
        /// <param name="maxValue">Maximal value to match filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterRangeDateTime Add(string name, DateTime minValue, DateTime maxValue, bool exclude)
        {
            AttributeFilterRangeDateTime item = new AttributeFilterRangeDateTime(name, minValue, maxValue, exclude);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new range filter only match records if attribute float value is beetwen min. and max. (inclusive)
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="minValue">Minimal value to match filter</param>
        /// <param name="maxValue">Maximal value to match filter</param>
        /// <param name="exclude">Exclude or include matches</param>
        /// <returns>New attribute filter object</returns>
        public AttributeFilterRangeFloat Add(string name, float minValue, float maxValue, bool exclude)
        {
            AttributeFilterRangeFloat item = new AttributeFilterRangeFloat(name, minValue, maxValue, exclude);
            Add(item);
            return item;
        }

        #endregion

        /// <summary>
        /// Serialize object to stream using specified binary writer.
        /// </summary>
        /// <param name="writer">Binary writer (output formatter) object</param>
        internal void Serialize(IBinaryWriter writer)
        {
			ArgumentAssert.IsInRange(Count, 0, _maxFiltersCount, "Count");

            // filters count
            writer.Write(Count);
            // serialize all filters
            foreach (AttributeFilterBase filter in this)
            {
                filter.Serialize(writer, _maxValuesCount);
            }
        }

        #endregion
    }
}
