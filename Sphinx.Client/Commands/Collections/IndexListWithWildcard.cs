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
using System.Text;

#endregion

namespace Sphinx.Client.Commands.Collections
{
    /// <summary>
    /// Represents Sphinx index names list with wildcard support.
    /// </summary>
    public class IndexListWithWildcard : StringList
    {
        private const string WILDCARD_ALL = "*";

        /// <summary>
        /// Concatenates a specified separator String between each item of a current list, yielding a single concatenated string.
        /// Returns wildcard symbol if list is empty or some of list items equals to wildcard symbol '*'.
        /// </summary>
        /// <returns>A String consisting of the elements of value interspersed with the separator string.</returns>
        public override string ToString()
        {
            if (Count == 0)
            {
                // No index names are specified, return wildcard symbol
                return WILDCARD_ALL;
            }

            StringBuilder sb = new StringBuilder();
            int num = 0;
            foreach (string s in this)
            {
                if (String.IsNullOrEmpty(s)) continue;
                string val = s.Trim();
                if (String.IsNullOrEmpty(val)) continue;
                if (WILDCARD_ALL.Equals(val))
                {
                    // if some of index names equals to wildcard char - return only wildcard char as result
                    return WILDCARD_ALL;
                }
                if (num++ > 0) sb.Append(Separator);
                sb.Append(s);
            }
            return sb.ToString();
        }

    }
}
