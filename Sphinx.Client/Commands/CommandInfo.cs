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



#endregion

#region Usings

using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands
{
    public class CommandInfo 
    {
        #region Fields
        private readonly ServerCommand _id;
        private readonly short _version;
        
        #endregion

        #region Constructors
		public CommandInfo(ServerCommand id, short version)
        {
            _id = id;
            _version = version;
        }

 	    #endregion

        #region Properties
        public ServerCommand Id
        {
            get { return _id; }
        }

        public short Version
        {
            get { return _version; }
        }
        #endregion

        #region Methods 
        public void Serialize(IBinaryWriter writer)
        {
            writer.Write((short) Id);
            writer.Write(Version);
        }

        #endregion
    }
}
