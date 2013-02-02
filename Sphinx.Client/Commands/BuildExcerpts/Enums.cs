using System;
using System.Collections.Generic;
using System.Text;

namespace Sphinx.Client.Commands.BuildExcerpts
{
	[Flags]
	public enum BuildExcerptsOptions : int
	{
		None = 0,

		/// <summary>
		/// Remove unneeded spaces
		/// </summary>
		RemoveSpaces = 1,

		/// <summary>
		/// Whether to highlight exact query phrase matches only instead of individual keywords
		/// </summary>
		HighlightExactPhrase = 2,

		/// <summary>
		/// Whether to extract single best passage only
		/// </summary>
		ExtractOnlyBestPassage = 4,

		/// <summary>
		/// Extract passages by phrase boundaries setup in tokenizer
		/// </summary>
		UseBoundaries = 8,

		/// <summary>
		/// If flag is set, sort the extracted passages in order of relevance (decreasing weight), or in order of appearance in the document (increasing position) otherwise
		/// </summary>
		OrderByWeight = 16,

		/// <summary>
		/// Added in Sphinx 1.10-beta. Whether to handle keywords in list as a query in <a href="http://sphinxsearch.com/docs/current.html#extended-syntax">extended syntax</a>, or as a bag of words (default behavior). For instance, in query mode ("one two" | "three four") will only highlight and include those occurrences "one two" or "three four" when the two words from each pair are adjacent to each other. In default mode, any single occurrence of "one", "two", "three", or "four" would be highlighted.
		/// </summary>
		QueryMode = 32,

		/// <summary>
		/// Added in version 1.10-beta. Ignores the snippet length limit until it includes all the keywords.
		/// </summary>
		ForceAllWords = 64,

		/// <summary>
		/// Added in version 1.10-beta. Whether to handle documents in list as data to extract snippets from (default behavior), or to treat it as file names, and load data from specified files on the server side. 
		/// </summary>
		LoadFiles = 128,

		/// <summary>
		/// Added in version 1.10-beta. Allows empty string to be returned as highlighting result when a snippet could not be generated (no keywords match, or no passages fit the limit). By default, the beginning of original text would be returned instead of an empty string.
		/// </summary>
		AllowEmpty = 256,

		/// <summary>
		/// Added in version 2.0.1-beta. Emits an HTML tag with an enclosing zone name before each passage.
		/// </summary>
		EmitZones = 512
	}

	/// <summary>
	/// HTML stripping modes for <see cref="BuildExcerptsCommand"/> command.
	/// </summary>
	public enum HtmlStripMode
	{
		/// <summary>
		/// Skip stripping HTML irregardless of index settings
		/// </summary>		
 		None,

		/// <summary>
		/// Forcibly apply stripping HTML irregardless of index settings
		/// </summary>		
		Strip,

		/// <summary>
		/// Index settings will be used
		/// </summary>
		Index,

		/// <summary>
		/// Retains HTML markup and protects it from highlighting. The "retain" mode can only be used when highlighting full documents and thus requires that no snippet size limits are set.
		/// </summary>
		Retain
	}

	/// <summary>
	/// The passage boundary option values for <see cref="BuildExcerptsCommand"/> command.
	/// Ensures that passages do not cross a sentence, paragraph, or zone boundary (when used with an index that has the respective indexing settings enabled).
	/// Added in version 2.0.1-beta.
	/// </summary>
	public enum PassageBoundary
	{
		None,
		Sentence,
		Paragraph,
		Zone
	}
}
