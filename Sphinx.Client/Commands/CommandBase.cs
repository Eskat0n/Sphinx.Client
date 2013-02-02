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
using Sphinx.Client.Common;
using Sphinx.Client.Connections;
using Sphinx.Client.Helpers;
using Sphinx.Client.Network;

#endregion

namespace Sphinx.Client.Commands
{
    /// <summary>
    /// Represents an Sphinx searchd command to execute on server. Provides a base class for specific classes that represent real Sphinx commands.
    /// An abstract class, it cannot be instantiated.
    /// </summary>
    public abstract class CommandBase  
    {
        #region Fields
        // connection object
        private readonly ConnectionBase _connection;

        #endregion

        #region Constructors
        protected CommandBase(ConnectionBase connection)
        {
            ArgumentAssert.IsNotNull(connection, "connection");
            _connection = connection;
        }
        
        #endregion

        #region Properties
        #region Implemented
        /// <summary>
        /// Connection to Sphinx server
        /// </summary>
        public virtual ConnectionBase Connection
        {
            get { return _connection; }
        }
        
        #endregion

        #region Abstract
        /// <summary>
        /// Property must return struct <see cref="CommandInfo">CommandInfo</see>, contains command identification information (ID and version).
        /// An abstract property, must be overriden in derived class.
        /// </summary>
        protected abstract CommandInfo CommandInfo { get; }

        #endregion
        
        #endregion

        #region Methods
        #region Implemented
        /// <summary>
        /// Executes Sphinx command against a connection object.
        /// </summary>
        /// <returns><see cref="CommandResultBase{TResult}"/> based result object.</returns>
        /// <exception cref="ServerErrorException"/>
        /// <exception cref="SphinxException"/>
        /// <exception cref="IOException"/>
		/// <exception cref="ArgumentException"/>
		public virtual void Execute()
        {
        	ValidateParameters();
            Connection.PerformCommand(this);
        }
        #endregion

        #region Abstract
        /// <summary>
        /// Serializes an command and graph of internal objects to the provided stream.
        /// </summary>
        /// <param name="stream">The stream where the command puts the serialized data.</param>
		internal protected abstract void Serialize(IStreamAdapter stream);

        /// <summary>
        /// Deserializes the Sphinx server response data on the provided stream and reconstitutes the graph of objects.
        /// </summary>
        /// <param name="stream">The stream that contains the data to deserialize.</param>
		internal protected abstract void Deserialize(IStreamAdapter stream);

		/// <summary>
		/// Validates all actual command parameters. Throws <see cref="ArgumentException"/> based exception if some of parameters have invalid value(s).
		/// </summary>
		/// <exception cref="ArgumentException"/>
		protected abstract void ValidateParameters();
        
        #endregion

        #endregion
    }
}
