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

namespace Sphinx.Client.Commands.BuildKeywords
{
    /// <summary>
    /// Represents keyword information in result set of BuildKeywords command
    /// </summary>
    public class KeywordInfo
    {
		#region Fields
		private string _tokenizedForm;
		private string _normalizedForm;
		private long _documentsCount;
		private long _hitsCount;		
		#endregion

        #region Properties
    	/// <summary>
        /// Tokenized keyword form.
        /// </summary>
        public string TokenizedForm
    	{
    		get { return _tokenizedForm; }
    		protected set { _tokenizedForm = value; }
    	}

    	/// <summary>
        /// Normalized keyword form.
        /// </summary>
        public string NormalizedForm
    	{
    		get { return _normalizedForm; }
    		protected set { _normalizedForm = value; }
    	}

    	/// <summary>
        /// How much documents with specifed keyword is found.
        /// <remarks>Contains zero value, if keyword occurrence statistics calculation is not requested by command</remarks>
        /// </summary>
        public long DocumentsCount
    	{
    		get { return _documentsCount; }
    		protected set { _documentsCount = value; }
    	}

    	/// <summary>
        /// Total keyword hits.
        /// <remarks>Contains zero value, if keyword occurrence statistics calculation is not requested by command</remarks>
        /// </summary>
        public long HitsCount
    	{
    		get { return _hitsCount; }
    		private set { _hitsCount = value; }
    	}

    	#endregion

        #region Methods
        internal void Deserialize(IBinaryReader reader, bool deserializeAdditionalStatistics)
        {
            TokenizedForm = reader.ReadString();
            NormalizedForm = reader.ReadString();
            if (deserializeAdditionalStatistics)
            {
                DocumentsCount = reader.ReadInt32();
                HitsCount = reader.ReadInt32();
            }
        }

        #endregion
    }
}
