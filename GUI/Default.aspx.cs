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
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using SD.HnD.BL;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.HelperClasses;
using System.IO;
using System.Text;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Default entrance page for the forum system. 
	/// </summary>
	public partial class _default : System.Web.UI.Page
	{
		#region Class Member Declarations
		private Dictionary<int, DataView> _forumViewsPerDisplayedSection;
        private SectionCollection _sectionsToDisplay;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.Title += ApplicationAdapter.GetSiteName();

				// first time loaded, fill in properties
                lblUserName.Text = SessionAdapter.GetUserNickName();
				
				HttpContext hcCurrent = HttpContext.Current;
				DataTable bookmarkStatistics = null;

				// check if user is authenticated
				if(hcCurrent.Request.IsAuthenticated)
				{
					lblWelcomeTextLoggedIn.Visible=true;                    
                    bookmarkStatistics = UserGuiHelper.GetBookmarkStatisticsAsDataTable(SessionAdapter.GetUserID());
				}
				else
				{
					lblWelcomeTextNotLoggedIn.Visible=true;
					bookmarkStatistics = new DataTable();
				}

				// check if the user has the action right to approve attachments on some forum. If so, show the # of attachments which need approval
				List<int> forumsWithApprovalRight = SessionAdapter.GetForumsWithActionRight(ActionRights.ApproveAttachment);
				bool canApproveAttachments = ((forumsWithApprovalRight != null) && (forumsWithApprovalRight.Count > 0));
				if(canApproveAttachments)
				{
					int numberOfAttachmentsToApprove = MessageGuiHelper.GetTotalNumberOfAttachmentsToApprove(
							SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum),
							SessionAdapter.GetForumsWithActionRight(ActionRights.ApproveAttachment),
							SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), SessionAdapter.GetUserID());
					if(numberOfAttachmentsToApprove>0)
					{
						phAttachmentsToApprove.Visible=true;
						phAttentionRemarks.Visible = true;
					}
				}
				if(SessionAdapter.HasSystemActionRight(ActionRights.QueueContentManagement))
				{
					int numberOfThreadsInSupportQueues = SupportQueueGuiHelper.GetTotalNumberOfThreadsInSupportQueues(
							SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum));
					if(numberOfThreadsInSupportQueues > 0)
					{
						phThreadsToSupport.Visible = true;
						phAttentionRemarks.Visible = true;
					}
				}

                DateTime lastVisitDate = SessionAdapter.GetLastVisitDate();

                if(SessionAdapter.IsLastVisitDateValid())
				{
					phLastVisitDate.Visible=true;
                    lblLastVisitDate.Text = lastVisitDate.ToString("dd-MMM-yyyy HH:mm");
				}

				// Get all sections which possibly can be displayed. Obtain this from the cache, as it's hardly changing data, and 
				// this page is read a lot. 
                _sectionsToDisplay = CacheManager.GetAllSections();

				// Per section, create a view with all the forumdata and filter out the forums not visible for the current user.
                List<int> accessableForums = SessionAdapter.GetForumsWithActionRight(ActionRights.AccessForum);
				List<int> forumsWithThreadsFromOthers = SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers);
                _forumViewsPerDisplayedSection = ForumGuiHelper.GetAllAvailableForumsDataViews(_sectionsToDisplay, accessableForums,
						forumsWithThreadsFromOthers, SessionAdapter.GetUserID());

				// filter out sections which do not have displayable forums for this user
				EntityView<SectionEntity> sectionsToUse = CreateFilteredSectionsCollection();

				// show the sections with displayable forums, thus the displayable sections.
				rpSections.DataSource = sectionsToUse;
				rpSections.DataBind();

				// get bookmarks and show them in the gui
				if((bookmarkStatistics.Rows.Count<=0)||((bookmarkStatistics.Rows.Count==1)&&((int)bookmarkStatistics.Rows[0][0]==0)))
				{
					// no bookmarks yet
					lblAmountBookmarks.Text = "0";
					lblAmountPostingsInBookmarks.Text = "0";
					lblBookmarksLastPostingDate.Text = "Never";
					imgIconBookmarkNoNewPosts.Visible=true;
				}
				else
				{
					lblAmountBookmarks.Text = bookmarkStatistics.Rows[0]["AmountThreads"].ToString();
					lblAmountPostingsInBookmarks.Text = bookmarkStatistics.Rows[0]["AmountPostings"].ToString();
					DateTime dateLastPosting = (DateTime)bookmarkStatistics.Rows[0]["LastPostingDate"];
					lblBookmarksLastPostingDate.Text = dateLastPosting.ToString("dd-MMM-yyyy HH:mm");
                    if (dateLastPosting > lastVisitDate)
					{
						imgIconBookmarkNewPosts.Visible=true;
					}
					else
					{
						imgIconBookmarkNoNewPosts.Visible=true;
					}
				}
                
                DataTable activeThreadsStatistics = ThreadGuiHelper.GetActiveThreadsStatisticsAsDataTable(accessableForums, 
						CacheManager.GetSystemData().HoursThresholdForActiveThreads, 
						SessionAdapter.GetForumsWithActionRight(ActionRights.ViewNormalThreadsStartedByOthers), SessionAdapter.GetUserID());
                if (activeThreadsStatistics != null)
                {
                    if ((activeThreadsStatistics.Rows.Count <= 0) || ((activeThreadsStatistics.Rows.Count == 1) && ((int)activeThreadsStatistics.Rows[0][0] == 0)))
                    {
                        lblAmountActiveThreads.Text = "0";
                        lblAmountPostingsInActiveThreads.Text = "0";
                        lblActiveThreadsLastPostingDate.Text = "Never";
                        imgIconActiveThreadsNoNewPosts.Visible = true;
                    }
                    else
                    {
                        lblAmountActiveThreads.Text = activeThreadsStatistics.Rows[0]["AmountThreads"].ToString();
                        lblAmountPostingsInActiveThreads.Text = activeThreadsStatistics.Rows[0]["AmountPostings"].ToString();
                        DateTime dateLastPosting = (DateTime)activeThreadsStatistics.Rows[0]["LastPostingDate"];
                        lblActiveThreadsLastPostingDate.Text = dateLastPosting.ToString("dd-MMM-yyyy HH:mm");
                        if (dateLastPosting > lastVisitDate)
                        {
                            imgIconActiveThreadsNewPosts.Visible = true;
                        }
                        else
                        {
                            imgIconActiveThreadsNoNewPosts.Visible = true;
                        }
                    }
                }
			}

			RegisterCollapseExpandClientScript();
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

		/// <summary>
		/// Registers the collapse expand client script.
		/// </summary>
		private void RegisterCollapseExpandClientScript()
		{
			StringBuilder script = new StringBuilder(File.ReadAllText(Path.Combine(ApplicationAdapter.GetDataFilesMapPath(), "CollapseExpandScript.template")));
			script.Replace("[RootCookieName]", ApplicationAdapter.GetSiteName());
			ClientScriptManager scriptManager = this.ClientScript;
			Type typeToUse = this.GetType();
			if(!scriptManager.IsStartupScriptRegistered("CollapseExpandScript"))
			{
				// register
				scriptManager.RegisterStartupScript(typeToUse, "CollapseExpandScript", script.ToString(), true);
			}
		}


		/// <summary>
        /// Creates an EntityView on _sectionsToDisplay with a filter so that empty sections aren't visible. 
		/// </summary>
		private EntityView<SectionEntity> CreateFilteredSectionsCollection()
		{
			List<int> sectionIDsToFilter = new List<int>();
			// pair.Key is sectionID, pair.Value is DataView with foruminformation + statistics for all the forums in that section.
			foreach(KeyValuePair<int, DataView> pair in _forumViewsPerDisplayedSection)
			{
				if(pair.Value.Count <= 0)
				{
					// empty section, remove it from section list. Since this section list is used to look up forumviews in 
					// _forumViewsPerDisplayedSection, we don't have to remove the empty dataview here. Simply add the sectionID (==pair.Key) to the
					// list of sectionids to filter
					sectionIDsToFilter.Add(pair.Key);
				}
			}

			// create a view on the sections to display and filter the view with a filter on sectionid: a sectionid must not be part of sectionIDsToFilter.
			// if there are no sections to filter out, simply don't pass a filter.
			if(sectionIDsToFilter.Count <= 0)
			{
				return new EntityView<SectionEntity>(_sectionsToDisplay);
			}
			else
			{
				return new EntityView<SectionEntity>(_sectionsToDisplay, (SectionFields.SectionID != sectionIDsToFilter));
			}
		}


		/// <summary>
		/// Handles the ItemDataBound event of the rpSections control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
		protected void rpSections_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
						// get the forumlist and bind it to the repeatercontrol created.
						SectionEntity currentSection = (SectionEntity)e.Item.DataItem;
						DataView forumsView = _forumViewsPerDisplayedSection[currentSection.SectionID];

						// Find repeater control in this item
						Repeater rpForums = (Repeater)e.Item.FindControl("rpForums");

						// bind it
						rpForums.DataSource = forumsView;
						rpForums.DataBind();
					break;
			}
		}


		/// <summary>
		/// Handles the ItemDataBound event of the rpForums control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
		protected void rpForums_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
				{
					Label forumLastPostingDateLabel = (Label)e.Item.FindControl("lblForumLastPostingDate");
					
					// check if date is NULL
					if(((DataRowView)e.Item.DataItem)["ForumLastPostingDate"] is System.DBNull)
					{
						forumLastPostingDateLabel.Text = "Never";
						
						// Date is null, there are no messages. 
						System.Web.UI.WebControls.Image noNewPostsIcon = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNoNewPosts");
						noNewPostsIcon.Visible = true;
					}
					else
					{
						HttpContext hcCurrent = HttpContext.Current;
						DateTime forumLastPostingDate = (DateTime)(((DataRowView)e.Item.DataItem)["ForumLastPostingDate"]);
                        DateTime lastVisitDate = SessionAdapter.GetLastVisitDate();

						forumLastPostingDateLabel.Text = forumLastPostingDate.ToString("dd-MMM-yyyy HH:mm");
						
						// date is not 0, check if the date is > than the date in the session variable. If so, the posting is newer and we
						// should visualize the New Messages image, otherwise the No new Messages image.
						System.Web.UI.WebControls.Image postsIcon;
						
						if(forumLastPostingDate > lastVisitDate)
						{
							// there are new messages since last visit
							postsIcon = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNewPosts");
						}
						else
						{
							// no new messages
							postsIcon = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgIconNoNewPosts");
						}
						postsIcon.Visible = true;
					}
				} 
				break;
			}
		}
	}
}
