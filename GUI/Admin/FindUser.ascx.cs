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
namespace SD.HnD.GUI.Admin
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	using SD.LLBLGen.Pro.ORMSupportClasses;
	using SD.HnD.DAL.CollectionClasses;
	using SD.HnD.DAL.EntityClasses;
	using SD.HnD.BL;
	using System.Collections.Generic;

	/// <summary>
	///		Summary description for FindUser.
	/// </summary>
	public partial class FindUser : System.Web.UI.UserControl
	{
		#region Events
		public event EventHandler SelectClicked;
		#endregion

		#region Class Member Declarations
		protected string	_description;

		private bool	_multiSelect;
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			_description = "user";
			if(_multiSelect)
			{
				_description = "users";
			}

			if(!Page.IsPostBack)
			{
				RoleCollection roles = SecurityGuiHelper.GetAllRoles();
				cbxRoles.DataSource = roles;
				cbxRoles.DataTextField = "RoleDescription";
				cbxRoles.DataValueField = "RoleID";
				cbxRoles.DataBind();
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
			bool bHandled = false;

			CommandEventArgs ceArgs = e as CommandEventArgs;
			if(ceArgs != null)
			{
				switch(ceArgs.CommandName)
				{
					case "btnFindUsers":
						OnFind(ceArgs);
						bHandled = true;   
						break;
					case "btnSelect":
						OnSelect(ceArgs);
						break;
				}
			}
			return bHandled;            
		}


		/// <summary>
		/// Finds the user specified in the filter.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected virtual void OnFind(EventArgs e)
		{
			if(!(chkFilterOnRole.Checked || chkFilterOnNickName.Checked || chkFilterOnEmailAddress.Checked))
			{
				// nothing selected
				return;
			}

			UserCollection matchingUsers = UserGuiHelper.FindUsers(chkFilterOnRole.Checked, Convert.ToInt32(cbxRoles.SelectedValue), 
					chkFilterOnNickName.Checked, tbxNickName.Text.Trim(), 
					chkFilterOnEmailAddress.Checked, tbxEmailAddress.Text.Trim());

			lbxMatchingUsers.DataSource = matchingUsers;
			lbxMatchingUsers.DataTextField = "NickName";
			lbxMatchingUsers.DataValueField = "UserID";
			lbxMatchingUsers.DataBind();
			phSearchResults.Visible = true;
			btnSelect.Enabled = (matchingUsers.Count>0);
		}


		/// <summary>
		/// Raises the SelectClicked event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected virtual void OnSelect(EventArgs e)
		{
			if(lbxMatchingUsers.SelectedIndex<0)
			{
				return;
			}

			if(SelectClicked!=null)
			{
				SelectClicked(this, new EventArgs());
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Sets the button description.
		/// </summary>
		/// <value>The button description.</value>
		public string ButtonDescription
		{
			set
			{
				btnSelect.Text = value;
			}
		}

		/// <summary>
		/// Gets / sets multiSelect
		/// </summary>
		public bool MultiSelect
		{
			get
			{
				return _multiSelect;
			}
			set
			{
				_multiSelect = value;
				if(value)
				{
					lbxMatchingUsers.SelectionMode = ListSelectionMode.Multiple;
				}
				else
				{
					lbxMatchingUsers.SelectionMode = ListSelectionMode.Single;
				}
			}
		}


		/// <summary>
		/// Gets the selected userIDs.
		/// </summary>
		public List<int> SelectedUserIDs
		{
			get
			{
				List<int> toReturn = new List<int>();
				if(_multiSelect)
				{
					foreach(ListItem item in lbxMatchingUsers.Items)
					{
						if(item.Selected)
						{
							toReturn.Add(Convert.ToInt32(item.Value));
						}
					}
				}
				else
				{
					toReturn.Add(Convert.ToInt32(lbxMatchingUsers.SelectedValue));
				}

				return toReturn;
			}
		}

		#endregion
	}
}
