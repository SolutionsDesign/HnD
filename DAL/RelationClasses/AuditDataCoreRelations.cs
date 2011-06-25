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
	/// <summary>Implements the relations factory for the entity: AuditDataCore. </summary>
	public partial class AuditDataCoreRelations : IRelationFactory
	{
		/// <summary>CTor</summary>
		public AuditDataCoreRelations()
		{
		}

		/// <summary>Gets all relations of the AuditDataCoreEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AuditActionEntityUsingAuditActionID);
			toReturn.Add(this.UserEntityUsingUserID);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AuditDataCoreEntity and AuditActionEntity over the m:1 relation they have, using the relation between the fields:
		/// AuditDataCore.AuditActionID - AuditAction.AuditActionID
		/// </summary>
		public virtual IEntityRelation AuditActionEntityUsingAuditActionID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AuditAction", false);
				relation.AddEntityFieldPair(AuditActionFields.AuditActionID, AuditDataCoreFields.AuditActionID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditActionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataCoreEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AuditDataCoreEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// AuditDataCore.UserID - User.UserID
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UserAudited", false);
				relation.AddEntityFieldPair(UserFields.UserID, AuditDataCoreFields.UserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataCoreEntity", true);
				return relation;
			}
		}



		/// <summary>Returns a new IEntityRelation object, between AuditDataCoreEntity and AuditDataMessageRelatedEntity over the 1:1 relation they have, which is used to build a target per entity hierarchy</summary>		
		internal IEntityRelation RelationToSubTypeAuditDataMessageRelatedEntity
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, true);
				relation.AddEntityFieldPair(AuditDataCoreFields.AuditDataID, AuditDataMessageRelatedFields.AuditDataID);
				relation.IsHierarchyRelation=true;
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AuditDataCoreEntity and AuditDataThreadRelatedEntity over the 1:1 relation they have, which is used to build a target per entity hierarchy</summary>		
		internal IEntityRelation RelationToSubTypeAuditDataThreadRelatedEntity
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, true);
				relation.AddEntityFieldPair(AuditDataCoreFields.AuditDataID, AuditDataThreadRelatedFields.AuditDataID);
				relation.IsHierarchyRelation=true;
				return relation;
			}
		}
		
		/// <summary>Returns the relation object the entity, to which this relation factory belongs, has with the subtype with the specified name</summary>
		/// <param name="subTypeEntityName">name of direct subtype which is a subtype of the current entity through the relation to return.</param>
		/// <returns>relation which makes the current entity a supertype of the subtype entity with the name specified, or null if not applicable/found</returns>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName)
		{
			switch(subTypeEntityName)
			{
				case "AuditDataMessageRelatedEntity":
					return this.RelationToSubTypeAuditDataMessageRelatedEntity;
				case "AuditDataThreadRelatedEntity":
					return this.RelationToSubTypeAuditDataThreadRelatedEntity;
				default:
					return null;
			}
		}
		
		/// <summary>Returns the relation object the entity, to which this relation factory belongs, has with its supertype, if applicable.</summary>
		/// <returns>relation which makes the current entity a subtype of its supertype entity or null if not applicable/found</returns>
		public virtual IEntityRelation GetSuperTypeRelation()
		{
			return null;
		}

		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticAuditDataCoreRelations
	{
		internal static readonly IEntityRelation AuditActionEntityUsingAuditActionIDStatic = new AuditDataCoreRelations().AuditActionEntityUsingAuditActionID;
		internal static readonly IEntityRelation UserEntityUsingUserIDStatic = new AuditDataCoreRelations().UserEntityUsingUserID;

		/// <summary>CTor</summary>
		static StaticAuditDataCoreRelations()
		{
		}
	}
}
