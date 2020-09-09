using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.Gui.Models.Admin
{
	public class UsersInRolesData
	{
		public int RoleID { get; set; }
		public EntityCollection<RoleEntity> AvailableRoles { get; set; }
	}
}