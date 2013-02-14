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

using System.Net;
using Sphinx.Client.Commands;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Connections
{
	/// <summary>
	/// Persistent connections allow to use single network connection to execute multiple commands that would otherwise require create new network connection for each command.
	/// </summary>
	public class PersistentTcpConnection : TcpConnection
	{
		#region Constants
		private const short PERSIST_COMMAND_VERSION = 0;
		private const int PERSIST_COMMAND_BODY = 1;

		private static CommandInfo _persistCommandInfo = new CommandInfo(ServerCommand.Persist, PERSIST_COMMAND_VERSION);
		#endregion

		#region Constructors
		public PersistentTcpConnection()
		{
		}

		public PersistentTcpConnection(string host): base(host)
		{
		}

		public PersistentTcpConnection(string host, int port): base(host, port)
		{
		}

		public PersistentTcpConnection(IPEndPoint address): base(address)
		{
		}

		#endregion

		#region Methods
		/// <summary>
		/// Send request to Sphinx server using underlying data stream and process server response. 
		/// Connection behaviour is changed - underlying network connection will not closed until <see cref="PersistentTcpConnection.Close()"/> method is called or object is disposed.
		/// </summary>
		/// <param name="command">Command to execute</param>
		internal override void PerformCommand(CommandBase command)
		{
			ArgumentAssert.IsNotNull(command, "command");
			if (!IsConnected)
			{
				Open();
				SendHandshake();
			}
			command.Serialize(DataStream);
			DataStream.Flush();
			command.Deserialize(DataStream);
		}

		/// <summary>
		/// Sends client protocol version and checks protocol version supported by server. 
		/// Overriden version sends additional information to make connection persistent.
		/// </summary>
		protected override void SendHandshake()
		{
			base.SendHandshake();
			// send 'persistent connection' command
			IBinaryWriter writer = FormatterFactory.CreateWriter(DataStream);
			_persistCommandInfo.Serialize(writer);
			
			// command body length
			writer.Write(sizeof(int));
			// enable persistent connection boolean flag
			writer.Write(PERSIST_COMMAND_BODY);
		}
		
		#endregion
	}
}