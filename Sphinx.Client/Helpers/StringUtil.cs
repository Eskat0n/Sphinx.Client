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

using System.Text.RegularExpressions;

#endregion

namespace Sphinx.Client.Helpers
{

    /// <summary>
    /// Provides a set of static methods for string operations. This class cannot be inherited. 
    /// </summary>    
    public static class StringUtil
    {
        /// <summary>
        /// Escape special symbols used by Sphinx in specified string.
        /// </summary>
        /// <param name="input">String to process</param>
        /// <returns>Escaped string</returns>
        public static string EscapeString(string input)
        {
            return Regex.Replace(input, "[\\\\()|\\-!@~\"&/^$=<]", "\\$0");
        }
    }
}
