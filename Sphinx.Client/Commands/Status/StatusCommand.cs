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
using Sphinx.Client.Connections;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Status
{
    /// <summary>
    /// Represents command to get Sphinx server status. Returns an array of status variable name and value pairs.
    /// </summary>
    public class StatusCommand : CommandWithResultBase<StatusCommandResult>
    {
        #region Constants
        internal const short COMMAND_VERSION = 0x100;
        private const int STATUS_BODY = 1;

        #endregion

        #region Fields
        private static readonly CommandInfo _commandInfo = new CommandInfo(ServerCommand.Status, COMMAND_VERSION);
        #endregion

        #region Constructors
        public StatusCommand(ConnectionBase connection): base(connection)
        {
        }

        #endregion

        #region Properties
        #region Overrides of CommandWithResultBase
        protected override CommandInfo CommandInfo {
            get { return _commandInfo; } 
        }

    	protected override void ValidateParameters()
    	{
    	}
    	#endregion

        #endregion

        #region Methods
		#region Overrides of CommandWithResultBase

        protected override void SerializeRequest(IBinaryWriter writer)
        {
            writer.Write(STATUS_BODY);
        }

        protected override void DeserializeResponse(IBinaryReader reader)
        {
            Result.Deserialize(reader);
        }

        #endregion
 
	    #endregion
    }
}
