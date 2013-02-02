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
using System.Runtime.Serialization;

#endregion

namespace Sphinx.Client.Common
{
	/// <summary>
	/// Base exception class for Sphinx errors
	/// </summary>
	[Serializable]
	public class SphinxException : Exception
	{
		public SphinxException()
		{
		}

		public SphinxException(string message) : base(message)
		{
		}

		public SphinxException(string message, Exception innerEx): base(message, innerEx)
		{
		}

		protected SphinxException(SerializationInfo info, StreamingContext context): base(info, context)
		{
		}
	}

	/// <summary>
	/// The exception that is thrown when the Sphinx service cannot fulfill a request.
	/// </summary>
	[Serializable]
	public class ServerErrorException : SphinxException
	{
		public ServerErrorException()
		{
		}

		public ServerErrorException(string message): base(message)
		{
		}

		public ServerErrorException(string message, Exception innerEx): base(message, innerEx)
		{
		}

		protected ServerErrorException(SerializationInfo info, StreamingContext context): base(info, context)
		{
		}
	}

	/// <summary>
	/// The exception that is thrown when the Sphinx service cannot fulfill a search request.
	/// </summary>
	[Serializable]
	public class QueryErrorException : SphinxException
	{
		public QueryErrorException()
		{
		}

		public QueryErrorException(string message): base(message)
		{
		}

		public QueryErrorException(string message, Exception innerEx): base(message, innerEx)
		{
		}

		protected QueryErrorException(SerializationInfo info, StreamingContext context): base(info, context)
		{
		}
	}

}
