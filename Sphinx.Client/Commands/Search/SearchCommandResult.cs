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
using System.Collections.ObjectModel;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Search
{
    /// <summary>
    /// Represents <see cref="Search"/> command query results list.
    /// </summary>
    public class SearchCommandResult : CommandResultBase
    {
        #region Fields
        private readonly List<SearchQueryResult> _queryResults = new List<SearchQueryResult>();
        
        #endregion

        #region Properties
        /// <summary>
        /// Search query results list. Results item index are indentical to original <see cref="SearchQuery"/> object index in <see cref="Search"/> command list parameters.
        /// </summary>
		public ReadOnlyCollection<SearchQueryResult> QueryResults
        {
            get
            {
                return _queryResults.AsReadOnly();
            }
        }
        
        #endregion

        #region Methods
        internal void Deserialize(IBinaryReader reader, int count)
        {
            for (int i = 0; i < count; i++)
            {
                SearchQueryResult result = new SearchQueryResult();
                result.Deserialize(reader);
				_queryResults.Add(result);
            }
        }

        #endregion
    }

}
