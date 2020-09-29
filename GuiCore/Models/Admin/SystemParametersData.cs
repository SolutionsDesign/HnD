using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.Gui.Models.Admin
{
	public class SystemParametersData
	{
		public EntityCollection<RoleEntity> AllRoles { get; set; }
		public EntityCollection<UserTitleEntity> AllUserTitles { get; set; }
		public SystemDataEntity SystemData { get; set; }
		public bool Persisted { get; set; }
	}
}