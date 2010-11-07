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
	/// <summary>Implements the static Relations variant for the entity: AuditDataMessageRelated. </summary>
	public partial class AuditDataMessageRelatedRelations : AuditDataCoreRelations
	{
		/// <summary>CTor</summary>
		public AuditDataMessageRelatedRelations()
		{
		}

		/// <summary>Gets all relations of the AuditDataMessageRelatedEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = base.GetAllRelations();
			toReturn.Add(this.MessageEntityUsingMessageID);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between AuditDataMessageRelatedEntity and AuditActionEntity over the m:1 relation they have, using the relation between the fields:
		/// AuditDataMessageRelated.AuditActionID - AuditAction.AuditActionID
		/// </summary>
		public override IEntityRelation AuditActionEntityUsingAuditActionID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AuditAction", false);
				relation.AddEntityFieldPair(AuditActionFields.AuditActionID, AuditDataMessageRelatedFields.AuditActionID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditActionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataMessageRelatedEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AuditDataMessageRelatedEntity and MessageEntity over the m:1 relation they have, using the relation between the fields:
		/// AuditDataMessageRelated.MessageID - Message.MessageID
		/// </summary>
		public virtual IEntityRelation MessageEntityUsingMessageID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Message", false);
				relation.AddEntityFieldPair(MessageFields.MessageID, AuditDataMessageRelatedFields.MessageID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MessageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataMessageRelatedEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AuditDataMessageRelatedEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// AuditDataMessageRelated.UserID - User.UserID
		/// </summary>
		public override IEntityRelation UserEntityUsingUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UserAudited", false);
				relation.AddEntityFieldPair(UserFields.UserID, AuditDataMessageRelatedFields.UserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataMessageRelatedEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AuditDataMessageRelatedEntity and AuditDataCoreEntity over the 1:1 relation they have, which is used to build a target per entity hierarchy</summary>
		internal IEntityRelation RelationToSuperTypeAuditDataCoreEntity
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, false);
				relation.AddEntityFieldPair(AuditDataCoreFields.AuditDataID, AuditDataMessageRelatedFields.AuditDataID);
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
}
