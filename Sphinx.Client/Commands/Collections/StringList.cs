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
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Collections
{
    /// <summary>
    /// Provides serialiable string list.
    /// </summary>
    public class StringList : List<string>
    {
        #region Constants
        private const string DEFAULT_LIST_SEPARATOR = ",";

        #endregion

        #region Fields
        private string _separator = DEFAULT_LIST_SEPARATOR;

        #endregion

        #region Properties
        /// <summary>
        /// Item separator string used on string concatination
        /// </summary>
        protected virtual string Separator
        {
            get { return _separator; }
            set { _separator = value; }
        }

        #endregion

        #region Methods
        public void UnionWith(IEnumerable<string> values)
        {
            CollectionUtil.UnionCollections(this, values);
        }

        /// <summary>
        /// Concatenates a specified separator String between each item of a current list, yielding a single concatenated string.
        /// </summary>
        /// <returns>A String consisting of the elements of value interspersed with the <see cref="Separator"/> string.</returns>
        public override string ToString()
        {
        	return Count == 0 ? String.Empty : String.Join(Separator, ToArray());
        }

    	/// <summary>
        /// Serialize object to stream using specified binary writer.
        /// </summary>
        /// <param name="writer">Binary writer (output formatter) object</param>
        internal virtual void Serialize(IBinaryWriter writer)
        {
            writer.Write(ToString());
        }

        #endregion
    }
}
