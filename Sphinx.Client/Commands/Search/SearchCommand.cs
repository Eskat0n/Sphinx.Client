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
using Sphinx.Client.Commands.Collections;
using Sphinx.Client.Connections;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Search
{
    /// <summary>
    /// Represents Sphinx search command to perform batch search using specified query list.
    /// </summary>
    public class SearchCommand : CommandWithResultBase<SearchCommandResult>
    {
        #region Constants
        internal const short COMMAND_VERSION = 0x119;
        private const int DEFAULT_MAX_QUERIES = 32;
        
        #endregion

        #region Fields
        private static readonly CommandInfo _commandInfo = new CommandInfo(ServerCommand.Search, COMMAND_VERSION);

        private readonly SearchQueryList _queryList = new SearchQueryList();
        private int _maxQueries = DEFAULT_MAX_QUERIES;
        #endregion

        #region Constructors
        public SearchCommand(ConnectionBase connection): base(connection)
        {
        }

        public SearchCommand(ConnectionBase connection, IEnumerable<SearchQuery> queryList): base(connection)
        {
			ArgumentAssert.IsNotNull(queryList, "queryList");
            QueryList.AddRange(queryList);
        }

        public SearchCommand(ConnectionBase connection, SearchQuery query): base(connection)
        {
			ArgumentAssert.IsNotNull(query, "query");
			QueryList.Add(query);
        }
        #endregion

        #region Properties

        #region Command parameters
        /// <summary>
        /// Search query list
        /// </summary>
        public SearchQueryList QueryList
        {
            get { return _queryList; }
        }
        
        public int MaxQueries
        {
            get { return _maxQueries; }
            set { _maxQueries = value; }
        }
        #endregion

        #region Overrides of CommandWithResultBase
        protected override CommandInfo CommandInfo
        {
            get { return _commandInfo; }
        }

        #endregion

        #endregion

        #region Methods

        #region Overrides of CommandWithResultBase

    	protected override void ValidateParameters()
    	{
			ArgumentAssert.IsNotEmpty<SearchQuery>(QueryList, "QueryList");
    	    if (MaxQueries > 0)
    	    {
    	        ArgumentAssert.IsInRange(QueryList, 1, MaxQueries, "QueryList");
    	    }
    	    QueryList.ValidateParameters();
		}

        protected override void SerializeRequest(IBinaryWriter writer)
        {
			writer.Write(0); // its a client
            QueryList.Serialize(writer);
        }

        protected override void DeserializeResponse(IBinaryReader reader)
        {
            Result.Deserialize(reader, QueryList.Count);
        }

        #endregion

	    #endregion    
    }
}
