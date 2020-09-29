/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
    https://www.llblgen.com
	https://www.sd.nl

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

using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.Gui.Classes;

namespace SD.HnD.Gui.Models.Admin
{
	/// <summary>
	/// Model class for the find user process.
	/// </summary>
	public class FindUserData
	{
		private string _filterAsString = string.Empty;


		public FindUserData() : this(AdminFindUserState.Start)
		{
		}


		public FindUserData(AdminFindUserState state)
		{
			this.FindUserState = state;
			this.SingleSelect = false;
		}


		public string FilterToString()
		{
			if(!string.IsNullOrWhiteSpace(_filterAsString))
			{
				return _filterAsString;
			}

			if(!this.IsAnythingChecked)
			{
				return "No filter specified";
			}

			var fragments = new List<string>();
			if(this.FilterOnRole)
			{
				fragments.Add(string.Format("Role: {0}", this.Roles?.FirstOrDefault(r => r.RoleID == SelectedRoleID)?.RoleDescription));
			}

			if(this.FilterOnNickName)
			{
				fragments.Add(string.Format("Nickname: {0}", this.SpecifiedNickName));
			}

			if(this.FilterOnEmailAddress)
			{
				fragments.Add(string.Format("Email-address: {0}", this.SpecifiedEmailAddress));
			}

			return string.Join(", ", fragments);
		}


		public AdminFindUserState FindUserState { get; set; }
		public EntityCollection<RoleEntity> Roles { get; set; }
		public bool SingleSelect { get; set; }
		public string ActionToPostTo { get; set; }
		public string ActionButtonText { get; set; }
		public EntityCollection<UserEntity> FoundUsers { get; set; }
		public List<int> SelectedUserIDs { get; set; }
		public EntityCollection<UserEntity> SelectedUsers { get; set; }

		public bool FilterOnRole { get; set; }
		public bool FilterOnNickName { get; set; }
		public bool FilterOnEmailAddress { get; set; }
		public int SelectedRoleID { get; set; }
		public string SpecifiedNickName { get; set; }
		public string SpecifiedEmailAddress { get; set; }


		public void OverrideFilterAsString(string toUse)
		{
			_filterAsString = toUse;
		}


		public bool IsAnythingChecked
		{
			get { return this.FilterOnRole || this.FilterOnEmailAddress || this.FilterOnNickName; }
		}
	}
}