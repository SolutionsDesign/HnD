///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
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
	/// <summary>Implements the relations factory for the entity: AuditAction. </summary>
	public partial class AuditActionRelations
	{
		/// <summary>CTor</summary>
		public AuditActionRelations()
		{
		}

		/// <summary>Gets all relations of the AuditActionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AuditDataCoreEntityUsingAuditActionID);
			toReturn.Add(this.RoleAuditActionEntityUsingAuditActionID);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AuditActionEntity and AuditDataCoreEntity over the 1:n relation they have, using the relation between the fields:
		/// AuditAction.AuditActionID - AuditDataCore.AuditActionID
		/// </summary>
		public virtual IEntityRelation AuditDataCoreEntityUsingAuditActionID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AuditDataCore" , true);
				relation.AddEntityFieldPair(AuditActionFields.AuditActionID, AuditDataCoreFields.AuditActionID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditActionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataCoreEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AuditActionEntity and RoleAuditActionEntity over the 1:n relation they have, using the relation between the fields:
		/// AuditAction.AuditActionID - RoleAuditAction.AuditActionID
		/// </summary>
		public virtual IEntityRelation RoleAuditActionEntityUsingAuditActionID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleAuditActions" , true);
				relation.AddEntityFieldPair(AuditActionFields.AuditActionID, RoleAuditActionFields.AuditActionID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditActionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAuditActionEntity", false);
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
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticAuditActionRelations
	{
		internal static readonly IEntityRelation AuditDataCoreEntityUsingAuditActionIDStatic = new AuditActionRelations().AuditDataCoreEntityUsingAuditActionID;
		internal static readonly IEntityRelation RoleAuditActionEntityUsingAuditActionIDStatic = new AuditActionRelations().RoleAuditActionEntityUsingAuditActionID;

		/// <summary>CTor</summary>
		static StaticAuditActionRelations()
		{
		}
	}
}
