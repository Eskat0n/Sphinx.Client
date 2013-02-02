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
using Sphinx.Client.Common;
using Sphinx.Client.IO;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.Commands.UpdateAttributes
{
    /// <summary>
    /// Represents <see cref="UpdateAttributesCommand"/> results returned by server.
    /// </summary>
    public class UpdateAttributesCommandResult : CommandResultBase
    {
		#region Fields
		private int _documentsUpdated;
		
		#endregion

        #region Properties
		/// <summary>
        /// The number of documents updated by <see cref="UpdateAttributesCommand"/> command.
        /// </summary>
        public int DocumentsUpdated
    	{
    		get { return _documentsUpdated; }
    		set { _documentsUpdated = value; }
    	}

    	#endregion

        #region Methods
		internal void Deserialize(IBinaryReader reader)
        {
            DocumentsUpdated = reader.ReadInt32();
            if (DocumentsUpdated == -1)
                throw new SphinxException(String.Format(Messages.Exception_CouldNotUpdateIndexAttributeValues, DocumentsUpdated));
        }
 
	    #endregion
    }
}
