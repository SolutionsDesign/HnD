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
	/// <summary>Implements the static Relations variant for the entity: Forum. </summary>
	public partial class ForumRelations
	{
		/// <summary>CTor</summary>
		public ForumRelations()
		{
		}

		/// <summary>Gets all relations of the ForumEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ForumRoleForumActionRightEntityUsingForumID);
			toReturn.Add(this.ThreadEntityUsingForumID);
			toReturn.Add(this.SectionEntityUsingSectionID);
			toReturn.Add(this.SupportQueueEntityUsingDefaultSupportQueueID);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ForumEntity and ForumRoleForumActionRightEntity over the 1:n relation they have, using the relation between the fields:
		/// Forum.ForumID - ForumRoleForumActionRight.ForumID
		/// </summary>
		public virtual IEntityRelation ForumRoleForumActionRightEntityUsingForumID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ForumRoleForumActionRights" , true);
				relation.AddEntityFieldPair(ForumFields.ForumID, ForumRoleForumActionRightFields.ForumID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumRoleForumActionRightEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ForumEntity and ThreadEntity over the 1:n relation they have, using the relation between the fields:
		/// Forum.ForumID - Thread.ForumID
		/// </summary>
		public virtual IEntityRelation ThreadEntityUsingForumID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Threads" , true);
				relation.AddEntityFieldPair(ForumFields.ForumID, ThreadFields.ForumID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ForumEntity and SectionEntity over the m:1 relation they have, using the relation between the fields:
		/// Forum.SectionID - Section.SectionID
		/// </summary>
		public virtual IEntityRelation SectionEntityUsingSectionID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Section", false);
				relation.AddEntityFieldPair(SectionFields.SectionID, ForumFields.SectionID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SectionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ForumEntity and SupportQueueEntity over the m:1 relation they have, using the relation between the fields:
		/// Forum.DefaultSupportQueueID - SupportQueue.QueueID
		/// </summary>
		public virtual IEntityRelation SupportQueueEntityUsingDefaultSupportQueueID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DefaultSupportQueue", false);
				relation.AddEntityFieldPair(SupportQueueFields.QueueID, ForumFields.DefaultSupportQueueID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumEntity", true);
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
