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
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SD.HnD.BL;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Form which views all active threads. An active thread is a thread which isn't marked done.
	/// </summary>
	public partial class ActiveThreads : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// fill the page's content
            List<int> accessableForums = SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum);
			DataView activeThreads = ThreadGuiHelper.GetActiveThreadsAsDataView(accessableForums, CacheManager.GetSystemData().HoursThresholdForActiveThreads,
						SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), SessionAdapter.GetUserID());
			rpThreads.DataSource = activeThreads;
			rpThreads.DataBind();
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
			this.rpThreads.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rpThreads_ItemDataBound);
		}
		#endregion


		/// <summary>
		/// Event handler which will be called every time a row in the Repeater rpThreads is bound to a row in the view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rpThreads_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
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
