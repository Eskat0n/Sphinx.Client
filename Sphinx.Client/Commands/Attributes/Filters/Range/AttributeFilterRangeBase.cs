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

using Sphinx.Client.Commands.Search;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Filters.Range
{
    /// <summary>
    /// Represents integer values range to filter matches by attributes in search results.
    /// </summary>
    public abstract class AttributeFilterRangeBase<T> : AttributeFilterBase
	{
		#region Fields
    	private T _minValue;
		private T _maxValue;

		#endregion

		#region Constructors
		protected AttributeFilterRangeBase(string name, T minValue, T maxValue, bool exclude): base(name, exclude)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
        
        #endregion

        #region Properties

    	/// <summary>
    	/// Attribute filter type. AttributeFilterType.RangeInt32 is default value.
    	/// </summary>
    	public abstract override AttributeFilterType FilterType { get; }

        /// <summary>
        /// Represents the smallest possible value of attribute to filter (inclusive).
        /// </summary>
        public T MinValue {
			get { return _minValue; }
			set { _minValue = value; }
        }

    	/// <summary>
        /// Represents the largest possible value of attribute to filter (inclusive).
        /// </summary>
        public T MaxValue
    	{
    		get { return _maxValue; }
    		set { _maxValue = value; }
    	}

    	#endregion

		#region Methods
    	protected abstract void WriteBody(IBinaryWriter writer);

		protected override void WriteBody(IBinaryWriter writer, int maxCount)
		{
			WriteBody(writer);
		}
		#endregion
	}
}
