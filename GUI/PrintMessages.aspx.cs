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
using SD.HnD.DAL.CollectionClasses;
using System.Globalization;
using SD.HnD.DAL.TypedListClasses;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Code behind class for Messages.aspx, which renders a page of messages in a given thread. 
	/// </summary>
	public partial class PrintMessages : System.Web.UI.Page
	{
		#region Class Member declarations
		private ThreadEntity	_thread;
		private bool			_showIPAddresses;
		#endregion


		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			int threadID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ThreadID"]);
			_thread = ThreadGuiHelper.GetThread(threadID);
			if(_thread == null)
			{
				// not found, return to start page
				Response.Redirect("default.aspx");
			}

			// Check credentials
			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				Response.Redirect("default.aspx");
			}

			// show user IP addresses if the user has system admin rights, security admin rights or user admin rights.
			_showIPAddresses = (SessionAdapter.HasSystemActionRight(ActionRights.SystemManagement) ||
										SessionAdapter.HasSystemActionRight(ActionRights.SecurityManagement) ||
										SessionAdapter.HasSystemActionRight(ActionRights.UserManagement));
			// Get the forum entity related to the thread. Use BL class. We could have used Lazy loading, though for the sake of separation, we'll 
			// call into the BL class. 
			ForumEntity forum = CacheManager.GetForum(_thread.ForumID);
			if(forum == null)
			{
				// not found, orphaned thread, return to default page.
				Response.Redirect("default.aspx");
			}

			// check if the user can view this thread. If not, don't continue.
			if((_thread.StartedByUserID != SessionAdapter.GetUserID()) &&
				!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
				!_thread.IsSticky)
			{
				// can't view this thread, it isn't visible to the user
				Response.Redirect("default.aspx", true);
			}

			lblForumName_Header.Text = forum.ForumName;
						
			if(!Page.IsPostBack)
			{
				//bool threadStartedByCurrentUser = (_thread.StartedByUserID == SessionAdapter.GetUserID());
				//// Get messages and bind it to the repeater control. Use the startmessage to get only the message visible on the current page. 
				//MessagesInThreadTypedList messages = ThreadGuiHelper.GetAllMessagesInThreadAsTypedList(threadID, 0, 0);
				//rptMessages.DataSource = messages;
				//rptMessages.DataBind();
			}			
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets the thread subject.
		/// </summary>
		/// <value>The thread subject.</value>
		protected string ThreadSubject
		{
			get 
			{
				if(_thread != null)
				{
					return _thread.Subject;
				}
				else
				{
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// Gets the thread ID.
		/// </summary>
		/// <value>The thread ID.</value>
		protected int ThreadID
		{
			get
			{
				if(_thread != null)
				{
					return _thread.ThreadID;
				}
				else
				{
					return 0;
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether IP addresses should be shown. Used by the HTML code
		/// </summary>
		protected bool ShowIPAddresses
		{
			get { return _showIPAddresses; }
		}
		#endregion

		private void Page_PreInit(object sender, EventArgs e)
		{
			// switch off theming as the EnableTheming option on the page level doesn't work 
			Page.Theme = "";
		} 
	}
}
