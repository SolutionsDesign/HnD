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
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Utility;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind of the MyThreads viewer form.
	/// </summary>
	public partial class MyThreads : System.Web.UI.Page
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			int callingUserID = SessionAdapter.GetUserID();
			if(callingUserID == 0)
			{
				// anonymous, redirect
				Response.Redirect("default.aspx", true);
			}

			if(!Page.IsPostBack)
			{
				int rowCount = 0;
				int currentPage = HnDGeneralUtils.TryConvertToInt(Request["Page"]);
				if(currentPage == 0)
				{
					currentPage = 1;
					// reset # of rows in the session.
					rowCount = 0;
				}
				else
				{
					rowCount = SessionAdapter.GetTempResult<int>("MyThreadsRowCount");
				}

				// check if the rowCount is valid
				if(rowCount <= 0)
				{
					// reload rowCount
					rowCount = UserGuiHelper.GetRowCountLastThreadsForUserAsDataView(SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum),
						callingUserID, SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
						callingUserID);
					SessionAdapter.SetTempResult("MyThreadsRowCount", rowCount);
				}

				short pageSize = CacheManager.GetSystemData().PageSizeSearchResults;
				if(pageSize <= 0)
				{
					pageSize = 50;
				}

				int rowCountCapped = rowCount;
				if(rowCount > 500)
				{
					// maximum is 500
					rowCountCapped = 500;
					lblCappingWarning.Visible = true;
				}
				int amountPages = (rowCountCapped / pageSize);
				if((amountPages * pageSize) < rowCountCapped)
				{
					amountPages++;
				}

				plPageListBottom.AmountPages = amountPages;
				plPageListBottom.CurrentPage = currentPage;
				plPageListTop.AmountPages = amountPages;
				plPageListTop.CurrentPage = currentPage;
				lblAmountThreads.Text = rowCount.ToString();

				DataView lastThreads = UserGuiHelper.GetLastThreadsForUserAsDataView(SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum),
						callingUserID, SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers),
						callingUserID, pageSize, currentPage);
				rpThreads.DataSource = lastThreads;
				rpThreads.DataBind();
			}
		}


		/// <summary>
		/// Event handler which will be called every time a row in the Repeater rpThreads is bound to a row in the view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rpThreads_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			int maxAmountMessagesPerPage = SessionAdapter.GetUserDefaultNumberOfMessagesPerPage();

			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					// Thread has always a last posting date: a thread has at least 1 posting.
					DateTime threadLastPostingDate = (DateTime)(((DataRowView)e.Item.DataItem)["ThreadLastPostingDate"]);
					DateTime lastVisitDate = SessionAdapter.GetLastVisitDate();
					bool isSticky = (bool)(((DataRowView)e.Item.DataItem)["IsSticky"]);
					bool isClosed = (bool)(((DataRowView)e.Item.DataItem)["IsClosed"]);

					// date is not 0, check if the date is > than the date in the session variable. If so, the posting is newer and we
					// should visualize the New Messages image, otherwise the No new Messages image. Also take into account
					// the type of the thread: sticky, closed or normal.
					System.Web.UI.WebControls.Image imgIconPosts;

					if(threadLastPostingDate > lastVisitDate)
					{
						// there are new messages since last visit
						if(isSticky)
						{
							imgIconPosts = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNewPostsSticky");
						}
						else
						{
							if(isClosed)
							{
								imgIconPosts = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNewPostsClosed");
							}
							else
							{
								// is normal
								imgIconPosts = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNewPosts");
							}
						}
					}
					else
					{
						// no new messages
						if(isSticky)
						{
							imgIconPosts = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNoNewPostsSticky");
						}
						else
						{
							if(isClosed)
							{
								imgIconPosts = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNoNewPostsClosed");
							}
							else
							{
								// is normal
								imgIconPosts = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNoNewPosts");
							}
						}
					}
					imgIconPosts.Visible = true;
					break;
			}
		}
	}
}
