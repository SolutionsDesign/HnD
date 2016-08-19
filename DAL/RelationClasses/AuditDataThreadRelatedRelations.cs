///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.0
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
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
	/// <summary>Implements the relations factory for the entity: AuditDataThreadRelated. </summary>
	public partial class AuditDataThreadRelatedRelations : AuditDataCoreRelations
	{
		/// <summary>CTor</summary>
		public AuditDataThreadRelatedRelations()
		{
		}

		/// <summary>Gets all relations of the AuditDataThreadRelatedEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = base.GetAllRelations();
			toReturn.Add(this.ThreadEntityUsingThreadID);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AuditDataThreadRelatedEntity and AuditActionEntity over the m:1 relation they have, using the relation between the fields:
		/// AuditDataThreadRelated.AuditActionID - AuditAction.AuditActionID
		/// </summary>
		public override IEntityRelation AuditActionEntityUsingAuditActionID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AuditAction", false);
				relation.AddEntityFieldPair(AuditActionFields.AuditActionID, AuditDataThreadRelatedFields.AuditActionID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditActionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataThreadRelatedEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AuditDataThreadRelatedEntity and ThreadEntity over the m:1 relation they have, using the relation between the fields:
		/// AuditDataThreadRelated.ThreadID - Thread.ThreadID
		/// </summary>
		public virtual IEntityRelation ThreadEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Thread", false);
				relation.AddEntityFieldPair(ThreadFields.ThreadID, AuditDataThreadRelatedFields.ThreadID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataThreadRelatedEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AuditDataThreadRelatedEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// AuditDataThreadRelated.UserID - User.UserID
		/// </summary>
		public override IEntityRelation UserEntityUsingUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UserAudited", false);
				relation.AddEntityFieldPair(UserFields.UserID, AuditDataThreadRelatedFields.UserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataThreadRelatedEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AuditDataThreadRelatedEntity and AuditDataCoreEntity over the 1:1 relation they have, which is used to build a target per entity hierarchy</summary>
		internal IEntityRelation RelationToSuperTypeAuditDataCoreEntity
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, false);
				relation.AddEntityFieldPair(AuditDataCoreFields.AuditDataID, AuditDataThreadRelatedFields.AuditDataID);
				relation.IsHierarchyRelation=true;
				return relation;
			}
		}

		
		/// <summary>Returns the relation object the entity, to which this relation factory belongs, has with the subtype with the specified name</summary>
		/// <param name="subTypeEntityName">name of direct subtype which is a subtype of the current entity through the relation to return.</param>
		/// <returns>relation which makes the current entity a supertype of the subtype entity with the name specified, or null if not applicable/found</returns>
		public override IEntityRelation GetSubTypeRelation(string subTypeEntityName)
		{
			return null;
		}
		
		/// <summary>Returns the relation object the entity, to which this relation factory belongs, has with its supertype, if applicable.</summary>
		/// <returns>relation which makes the current entity a subtype of its supertype entity or null if not applicable/found</returns>
		public override IEntityRelation GetSuperTypeRelation()
		{
			return this.RelationToSuperTypeAuditDataCoreEntity;
		}

		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticAuditDataThreadRelatedRelations
	{
		internal static readonly IEntityRelation AuditActionEntityUsingAuditActionIDStatic = new AuditDataThreadRelatedRelations().AuditActionEntityUsingAuditActionID;
		internal static readonly IEntityRelation ThreadEntityUsingThreadIDStatic = new AuditDataThreadRelatedRelations().ThreadEntityUsingThreadID;
		internal static readonly IEntityRelation UserEntityUsingUserIDStatic = new AuditDataThreadRelatedRelations().UserEntityUsingUserID;

		/// <summary>CTor</summary>
		static StaticAuditDataThreadRelatedRelations()
		{
		}
	}
}
