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
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.Utility;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind for the ModifyForum form.
	/// </summary>
	public partial class ModifyForum : System.Web.UI.Page
	{
		private	int _forumID;

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
			if(!SessionAdapter.HasSystemActionRight(ActionRights.SystemManagement))
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx",true);
			}

			_forumID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ForumID"]);

			if(!Page.IsPostBack)
			{
				// read sections for the drop down list.
				SectionCollection sections = SectionGuiHelper.GetAllSections();
				cbxSections.DataSource = sections;
				cbxSections.DataBind();

				SupportQueueCollection supportQueues = CacheManager.GetAllSupportQueues();
				cbxSupportQueues.DataSource = supportQueues;
				cbxSupportQueues.DataBind();

				// Load the forum.
				ForumEntity forum = ForumGuiHelper.GetForum(_forumID);
				if(forum!=null)
				{
					// forum found
					tbxForumDescription.Text = forum.ForumDescription;
					tbxForumName.Value = forum.ForumName;
					tbxOrderNo.Text = forum.OrderNo.ToString();

					cbxSections.SelectedValue = forum.SectionID.ToString();

					if(forum.DefaultSupportQueueID.HasValue)
					{
						cbxSupportQueues.SelectedValue = forum.DefaultSupportQueueID.Value.ToString();
					}
					chkHasRSSFeed.Checked = forum.HasRSSFeed;
					cbxThreadListInterval.SelectedValue = forum.DefaultThreadListInterval.ToString();
					tbxMaxAttachmentSize.Text = forum.MaxAttachmentSize.ToString();
					tbxMaxNoOfAttachmentsPerMessage.Text = forum.MaxNoOfAttachmentsPerMessage.ToString();

					if(forum.NewThreadWelcomeText != null)
					{
						tbxNewThreadWelcomeText.Text = forum.NewThreadWelcomeText;
					}

				}
				else
				{
					// not found
					Response.Redirect("Default.aspx",true);
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
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSave.ServerClick += new System.EventHandler(this.btnSave_ServerClick);
			this.btnCancel.ServerClick += new System.EventHandler(this.btnCancel_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_ServerClick(object sender, System.EventArgs e)
		{
			// store the new data.
			if(Page.IsValid)
			{
				int? supportQueueID = null;
				int selectedSupportQueueID = Convert.ToInt32(cbxSupportQueues.SelectedItem.Value);
				if( selectedSupportQueueID > 0)
				{
					supportQueueID = selectedSupportQueueID;
				}

				string newThreadWelcomeText = null;
				string newThreadWelcomeTextAsHTML = null;
				if(tbxNewThreadWelcomeText.Text.Trim().Length > 0)
				{
					// has specified welcome text, convert to HTML
					newThreadWelcomeText = tbxNewThreadWelcomeText.Text.Trim();
					string parserLog, textAsXML;
					bool errorsOccured;
					newThreadWelcomeTextAsHTML = TextParser.TransformUBBMessageStringToHTML(newThreadWelcomeText, ApplicationAdapter.GetParserData(),
							out parserLog, out errorsOccured, out textAsXML);
				}

				// page is valid, store the forum.
				if(ForumManager.ModifyForum(_forumID, HnDGeneralUtils.TryConvertToInt(cbxSections.SelectedItem.Value), tbxForumName.Value,
						tbxForumDescription.Text, chkHasRSSFeed.Checked, supportQueueID, HnDGeneralUtils.TryConvertToInt(cbxThreadListInterval.SelectedValue),
						HnDGeneralUtils.TryConvertToShort(tbxOrderNo.Text), HnDGeneralUtils.TryConvertToInt(tbxMaxAttachmentSize.Text),
						HnDGeneralUtils.TryConvertToShort(tbxMaxNoOfAttachmentsPerMessage.Text), newThreadWelcomeText, newThreadWelcomeTextAsHTML))
				{
					// went ok!
					// invalidate cache
					CacheManager.InvalidateCachedItem(CacheManager.ProduceCacheKey(CacheKeys.SingleForum, _forumID));
					// done
					Response.Redirect("ModifyDeleteForum.aspx",true);
				}
			}
		}

		private void btnCancel_ServerClick(object sender, System.EventArgs e)
		{
			// Do nothing
			Response.Redirect("ModifyDeleteForum.aspx", true);
		}
	}
}
