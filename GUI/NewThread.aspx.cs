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
using SD.HnD.DAL.EntityClasses;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind file for the NewThread form.
	/// </summary>
	public partial class NewThread : System.Web.UI.Page
	{
		#region Class Member Declarations
		private ForumEntity _forum;
		private bool _userCanCreateNormalThreads, _userCanCreateStickyThreads;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			int forumID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ForumID"]);
			_forum = CacheManager.GetForum(forumID);
			if(_forum == null)
			{
				// not found
				Response.Redirect("default.aspx", true);
			}

			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(forumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				Response.Redirect("default.aspx", true);
			}

			_userCanCreateNormalThreads = SessionAdapter.CanPerformForumActionRight(forumID, ActionRights.AddNormalThread);
			_userCanCreateStickyThreads = SessionAdapter.CanPerformForumActionRight(forumID, ActionRights.AddStickyThread);

			if(!(_userCanCreateNormalThreads || _userCanCreateStickyThreads))
			{
				// doesn't have the right to add new threads to this forum. redirect
				Response.Redirect("default.aspx", true);
			}

			meMessageEditor.ShowAddAttachment = ((_forum.MaxNoOfAttachmentsPerMessage > 0) &&
														SessionAdapter.CanPerformForumActionRight(forumID, ActionRights.AddAttachment));

			if(!String.IsNullOrEmpty(_forum.NewThreadWelcomeTextAsHTML)) 
			{
				phWelcomeText.Visible = true;
				litWelcomeText.Text = _forum.NewThreadWelcomeTextAsHTML;
			}

			if(!Page.IsPostBack)
			{
				// fill the page's content
				lnkThreads.Text = HttpUtility.HtmlEncode(_forum.ForumName);
				lnkThreads.NavigateUrl += "?ForumID=" + forumID;
				meMessageEditor.ForumName = _forum.ForumName;
				meMessageEditor.ForumDescription = HttpUtility.HtmlEncode(_forum.ForumDescription);
				meMessageEditor.CanBeSticky = _userCanCreateStickyThreads;
				meMessageEditor.CanBeNormal = _userCanCreateNormalThreads;
				meMessageEditor.IsThreadStart = true;
				lblSectionName.Text = CacheManager.GetSectionName(_forum.SectionID);
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

		}
		#endregion

		protected void PostMessageHandler(object sender, System.EventArgs e)
		{
            int userID = SessionAdapter.GetUserID();
			int messageID = 0;
			// store the new message as a new thread in the current forum.
			bool isSticky = meMessageEditor.IsSticky;
			if(!_userCanCreateNormalThreads && _userCanCreateStickyThreads)
			{
				// always sticky
				isSticky = true;
			}
            int threadID = ForumManager.CreateNewThreadInForum(_forum.ForumID, userID, meMessageEditor.NewThreadSubject, 
											meMessageEditor.MessageText, meMessageEditor.MessageTextHTML, isSticky, 
											Request.UserHostAddress.ToString(), _forum.DefaultSupportQueueID, meMessageEditor.SubscribeToThread, out messageID);	

			// invalidate forum RSS in cache
			ApplicationAdapter.InvalidateCachedForumRSS(_forum.ForumID);

            if (SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditNewThread))
			{
                SecurityManager.AuditNewThread(userID, threadID);
			}

			// invalidate Forum in ASP.NET cache
			CacheManager.InvalidateCachedItem(CacheManager.ProduceCacheKey(CacheKeys.SingleForum, _forum.ForumID));

			if(meMessageEditor.AddAttachment)
			{
				// go to attachment management. 
				Response.Redirect(string.Format("Attachments.aspx?SourceType=2&MessageID={0}", messageID), true);
			}
			else
			{
				// all ok, redirect to thread list
				Response.Redirect("Threads.aspx?ForumID=" + _forum.ForumID, true);
			}
		}

		protected void CancelActionHandler(object sender, System.EventArgs e)
		{
			Response.Redirect("Threads.aspx?ForumID=" + _forum.ForumID, true);
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the name of the forum.
		/// </summary>
		/// <value>The name of the forum.</value>
		protected string ForumName
		{
			get
			{
				string toReturn = string.Empty;
				if(_forum != null)
				{
					toReturn = _forum.ForumName;
				}
				return toReturn;
			}
		}
		#endregion
	}
}
