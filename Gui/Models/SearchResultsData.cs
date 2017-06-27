using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SD.HnD.DALAdapter.TypedListClasses;

namespace SD.HnD.Gui.Models
{
	public class SearchResultsData
	{
		/// <summary>
		/// The number of the current page
		/// </summary>
		public int PageNo { get; set; }
		/// <summary>
		/// The number of pages in the total results of the search.
		/// </summary>
		public int NumberOfPages { get; set; }
		/// <summary>
		/// The list of rows for the page to render. These are the rows on the page with no PageNo
		/// </summary>
		public List<SearchResultRow> PageRows { get; set; }
	}
}