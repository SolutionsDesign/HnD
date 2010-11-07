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
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.EntityClasses;
using System.Collections.Generic;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Shows audit info for the selected user.
	/// </summary>
	public partial class ViewAuditInfo : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// If the user doesn't have any access rights to management stuff, the user should
			// be redirected to the default of the global system. 
            if (!SessionAdapter.HasSystemActionRights())
            {
				// doesn't have system rights. redirect.
				Response.Redirect("../Default.aspx",true);
			}
			
			// Check if the user has the right systemright
			bool userHasAccess = SessionAdapter.HasSystemActionRight(ActionRights.UserManagement);
			if(!userHasAccess)
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx",true);
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
			this.rptAudits.ItemDataBound+=new RepeaterItemEventHandler(rptAudits_ItemDataBound);

		}
		#endregion

		/// <summary>
		/// Handler for the selectclicked event of the finduser control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectClickedHandler(object sender, System.EventArgs e)
		{
			List<int> selectedUserIDs = userFinder.SelectedUserIDs;
			if(selectedUserIDs.Count < 0)
			{
				// nothing selected, return
				return;
			}

			// just use the first selected user
			int selectedUserID = selectedUserIDs[0];
			UserEntity user = UserGuiHelper.GetUser(selectedUserID);
			lblUserName.Text = user.NickName;
			AuditDataCoreCollection audits = SecurityGuiHelper.GetAllAuditsForUser(selectedUserID);
			phAuditInfo.Visible=true;

			rptAudits.DataSource = audits;
			rptAudits.DataBind();
		}

		private void rptAudits_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					AuditDataCoreEntity auditCore = (AuditDataCoreEntity)e.Item.DataItem;
					Label lblAuditAction = (Label)e.Item.FindControl("lblAuditAction");
					lblAuditAction.Text = ((AuditActions)auditCore.AuditActionID).ToString();
					Label lblAuditDateTime = (Label)e.Item.FindControl("lblAuditDateTime");
					lblAuditDateTime.Text = auditCore.AuditedOn.ToString("dd-MMM-yyyy HH:mm:ss");

					HyperLink infoLink = (HyperLink)e.Item.FindControl("lnkAdditionalInfoLink");

					switch((AuditActions)auditCore.AuditActionID)
					{
						case AuditActions.AuditNewMessage:
						case AuditActions.AuditAlteredMessage:
						case AuditActions.AuditApproveAttachment:
							AuditDataMessageRelatedEntity auditMessageData = auditCore as AuditDataMessageRelatedEntity;
							if(auditMessageData!=null)
							{
								// convert the link into a link to the message in question.
								infoLink.Visible=true;
								infoLink.NavigateUrl = "../GotoMessage.aspx?ThreadID=" + auditMessageData.Message.ThreadID + "&MessageID=" + auditMessageData.MessageID;
								infoLink.Text = "Message in thread: '" + auditMessageData.Message.Thread.Subject + "'";
							}
							break;
						case AuditActions.AuditEditMemo:
						case AuditActions.AuditNewThread:
							AuditDataThreadRelatedEntity auditThreadData = auditCore as AuditDataThreadRelatedEntity;
							if(auditThreadData!=null)
							{
								infoLink.Visible=true;
								infoLink.NavigateUrl = "../Messages.aspx?ThreadID=" + auditThreadData.ThreadID;
								infoLink.Text = "Thread: '" + auditThreadData.Thread.Subject + "'";
							}
							break;
						case AuditActions.AuditLogin:
							break;
					}
					break;
			}
		}
	}
}
