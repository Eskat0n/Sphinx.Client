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

#endregion

namespace Sphinx.Client.Commands.Attributes
{
    interface IAttributeValuesPerDocument<T> 
    {
        /// <summary>
        /// Dictionary contains attribute values per document. Key value for document ID (as long) and <see cref="T"/> for attribute value.
        /// </summary>
        IDictionary<long, T> Values { get; }
    }
}
