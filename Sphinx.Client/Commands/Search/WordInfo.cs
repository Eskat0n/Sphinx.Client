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

using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Search
{
    /// <summary>
    /// Represents keyword stemmed form and optional keyword index statistics.
    /// </summary>
    public class WordInfo 
    {
        #region Fields
        private string _word;
        private long _docs;
        private long _hits;
        
        #endregion

        #region Constructors
        internal WordInfo()
        {

        }

        public WordInfo(string word, long docs, long hits)
        {
            _word = word;
            _docs = docs;
            _hits = hits;
        }
        
        #endregion

        #region Properties
        /// <summary>
        /// Word form as returned from search daemon, stemmed or otherwise postprocessed.
        /// </summary>
        public string Word
        {
            get { return _word; }
        }

        /// <summary>
        /// Total amount of matching documents in collection.
        /// </summary>
        public long Documents
        {
            get { return _docs; }
        }

        /// <summary>
        /// Total amount of hits (occurences) in collection. 
        /// </summary>
        public long Hits
        {
            get { return _hits; }
        }
        
        #endregion

        #region Methods
        internal void Deserialize(IBinaryReader reader)
        {
            _word = reader.ReadString();
            _docs = reader.ReadInt32();
            _hits = reader.ReadInt32();
        }

        #endregion
    }
}
