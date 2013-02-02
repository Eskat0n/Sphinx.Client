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

namespace Sphinx.Client.Commands.FlushAttributes
{
	/// <summary>
	/// Forces searchd to flush pending attribute updates to disk, and blocks until completion. 
	/// Introduced in version 1.10-beta.
	/// </summary>
	public class FlushAttributesCommand : CommandWithResultBase<FlushAttributesCommandResult>
	{
		#region Constants
		internal const short COMMAND_VERSION = 0x100;

		#endregion

		#region Fields
		private static readonly CommandInfo _commandInfo = new CommandInfo(ServerCommand.FlushAttributes, COMMAND_VERSION);

		#endregion

		#region Constructors
		public FlushAttributesCommand(ConnectionBase connection): base(connection)
		{
		}

		#endregion

		#region Properties

		#region Overrides of CommandWithResultBase
		protected override CommandInfo CommandInfo
		{
			get { return _commandInfo; }
		}

		protected override void ValidateParameters()
		{
		}

		#endregion

		#endregion

		#region Methods

		#region Overrides of CommandWithResultBase
		/// <summary>
		/// Serialize command parameters using specified binary stream writer.
		/// </summary>
		/// <param name="writer">Binary stream writer object</param>
		protected override void SerializeRequest(IBinaryWriter writer)
		{
		}

		/// <summary>
		/// Deserialize server response body using specified binary stream reader.
		/// </summary>
		/// <param name="reader">Binary stream reader object</param>
		protected override void DeserializeResponse(IBinaryReader reader)
		{
			Result.Deserialize(reader); 
		}

		#endregion
 
		#endregion    
	}
}