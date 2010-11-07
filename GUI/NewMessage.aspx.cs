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
	/// Code behind of the New message form.
	/// </summary>
	public partial class NewMessage : System.Web.UI.Page
	{
		#region Class Member Declarations
		private int _startAtMessageIndex, _quoteMessageID;
		private ThreadEntity _thread;
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
				// not found, return to default page
				Response.Redirect("default.aspx", true);
			}

			_startAtMessageIndex = HnDGeneralUtils.TryConvertToInt(Request.QueryString["StartAtMessage"]);
			_quoteMessageID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["QuoteMessageID"]);

			// Check credentials
			bool userHasAccess = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AccessForum);
			if(!userHasAccess)
			{
				// doesn't have access to this forum. redirect
				Response.Redirect("default.aspx");
			}

			// Check if the current user is allowed to add new messages to the thread.
			bool userMayAddNewMessages=false;
			if(!_thread.IsClosed)
			{
				if(_thread.IsSticky)
				{
					if(SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAndEditMessageInSticky))
					{
						userMayAddNewMessages=true;
					}
				}
				else
				{
					if(SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAndEditMessage))
					{
						userMayAddNewMessages=true;
					}
				}
			}
			
			if(!userMayAddNewMessages)
			{
				// is not allowed to post a new message
				Response.Redirect("Messages.aspx?ThreadID=" + threadID, true);
			}

			// use BL class. We could have used Lazy loading, though for the sake of separation, we'll call into the BL class. 
			ForumEntity forum = CacheManager.GetForum(_thread.ForumID);
			if(forum == null)
			{
				// orphaned thread
				Response.Redirect("default.aspx");
			}

			// check if the user can view the thread the message is in. If not, don't continue.
			if((_thread.StartedByUserID != SessionAdapter.GetUserID()) &&
				!SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.ViewNormalThreadsStartedByOthers))
			{
				// can't add a message, it's in a thread which isn't visible to the user
				Response.Redirect("default.aspx", true);
			}

			meMessageEditor.ShowAddAttachment = ((forum.MaxNoOfAttachmentsPerMessage > 0) &&
											SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.AddAttachment));
			meMessageEditor.ShowSubscribeToThread = !UserGuiHelper.CheckIfThreadIsAlreadySubscribed(SessionAdapter.GetUserID(), _thread.ThreadID);

			// User is able to post a new message to the current thread. 
			if(!Page.IsPostBack)
			{
				// fill the page's content
				lnkThreads.Text = HttpUtility.HtmlEncode(forum.ForumName);
				lnkThreads.NavigateUrl += "?ForumID=" + _thread.ForumID;
				meMessageEditor.ForumName = forum.ForumName;
				meMessageEditor.ThreadSubject = _thread.Subject;
				lblSectionName.Text = CacheManager.GetSectionName(forum.SectionID);
				lnkMessages.NavigateUrl+=threadID;
				lnkMessages.Text = HttpUtility.HtmlEncode(_thread.Subject);
				phLastPostingInThread.Visible = (_quoteMessageID<=0);

				bool userMayEditMemo = SessionAdapter.CanPerformForumActionRight(_thread.ForumID, ActionRights.EditThreadMemo);
				
				// get quoted message if passed in.
				if(_quoteMessageID>0)
				{
					// get message and insert it into the textbox including quote tags.
					MessageEntity messageToQuote = MessageGuiHelper.GetMessage(_quoteMessageID);
					if(messageToQuote != null)
					{
						// message found.
						UserEntity quotedUser = UserGuiHelper.GetUser(messageToQuote.PostedByUserID);
						if(quotedUser != null)
						{
							// user found. proceed
							meMessageEditor.OriginalMessageText = TextParser.MakeStringQuoted(messageToQuote.MessageText, quotedUser.NickName);
						}
					}
				}
				else
				{
					// no quoted message. Load the last message from the active thread and display it in the form. This
					// message entity has the poster user entity prefetched, together with the usertitle of the user.
					MessageEntity lastMessageInThread = ThreadGuiHelper.GetLastMessageInThreadWithUserInfo(threadID);
					if(lastMessageInThread!=null)
					{
						litMessageBody.Text = lastMessageInThread.MessageTextAsHTML;
						lblPostingDate.Text = lastMessageInThread.PostingDate.ToString("dd-MMM-yyyy HH:mm:ss");
						if(lastMessageInThread.PostedByUser != null)
						{
							UserEntity messagePoster = lastMessageInThread.PostedByUser;
							if(messagePoster.UserTitle != null)
							{
								lblUserTitleDescription.Text = messagePoster.UserTitle.UserTitleDescription;
							}
							lblLocation.Text = messagePoster.Location;
							if(messagePoster.JoinDate.HasValue)
							{
								lblJoinDate.Text = messagePoster.JoinDate.Value.ToString("dd-MMM-yyyy HH:mm:ss");
							}
							if(messagePoster.AmountOfPostings.HasValue)
							{
								lblAmountOfPostings.Text = messagePoster.AmountOfPostings.Value.ToString();
							}
							if(messagePoster.SignatureAsHTML != null)
							{
								litSignature.Text = messagePoster.SignatureAsHTML;
							}
							lblNickname.Text = messagePoster.NickName;
						}
					}
				}
				
				if((_thread.Memo.Length > 0) && userMayEditMemo)
				{
					// convert memo contents to HTML so it's displayed above the thread. 
					string parserLog, messageTextXml;
					bool errorsOccured = false;
					string memoAsHTML = TextParser.TransformUBBMessageStringToHTML(_thread.Memo, ApplicationAdapter.GetParserData(), out parserLog, out errorsOccured, out messageTextXml);
					lblMemo.Text = memoAsHTML;
				}
				phMemo.Visible = userMayEditMemo;
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

			// store the new message in the given thread
            string mailTemplate = ApplicationAdapter.GetEmailTemplate(EmailTemplate.ThreadUpdatedNotification);
            int messageID = ThreadManager.CreateNewMessageInThread(_thread.ThreadID, userID, meMessageEditor.MessageText, meMessageEditor.MessageTextHTML, 
					Request.UserHostAddress.ToString(), meMessageEditor.MessageTextXML, meMessageEditor.SubscribeToThread,
					mailTemplate, ApplicationAdapter.GetEmailData(), CacheManager.GetSystemData().SendReplyNotifications);	

			// invalidate forum RSS in cache
			ApplicationAdapter.InvalidateCachedForumRSS(_thread.ForumID);

			// if auditing is required, we've to do this now.
            if (SessionAdapter.CheckIfNeedsAuditing(AuditActions.AuditNewMessage))
			{
                SecurityManager.AuditNewMessage(userID, messageID);
			}

			// invalidate forum in asp.net cache
			CacheManager.InvalidateCachedItem(CacheManager.ProduceCacheKey(CacheKeys.SingleForum, _thread.ForumID));

			// all ok, redirect to message list
			int startAtMessageIndex = ThreadGuiHelper.GetStartAtMessageForGivenMessageAndThread(_thread.ThreadID, messageID, SessionAdapter.GetUserDefaultNumberOfMessagesPerPage());
			if(meMessageEditor.AddAttachment)
			{
				// redirect to manage attachment form for this message
				Response.Redirect(string.Format("Attachments.aspx?SourceType=1&MessageID={0}", messageID), true);
			}
			else
			{
				Response.Redirect(string.Format("Messages.aspx?ThreadID={0}&StartAtMessage={1}&#{2}", _thread.ThreadID, startAtMessageIndex, messageID), true);
			}
		}

		protected void CancelActionHandler(object sender, System.EventArgs e)
		{
			Response.Redirect("Messages.aspx?ThreadID=" + _thread.ThreadID + "&StartAtMessage=" + _startAtMessageIndex, true);
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
				string toReturn = string.Empty;
				if(_thread != null)
				{
					toReturn = _thread.Subject;
				}
				return toReturn;
			}
		}
		#endregion
	}
}
