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
	/// <summary>Implements the relations factory for the entity: ActionRight. </summary>
	public partial class ActionRightRelations
	{
		/// <summary>CTor</summary>
		public ActionRightRelations()
		{
		}

		/// <summary>Gets all relations of the ActionRightEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ForumRoleForumActionRightEntityUsingActionRightID);
			toReturn.Add(this.RoleSystemActionRightEntityUsingActionRightID);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ActionRightEntity and ForumRoleForumActionRightEntity over the 1:n relation they have, using the relation between the fields:
		/// ActionRight.ActionRightID - ForumRoleForumActionRight.ActionRightID
		/// </summary>
		public virtual IEntityRelation ForumRoleForumActionRightEntityUsingActionRightID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ForumRoleForumActionRights" , true);
				relation.AddEntityFieldPair(ActionRightFields.ActionRightID, ForumRoleForumActionRightFields.ActionRightID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionRightEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumRoleForumActionRightEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ActionRightEntity and RoleSystemActionRightEntity over the 1:n relation they have, using the relation between the fields:
		/// ActionRight.ActionRightID - RoleSystemActionRight.ActionRightID
		/// </summary>
		public virtual IEntityRelation RoleSystemActionRightEntityUsingActionRightID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleSystemActionRights" , true);
				relation.AddEntityFieldPair(ActionRightFields.ActionRightID, RoleSystemActionRightFields.ActionRightID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionRightEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleSystemActionRightEntity", false);
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
	internal static class StaticActionRightRelations
	{
		internal static readonly IEntityRelation ForumRoleForumActionRightEntityUsingActionRightIDStatic = new ActionRightRelations().ForumRoleForumActionRightEntityUsingActionRightID;
		internal static readonly IEntityRelation RoleSystemActionRightEntityUsingActionRightIDStatic = new ActionRightRelations().RoleSystemActionRightEntityUsingActionRightID;

		/// <summary>CTor</summary>
		static StaticActionRightRelations()
		{
		}
	}
}
