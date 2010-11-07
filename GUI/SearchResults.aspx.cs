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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SD.HnD.BL;
using SD.HnD.Utility;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind file for the SearchResults form
	/// </summary>
	public partial class SearchResults : System.Web.UI.Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			int currentPage = HnDGeneralUtils.TryConvertToInt(Request["Page"]);
			if(currentPage == 0)
			{
				currentPage = 1;
			}

			if(!Page.IsPostBack)
			{
				plPageListTop.CurrentPage = currentPage;
				plPageListBottom.CurrentPage = currentPage;

				DataTable results = SessionAdapter.GetSearchResults();
				if(results==null)
				{
					// no results, redirect to search page
					Response.Redirect("Search.aspx");
				}

				short pageSize = CacheManager.GetSystemData().PageSizeSearchResults;
				if(pageSize <= 0)
				{
					pageSize = 50;
				}
				
				int amountPages = (results.Rows.Count/pageSize);
				if((amountPages*pageSize)<results.Rows.Count)
				{
					amountPages++;
				}
				plPageListBottom.AmountPages=amountPages;
				plPageListTop.AmountPages = amountPages;

				// get the page of the resultset to bind. We page in-memory, so we have to execute the search query just once. 
				DataTable toBind = results.Clone();
				for (int i = 0;
					(i < pageSize) && ((((currentPage - 1) * pageSize) + i) < results.Rows.Count); 
					i++)
				{
					toBind.ImportRow(results.Rows[((currentPage - 1) * pageSize) + i]);
				}

				rptResults.DataSource = toBind;
				rptResults.DataBind();

				lblAmountThreads.Text = results.Rows.Count.ToString();
				lblSearchTerms.Text = HttpUtility.HtmlEncode(SessionAdapter.GetSearchTerms());
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
			this.Load += new System.EventHandler(this.Page_Load);
			rptResults.ItemDataBound +=new RepeaterItemEventHandler(rptResults_ItemDataBound);
		}
		#endregion

		/// <summary>
		/// Event handler which will be called every time a row in the Repeater rpResults is bound to a row in the view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rptResults_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					HyperLink lnkThread = (HyperLink)e.Item.FindControl("lnkThread");
					string threadSubject = ((DataRowView)e.Item.DataItem)["Subject"].ToString();
					if(threadSubject.Length>50)
					{
						threadSubject=threadSubject.Substring(0, 50) + "...";
					}
					lnkThread.Text = threadSubject;
					break;
			}
		}

	}
}
