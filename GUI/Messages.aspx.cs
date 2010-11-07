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
	public partial class Messages : System.Web.UI.Page
	{
		#region Class Member declarations
		private int				_startMessageNo;
		private ThreadEntity	_thread;
		private bool			_showEditMessageLink, _showDeleteMessageLink, _showQuoteMessageLink, _showIPAddresses, _forumAllowsAttachments,
								_userMayAddAttachments, _userCanCreateThreads, _userMayDoForumSpecificThreadManagement, _userMayDoSystemWideThreadManagement,
								_userMayEditMemo, _userMayMarkThreadAsDone, _userMayManageSupportQueueContents, _threadStartedByCurrentUser, _userMayAddNewMessages, 
								_userMayDoBasicThreadOperations;
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

			_startMessageNo = HnDGeneralUtils.TryConvertToInt(Request.QueryString["StartAtMessage"]);
			bool highLightSearchResults = (HnDGeneralUtils.TryConvertToInt(Request.QueryString["HighLight"]) == 1);

			if(!_thread.IsClosed)
			{
				if(_thread.IsSticky)
				{
					_userMayAddNewMessages = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAndEditMessageInSticky);
				}
				else
				{
					_userMayAddNewMessages = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAndEditMessage);
				}
				// set show*link class members. These have to be set despite the postback status, as they're used in the repeater. Only set
				// them to true if the thread isn't closed. They've been initialized to false already. 
				_showEditMessageLink = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.EditDeleteOtherUsersMessages);
				_showDeleteMessageLink = _showEditMessageLink;
				_showQuoteMessageLink = _userMayAddNewMessages;
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
			_forumAllowsAttachments = (forum.MaxNoOfAttachmentsPerMessage > 0);

			// check if the user can view this thread. If not, don't continue.
			if((_thread.StartedByUserID != SessionAdapter.GetUserID()) &&
				!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers) &&
				!_thread.IsSticky)
			{
				// can't view this thread, it isn't visible to the user
				Response.Redirect("default.aspx", true);
			}

			_threadStartedByCurrentUser = (_thread.StartedByUserID == SessionAdapter.GetUserID());
			_userMayAddAttachments = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAttachment);
			_userCanCreateThreads = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddNormalThread) ||
													SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddStickyThread);
			_userMayDoForumSpecificThreadManagement = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ForumSpecificThreadManagement);
			_userMayDoSystemWideThreadManagement = SessionAdapter.HasSystemActionRight(ActionRights.SystemWideThreadManagement);
			_userMayEditMemo = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.EditThreadMemo);
			_userMayMarkThreadAsDone = (SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.FlagThreadAsDone) || _threadStartedByCurrentUser);
			_userMayManageSupportQueueContents = SessionAdapter.HasSystemActionRight(ActionRights.QueueContentManagement);
			_userMayDoBasicThreadOperations = (SessionAdapter.GetUserID() > 0);

			if(!Page.IsPostBack)
			{
				plPageListBottom.HighLight = highLightSearchResults;
				plPageListTop.HighLight = highLightSearchResults;
				litHighLightLogic.Visible = highLightSearchResults;

				if(highLightSearchResults)
				{
					// make highlighting of search results possible
					string searchTerms = SessionAdapter.GetSearchTerms();
					if(searchTerms == null)
					{
						searchTerms = string.Empty;
					}
					this.ClientScript.RegisterHiddenField("searchTerms", searchTerms.Replace("AND", "").Replace("OR", "").Replace("and", "").Replace("or", "").Replace("\"", ""));
				}
				else
				{
					// replace hightlighting scriptblock.
					this.ClientScript.RegisterClientScriptBlock(this.GetType(), "onLoad", "<script language=\"javascript\"  type=\"text/javascript\">function SearchHighlight() {}</script>");
				}

				if(_userMayManageSupportQueueContents)
				{
					// fill support queue management area with data.
					SupportQueueCollection supportQueues = CacheManager.GetAllSupportQueues();
					cbxSupportQueues.DataSource = supportQueues;
					cbxSupportQueues.DataBind();

					SupportQueueEntity containingQueue = SupportQueueGuiHelper.GetQueueOfThread(_thread.ThreadID);
					if(containingQueue != null)
					{
						cbxSupportQueues.SelectedValue = containingQueue.QueueID.ToString();
						// get claim info
						SupportQueueThreadEntity supportQueueThreadInfo = SupportQueueGuiHelper.GetSupportQueueThreadInfo(_thread.ThreadID, true);
						if((supportQueueThreadInfo != null) && supportQueueThreadInfo.ClaimedByUserID.HasValue)
						{
							// claimed by someone
							lblClaimDate.Text = supportQueueThreadInfo.ClaimedOn.Value.ToString("dd-MMM-yyyy HH:mm.ss", DateTimeFormatInfo.InvariantInfo);
							lnkClaimerThread.Visible = true;
							lblNotClaimed.Visible = false;
							lnkClaimerThread.Text = supportQueueThreadInfo.ClaimedByUser.NickName;
							lnkClaimerThread.NavigateUrl += supportQueueThreadInfo.ClaimedByUserID.ToString();
							btnClaim.Visible = false;
							btnRelease.Visible = true;
						}
						else
						{
							// not claimed
							lblClaimDate.Text = string.Empty;
							btnClaim.Visible = true;
							btnRelease.Visible = false;
						}
					}
				}
				phSupportQueueManagement.Visible = _userMayManageSupportQueueContents;

				if((_thread.Memo.Length > 0) && _userMayEditMemo)
				{
					// convert memo contents to HTML so it's displayed above the thread. 
					string parserLog, messageTextXml;
					bool errorsOccured = false;
					string memoAsHTML = TextParser.TransformUBBMessageStringToHTML(_thread.Memo, ApplicationAdapter.GetParserData(), out parserLog, out errorsOccured, out messageTextXml);
					lblMemo.Text = memoAsHTML;
				}
				phMemo.Visible = _userMayEditMemo;

				bool isBookmarked = UserGuiHelper.CheckIfThreadIsAlreadyBookmarked(SessionAdapter.GetUserID(), threadID);
				bool isSubscribed = UserGuiHelper.CheckIfThreadIsAlreadySubscribed(SessionAdapter.GetUserID(), threadID);
				btnBookmarkThread.Visible = !isBookmarked && _userMayDoBasicThreadOperations;
				btnUnbookmarkThread.Visible = isBookmarked && _userMayDoBasicThreadOperations;
				bool sendReplyNotifications = CacheManager.GetSystemData().SendReplyNotifications;
				btnSubscribeToThread.Visible = !isSubscribed && _userMayDoBasicThreadOperations && sendReplyNotifications;
				btnUnsubscribeFromThread.Visible = isSubscribed && _userMayDoBasicThreadOperations && sendReplyNotifications;
								
				// fill the page's content
				lnkThreads.Text = HttpUtility.HtmlEncode(forum.ForumName);
				lnkThreads.NavigateUrl += "?ForumID=" + _thread.ForumID;
				lblForumName_Header.Text = forum.ForumName;
				lblSectionName.Text = CacheManager.GetSectionName(forum.SectionID);
				
				// Check if the current user is allowed to add new messages to the thread.
				
				// these controls are not visible by default, show them if necessary
				if(_userMayDoForumSpecificThreadManagement || _userMayDoSystemWideThreadManagement)
				{
					if(!_thread.IsClosed && _userMayAddNewMessages)
					{
						lnkCloseThread.Visible=true;
						lnkCloseThread.NavigateUrl+="?ThreadID=" + threadID + "&StartAtMessage=" + _startMessageNo;
					}
					lnkEditThreadProperties.Visible=true;
					lnkEditThreadProperties.NavigateUrl+="?ThreadID=" + threadID;
				}

				if(_userMayDoSystemWideThreadManagement)
				{
					lnkMoveThread.Visible=true;
					lnkMoveThread.NavigateUrl+="?ThreadID=" + threadID;
					lnkDeleteThread.Visible=true;
					lnkDeleteThread.NavigateUrl+="?ThreadID=" + threadID;
				}

				btnThreadDone.Visible = _thread.MarkedAsDone;
				btnThreadNotDone.Visible = !_thread.MarkedAsDone;
				btnThreadDone.Enabled = _userMayMarkThreadAsDone;
				btnThreadNotDone.Enabled = _userMayMarkThreadAsDone;

				if(_userMayEditMemo)
				{
					lnkEditMemo.Visible=true;
					lnkEditMemo.NavigateUrl+="?ThreadID=" + threadID + "&StartAtMessage=" + _startMessageNo;
				}
				
				// These controls are visible by default. Hide them when the user can't create threads on this forum
				if(_userCanCreateThreads)
				{
					lnkNewThreadBottom.NavigateUrl += "?ForumID=" + _thread.ForumID + "&StartAtMessage=" + _startMessageNo;
					lnkNewThreadTop.NavigateUrl += "?ForumID=" + _thread.ForumID + "&StartAtMessage=" + _startMessageNo;
				}
				else
				{
					lnkNewThreadBottom.Visible = false;
					lnkNewThreadTop.Visible = false;
				}
				
				if(_userMayAddNewMessages)
				{
					lnkNewMessageBottom.NavigateUrl += "?ThreadID=" + threadID + "&StartAtMessage=" + _startMessageNo;
					lnkNewMessageTop.NavigateUrl += "?ThreadID=" + threadID + "&StartAtMessage=" + _startMessageNo;
				}
				else
				{
					lnkNewMessageBottom.Visible = false;
					lnkNewMessageTop.Visible = false;
				}
				lblSeparatorTop.Visible = (_userMayAddNewMessages && _userCanCreateThreads);
				lblSeparatorBottom.Visible = (_userMayAddNewMessages && _userCanCreateThreads);

				// The amount of postings in this thread are in the dataview row, which should contain just 1 row.
				int maxAmountMessagesPerPage = SessionAdapter.GetUserDefaultNumberOfMessagesPerPage();
				int amountOfMessages = ThreadGuiHelper.GetTotalNumberOfMessagesInThread(threadID);
				int amountOfPages = ((amountOfMessages-1) / maxAmountMessagesPerPage)+1;
				int currentPageNo = (_startMessageNo / maxAmountMessagesPerPage)+1;
				lblCurrentPage.Text = currentPageNo.ToString();
				lblTotalPages.Text = amountOfPages.ToString();

				lnkPrintThread.NavigateUrl += "?ThreadID=" + threadID;

				plPageListBottom.AmountMessages = amountOfMessages;
				plPageListBottom.StartMessageNo = _startMessageNo;
				plPageListBottom.ThreadID = threadID;
				plPageListTop.AmountMessages = amountOfMessages;
				plPageListTop.StartMessageNo = _startMessageNo;
				plPageListTop.ThreadID = threadID;
				
				// Get messages and bind it to the repeater control. Use the startmessage to get only the message visible on the current page. 
				MessagesInThreadTypedList messages = ThreadGuiHelper.GetAllMessagesInThreadAsTypedList(threadID, currentPageNo, maxAmountMessagesPerPage);
				rptMessages.DataSource = messages;
				rptMessages.DataBind();
			}			
		}

		/// <summary>
		/// Event handler for the ItemDataBound for the repeater control. Will set/reset controls inside the repeater
		/// template according to the user and his rights.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void rptMessages_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					// check if the thread is closed. If so, no editing nor new postings are allowed. 
					if(!_thread.IsClosed)
					{
						HyperLink lnkEditMessage = (HyperLink)e.Item.FindControl("lnkEditMessage");
						HyperLink lnkDeleteMessage = (HyperLink)e.Item.FindControl("lnkDeleteMessage");
						HyperLink lnkNewMessageWQuote = (HyperLink)e.Item.FindControl("lnkNewMessageWQuote");

						// editing and new messages are allowed when the rights are ok and the user isn't the AC
						// Check if the current message is posted by the current user
						bool showEditLink = _showEditMessageLink;
                        int currentUserID = SessionAdapter.GetUserID();
                        if ((currentUserID == (int)((DataRowView)e.Item.DataItem)["UserID"]) && (currentUserID != 0))
						{
							// yes. so enable editing
							showEditLink=true;
						}

						// you can only delete a message that's not the first message of the first thread.
                        int currentPageNumber = HnDGeneralUtils.TryConvertToInt(lblCurrentPage.Text);
						bool showDeleteLink = (currentPageNumber > 1 || e.Item.ItemIndex > 0) && _showDeleteMessageLink;

						lnkEditMessage.Visible = showEditLink;
						lnkNewMessageWQuote.Visible=_showQuoteMessageLink;
						lnkDeleteMessage.Visible = showDeleteLink;

						if(showEditLink && showDeleteLink)
						{
							// enable separator lable
							((Label)e.Item.FindControl("lblMessageCmdSepDeleteEdit")).Visible=true;
						}

						if((showEditLink && _showQuoteMessageLink)||(showDeleteLink && _showQuoteMessageLink))
						{
							// enable separator lable
							((Label)e.Item.FindControl("lblMessageCmdSepEditQuote")).Visible=true;
						}
					}
					break;
			}		
		}


		protected void btnSet_Click(object sender, EventArgs e)
		{
			if(!_userMayManageSupportQueueContents)
			{
				return;
			}

			// move this thread to a support queue. 
			// check the selected ID to see if it is the same as the current Queue. If so, ignore, otherwise set the queue.
			int selectedQueueID = HnDGeneralUtils.TryConvertToInt(cbxSupportQueues.SelectedValue);

			SupportQueueEntity containingQueue = SupportQueueGuiHelper.GetQueueOfThread(_thread.ThreadID);
			// now set the queue if: 
			// a) the thread isn't in a queue and the selected queueID > 0 (so not None)
			// b) the thread is in a queue and the selected queueuID isn't the id of the queue containing the thread
			if(((containingQueue == null) && (selectedQueueID != -1)) || ((containingQueue != null) && (containingQueue.QueueID != selectedQueueID)))
			{
				// Set the queue. if the new queue is -1, remove from queue.
				if(selectedQueueID > 0)
				{
					SupportQueueManager.AddThreadToQueue(_thread.ThreadID, selectedQueueID, SessionAdapter.GetUserID(), null);
				}
				else
				{
					SupportQueueManager.RemoveThreadFromQueue(_thread.ThreadID, null);
				}
			}

			// done redirect to this page to refresh.
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
		}


		protected void btnClaim_Click(object sender, EventArgs e)
		{
			if(!_userMayManageSupportQueueContents)
			{
				return;
			}

			// claim this thread
			SupportQueueManager.ClaimThread(SessionAdapter.GetUserID(), _thread.ThreadID);
			// done redirect to this page to refresh.
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
		}


		protected void btnRelease_Click(object sender, EventArgs e)
		{
			if(!_userMayManageSupportQueueContents)
			{
				return;
			}

			// release any claim on this thread.
			SupportQueueManager.ReleaseClaimOnThread( _thread.ThreadID);
			// done redirect to this page to refresh.
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
		}

		protected void btnBookmarkThread_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(!_userMayDoBasicThreadOperations)
			{
				return;
			}
			// bookmark this thread.
			bool result = UserManager.AddThreadToBookmarks(SessionAdapter.GetUserID(), _thread.ThreadID);
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
		}

		protected void btnUnbookmarkThread_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(!_userMayDoBasicThreadOperations)
			{
				return;
			}
			// remove the bookmark on this thread. 
			UserManager.RemoveSingleBookmark(_thread.ThreadID, SessionAdapter.GetUserID());
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
		}

		protected void btnThreadNotDone_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(!_userMayMarkThreadAsDone)
			{
				return;
			}
			// thread is done, mark it as such.
            ThreadManager.MarkThreadAsDone(_thread.ThreadID);
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
		}

        protected void btnThreadDone_Click(object sender, ImageClickEventArgs e)
        {
			if(!_userMayMarkThreadAsDone)
			{
				return;
			}
            // thread is re-opened, mark it as not done.
            ThreadManager.UnMarkThreadAsDone(_thread.ThreadID, SessionAdapter.GetUserID());
            Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
        }

		protected void btnSubscribeToThread_Click(object sender, ImageClickEventArgs e)
		{
			if(!_userMayDoBasicThreadOperations)
			{
				return;
			}
			bool result = UserManager.AddThreadToSubscriptions(_thread.ThreadID, SessionAdapter.GetUserID(), null);
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
		}

		protected void btnUnSubscribeFromThread_Click(object sender, ImageClickEventArgs e)
		{
			if(!_userMayDoBasicThreadOperations)
			{
				return;
			}
			UserManager.RemoveSingleSubscription(_thread.ThreadID, SessionAdapter.GetUserID());
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startMessageNo);
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


		/// <summary>
		/// Gets a value indicating whether [forum allows attachments].
		/// </summary>
		protected bool ForumAllowsAttachments
		{
			get { return _forumAllowsAttachments; }
		}

		/// <summary>
		/// Gets a value indicating whether [user may add attachments].
		/// </summary>
		protected bool UserMayAddAttachments
		{
			get { return _userMayAddAttachments; }
		}
		#endregion
}
}
