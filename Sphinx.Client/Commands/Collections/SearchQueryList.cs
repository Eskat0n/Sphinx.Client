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
using Sphinx.Client.Common;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Collections
{
	public class SearchQueryList : List<SearchQuery>
    {

        #region Methods
        /// <summary>
        /// Add new query with current settings to multi-query batch.  Will use indexes specified in indexes argument or all available indexes by default. Will use indexes specified in indexes argument or all available indexes by default.
        /// </summary>
        /// <param name="query">query string</param>
        /// <returns><seealso cref="SearchQuery"/> object search query parameters</returns>
        /// <exception cref="ArgumentException">Arguments invalid or unexpected</exception>
        public SearchQuery Add(string query)
        {
            SearchQuery q = new SearchQuery(query);
            Add(q);
            return q;
        }

        /// <summary>
        /// Add new query with current settings to multi-query batch.
        /// </summary>
        /// <param name="query">query string</param>
        /// <param name="indexes">index name(s) to query. May contain list of index names.</param>
        /// <returns><seealso cref="SearchQuery"/> object with executed search query results</returns>
        /// <exception cref="ArgumentException">Arguments invalid or unexpected</exception>
        public SearchQuery Add(string query, string[] indexes)
        {
            SearchQuery q = new SearchQuery(query, indexes);
            Add(q);
            return q;
        }

        /// <summary>
        /// Add new query with current settings to multi-query batch. You can specify query comment for debuging purposes.
        /// </summary>
        /// <param name="query">query string</param>
        /// <param name="indexes">index name(s) to query. May contain list of index names.</param>
        /// <param name="comment">comment are sent to the query log, marked in square brackets, just before the search terms, which can be very useful for debugging.</param>
        /// <returns><seealso cref="SearchQuery"/> object with executed search query results</returns>
        /// <exception cref="SphinxException">Arguments invalid or unexpected</exception>
        public SearchQuery Add(string query, string[] indexes, string comment)
        {
            SearchQuery q = new SearchQuery(query, indexes, comment);
            Add(q);
            return q;
        }

		/// <summary>
		/// Validate parameters
		/// </summary>
		internal void ValidateParameters()
		{
			foreach (SearchQuery query in this)
			{
				ArgumentAssert.IsNotNull(query, "query");
				query.ValidateParameters();
			}
		}

        /// <summary>
        /// Serialize object to stream using specified binary writer.
        /// </summary>
        /// <param name="writer">Binary writer (output formatter) object</param>
        internal void Serialize(IBinaryWriter writer)
        {
            writer.Write(Count);
            foreach (SearchQuery q in this)
            {
                q.Serialize(writer);
            }
        }

        #endregion
    }
}
