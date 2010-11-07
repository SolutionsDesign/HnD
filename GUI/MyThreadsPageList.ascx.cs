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

namespace SD.HnD.GUI
{
	/// <summary>
	///	Page list control for the MyThreads page
	/// </summary>
	public partial class MyThreadsPageList : System.Web.UI.UserControl
	{

		#region Class Member Declarations
		private	int	_amountPages, _currentPage;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			int[] pageNos = new int[_amountPages];

			for(int i=0;i<_amountPages;i++)
			{
				pageNos[i]=(i+1);
			}
				
			rptPageList.DataSource = pageNos;
			rptPageList.DataBind();
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			this.rptPageList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptPageList_ItemDataBound);
		}
		#endregion

		/// <summary>
		/// Event handler for the ItemDataBound event for the repeater control. In here the decision is made
		/// if the current item will be a link (we're not on this page) or not (thus a label)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rptPageList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			switch(e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.Item:
					if(_currentPage == (int)e.Item.DataItem)
					{
						Label lblMessagePage = (Label)e.Item.FindControl("lblMessagesPage");
						lblMessagePage.Visible=true;
					}
					else
					{
						HyperLink lnkResultPage = (HyperLink)e.Item.FindControl("lnkResultPage");
						lnkResultPage.NavigateUrl += (int)e.Item.DataItem;
						lnkResultPage.Visible=true;
					}
					break;
			}
		}

		#region Class Property Declarations
		/// <summary>
		/// sets amountPages
		/// </summary>
		public int AmountPages
		{
			set
			{
				_amountPages = value;
			}
		}

		/// <summary>
		/// sets currentPage
		/// </summary>
		public int CurrentPage
		{
			set
			{
				_currentPage = value;
			}
		}
		#endregion
	}
}
