using SD.HnD.DALAdapter.EntityClasses;

namespace SD.HnD.Gui.Models.Admin
{
	public class AddUsersToRoleData : ActionWithUserSearchData
	{
		public AddUsersToRoleData() : this(new FindUserData())
		{
		}

		public AddUsersToRoleData(FindUserData data) : base(data ?? new FindUserData())
		{
		}
		
		public int SelectedRoleID { get; set; }
		public string SelectedRoleDescription { get; set; }
	}
}