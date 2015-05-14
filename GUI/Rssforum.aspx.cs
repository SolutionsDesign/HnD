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
using SD.HnD.DAL.TypedListClasses;
using SD.HnD.Utility;
using SD.HnD.DAL.EntityClasses;

namespace SD.HnD.GUI
{
	/// <summary>
	/// Produces an RSS 2.0 feed for the forum specified.
	/// </summary>
	public partial class Rssforum : System.Web.UI.Page
	{
		#region Class Member Declarations
		private string _siteName, _forumURL;
		private ForumEntity _forum;
		#endregion

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			_siteName = HttpUtility.HtmlEncode(ApplicationAdapter.GetSiteName());

			int forumID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ForumID"]);
			_forum = CacheManager.GetForum(forumID);
			if((_forum != null) && _forum.HasRSSFeed)
			{
				_forumURL = "http://" + Request.Url.Host + ApplicationAdapter.GetVirtualRoot() + String.Format(@"Threads.aspx?ForumID={0}", forumID);

				// get the messages
				//ForumMessagesTypedList messages = ForumGuiHelper.GetLastPostedMessagesInForum(10, forumID);
				//rptRSS.DataSource = messages;
				//rptRSS.DataBind();

				Response.Cache.SetExpires(DateTime.Now.AddDays(7));
				Response.Cache.SetCacheability(HttpCacheability.Public);
				Response.Cache.SetValidUntilExpires(true);
				Response.Cache.VaryByParams["ForumID"] = true;
				Response.Cache.AddValidationCallback(new HttpCacheValidateHandler(Validate), null);
			}
		}
		
		private void Page_PreInit(object sender, EventArgs e)
		{
			// switch off theming as the EnableTheming option on the page level doesn't work due to a bug in ASP.NET 2.0
			Page.Theme = "";
		} 


		/// <summary>
		/// Cache validator routine.
		/// </summary>
		/// <param name="context"></param>
		/// <param name="data"></param>
		/// <param name="status"></param>
		public void Validate(HttpContext context, Object data, ref HttpValidationStatus status) 
		{
			// get flag
			Hashtable cacheFlags = ApplicationAdapter.GetCacheFlags();

			bool isValid = true;
			if(cacheFlags.ContainsKey(_forum.ForumID))
			{
				isValid = (bool)cacheFlags[_forum.ForumID];
			}

			if(isValid)
			{
				status = HttpValidationStatus.Valid;
			}
			else
			{
				status = HttpValidationStatus.Invalid;
			}
		}


		protected void rptRSS_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					DataRowView currentRow = (DataRowView)e.Item.DataItem;
					string nickName = currentRow["NickName"].ToString();
					string message = currentRow["MessageTextAsHTML"].ToString();
					string subject = currentRow["Subject"].ToString();
					Literal title = (Literal)e.Item.FindControl("title");
					title.Text = HttpUtility.HtmlEncode(String.Format("{0} by {1}", subject, nickName));
					
					Literal description = (Literal)e.Item.FindControl("description");
					description.Text = HttpUtility.HtmlEncode(message);

					Literal link = (Literal)e.Item.FindControl("itemLink");
					int threadID = (int)currentRow["ThreadID"];
					int messageID = (int)currentRow["MessageID"];
					int startAtMessage = ThreadGuiHelper.GetStartAtMessageForGivenMessageAndThread(threadID, messageID, ApplicationAdapter.GetMaxAmountMessagesPerPage());
					link.Text = HttpUtility.HtmlEncode("http://" + Request.Url.Host + ApplicationAdapter.GetVirtualRoot() + String.Format(@"Messages.aspx?ThreadID=" + threadID + "&StartAtMessage=" + startAtMessage + "#" + messageID));

					Literal permaLink = (Literal)e.Item.FindControl("permaLink");
					permaLink.Text = link.Text;

					Literal pubDate = (Literal)e.Item.FindControl("pubDate");
					pubDate.Text = String.Format("{0:R}", ((DateTime)currentRow["PostingDate"]).AddHours(-2));

					Literal author = (Literal)e.Item.FindControl("author");
					author.Text = nickName;

					Literal category = (Literal)e.Item.FindControl("threadName");
					category.Text = HttpUtility.HtmlEncode(subject);
					break;
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the name of the site.
		/// </summary>
		/// <value>The name of the site.</value>
		protected string SiteName
		{
			get { return _siteName; }
		}

		/// <summary>
		/// Gets the forum URL.
		/// </summary>
		/// <value>The forum URL.</value>
		protected string ForumURL
		{
			get { return _forumURL; }
		}

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
