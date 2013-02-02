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

namespace Sphinx.Client.Commands.FlushAttributes
{
	/// <summary>
	/// Represents <see cref="FlushAttributesCommand"/> results returned by server.
	/// </summary>
	public class FlushAttributesCommandResult : CommandResultBase
	{
		#region Fields
		private int _flushTag;
		
		#endregion

		#region Properties
		/// <summary>
		/// Contains a non-negative internal "flush tag" on success.
		/// Flush tag should be treated as an ever growing magic number that does not mean anything. It's guaranteed to be non-negative. It is guaranteed to grow over time, though not necessarily in a sequential fashion; for instance, two calls that return 10 and then 1000 respectively are a valid situation. If two calls to FlushAttrs() return the same tag, it means that there were no actual attribute updates in between them, and therefore current flushed state remained the same (for all indexes).
		/// </summary>
		public int FlushTag
		{
			get { return _flushTag; }
			protected set { _flushTag = value; }
		}

		#endregion

		#region Methods
		internal void Deserialize(IBinaryReader reader)
		{
			FlushTag = reader.ReadInt32();
			if (FlushTag < 0)
			{
				throw new SphinxException(String.Format(Messages.Exception_CouldNotFlushIndexAttributeValues, FlushTag));
			}
		}
 
		#endregion
	}
}