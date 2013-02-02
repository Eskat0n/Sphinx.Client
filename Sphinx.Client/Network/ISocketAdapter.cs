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

using System.IO;

#endregion

namespace Sphinx.Client.Network
{
    public interface ISocketAdapter
    {
        /// <summary>
        /// Server socket host network address
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Server socket port number
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Is client socket is connected to server socket
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// Connection timeout
        /// </summary>
        int ConnectionTimeout { get; set; }

        /// <summary>
        /// Network data stream object
        /// </summary>
		IStreamAdapter DataStream { get; }

        /// <summary>
        /// Establish new connection to specified <see cref="Host"/> and <see cref="Port"/>
        /// </summary>
        void Open();

        /// <summary>
        /// Close opened connection socket
        /// </summary>
        void Close();
    }
}
