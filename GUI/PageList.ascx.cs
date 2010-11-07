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
using SD.HnD.BL;

namespace SD.HnD.GUI
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///	ASP.NET Usercontrol class which will display a list of pagelinks: Pages: 1, 2, 3, etc
	/// </summary>
	public abstract partial class PageList : System.Web.UI.UserControl
	{
		#region Class Member Declarations
		private int _amountMessages, _amountPages, _startMessageNo, _threadID;
		private bool _highLight, _useCommaAsSeparator, _isOnThreadsPage; 
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			int[] pageList = new int[_amountPages];

			for(int i=0;i<_amountPages;i++)
			{
				pageList[i] = (i + 1);
			}

			if(_isOnThreadsPage)
			{
				rptPageListThreads.Visible = true;
				rptPageListThreads.DataSource = pageList;
				rptPageListThreads.DataBind();
			}
			else
			{
				rptPageListMessages.Visible = true;
				rptPageListMessages.DataSource = pageList;
				rptPageListMessages.DataBind();
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
			this.rptPageListMessages.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptPageListMessages_ItemDataBound);
			this.rptPageListThreads.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptPageListThreads_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Event handler for the ItemDataBound event for the repeater control for the pagelist in the Messages page. In here the decision is made
		/// if the current item will be a link (we're not on this page) or not (thus a label)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rptPageListMessages_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			int maxAmountMessagesPerPage = SessionAdapter.GetUserDefaultNumberOfMessagesPerPage();

			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					int currentPage = (_startMessageNo/maxAmountMessagesPerPage)+1;
					if((currentPage) == (int)(e.Item.DataItem))
					{
						// the current number emitted by the repeater is the page number we're on at the moment.
						Label lblMessagePage = (Label)e.Item.FindControl("lblMessagesPage");
						lblMessagePage.Visible=true;
					}
					else
					{
						HyperLink lnkMessagePage = (HyperLink)e.Item.FindControl("lnkMessagesPage");
						lnkMessagePage.NavigateUrl += "?ThreadID=" + _threadID + "&StartAtMessage=" + 
												(((int)(e.Item.DataItem)-1)*maxAmountMessagesPerPage);
						if(_highLight)
						{
							lnkMessagePage.NavigateUrl+="&HighLight=1";
						}
						lnkMessagePage.Visible=true;
					}
					break;
			}
		}


		/// <summary>
		/// Event handler for the ItemDataBound event for the repeater control for the pagelist in the Threads page. In here the decision is made
		/// if the current item will be a link (we're not on this page) or not (thus a label)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rptPageListThreads_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			int maxAmountMessagesPerPage = SessionAdapter.GetUserDefaultNumberOfMessagesPerPage();

			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					int currentPage = (_startMessageNo / maxAmountMessagesPerPage) + 1;
					HyperLink lnkMessagePage = (HyperLink)e.Item.FindControl("lnkMessagesPage");
					lnkMessagePage.NavigateUrl += "?ThreadID=" + _threadID + "&StartAtMessage=" +
											(((int)(e.Item.DataItem) - 1) * maxAmountMessagesPerPage);
					if(_highLight)
					{
						lnkMessagePage.NavigateUrl += "&HighLight=1";
					}
					break;
			}
		}


		#region Class Property Definitions
		/// <summary>
		/// StartMessageNo property. Sets the startmessage number for the active page calculation.
		/// </summary>
		public int StartMessageNo
		{
			set { _startMessageNo = value; }
		}

		/// <summary>
		/// AmountMessages property. Calculates with this value the amount of pages.
		/// </summary>
		public int AmountMessages
		{
        
			set
			{
				int maxAmountMessagesPerPage = SessionAdapter.GetUserDefaultNumberOfMessagesPerPage();

				_amountMessages = value;
				_amountPages=((_amountMessages-1)/maxAmountMessagesPerPage)+1;
			}
		}
		
		/// <summary>
		/// ThreadID property, for link emitter
		/// </summary>
		public int ThreadID
		{
			set { _threadID = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether [high light].
		/// </summary>
		public bool HighLight
		{
			get { return _highLight;}
			set { _highLight = value;}
		}

		/// <summary>
		/// Gets / sets UseCommaAsSeparator
		/// </summary>
		public bool UseCommaAsSeparator
		{
			get
			{
				return _useCommaAsSeparator;
			}
			set
			{
				_useCommaAsSeparator = value;
			}
		}

		/// <summary>
		/// Gets / sets onThreadsPage
		/// </summary>
		public bool IsOnThreadsPage
		{
			get
			{
				return _isOnThreadsPage;
			}
			set
			{
				_isOnThreadsPage = value;
			}
		}

		#endregion
	}
}
