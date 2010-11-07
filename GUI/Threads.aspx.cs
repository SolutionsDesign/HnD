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
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Text;

using SD.HnD.BL;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Utility;

namespace SD.HnD.GUI
{
	/// <summary>
	/// The code behind class for the Threads.aspx webform which enlists all threads in a given forum.
	/// </summary>
	public partial class Threads : System.Web.UI.Page
	{
		#region Class Member Declarations
		private string _forumName;
		#endregion

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			int	forumID=HnDGeneralUtils.TryConvertToInt(Request.QueryString["ForumID"]);

			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(forumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				Response.Redirect("default.aspx");
			}
			
			bool userCanCreateThreads = (SessionAdapter.CanPerformForumActionRight(forumID, ActionRights.AddNormalThread) ||
										SessionAdapter.CanPerformForumActionRight(forumID, ActionRights.AddStickyThread));
			
			// Controls are visible by default. Hide them when the user can't create threads on this forum
			if(!userCanCreateThreads)
			{
				lnkNewThreadBottom.Visible=false;
				lnkNewThreadTop.Visible=false;
			}
			
			// fill the page's content
			ForumEntity forum = CacheManager.GetForum(forumID);
			if(forum==null)
			{
				// not found.
				Response.Redirect("default.aspx");
			}
			_forumName = forum.ForumName;

			if(!Page.IsPostBack)
			{
				cbxThreadListInterval.SelectedValue = forum.DefaultThreadListInterval.ToString();

				string forumNameEncoded = HttpUtility.HtmlEncode(_forumName);
				lblForumName.Text = forumNameEncoded;
				lblForumName_Header.Text = HttpUtility.HtmlEncode(_forumName);
				lblForumDescription.Text = HttpUtility.HtmlEncode(forum.ForumDescription);
				lblSectionName.Text = CacheManager.GetSectionName(forum.SectionID);

				string newThreadURL = string.Format("{0}?ForumID={1}", lnkNewThreadTop.NavigateUrl, forumID);
				lnkNewThreadTop.NavigateUrl = newThreadURL;
				lnkNewThreadBottom.NavigateUrl = newThreadURL;
				if(forum.HasRSSFeed)
				{
					lnkForumRSS.NavigateUrl += string.Format("?ForumID={0}", forumID);
				}
				else
				{
					lnkForumRSS.Visible=false;
					litRssButtonSpacer.Visible=false;
				}
			}
			
			SystemDataEntity systemData = CacheManager.GetSystemData();
			int postLimiter = HnDGeneralUtils.TryConvertToInt(cbxThreadListInterval.SelectedValue);
			DataView threadsView = ForumGuiHelper.GetAllThreadsInForumAsDataView(forumID, (ThreadListInterval)(byte)postLimiter,
					systemData.MinNumberOfThreadsToFetch, systemData.MinNumberOfNonStickyVisibleThreads,
					SessionAdapter.CanPerformForumActionRight(forumID, ActionRights.ViewNormalThreadsStartedByOthers), 
					SessionAdapter.GetUserID());
			
			rpThreads.DataSource = threadsView;
			rpThreads.DataBind();
			threadsView.Dispose();
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
			this.rpThreads.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rpThreads_ItemDataBound);
			this.cbxThreadListInterval.SelectedIndexChanged += new System.EventHandler(this.cbxThreadListInterval_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected void cbxThreadListInterval_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Empty routine, the postback will re-fill the threadlist.
		}

		
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

                    if (threadLastPostingDate > lastVisitDate)
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
					imgIconPosts.Visible=true;
					break;
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the name of the forum.
		/// </summary>
		/// <value>The name of the forum.</value>
		protected string ForumName
		{
			get { return _forumName; }
		}
		#endregion
	}
}
