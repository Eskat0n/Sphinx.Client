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
using Sphinx.Client.Commands.Search;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Filters.Values
{
    public abstract class AttributeFilterValuesBase<T> : AttributeFilterBase
    {
        #region Fields
        private readonly List<T> _values = new List<T>();
        #endregion

        #region Constructs
        protected AttributeFilterValuesBase(string name, T value, bool exclude): base(name, exclude)
        {
            _values.Add(value);
        }

        protected AttributeFilterValuesBase(string name, IEnumerable<T> values, bool exclude): base(name, exclude)
        {
            ArgumentAssert.IsNotNull(values, "values");
            _values.AddRange(values);
        }
        
        #endregion

        #region Properties
        /// <summary>
        /// MVA attribute values to filter.
        /// </summary>
        public IList<T> Values 
        { 
            get { return _values; }
        }

        #endregion

        #region Methods
        #region Implemented
		protected override void WriteBody(IBinaryWriter writer, int maxCount)
        {
			ArgumentAssert.IsInRange(Values.Count, 0, maxCount, "Values.Count");

            writer.Write(Values.Count);
            foreach (T value in Values)
            {
                writer.Write(ConvertToInt64(value));
            }
        } 
        #endregion

        #region Abstract
        /// <summary>
        /// Convert <typeparamref name="T"/> value to In64.
        /// An abstract method and must be implemented in derived class.
        /// </summary>
        /// <param name="value">Original value</param>
        protected abstract long ConvertToInt64(T value);
        
        #endregion

        #endregion
    }
}
