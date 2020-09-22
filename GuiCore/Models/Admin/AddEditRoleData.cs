using System.Collections.Generic;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.Gui.Models.Admin
{
	public class AddEditRoleData
	{
		public AddEditRoleData()
		{
			this.RoleEdited = new RoleEntity();
		}
		
		public RoleEntity RoleEdited { get; set; }
		public List<int> SystemRightsSet { get; set; }
		public EntityCollection<ActionRightEntity> AvailableSystemRights { get; set; }
		public List<int> AuditActionsSet { get; set; }
		public EntityCollection<AuditActionEntity> AvailableAuditActions { get; set; }
	}
}