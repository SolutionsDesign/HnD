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
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.TypedListClasses;

namespace SD.HnD.Gui.Models.Admin
{
	public class ManageForumRoleRightsData
	{
		public ManageForumRoleRightsData()
		{
			this.ActionRightsSet = new List<int>();
			this.LastActionResult = string.Empty;
		}


		public int RoleID { get; set; }
		public int ForumID { get; set; }
		public List<int> ActionRightsSet { get; set; }
		public EntityCollection<RoleEntity> AvailableRoles { get; set; }
		public EntityCollection<ActionRightEntity> AvailableActionRights { get; set; }
		public List<ForumsWithSectionNameRow> AvailableForums { get; set; }
		public string LastActionResult { get; set; }
	}
}