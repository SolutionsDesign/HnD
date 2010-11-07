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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SD.HnD.BL;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Utility;
using System.Globalization;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind for the SupportQueues page.
	/// </summary>
	public partial class SupportQueues : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// check if the user has the right to be here
			bool userMayManageQueues = SessionAdapter.HasSystemActionRight(ActionRights.QueueContentManagement);
			if(!userMayManageQueues)
			{
				// doesn't have the right to manage queue contents. redirect
				Response.Redirect("default.aspx", true);
			}

			if(!Page.IsPostBack)
			{
				SupportQueueCollection supportQueues = CacheManager.GetAllSupportQueues();
				rpQueues.DataSource = supportQueues;
				rpQueues.DataBind();
			}
		}


		/// <summary>
		/// Handles the ItemDataBound event of the rptQueues control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
		protected void rpQueues_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					SupportQueueEntity currentSupportQueue = (SupportQueueEntity)e.Item.DataItem;

					// get the threads in the queue and bind it to the repeater. If there are no threads, show the placeholder and hide the repeater.
					DataView threadsInQueue = SupportQueueGuiHelper.GetAllThreadsInSupportQueueAsDataView(
							SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum), currentSupportQueue.QueueID);

					if(threadsInQueue.Count > 0)
					{
						// there is data, bind it to the repeater

						// Find repeater control in this item
						Repeater rpThreads = (Repeater)e.Item.FindControl("rpThreads");

						// bind it
						rpThreads.DataSource = threadsInQueue;
						rpThreads.DataBind();
					}
					else
					{
						// no data, show the placeholder
						PlaceHolder noDataText = (PlaceHolder)e.Item.FindControl("phNoDataText");
						noDataText.Visible = true;
					}
					break;
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
					if(((DataRowView)e.Item.DataItem)["ClaimedByUserID"] != DBNull.Value)
					{
						// thread is claimed by someone
						HyperLink lnkClaimerThread = (HyperLink)e.Item.FindControl("lnkClaimerThread");
						lnkClaimerThread.NavigateUrl += ((DataRowView)e.Item.DataItem)["ClaimedByUserID"].ToString();
						lnkClaimerThread.Text = HttpUtility.HtmlEncode((string)((DataRowView)e.Item.DataItem)["NickNameClaimedThread"]);
						Label lblClaimDate = (Label)e.Item.FindControl("lblClaimDate");
						lblClaimDate.Text = ((DateTime)((DataRowView)e.Item.DataItem)["ClaimedOn"]).ToString("dd-MMM-yyyy HH:mm.ss", DateTimeFormatInfo.InvariantInfo);
					}
					break;
			}
		}


		/// <summary>
		/// Handles the ItemCommand event of the rpThreads control.
		/// </summary>
		/// <param name="source">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterCommandEventArgs"/> instance containing the event data.</param>
		protected void rpThreads_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			switch(e.CommandName)
			{
				case "ReleaseClaim":
					// release a claim on the thread.
					SupportQueueManager.ReleaseClaimOnThread(HnDGeneralUtils.TryConvertToInt((string)e.CommandArgument));
					// done, refresh
					Response.Redirect("SupportQueues.aspx", true);
					break;
				case "Claim":
					// claim the thread specified for the current user
					SupportQueueManager.ClaimThread(SessionAdapter.GetUserID(), HnDGeneralUtils.TryConvertToInt((string)e.CommandArgument));

					// done, refresh
					Response.Redirect("SupportQueues.aspx", true);
					break;
			}
		}
	}
}
