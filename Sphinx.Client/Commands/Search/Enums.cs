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
namespace Sphinx.Client.Commands.Search
{
    /// <summary>
    /// Search query words matching mode
    /// </summary>
    public enum MatchMode : int
    {
        /// <summary>
        /// Matches all query words (default mode)
        /// </summary>
        All = 0,

        /// <summary>
        /// Matches any of the query words
        /// </summary>
        Any = 1,

        /// <summary>
        /// Matches query as a phrase, requiring perfect match
        /// </summary>
        Phrase = 2,

        /// <summary>
        /// Matches query as a boolean expression
        /// </summary>
        Boolean = 3,

        /// <summary>
        /// Matches query as an expression in Sphinx internal query language (see Sphinx documentation section 4.3, "Extended query syntax"). 
        /// As of 0.9.9, this has been superceded by <see cref="MatchMode.Extended2"/>, providing additional functionality and better performance. The ident is retained for legacy application code that will continue to be compatible once Sphinx and its components, including the API, are upgraded.
        /// </summary>
        Extended = 4,

        /// <summary>
        /// Matches query, forcibly using the "full scan" mode as below. NB, any query terms will be ignored, such that filters, filter-ranges and grouping will still be applied, but no text-matching.
        /// </summary>
        Fullscan = 5,

        /// <summary>
        /// Matches query using the second version of the Extended matching mode.
        /// </summary>
        Extended2 = 6
    }

    /// <summary>
    /// Search results ranking mode (used with MatchMode.Extended2 only)
    /// </summary>
    public enum MatchRankMode : int
    {
        /// <summary>
        /// Default ranking mode which uses and combines both phrase proximity and BM25 ranking. 
        /// </summary>
        ProximityBM25 = 0,

        /// <summary>
        /// Statistical ranking mode which uses BM25 ranking only (similar to most other full-text engines). This mode is faster but may result in worse quality on queries which contain more than 1 keyword. 
        /// </summary>
        BM25 = 1,

        /// <summary>
        /// Disabled ranking mode. This mode is the fastest. It is essentially equivalent to boolean searching. A weight of 1 is assigned to all matches. 
        /// </summary>
        None = 2,

        /// <summary>
        /// Ranking by keyword occurrences count. This ranker computes the amount of per-field keyword occurrences, then multiplies the amounts by field weights, then sums the resulting values for the final result. 
        /// </summary>
        WordCount = 3,

        /// <summary>
        /// Returns raw phrase proximity value as a result. This mode is internally used to emulate <see cref="MatchMode.All"/> queries.
        /// </summary>
        Proximity = 4,

        /// <summary>
        /// Returns rank as it was computed in <see cref="MatchMode.Any"/> mode ealier, and is internally used to emulate <see cref="MatchMode.Any"/> queries. 
        /// </summary>
        Any = 5,

        /// <summary>
        /// Returns rank as 32-bit mask with N-th bit corresponding to N-th fulltext field, numbered from 0. The bit will only be set when the respective field has any keyword occurences satisfiying the query.
        /// </summary>
        FieldMask = 6,

		/// <summary>
		/// Added in version 1.10-beta, is generally based on the default ProximityBM25 ranker, but additionally boosts the matches when they occur in the very beginning or the very end of a text field. Thus, if a field equals the exact query, SPH04 should rank it higher than a field that contains the exact query but is not equal to it. (For instance, when the query is "Hyde Park", a document entitled "Hyde Park" should be ranked higher than a one entitled "Hyde Park, London" or "The Hyde Park Cafe".)
		/// </summary>
		Sph04 = 7
    }

    /// <summary>
    /// Search results sorting mode
    /// </summary>
    public enum ResultsSortMode : int
    {
        /// <summary>
        /// Sort results by relevance in descending order (best matches first)
        /// </summary>
        Relevance = 0,

        /// <summary>
        /// Sort results by an attribute in descending order (bigger attribute values first)
        /// </summary>
        AttributeDescending = 1,

        /// <summary>
        /// Sort results by an attribute in ascending order (smaller attribute values first)
        /// </summary>
        AttributeAscending = 2,

        /// <summary>
        /// Sort results by time segments (last hour/day/week/month) in descending order, and then by relevance in descending order
        /// </summary>
        TimeSegments = 3,

        /// <summary>
        /// Sort results by SQL-like sort expression, must contains attributes or internal attributes names with order direction specified by keyword (ASC/DESC)
        /// </summary>
        Extended = 4,

        /// <summary>
        /// Sort results by an arithmetic expression
        /// </summary>
        Expression = 5
    }

    /// <summary>
    /// Search results grouping function
    /// </summary>
    public enum ResultsGroupFunction : int
    {
		/// <summary>
		/// Extracts year, month and day in YYYYMMDD format from timestamp
		/// </summary>
        Day = 0,

		/// <summary>
		/// Extracts year and first day of the week number (counting from year start) in YYYYNNN format from timestamp
		/// </summary>
        Week = 1,

		/// <summary>
		/// Extracts month in YYYYMM format from timestamp
		/// </summary>
        Month = 2,

		/// <summary>
		/// Extracts year in YYYY format from timestamp
		/// </summary>
        Year = 3,

		/// <summary>
		/// Uses attribute value itself for grouping
		/// </summary>
        Attribute = 4

        //AttributePair = 5 not supported anymore by Sphinx
    }

    /// <summary>
    /// Attribute filter type
    /// </summary>
    public enum AttributeFilterType : int
    {
		/// <summary>
		/// filter by int64 values set
		/// </summary>
        ValuesInt64 = 0,

		/// <summary>
		/// filter by boolean values set
		/// </summary>
		ValuesBoolean = ValuesInt64,

		/// <summary>
		/// filter by DateTime values set
		/// </summary>
		ValuesTimestamp = ValuesInt64,

		/// <summary>
		/// filter by int32 values set
		/// </summary>
		ValuesInt32 = ValuesInt64,

		/// <summary>
		/// filter by int64 range
		/// </summary>
        RangeInt64 = 1,

		/// <summary>
		/// filter by int32 range
		/// </summary>
        RangeInt32 = 2,

		/// <summary>
		/// filter by float range
		/// </summary>
		RangeFloat = RangeInt32,

		/// <summary>
		/// filter by timestamp range
		/// </summary>
		RangeTimestamp = RangeInt64,
    }

	/// <summary>
	/// Document id size
	/// </summary>
	public enum IdSize : int
	{
		Int32 = 0,
		Int64 = 1
	}

	/// <summary>
	/// Specifies the search query status retured by <see cref="Search"/> command.
	/// </summary>
	public enum QueryStatus
	{
		Unknown = -1,
		Ok = 0,
		Error = 1,
		Warning = 3
	}
}
