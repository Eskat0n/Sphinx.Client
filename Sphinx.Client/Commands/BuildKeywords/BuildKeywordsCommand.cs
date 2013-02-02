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

namespace Sphinx.Client.Commands.BuildKeywords
{
    /// <summary>
    /// Represents command to extract keywords from query string using tokenizer settings for given index, optionally with per-keyword occurrence statistics. Returns an array of key-value pairs with per-keyword information. 
    /// </summary>
    public class BuildKeywordsCommand : CommandWithResultBase<BuildKeywordsCommandResult>
    {
        #region Constants
        internal const short COMMAND_VERSION = 0x100;

        #endregion

        #region Fields
        private static readonly CommandInfo _commandInfo = new CommandInfo(ServerCommand.Keywords, COMMAND_VERSION);

        private readonly StringList _indexNames = new StringList();
        private string _queryText;
        private bool _calcStatistics;

        #endregion

        #region Constructors
        public BuildKeywordsCommand(ConnectionBase connection): base(connection)
        {
        }

        public BuildKeywordsCommand(ConnectionBase connection, IEnumerable<string> indexes, string query): base(connection)
        {
			ArgumentAssert.IsNotNull(indexes, "indexes");

			_indexNames.UnionWith(indexes);
			_queryText = query;
        }

        public BuildKeywordsCommand(ConnectionBase connection, IEnumerable<string> indexes, string query, bool calculateStatistics): this(connection, indexes, query)
        {
			_calcStatistics = calculateStatistics;
        }

        #endregion

        #region Properties

        #region Command parameters
        /// <summary>
        /// List of index names
        /// </summary>
        public IList<string> Indexes
        {
            get { return _indexNames; }
        }

        /// <summary>
        /// Query expression to extract keywords
        /// </summary>
        public string Query
        {
            set { _queryText = value; }
            get { return _queryText; }
        }

        /// <summary>
        /// Include documents and hits count per keyword to results
        /// </summary>
        public bool CalculateStatistics
        {
            set { _calcStatistics = value; }
            get { return _calcStatistics; }
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
			ArgumentAssert.IsNotEmpty<string>(Indexes, "Indexes");
			ArgumentAssert.IsNotEmpty(Query, "Query");
		}

        protected override void SerializeRequest(IBinaryWriter writer)
        {
            writer.Write(Query);
			_indexNames.Serialize(writer);
            writer.Write(CalculateStatistics);
        }

        protected override void DeserializeResponse(IBinaryReader reader)
        {
            Result.Deserialize(reader, CalculateStatistics);
        }

        #endregion
 
	    #endregion    
    }
}
