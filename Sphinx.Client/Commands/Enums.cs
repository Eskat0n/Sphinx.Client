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
namespace Sphinx.Client.Commands
{

    /// <summary>
    /// Sphinx searchd server command identifiers
    /// </summary>
    public enum ServerCommand : short
    {
        Search   		= 0,
        Excerpt  		= 1,
        Update   		= 2,
        Keywords 		= 3,
        Persist  		= 4,
        Status   		= 5,
		FlushAttributes = 7
    }

    /// <summary>
    /// Sphinx searchd server command execution status code
    /// </summary>
    public enum CommandStatus : short
    {
        Unknown = -1,
        Ok = 0,
        Error = 1,
        Retry = 2,
        Warning = 3
    }

}
