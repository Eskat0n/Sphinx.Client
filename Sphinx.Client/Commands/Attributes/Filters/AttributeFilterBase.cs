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
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Attributes.Filters
{
    /// <summary>
    /// Base class for attribute filters classes.
    /// An abstract class, it cannot be instantiated.
    /// </summary>
    public abstract class AttributeFilterBase
    {
        #region Fields
        private string _name;
        private bool _exclude;
        
        #endregion

        #region Constructors
        protected AttributeFilterBase(string name, bool exclude)
        {
            Name = name;
            Exclude = exclude;
        }
        
        #endregion

        #region Properties
        #region Implemented
        /// <summary>
        /// Attribute name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set 
            {
                ArgumentAssert.IsNotEmpty(value, "Name");
                _name = value; 
            }
        }

        /// <summary>
        /// If true - documents with matched attribute value will be excluded (filtered-out) from search results. 
        /// Otherwise all other documents with unmatched attribute values will be excluded.
        /// </summary>
        public bool Exclude
        {
            get { return _exclude; }
            set { _exclude = value; }
        } 
        #endregion
        
        #region Abstract
        public abstract AttributeFilterType FilterType
        {
            get;
        }
        
        #endregion
        
        #endregion

        #region Methods
        
        #region Abstract
		protected abstract void WriteBody(IBinaryWriter writer, int maxCount);
        
        #endregion

        #region Implemented
        protected virtual void WriteHead(IBinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write((int)FilterType);
        }

        protected virtual void WriteTail(IBinaryWriter writer)
        {
            writer.Write(Exclude);
        }

        internal protected virtual void Serialize(IBinaryWriter writer, int maxCount)
        {
            WriteHead(writer);
			WriteBody(writer, maxCount);
            WriteTail(writer);
        }
        
        #endregion

        #endregion

    }
}
