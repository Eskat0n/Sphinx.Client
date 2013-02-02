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
using Sphinx.Client.Commands.Collections;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Search
{
    /// <summary>
    /// Represents search query matches list in <see cref="Search" /> command.
    /// </summary>
    public class MatchList : List<Match>
    {
        #region Methods
        internal void Deserialize(IBinaryReader reader)
        {
            Clear();
            AttributesInfoList attributes = new AttributesInfoList();
            // read attributes list
            attributes.Deserialize(reader);

            int count = reader.ReadInt32();
            bool is64Bit = reader.ReadBoolean();

            MatchParseContext context = new MatchParseContext(attributes, is64Bit);

            for (int i=0; i < count; i++)
            {
                Match match = new Match();
                match.Deserialize(reader, context);
                Add(match);
            }
        }

        #endregion
    }
}
