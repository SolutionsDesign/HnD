using System.Collections.Generic;
using SD.HnD.DALAdapter.TypedListClasses;

namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Wrapper class to store search terms + results as one object in the cache. 
	/// </summary>
	public class SearchResultsWrapper
	{
		public string SearchTerms { get; set; } = string.Empty;
		public List<SearchResultRow> SearchResults { get; set; } = null;
	}
}