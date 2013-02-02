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

namespace Sphinx.Client.Commands.Status
{
    /// <summary>
    /// Represents <see cref="StatusCommand"/> command execution result.
    /// </summary>
    public class StatusCommandResult : CommandResultBase
    {
        #region Fields
        private readonly StatusInfoList _statusList = new StatusInfoList();
        
        #endregion

        #region Properties
        /// <summary>
        /// Sphinx server status variables names and values list.
        /// </summary>
        public IList<StatusInfo> StatusInfo
        {
            get { return _statusList; }
        }
        
        #endregion

        #region Methods
        internal void Deserialize(IBinaryReader reader)
        {
            _statusList.Deserialize(reader);
        }

        #endregion
    }
}
