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
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SD.HnD.Utility;
using SD.HnD.DAL.EntityClasses;

namespace SD.HnD.GUI
{
	/// <summary>
	///	Code behind of the general message editor control. 
	/// </summary>
	public abstract partial class MessageEditor : System.Web.UI.UserControl
	{
		#region Events
		public event EventHandler PostMessage;
		public event EventHandler CancelAction;
		#endregion

		#region Class Member Declarations
		private bool _isThreadStart;
		private	string	_threadSubject, _forumName, _originalMessageText, _messageText,	_messageTextHTML, 
						_parserLog, _newThreadSubject, _forumDescription, _messageTextXML,
						_messageType = "Message", _buttonText = "      Post     ";
        private bool _parserErrorsOccured, _isSticky, _canBeSticky, _allowEmptyMessage = false, _showAddAttachment, _showSubscribeToThread = true, 
					 _canBeNormal;
		#endregion


		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				_messageText = string.Empty;
				_messageTextHTML = string.Empty;
				tbxMessage.Text = _originalMessageText;
				lblForumName.Text = _forumName;
				lblThreadSubject.Text = HttpUtility.HtmlEncode(_threadSubject);
				lblTextType.Text = _messageType;
				btnPost.Text = _buttonText;
				rfvMessage.Enabled = !_allowEmptyMessage;
				chkAddAttachment.Visible = _showAddAttachment;
				chkSubscribeToThread.Visible = (_showSubscribeToThread && CacheManager.GetSystemData().SendReplyNotifications);
                chkSubscribeToThread.Checked = SessionAdapter.GetUserAutoSubscribeToThread();

				if(_isThreadStart)
				{
					phSubjectRow.Visible=true;
					phHeaderNewThread.Visible=true;
					lblForumDescription.Text = _forumDescription;
					phCanBeSticky.Visible = _canBeSticky;
					rfvSubject.Enabled=true;
					if(!_canBeNormal && _canBeSticky)
					{
						// user can't uncheck sticky and has to be checked.
						chkIsSticky.Checked = true;
						chkIsSticky.Enabled = false;
					}
				}
				else
				{
					phHeaderNormal.Visible=true;
				}
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
		
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// General event bubbler. All events of controls contained by this container are streaming through this bubbler.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		protected override bool OnBubbleEvent(object source, EventArgs e) 
		{   
			bool eventHandled = false;

			CommandEventArgs argsAsCommandEventArgs = e as CommandEventArgs;

			if(argsAsCommandEventArgs!=null)
			{
				switch(argsAsCommandEventArgs.CommandName)
				{
					case "btnPreview":
						OnPreviewMessage(argsAsCommandEventArgs);
						eventHandled = true;   
						break;
					case "btnPost":
						OnPostMessage(argsAsCommandEventArgs);
						eventHandled = true; 
						break;
					case "btnCancel":
						OnCancelMessage(argsAsCommandEventArgs);
						eventHandled = true;
						break;
				}
			}
			return eventHandled;            
		}

		/// <summary>
		/// Event handler for PreviewMessage
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnPreviewMessage(EventArgs e)
		{
			if(Page.IsValid)
			{
				lblPreviewBody.Text = TextParser.TransformUBBMessageStringToHTML(tbxMessage.Text, ApplicationAdapter.GetParserData(), out _parserLog, out _parserErrorsOccured, out _messageTextXML);
				lblPreviewPostedOn.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
				phPreviewRow.Visible=true;
			}
		}

		/// <summary>
		/// Event handler for PostMessage. This message is bubbled up
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnPostMessage(EventArgs e)
		{
			if(Page.IsValid)
			{
				if(!_allowEmptyMessage || (tbxMessage.Text.Length>0))
				{
					_messageText = tbxMessage.Text;
					_messageTextHTML = TextParser.TransformUBBMessageStringToHTML(_messageText, ApplicationAdapter.GetParserData(), out _parserLog, out _parserErrorsOccured, out _messageTextXML);
					_isSticky = chkIsSticky.Checked;
					_newThreadSubject = tbxSubject.Value.Replace("<", "&lt;");
				}

				// bubble the message through the eventhandler chain
				if(PostMessage != null)
				{
					PostMessage(this, e);
				}
			}
		}

		/// <summary>
		/// Event handler for CancelMessage
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnCancelMessage(EventArgs e)
		{
			// do nothin', just bubble
			if(CancelAction != null)
			{
				CancelAction(this, e);
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Sets the forum description.
		/// </summary>
		/// <value>The forum description.</value>
		public string ForumDescription
		{
			set { _forumDescription = value; }
		}

		/// <summary>
		/// Sets a value indicating whether this instance can be sticky.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance can be sticky; otherwise, <c>false</c>.
		/// </value>
		public bool CanBeSticky
		{
			set { _canBeSticky = value; }
		}


		/// <summary>
		/// Sets a value indicating whether the new thread can be a normal thread (non-sticky).
		/// </summary>
		public bool CanBeNormal
		{
			set { _canBeNormal = value; }
		}

		/// <summary>
		/// Gets a value indicating whether this instance is sticky.
		/// </summary>
		/// <value><c>true</c> if this instance is sticky; otherwise, <c>false</c>.</value>
		public bool IsSticky
		{
			get { return _isSticky;}
		}

		/// <summary>
		/// Gets the new thread subject.
		/// </summary>
		/// <value>The new thread subject.</value>
		public string NewThreadSubject
		{
			get { return _newThreadSubject; }
		}

		/// <summary>
		/// Gets / Sets a value indicating whether this instance is thread start.
		/// </summary>
		public bool IsThreadStart
		{
			get { return _isThreadStart; }
			set { _isThreadStart = value; }
		}

		/// <summary>
		/// Gets a value indicating whether [parser errors occured].
		/// </summary>
		/// <value><c>true</c> if [parser errors occured]; otherwise, <c>false</c>.</value>
		public bool ParserErrorsOccured
		{
			get { return _parserErrorsOccured; }
		}

		/// <summary>
		/// Gets the parser log.
		/// </summary>
		/// <value>The parser log.</value>
		public string ParserLog
		{
			get { return _parserLog; }
		}

		/// <summary>
		/// Sets the thread subject.
		/// </summary>
		/// <value>The thread subject.</value>
		public string ThreadSubject
		{
			set { _threadSubject = value; }
		}

		/// <summary>
		/// Sets the name of the forum.
		/// </summary>
		/// <value>The name of the forum.</value>
		public string ForumName
		{
			set { _forumName = value; }
		}

		/// <summary>
		/// Sets the original message text.
		/// </summary>
		/// <value>The original message text.</value>
		public string OriginalMessageText
		{
			set { _originalMessageText = value; }
		}

		/// <summary>
		/// Gets the message text.
		/// </summary>
		/// <value>The message text.</value>
		public string MessageText
		{
			get { return _messageText; }
		}

		/// <summary>
		/// Gets the message text HTML.
		/// </summary>
		/// <value>The message text HTML.</value>
		public string MessageTextHTML
		{
			get { return _messageTextHTML; }
		}

		/// <summary>
		/// Gets the message text XML.
		/// </summary>
		/// <value>The message text XML.</value>
		public string MessageTextXML
		{
			get { return _messageTextXML;}
		}

		/// <summary>
		/// Gets / sets messageType
		/// </summary>
		public string MessageType
		{
			get
			{
				return _messageType;
			}
			set
			{
				_messageType = value;
			}
		}

		/// <summary>
		/// Gets / sets ButtonText
		/// </summary>
		public string ButtonText
		{
			get
			{
				return _buttonText;
			}
			set
			{
				_buttonText = value;
			}
		}

		/// <summary>
		/// Gets / sets AllowEmptyMessage
		/// </summary>
		public bool AllowEmptyMessage
		{
			get
			{
				return _allowEmptyMessage;
			}
			set
			{
				_allowEmptyMessage = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether AddAttachment is checked or not.
		/// </summary>
		public bool AddAttachment
		{
			get { return chkAddAttachment.Checked; }
		}

        /// <summary>
        /// Gets a value indicating whether SubscribeToThread is checked or not.
        /// </summary>
        public bool SubscribeToThread
        {
            get { return chkSubscribeToThread.Checked && chkSubscribeToThread.Visible; }
        }

		/// <summary>
		/// Sets a value indicating whether AddAttachment checkbox should be shown
		/// </summary>
		public bool ShowAddAttachment
		{
			set { _showAddAttachment = value; }
		}


        /// <summary>
        /// Sets a value indicating whether SubscribeToMessage checkbox should be shown
        /// </summary>
        public bool ShowSubscribeToThread
        {
            set { _showSubscribeToThread = value; }
        }
		#endregion
	}
}
