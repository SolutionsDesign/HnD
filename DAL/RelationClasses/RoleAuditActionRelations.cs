///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.0
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using SD.HnD.DAL;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: RoleAuditAction. </summary>
	public partial class RoleAuditActionRelations
	{
		/// <summary>CTor</summary>
		public RoleAuditActionRelations()
		{
		}

		/// <summary>Gets all relations of the RoleAuditActionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AuditActionEntityUsingAuditActionID);
			toReturn.Add(this.RoleEntityUsingRoleID);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between RoleAuditActionEntity and AuditActionEntity over the m:1 relation they have, using the relation between the fields:
		/// RoleAuditAction.AuditActionID - AuditAction.AuditActionID
		/// </summary>
		public virtual IEntityRelation AuditActionEntityUsingAuditActionID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AuditAction", false);
				relation.AddEntityFieldPair(AuditActionFields.AuditActionID, RoleAuditActionFields.AuditActionID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditActionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAuditActionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between RoleAuditActionEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// RoleAuditAction.RoleID - Role.RoleID
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingRoleID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleID, RoleAuditActionFields.RoleID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAuditActionEntity", true);
				return relation;
			}
		}
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
}
