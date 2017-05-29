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
	/// <summary>Implements the relations factory for the entity: Message. </summary>
	public partial class MessageRelations
	{
		/// <summary>CTor</summary>
		public MessageRelations()
		{
		}

		/// <summary>Gets all relations of the MessageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AttachmentEntityUsingMessageID);
			toReturn.Add(this.AuditDataMessageRelatedEntityUsingMessageID);
			toReturn.Add(this.ThreadEntityUsingThreadID);
			toReturn.Add(this.UserEntityUsingPostedByUserID);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MessageEntity and AttachmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Message.MessageID - Attachment.MessageID
		/// </summary>
		public virtual IEntityRelation AttachmentEntityUsingMessageID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Attachments" , true);
				relation.AddEntityFieldPair(MessageFields.MessageID, AttachmentFields.MessageID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MessageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AttachmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MessageEntity and AuditDataMessageRelatedEntity over the 1:n relation they have, using the relation between the fields:
		/// Message.MessageID - AuditDataMessageRelated.MessageID
		/// </summary>
		public virtual IEntityRelation AuditDataMessageRelatedEntityUsingMessageID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AuditDataMessageRelated" , true);
				relation.AddEntityFieldPair(MessageFields.MessageID, AuditDataMessageRelatedFields.MessageID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MessageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataMessageRelatedEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MessageEntity and ThreadEntity over the m:1 relation they have, using the relation between the fields:
		/// Message.ThreadID - Thread.ThreadID
		/// </summary>
		public virtual IEntityRelation ThreadEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Thread", false);
				relation.AddEntityFieldPair(ThreadFields.ThreadID, MessageFields.ThreadID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MessageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between MessageEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Message.PostedByUserID - User.UserID
		/// </summary>
		public virtual IEntityRelation UserEntityUsingPostedByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "PostedByUser", false);
				relation.AddEntityFieldPair(UserFields.UserID, MessageFields.PostedByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MessageEntity", true);
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
	internal static class StaticMessageRelations
	{
		internal static readonly IEntityRelation AttachmentEntityUsingMessageIDStatic = new MessageRelations().AttachmentEntityUsingMessageID;
		internal static readonly IEntityRelation AuditDataMessageRelatedEntityUsingMessageIDStatic = new MessageRelations().AuditDataMessageRelatedEntityUsingMessageID;
		internal static readonly IEntityRelation ThreadEntityUsingThreadIDStatic = new MessageRelations().ThreadEntityUsingThreadID;
		internal static readonly IEntityRelation UserEntityUsingPostedByUserIDStatic = new MessageRelations().UserEntityUsingPostedByUserID;

		/// <summary>CTor</summary>
		static StaticMessageRelations()
		{
		}
	}
}
