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
using System.IO;
using System.Threading;
using Sphinx.Client.Common;
using Sphinx.Client.Connections;
using Sphinx.Client.IO;
using Sphinx.Client.Network;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.Commands
{
    /// <summary>
    /// Represents an Sphinx searchd command to execute on server with strongly typed results object, based on <see cref="CommandResultBase"/> class. Provides a base class for specific classes that represent real Sphinx commands, returning command execution results data.
    /// An abstract class, it cannot be instantiated.
    /// </summary>
    public abstract class CommandWithResultBase<TResult> : CommandBase, ICommandResult<TResult>
                    where TResult : CommandResultBase, new()
    {
        #region Constants
		private const int MAX_COMMAND_BODY_LENGTH = 8 * 1024 * 1024;
		#endregion

		#region Fields
		private TResult _result;

		/// <summary>
		/// Command body size limit. Default value is 8 MBytes (hardcoded in sphinxd).
		/// </summary>
		public static int MaxCommandBodyLength = MAX_COMMAND_BODY_LENGTH;

		#endregion
		
		#region Constructors
		protected CommandWithResultBase(ConnectionBase connection) : base(connection)
        {
        }
        
        #endregion

        #region Properties
        #region Implemented

		/// <summary>
    	/// Command execution result object. Holds all information returned by server, including command execution state and Sphinx server warnings.
    	/// </summary>
    	public virtual TResult Result
    	{
    		get { return _result; }
    		protected set { _result = value; }
    	}

    	#endregion

        #endregion

        #region Methods
        #region Implemented
        /// <summary>
        /// Executes Sphinx command against a connection object.
        /// </summary>
        /// <returns><see cref="CommandResultBase"/> based result object.</returns>
        /// <exception cref="ServerErrorException"/>
        /// <exception cref="SphinxException"/>
        /// <exception cref="IOException"/>
		/// <exception cref="ArgumentException"/>
        public override void Execute()
        {
            Result = new TResult();
            base.Execute();
        }

        /// <summary>
        /// Serializes an command and graph of internal objects to the provided stream.
        /// </summary>
        /// <param name="stream">The stream where the command puts the serialized data.</param>
        /// <exception cref="IOException"/>
		internal protected override void Serialize(IStreamAdapter stream)
        {
            IBinaryWriter writer = Connection.FormatterFactory.CreateWriter(stream);
            // send command id and version information
            CommandInfo.Serialize(writer);

            // serialize request body to temp. buffer to get command body length
            MemoryStream buffer = new MemoryStream();
			IBinaryWriter bufferWriter = Connection.FormatterFactory.CreateWriter(new StreamAdapter(buffer));
            SerializeRequest(bufferWriter);
            // send body length first
        	int length = (int) buffer.Length;
			writer.Write(length);
            // send buffer content
        	buffer.Position = 0;
			stream.WriteBytes(buffer.ToArray(), length);
        }

        /// <summary>
        /// Deserializes the Sphinx server response data on the provided stream and reconstitutes the graph of objects.
        /// </summary>
        /// <param name="stream">The stream that contains the data to deserialize.</param>
        /// <exception cref="ServerErrorException"/>
        /// <exception cref="SphinxException"/>
        /// <exception cref="IOException"/>
		internal protected override void Deserialize(IStreamAdapter stream)
        {
            IBinaryReader reader = Connection.FormatterFactory.CreateReader(stream);
            // read general command response header values
            Result.Status = (CommandStatus)reader.ReadInt16();
            short serverCommandVersion = reader.ReadInt16();

            // read response body length
            int length = reader.ReadInt32();
			if (length <= 0 || length > MaxCommandBodyLength)
			{
				throw new SphinxException(String.Format(Messages.Exception_InvalidServerResponseLength, length));
			}

        	// read server response body
			byte[] buffer = new byte[length];
			stream.ReadBytes(buffer, length);
        	MemoryStream bodyStream = new MemoryStream(buffer);
            IBinaryReader bodyReader = Connection.FormatterFactory.CreateReader(new StreamAdapter(bodyStream));

            // check response status
            ValidateResponse(bodyReader, serverCommandVersion);

        	// parse command result 
            DeserializeResponse(bodyReader);
        }

    	protected virtual void ValidateResponse(IBinaryReader bodyReader, short serverCommandVersion)
    	{
    		switch (Result.Status)
    		{
    			case CommandStatus.Ok:
    				break;
    			case CommandStatus.Warning:
    				// read warning message from response stream
    				Result.DeserializeWarning(bodyReader);
    				break;
    			case CommandStatus.Error:
    				string errorMessage = bodyReader.ReadString();
    				throw new ServerErrorException(String.Format(Messages.Exception_ServerError, errorMessage));
    			case CommandStatus.Retry:
    				string tempErrorMessage = bodyReader.ReadString();
    				throw new ServerErrorException(String.Format(Messages.Exception_TemproraryServerError, tempErrorMessage));
    			default:
    				throw new SphinxException(String.Format(Messages.Exception_UnknowStatusCode, (int)Result.Status));
    		}

    		// check server command version
    		short clientCommandVersion = CommandInfo.Version;
    		if (serverCommandVersion < clientCommandVersion)
    		{
    			throw new NotSupportedException(String.Format(Messages.Exception_CommandVersion, serverCommandVersion >> 8, serverCommandVersion & 0xff, clientCommandVersion >> 8, clientCommandVersion & 0xff));
    		}
    	}

    	#endregion

        #region Abstract
        /// <summary>
        /// Serialize command request body to stream. 
        /// An abstract method, must be implemented in derived class.
        /// </summary>
        /// <param name="writer">Data stream object</param>
        protected abstract void SerializeRequest(IBinaryWriter writer);

        /// <summary>
        /// Deserialize server response body.
        /// An abstract method, must be implemented in derived class.
        /// </summary>
        /// <param name="reader">Data stream object</param>
        protected abstract void DeserializeResponse(IBinaryReader reader);
        
        #endregion

        #endregion
    }
}
