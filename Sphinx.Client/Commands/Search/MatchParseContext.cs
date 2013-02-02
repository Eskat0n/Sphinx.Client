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

using Sphinx.Client.Commands.Collections;

#endregion

namespace Sphinx.Client.Commands.Search
{
    public class MatchParseContext
    {
        private readonly AttributesInfoList _attributes;
        private readonly bool _isLongIdentifiers;

        internal MatchParseContext(AttributesInfoList attributes, bool isLongIdentifiers)
        {
            _attributes = attributes;
            _isLongIdentifiers = isLongIdentifiers;
        }

        public AttributesInfoList Attributes
        {
            get { return _attributes; }
        }

        public bool LongIdentifiers
        {
            get { return _isLongIdentifiers; }
        }
    }
}
