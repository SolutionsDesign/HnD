using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.Gui.Classes;
using SD.Tools.Algorithmia.GeneralDataStructures;

namespace SD.HnD.Gui.Models.Admin
{
	/// <summary>
	/// Model class for the find user process.
	/// </summary>
	public class FindUserData
	{
		public FindUserData() : this(AdminFindUserState.Start)
		{
		}
		
		public FindUserData(AdminFindUserState state)
		{
			this.FindUserState = state;
			this.SingleSelect = false;
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

		public bool IsAnythingChecked
		{
			get { return this.FilterOnRole || this.FilterOnEmailAddress || this.FilterOnNickName;  }
		}


		public string FilterToString()
		{
			if(!this.IsAnythingChecked)
			{
				return "No filter specified";
			}

			var fragments = new List<string>();
			if(this.FilterOnRole)
			{
				fragments.Add(string.Format("Role: {0}", this.Roles?.FirstOrDefault(r=>r.RoleID==SelectedRoleID)?.RoleDescription));
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
	}
}