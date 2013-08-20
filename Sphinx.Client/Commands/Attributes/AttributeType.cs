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

#endregion

namespace Sphinx.Client.Commands.Attributes
{
    /// <summary>
    /// Attribute types
    /// </summary>
    public enum AttributeType : int
    {
        Integer = 1,
        Timestamp = 2,
        Ordinal = 3,
        Boolean = 4,
        Float = 5,
        Bigint = 6,
        String = 7,
        MultiInteger = 0x40000001,
        MultiLong = 0x40000002
	}

    [Flags]
    public enum MultiValueAttribute : int
    {
        MultiFlag = 0x40000000
    }
}
