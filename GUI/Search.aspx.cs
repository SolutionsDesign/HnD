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
using SD.HnD.BL;

using SD.HnD.DAL.TypedListClasses;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind of the search form
	/// </summary>
	public partial class Search : System.Web.UI.Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			// this is necessary so the 'clever' IE will also understand what to do: the enter key will then submit the form.
			this.ClientScript.RegisterHiddenField("__EVENTTARGET", "btnSearch"); 

			if(!Page.IsPostBack)
			{
				// clear tmp results in session
                SessionAdapter.AddSearchTermsAndResults(string.Empty, null);

				// Read all the current existing forums and their section names. 
				ForumsWithSectionNameTypedList forumsWithSectionName = ForumGuiHelper.GetAllForumsWithSectionNames();
				
                // Get a list of Forum IDs to which the user has access right.
                List<int> accessableForums = SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum);

				foreach(ForumsWithSectionNameRow currentRow in forumsWithSectionName)
				{
					// filter out forums the user doesn't have access rights for.
					if(accessableForums.Contains(currentRow.ForumID))
					{
						// forum is accessable to the user
						ListItem newItem = new ListItem(String.Format("{0} - {1}", currentRow.SectionName, currentRow.ForumName), currentRow.ForumID.ToString());
						newItem.Selected=true;
						lbxForums.Items.Add(newItem);
					}
				}

				// make listbox as high as # of forums, with a maximum of 15 and a minimum of 8
				if(lbxForums.Items.Count <= 15)
				{
					if(lbxForums.Items.Count > 8)
					{
						lbxForums.Rows = lbxForums.Items.Count;
					}
					else
					{
						lbxForums.Rows = 8;
					}
				}
				else
				{
					lbxForums.Rows = 15;
				}

				lblNumberOfPosts.Text = MessageGuiHelper.GetTotalNumberOfMessages().ToString();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSearch.ServerClick += new System.EventHandler(this.btnSearch_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_ServerClick(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				// grab forum id's
				List<int> forumIDs = new List<int>();
				for (int i = 0; i < lbxForums.Items.Count; i++)
				{
					if(lbxForums.Items[i].Selected)
					{
						forumIDs.Add(Convert.ToInt32(lbxForums.Items[i].Value));
					}
				}

				if(forumIDs.Count<=0)
				{
					// no forums selected, add all of them
					for (int i = 0; i < lbxForums.Items.Count; i++)
					{
						forumIDs.Add(Convert.ToInt32(lbxForums.Items[i].Value));
					}
				}

				SearchResultsOrderSetting orderFirstElement = (SearchResultsOrderSetting)cbxSortByFirstElement.SelectedIndex;
				SearchResultsOrderSetting orderSecondElement = (SearchResultsOrderSetting)cbxSortBySecondElement.SelectedIndex;

				SearchTarget targetToSearch = (SearchTarget)cbxElementToSearch.SelectedIndex;

				string searchTerms = tbxSearchString.Value;
				if(searchTerms.Length>1024)
				{
					searchTerms = searchTerms.Substring(0, 1024);
				}

				// Use Full text search variant. 
				SearchResultTypedList results = BL.Searcher.DoSearch(searchTerms, forumIDs, orderFirstElement, orderSecondElement, 
						SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), SessionAdapter.GetUserID(), targetToSearch);
				
				// store results in session.
                SessionAdapter.AddSearchTermsAndResults(searchTerms, results);
				// view results.
				Response.Redirect("SearchResults.aspx?Page=1", true);
			}
		}
	}
}
