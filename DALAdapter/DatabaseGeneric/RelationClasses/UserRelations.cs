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
	/// <summary>Implements the relations factory for the entity: User. </summary>
	public partial class UserRelations
	{
		/// <summary>CTor</summary>
		public UserRelations()
		{
		}

		/// <summary>Gets all relations of the UserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AuditDataCoreEntityUsingUserID);
			toReturn.Add(this.BookmarkEntityUsingUserID);
			toReturn.Add(this.IPBanEntityUsingIPBanSetByUserID);
			toReturn.Add(this.MessageEntityUsingPostedByUserID);
			toReturn.Add(this.RoleUserEntityUsingUserID);
			toReturn.Add(this.SupportQueueThreadEntityUsingClaimedByUserID);
			toReturn.Add(this.SupportQueueThreadEntityUsingPlacedInQueueByUserID);
			toReturn.Add(this.ThreadEntityUsingStartedByUserID);
			toReturn.Add(this.ThreadSubscriptionEntityUsingUserID);
			toReturn.Add(this.UserTitleEntityUsingUserTitleID);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between UserEntity and AuditDataCoreEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - AuditDataCore.UserID
		/// </summary>
		public virtual IEntityRelation AuditDataCoreEntityUsingUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LoggedAudits" , true);
				relation.AddEntityFieldPair(UserFields.UserID, AuditDataCoreFields.UserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AuditDataCoreEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and BookmarkEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - Bookmark.UserID
		/// </summary>
		public virtual IEntityRelation BookmarkEntityUsingUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Bookmarks" , true);
				relation.AddEntityFieldPair(UserFields.UserID, BookmarkFields.UserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BookmarkEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and IPBanEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - IPBan.IPBanSetByUserID
		/// </summary>
		public virtual IEntityRelation IPBanEntityUsingIPBanSetByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IPBansSet" , true);
				relation.AddEntityFieldPair(UserFields.UserID, IPBanFields.IPBanSetByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IPBanEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and MessageEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - Message.PostedByUserID
		/// </summary>
		public virtual IEntityRelation MessageEntityUsingPostedByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PostedMessages" , true);
				relation.AddEntityFieldPair(UserFields.UserID, MessageFields.PostedByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MessageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and RoleUserEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - RoleUser.UserID
		/// </summary>
		public virtual IEntityRelation RoleUserEntityUsingUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleUser" , true);
				relation.AddEntityFieldPair(UserFields.UserID, RoleUserFields.UserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleUserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and SupportQueueThreadEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - SupportQueueThread.ClaimedByUserID
		/// </summary>
		public virtual IEntityRelation SupportQueueThreadEntityUsingClaimedByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SupportQueueThreadsClaimed" , true);
				relation.AddEntityFieldPair(UserFields.UserID, SupportQueueThreadFields.ClaimedByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueThreadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and SupportQueueThreadEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - SupportQueueThread.PlacedInQueueByUserID
		/// </summary>
		public virtual IEntityRelation SupportQueueThreadEntityUsingPlacedInQueueByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SupportQueueThreadsPlaced" , true);
				relation.AddEntityFieldPair(UserFields.UserID, SupportQueueThreadFields.PlacedInQueueByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueThreadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and ThreadEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - Thread.StartedByUserID
		/// </summary>
		public virtual IEntityRelation ThreadEntityUsingStartedByUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StartedThreads" , true);
				relation.AddEntityFieldPair(UserFields.UserID, ThreadFields.StartedByUserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and ThreadSubscriptionEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserID - ThreadSubscription.UserID
		/// </summary>
		public virtual IEntityRelation ThreadSubscriptionEntityUsingUserID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ThreadSubscription" , true);
				relation.AddEntityFieldPair(UserFields.UserID, ThreadSubscriptionFields.UserID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ThreadSubscriptionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserTitleEntity over the m:1 relation they have, using the relation between the fields:
		/// User.UserTitleID - UserTitle.UserTitleID
		/// </summary>
		public virtual IEntityRelation UserTitleEntityUsingUserTitleID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "UserTitle", false);
				relation.AddEntityFieldPair(UserTitleFields.UserTitleID, UserFields.UserTitleID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserTitleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
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
	internal static class StaticUserRelations
	{
		internal static readonly IEntityRelation AuditDataCoreEntityUsingUserIDStatic = new UserRelations().AuditDataCoreEntityUsingUserID;
		internal static readonly IEntityRelation BookmarkEntityUsingUserIDStatic = new UserRelations().BookmarkEntityUsingUserID;
		internal static readonly IEntityRelation IPBanEntityUsingIPBanSetByUserIDStatic = new UserRelations().IPBanEntityUsingIPBanSetByUserID;
		internal static readonly IEntityRelation MessageEntityUsingPostedByUserIDStatic = new UserRelations().MessageEntityUsingPostedByUserID;
		internal static readonly IEntityRelation RoleUserEntityUsingUserIDStatic = new UserRelations().RoleUserEntityUsingUserID;
		internal static readonly IEntityRelation SupportQueueThreadEntityUsingClaimedByUserIDStatic = new UserRelations().SupportQueueThreadEntityUsingClaimedByUserID;
		internal static readonly IEntityRelation SupportQueueThreadEntityUsingPlacedInQueueByUserIDStatic = new UserRelations().SupportQueueThreadEntityUsingPlacedInQueueByUserID;
		internal static readonly IEntityRelation ThreadEntityUsingStartedByUserIDStatic = new UserRelations().ThreadEntityUsingStartedByUserID;
		internal static readonly IEntityRelation ThreadSubscriptionEntityUsingUserIDStatic = new UserRelations().ThreadSubscriptionEntityUsingUserID;
		internal static readonly IEntityRelation UserTitleEntityUsingUserTitleIDStatic = new UserRelations().UserTitleEntityUsingUserTitleID;

		/// <summary>CTor</summary>
		static StaticUserRelations()
		{
		}
	}
}
