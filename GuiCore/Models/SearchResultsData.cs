/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Linq;
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
		/// <summary>
		/// The total number of rows in the search result
		/// </summary>
		public int NumberOfResultRows { get; set; }
		public string SearchParameters { get; set; }
	}
}