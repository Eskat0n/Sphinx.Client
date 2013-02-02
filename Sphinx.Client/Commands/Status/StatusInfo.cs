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

using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Status
{
    /// <summary>
    /// Represents a row of Sphinx server status information data
    /// </summary>
    public class StatusInfo
    {
		#region Fields
		private string _name;
		private string _value;
		
		#endregion

		#region Properties
		/// <summary>
        /// Sphinx server status variable name
        /// </summary>
        public string Name
    	{
    		get { return _name; }
    		private set { _name = value; }
    	}

    	/// <summary>
        /// Sphinx server status variable value
        /// </summary>
        public string Value
    	{
    		get { return _value; }
    		private set { _value = value; }
    	}

    	#endregion

        #region Methods
        internal void Deserialize(IBinaryReader reader, int count)
        {
            for (int i=0; i < count; i++)
            {
                // NOTE: currently only 2 columns in status report are supported (this value is hardcoded in Sphinx server source code)
                string s = reader.ReadString();
                switch (i)
                {
                    case 0:
                        Name = s;
                        continue;
                    case 1:
                        Value = s;
                        continue;
                }
            }
        }

        #endregion
    }
}
