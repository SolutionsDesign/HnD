///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.2
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Role. </summary>
	public partial class RoleRelations
	{
		/// <summary>CTor</summary>
		public RoleRelations()
		{
		}

		/// <summary>Gets all relations of the RoleEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ForumRoleForumActionRightEntityUsingRoleID);
			toReturn.Add(this.RoleAuditActionEntityUsingRoleID);
			toReturn.Add(this.RoleSystemActionRightEntityUsingRoleID);
			toReturn.Add(this.RoleUserEntityUsingRoleID);
			toReturn.Add(this.SystemDataEntityUsingAnonymousRole);
			toReturn.Add(this.SystemDataEntityUsingDefaultRoleNewUser);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and ForumRoleForumActionRightEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleID - ForumRoleForumActionRight.RoleID
		/// </summary>
		public virtual IEntityRelation ForumRoleForumActionRightEntityUsingRoleID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ForumRoleForumActionRights" , true);
				relation.AddEntityFieldPair(RoleFields.RoleID, ForumRoleForumActionRightFields.RoleID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumRoleForumActionRightEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and RoleAuditActionEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleID - RoleAuditAction.RoleID
		/// </summary>
		public virtual IEntityRelation RoleAuditActionEntityUsingRoleID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleAuditAction" , true);
				relation.AddEntityFieldPair(RoleFields.RoleID, RoleAuditActionFields.RoleID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAuditActionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and RoleSystemActionRightEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleID - RoleSystemActionRight.RoleID
		/// </summary>
		public virtual IEntityRelation RoleSystemActionRightEntityUsingRoleID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleSystemActionRights" , true);
				relation.AddEntityFieldPair(RoleFields.RoleID, RoleSystemActionRightFields.RoleID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleSystemActionRightEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and RoleUserEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleID - RoleUser.RoleID
		/// </summary>
		public virtual IEntityRelation RoleUserEntityUsingRoleID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleUser" , true);
				relation.AddEntityFieldPair(RoleFields.RoleID, RoleUserFields.RoleID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleUserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and SystemDataEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleID - SystemData.AnonymousRole
		/// </summary>
		public virtual IEntityRelation SystemDataEntityUsingAnonymousRole
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemDataAnonymousRole" , true);
				relation.AddEntityFieldPair(RoleFields.RoleID, SystemDataFields.AnonymousRole);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and SystemDataEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleID - SystemData.DefaultRoleNewUser
		/// </summary>
		public virtual IEntityRelation SystemDataEntityUsingDefaultRoleNewUser
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemDataDefaultRoleNewUser" , true);
				relation.AddEntityFieldPair(RoleFields.RoleID, SystemDataFields.DefaultRoleNewUser);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemDataEntity", false);
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
	internal static class StaticRoleRelations
	{
		internal static readonly IEntityRelation ForumRoleForumActionRightEntityUsingRoleIDStatic = new RoleRelations().ForumRoleForumActionRightEntityUsingRoleID;
		internal static readonly IEntityRelation RoleAuditActionEntityUsingRoleIDStatic = new RoleRelations().RoleAuditActionEntityUsingRoleID;
		internal static readonly IEntityRelation RoleSystemActionRightEntityUsingRoleIDStatic = new RoleRelations().RoleSystemActionRightEntityUsingRoleID;
		internal static readonly IEntityRelation RoleUserEntityUsingRoleIDStatic = new RoleRelations().RoleUserEntityUsingRoleID;
		internal static readonly IEntityRelation SystemDataEntityUsingAnonymousRoleStatic = new RoleRelations().SystemDataEntityUsingAnonymousRole;
		internal static readonly IEntityRelation SystemDataEntityUsingDefaultRoleNewUserStatic = new RoleRelations().SystemDataEntityUsingDefaultRoleNewUser;

		/// <summary>CTor</summary>
		static StaticRoleRelations()
		{
		}
	}
}
