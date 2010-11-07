/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using SD.HnD.BL;

using SD.HnD.DAL.TypedListClasses;
using SD.HnD.Utility;

namespace SD.HnD.GUI
{
	/// <summary>
	/// the code here has to grab the querystring values, then setup the session and perform the search. It then
	/// redirects to the search display page.
	/// </summary>
	public partial class SearchUnAttended : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// clear tmp results in session
            SessionAdapter.AddSearchTermsAndResults(string.Empty, null);
			// Read all accessable forums for the current user.			
            List<int> accessableForums = SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum);
            
			string[] forumIDs = Request.QueryString.GetValues("ForumID");
			List<int> forumIDsToSearchIn = new List<int>();
			if(forumIDs!=null)
			{
				foreach(string forumIDAsString in forumIDs)
				{
					int forumID = HnDGeneralUtils.TryConvertToInt(forumIDAsString);
					if(accessableForums.Contains(forumID))
					{
						forumIDsToSearchIn.Add(forumID);
					}
				}
			}
			else
			{
				// add all forums the user has access to
				forumIDsToSearchIn.AddRange(accessableForums);
			}

			string searchTerms = Request.QueryString.Get("SearchTerms");
			if(searchTerms.Length > 1024)
			{
				searchTerms = searchTerms.Substring(0, 1024);
			}
			SearchResultTypedList results = BL.Searcher.DoSearch(searchTerms, forumIDsToSearchIn, SearchResultsOrderSetting.ForumAscending,
				SearchResultsOrderSetting.LastPostDateDescending, SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), 
				SessionAdapter.GetUserID(), SearchTarget.MessageText);
			// store results in session.
            SessionAdapter.AddSearchTermsAndResults(searchTerms, results);
			// view results.
			Response.Redirect("SearchResults.aspx?Page=1", true);
		}


		private void Page_PreInit(object sender, EventArgs e)
		{
			// switch off theming as the EnableTheming option on the page level doesn't work due to a bug in ASP.NET 2.0
			Page.Theme = "";
		} 
	}
}
