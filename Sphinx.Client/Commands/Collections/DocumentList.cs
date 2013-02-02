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

namespace Sphinx.Client.Commands.Collections
{
	public class DocumentList : StringList
	{
        /// <summary>
        /// Serialize object to stream using specified binary writer.
        /// </summary>
        /// <param name="writer">Binary writer (output formatter) object</param>
		internal override void Serialize(IBinaryWriter writer)
        {
			// documents count & content
			writer.Write(Count);
			foreach (string content in this)
			{
				writer.Write(content);
			}
        }
	}
}
