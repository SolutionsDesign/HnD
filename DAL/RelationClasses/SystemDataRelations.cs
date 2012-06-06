///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
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
	/// <summary>Implements the relations factory for the entity: SystemData. </summary>
	public partial class SystemDataRelations
	{
		/// <summary>CTor</summary>
		public SystemDataRelations()
		{
		}

		/// <summary>Gets all relations of the SystemDataEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.RoleEntityUsingAnonymousRole);
			toReturn.Add(this.RoleEntityUsingDefaultRoleNewUser);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between SystemDataEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemData.AnonymousRole - Role.RoleID
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingAnonymousRole
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "RoleForAnonymous", false);
				relation.AddEntityFieldPair(RoleFields.RoleID, SystemDataFields.AnonymousRole);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemDataEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SystemDataEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// SystemData.DefaultRoleNewUser - Role.RoleID
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingDefaultRoleNewUser
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "RoleForNewUser", false);
				relation.AddEntityFieldPair(RoleFields.RoleID, SystemDataFields.DefaultRoleNewUser);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemDataEntity", true);
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
	internal static class StaticSystemDataRelations
	{
		internal static readonly IEntityRelation RoleEntityUsingAnonymousRoleStatic = new SystemDataRelations().RoleEntityUsingAnonymousRole;
		internal static readonly IEntityRelation RoleEntityUsingDefaultRoleNewUserStatic = new SystemDataRelations().RoleEntityUsingDefaultRoleNewUser;

		/// <summary>CTor</summary>
		static StaticSystemDataRelations()
		{
		}
	}
}
