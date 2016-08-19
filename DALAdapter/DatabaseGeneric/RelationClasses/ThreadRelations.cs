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
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Thread. </summary>
	public partial class ThreadRelations
	{
		/// <summary>CTor</summary>
		public ThreadRelations()
		{
		}

		/// <summary>Gets all relations of the ThreadEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AuditDataThreadRelatedEntityUsingThreadID);
			toReturn.Add(this.BookmarkEntityUsingThreadID);
			toReturn.Add(this.MessageEntityUsingThreadID);
			toReturn.Add(this.ThreadSubscriptionEntityUsingThreadID);
			toReturn.Add(this.SupportQueueThreadEntityUsingThreadID);
			toReturn.Add(this.ForumEntityUsingForumID);
			toReturn.Add(this.UserEntityUsingStartedByUserID);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and AuditDataThreadRelatedEntity over the 1:n relation they have, using the relation between the fields:
		/// Thread.ThreadID - AuditDataThreadRelated.ThreadID
		/// </summary>
		public virtual IEntityRelation AuditDataThreadRelatedEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AuditDataThreadRelated" , true);
				relation.AddEntityFieldPair(ThreadFields.ThreadID, AuditDataThreadRelatedFields.ThreadID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataThreadRelatedEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and BookmarkEntity over the 1:n relation they have, using the relation between the fields:
		/// Thread.ThreadID - Bookmark.ThreadID
		/// </summary>
		public virtual IEntityRelation BookmarkEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PresentInBookmarks" , true);
				relation.AddEntityFieldPair(ThreadFields.ThreadID, BookmarkFields.ThreadID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BookmarkEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and MessageEntity over the 1:n relation they have, using the relation between the fields:
		/// Thread.ThreadID - Message.ThreadID
		/// </summary>
		public virtual IEntityRelation MessageEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Messages" , true);
				relation.AddEntityFieldPair(ThreadFields.ThreadID, MessageFields.ThreadID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MessageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and ThreadSubscriptionEntity over the 1:n relation they have, using the relation between the fields:
		/// Thread.ThreadID - ThreadSubscription.ThreadID
		/// </summary>
		public virtual IEntityRelation ThreadSubscriptionEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ThreadSubscription" , true);
				relation.AddEntityFieldPair(ThreadFields.ThreadID, ThreadSubscriptionFields.ThreadID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadSubscriptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and SupportQueueThreadEntity over the 1:1 relation they have, using the relation between the fields:
		/// Thread.ThreadID - SupportQueueThread.ThreadID
		/// </summary>
		public virtual IEntityRelation SupportQueueThreadEntityUsingThreadID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "SupportQueueThread", true);


				relation.AddEntityFieldPair(ThreadFields.ThreadID, SupportQueueThreadFields.ThreadID);


				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueThreadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and ForumEntity over the m:1 relation they have, using the relation between the fields:
		/// Thread.ForumID - Forum.ForumID
		/// </summary>
		public virtual IEntityRelation ForumEntityUsingForumID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Forum", false);
				relation.AddEntityFieldPair(ForumFields.ForumID, ThreadFields.ForumID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// Thread.StartedByUserID - User.UserID
		/// </summary>
		public virtual IEntityRelation UserEntityUsingStartedByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UserWhoStartedThread", false);
				relation.AddEntityFieldPair(UserFields.UserID, ThreadFields.StartedByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", true);
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
	internal static class StaticThreadRelations
	{
		internal static readonly IEntityRelation AuditDataThreadRelatedEntityUsingThreadIDStatic = new ThreadRelations().AuditDataThreadRelatedEntityUsingThreadID;
		internal static readonly IEntityRelation BookmarkEntityUsingThreadIDStatic = new ThreadRelations().BookmarkEntityUsingThreadID;
		internal static readonly IEntityRelation MessageEntityUsingThreadIDStatic = new ThreadRelations().MessageEntityUsingThreadID;
		internal static readonly IEntityRelation ThreadSubscriptionEntityUsingThreadIDStatic = new ThreadRelations().ThreadSubscriptionEntityUsingThreadID;
		internal static readonly IEntityRelation SupportQueueThreadEntityUsingThreadIDStatic = new ThreadRelations().SupportQueueThreadEntityUsingThreadID;
		internal static readonly IEntityRelation ForumEntityUsingForumIDStatic = new ThreadRelations().ForumEntityUsingForumID;
		internal static readonly IEntityRelation UserEntityUsingStartedByUserIDStatic = new ThreadRelations().UserEntityUsingStartedByUserID;

		/// <summary>CTor</summary>
		static StaticThreadRelations()
		{
		}
	}
}
