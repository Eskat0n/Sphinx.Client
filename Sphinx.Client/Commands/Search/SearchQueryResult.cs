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
using System.Collections.ObjectModel;
using Sphinx.Client.Commands.Collections;
using Sphinx.Client.Common;
using Sphinx.Client.IO;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.Commands.Search
{
    public class SearchQueryResult
    {
        #region Fields
        private QueryStatus _status;
        private readonly ResultFieldList _fields = new ResultFieldList();
        private readonly MatchList _matches = new MatchList();
        private readonly WordsInfoList _words = new WordsInfoList();
        private int _count;
        private int _totalFound;
        private TimeSpan _elapsedTime;
        private string _warning;
        
        #endregion

        #region Properties
        /// <summary>
        /// Search query result status.
        /// </summary>
        public QueryStatus Status
        {
            get { return _status; }
        }

        /// <summary>
        /// Full-text field names.
        /// </summary>
        public ReadOnlyCollection<string> Fields
        {
            get { return _fields.AsReadOnly(); }
        }

        /// <summary>
        /// Retrieved matches.
        /// </summary>
		public ReadOnlyCollection<Match> Matches
        {
            get { return _matches.AsReadOnly(); }
        }

        /// <summary>
        /// Per-word statistics.
        /// </summary>
		public ReadOnlyCollection<WordInfo> Words
        {
            get { return _words.AsReadOnly(); }
        }

        /// <summary>
        /// Total matches in this result set.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Total matches found in the index(es).
        /// </summary>
        public int TotalFound
        {
            get { return _totalFound; }
        }

        /// <summary>
        /// Elapsed time to process search query (as reported by searchd).
        /// </summary>
        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
        }

        /// <summary>
        /// Flag indicating there is warning message reported by server. Check <see cref="Warning"/> property.
        /// </summary>
        public bool HasWarning
        {
            get { return !String.IsNullOrEmpty(_warning); }
        }

        /// <summary>
        /// Warning message reported by Sphinx server
        /// </summary>
        public string Warning
        {
            get { return _warning; }
        }

        #endregion

        #region Methods
        internal void Deserialize(IBinaryReader reader)
        {
            // read query status
            _status = (QueryStatus)reader.ReadInt32();
            switch (_status)
            {
                case QueryStatus.Warning:
                    _warning = reader.ReadString();
                    break;

                case QueryStatus.Error:
                    string errorMessage = reader.ReadString();
                    throw new QueryErrorException(String.Format(Messages.Exception_QueryError, errorMessage));
            }

            // read fields
            _fields.Deserialize(reader);

            // read matches
            _matches.Deserialize(reader);

            // read search statistics
            _count = reader.ReadInt32();
            _totalFound = reader.ReadInt32();
            _elapsedTime = TimeSpan.FromMilliseconds(reader.ReadInt32());

            _words.Deserialize(reader);
        }

        #endregion
    }
}
