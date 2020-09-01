using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.Gui.Models.Admin
{
	public class ShowAuditInfoUserData : ActionWithUserSearchData
	{
		public ShowAuditInfoUserData() : this(new FindUserData())
		{
		}


		public ShowAuditInfoUserData(FindUserData data) : base(data)
		{
			this.AuditData = new EntityCollection<AuditDataCoreEntity>();
		}


		public EntityCollection<AuditDataCoreEntity> AuditData { get; set; }
		public UserEntity AuditedUser { get; set; }
	}
}