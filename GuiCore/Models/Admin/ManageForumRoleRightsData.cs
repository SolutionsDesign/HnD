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