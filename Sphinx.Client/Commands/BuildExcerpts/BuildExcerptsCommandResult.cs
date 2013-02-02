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

namespace Sphinx.Client.Commands.BuildExcerpts
{
    /// <summary>
    /// Excerpts (snippets) builder command. Ask server to generate excerpts (snippets) from given documents content, and returns the results list with highlighted keywords. 
    /// </summary>
    public class BuildExcerptsCommandResult : CommandResultBase
    {
        #region Fields
        private readonly List<string> _excerpts = new List<string>();
        
        #endregion

        #region Properties
		/// <summary>
        /// Builded documents excerpts list with highlighted keywords.
        /// </summary>
		public ReadOnlyCollection<string> Excerpts
        {
            get
            {
                return _excerpts.AsReadOnly();
            }
        }

        #endregion        
        
        #region Methods
        internal void Deserialize(IBinaryReader reader, int count)
        {
            for (int i = 0; i < count; i++)
            {
				_excerpts.Add(reader.ReadString());
            }
        }

        #endregion
    }
}
