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
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Data;
using System.Xml.Serialization;
using SD.HnD.DAL;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.RelationClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'Thread'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ThreadEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection	_auditDataThreadRelated;
		private bool	_alwaysFetchAuditDataThreadRelated, _alreadyFetchedAuditDataThreadRelated;
		private SD.HnD.DAL.CollectionClasses.BookmarkCollection	_presentInBookmarks;
		private bool	_alwaysFetchPresentInBookmarks, _alreadyFetchedPresentInBookmarks;
		private SD.HnD.DAL.CollectionClasses.MessageCollection	_messages;
		private bool	_alwaysFetchMessages, _alreadyFetchedMessages;
		private SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection	_threadSubscription;
		private bool	_alwaysFetchThreadSubscription, _alreadyFetchedThreadSubscription;
		private SD.HnD.DAL.CollectionClasses.UserCollection _usersWhoBookmarkedThread;
		private bool	_alwaysFetchUsersWhoBookmarkedThread, _alreadyFetchedUsersWhoBookmarkedThread;
		private SD.HnD.DAL.CollectionClasses.UserCollection _usersWhoPostedInThread;
		private bool	_alwaysFetchUsersWhoPostedInThread, _alreadyFetchedUsersWhoPostedInThread;
		private SD.HnD.DAL.CollectionClasses.UserCollection _usersWhoSubscribedThread;
		private bool	_alwaysFetchUsersWhoSubscribedThread, _alreadyFetchedUsersWhoSubscribedThread;
		private ForumEntity _forum;
		private bool	_alwaysFetchForum, _alreadyFetchedForum, _forumReturnsNewIfNotFound;
		private UserEntity _userWhoStartedThread;
		private bool	_alwaysFetchUserWhoStartedThread, _alreadyFetchedUserWhoStartedThread, _userWhoStartedThreadReturnsNewIfNotFound;
		private SupportQueueThreadEntity _supportQueueThread;
		private bool	_alwaysFetchSupportQueueThread, _alreadyFetchedSupportQueueThread, _supportQueueThreadReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Forum</summary>
			public static readonly string Forum = "Forum";
			/// <summary>Member name UserWhoStartedThread</summary>
			public static readonly string UserWhoStartedThread = "UserWhoStartedThread";
			/// <summary>Member name AuditDataThreadRelated</summary>
			public static readonly string AuditDataThreadRelated = "AuditDataThreadRelated";
			/// <summary>Member name PresentInBookmarks</summary>
			public static readonly string PresentInBookmarks = "PresentInBookmarks";
			/// <summary>Member name Messages</summary>
			public static readonly string Messages = "Messages";
			/// <summary>Member name ThreadSubscription</summary>
			public static readonly string ThreadSubscription = "ThreadSubscription";
			/// <summary>Member name UsersWhoBookmarkedThread</summary>
			public static readonly string UsersWhoBookmarkedThread = "UsersWhoBookmarkedThread";
			/// <summary>Member name UsersWhoPostedInThread</summary>
			public static readonly string UsersWhoPostedInThread = "UsersWhoPostedInThread";
			/// <summary>Member name UsersWhoSubscribedThread</summary>
			public static readonly string UsersWhoSubscribedThread = "UsersWhoSubscribedThread";
			/// <summary>Member name SupportQueueThread</summary>
			public static readonly string SupportQueueThread = "SupportQueueThread";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ThreadEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ThreadEntity() :base("ThreadEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		public ThreadEntity(System.Int32 threadID):base("ThreadEntity")
		{
			InitClassFetch(threadID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ThreadEntity(System.Int32 threadID, IPrefetchPath prefetchPathToUse):base("ThreadEntity")
		{
			InitClassFetch(threadID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="validator">The custom validator object for this ThreadEntity</param>
		public ThreadEntity(System.Int32 threadID, IValidator validator):base("ThreadEntity")
		{
			InitClassFetch(threadID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ThreadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_auditDataThreadRelated = (SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection)info.GetValue("_auditDataThreadRelated", typeof(SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection));
			_alwaysFetchAuditDataThreadRelated = info.GetBoolean("_alwaysFetchAuditDataThreadRelated");
			_alreadyFetchedAuditDataThreadRelated = info.GetBoolean("_alreadyFetchedAuditDataThreadRelated");

			_presentInBookmarks = (SD.HnD.DAL.CollectionClasses.BookmarkCollection)info.GetValue("_presentInBookmarks", typeof(SD.HnD.DAL.CollectionClasses.BookmarkCollection));
			_alwaysFetchPresentInBookmarks = info.GetBoolean("_alwaysFetchPresentInBookmarks");
			_alreadyFetchedPresentInBookmarks = info.GetBoolean("_alreadyFetchedPresentInBookmarks");

			_messages = (SD.HnD.DAL.CollectionClasses.MessageCollection)info.GetValue("_messages", typeof(SD.HnD.DAL.CollectionClasses.MessageCollection));
			_alwaysFetchMessages = info.GetBoolean("_alwaysFetchMessages");
			_alreadyFetchedMessages = info.GetBoolean("_alreadyFetchedMessages");

			_threadSubscription = (SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection)info.GetValue("_threadSubscription", typeof(SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection));
			_alwaysFetchThreadSubscription = info.GetBoolean("_alwaysFetchThreadSubscription");
			_alreadyFetchedThreadSubscription = info.GetBoolean("_alreadyFetchedThreadSubscription");
			_usersWhoBookmarkedThread = (SD.HnD.DAL.CollectionClasses.UserCollection)info.GetValue("_usersWhoBookmarkedThread", typeof(SD.HnD.DAL.CollectionClasses.UserCollection));
			_alwaysFetchUsersWhoBookmarkedThread = info.GetBoolean("_alwaysFetchUsersWhoBookmarkedThread");
			_alreadyFetchedUsersWhoBookmarkedThread = info.GetBoolean("_alreadyFetchedUsersWhoBookmarkedThread");

			_usersWhoPostedInThread = (SD.HnD.DAL.CollectionClasses.UserCollection)info.GetValue("_usersWhoPostedInThread", typeof(SD.HnD.DAL.CollectionClasses.UserCollection));
			_alwaysFetchUsersWhoPostedInThread = info.GetBoolean("_alwaysFetchUsersWhoPostedInThread");
			_alreadyFetchedUsersWhoPostedInThread = info.GetBoolean("_alreadyFetchedUsersWhoPostedInThread");

			_usersWhoSubscribedThread = (SD.HnD.DAL.CollectionClasses.UserCollection)info.GetValue("_usersWhoSubscribedThread", typeof(SD.HnD.DAL.CollectionClasses.UserCollection));
			_alwaysFetchUsersWhoSubscribedThread = info.GetBoolean("_alwaysFetchUsersWhoSubscribedThread");
			_alreadyFetchedUsersWhoSubscribedThread = info.GetBoolean("_alreadyFetchedUsersWhoSubscribedThread");
			_forum = (ForumEntity)info.GetValue("_forum", typeof(ForumEntity));
			if(_forum!=null)
			{
				_forum.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_forumReturnsNewIfNotFound = info.GetBoolean("_forumReturnsNewIfNotFound");
			_alwaysFetchForum = info.GetBoolean("_alwaysFetchForum");
			_alreadyFetchedForum = info.GetBoolean("_alreadyFetchedForum");

			_userWhoStartedThread = (UserEntity)info.GetValue("_userWhoStartedThread", typeof(UserEntity));
			if(_userWhoStartedThread!=null)
			{
				_userWhoStartedThread.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_userWhoStartedThreadReturnsNewIfNotFound = info.GetBoolean("_userWhoStartedThreadReturnsNewIfNotFound");
			_alwaysFetchUserWhoStartedThread = info.GetBoolean("_alwaysFetchUserWhoStartedThread");
			_alreadyFetchedUserWhoStartedThread = info.GetBoolean("_alreadyFetchedUserWhoStartedThread");
			_supportQueueThread = (SupportQueueThreadEntity)info.GetValue("_supportQueueThread", typeof(SupportQueueThreadEntity));
			if(_supportQueueThread!=null)
			{
				_supportQueueThread.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_supportQueueThreadReturnsNewIfNotFound = info.GetBoolean("_supportQueueThreadReturnsNewIfNotFound");
			_alwaysFetchSupportQueueThread = info.GetBoolean("_alwaysFetchSupportQueueThread");
			_alreadyFetchedSupportQueueThread = info.GetBoolean("_alreadyFetchedSupportQueueThread");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ThreadFieldIndex)fieldIndex)
			{
				case ThreadFieldIndex.ForumID:
					DesetupSyncForum(true, false);
					_alreadyFetchedForum = false;
					break;
				case ThreadFieldIndex.StartedByUserID:
					DesetupSyncUserWhoStartedThread(true, false);
					_alreadyFetchedUserWhoStartedThread = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedAuditDataThreadRelated = (_auditDataThreadRelated.Count > 0);
			_alreadyFetchedPresentInBookmarks = (_presentInBookmarks.Count > 0);
			_alreadyFetchedMessages = (_messages.Count > 0);
			_alreadyFetchedThreadSubscription = (_threadSubscription.Count > 0);
			_alreadyFetchedUsersWhoBookmarkedThread = (_usersWhoBookmarkedThread.Count > 0);
			_alreadyFetchedUsersWhoPostedInThread = (_usersWhoPostedInThread.Count > 0);
			_alreadyFetchedUsersWhoSubscribedThread = (_usersWhoSubscribedThread.Count > 0);
			_alreadyFetchedForum = (_forum != null);
			_alreadyFetchedUserWhoStartedThread = (_userWhoStartedThread != null);
			_alreadyFetchedSupportQueueThread = (_supportQueueThread != null);
		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		protected override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		internal static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Forum":
					toReturn.Add(Relations.ForumEntityUsingForumID);
					break;
				case "UserWhoStartedThread":
					toReturn.Add(Relations.UserEntityUsingStartedByUserID);
					break;
				case "AuditDataThreadRelated":
					toReturn.Add(Relations.AuditDataThreadRelatedEntityUsingThreadID);
					break;
				case "PresentInBookmarks":
					toReturn.Add(Relations.BookmarkEntityUsingThreadID);
					break;
				case "Messages":
					toReturn.Add(Relations.MessageEntityUsingThreadID);
					break;
				case "ThreadSubscription":
					toReturn.Add(Relations.ThreadSubscriptionEntityUsingThreadID);
					break;
				case "UsersWhoBookmarkedThread":
					toReturn.Add(Relations.BookmarkEntityUsingThreadID, "ThreadEntity__", "Bookmark_", JoinHint.None);
					toReturn.Add(BookmarkEntity.Relations.UserEntityUsingUserID, "Bookmark_", string.Empty, JoinHint.None);
					break;
				case "UsersWhoPostedInThread":
					toReturn.Add(Relations.MessageEntityUsingThreadID, "ThreadEntity__", "Message_", JoinHint.None);
					toReturn.Add(MessageEntity.Relations.UserEntityUsingPostedByUserID, "Message_", string.Empty, JoinHint.None);
					break;
				case "UsersWhoSubscribedThread":
					toReturn.Add(Relations.ThreadSubscriptionEntityUsingThreadID, "ThreadEntity__", "ThreadSubscription_", JoinHint.None);
					toReturn.Add(ThreadSubscriptionEntity.Relations.UserEntityUsingUserID, "ThreadSubscription_", string.Empty, JoinHint.None);
					break;
				case "SupportQueueThread":
					toReturn.Add(Relations.SupportQueueThreadEntityUsingThreadID);
					break;
				default:
					break;				
			}
			return toReturn;
		}



		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_auditDataThreadRelated", (!this.MarkedForDeletion?_auditDataThreadRelated:null));
			info.AddValue("_alwaysFetchAuditDataThreadRelated", _alwaysFetchAuditDataThreadRelated);
			info.AddValue("_alreadyFetchedAuditDataThreadRelated", _alreadyFetchedAuditDataThreadRelated);
			info.AddValue("_presentInBookmarks", (!this.MarkedForDeletion?_presentInBookmarks:null));
			info.AddValue("_alwaysFetchPresentInBookmarks", _alwaysFetchPresentInBookmarks);
			info.AddValue("_alreadyFetchedPresentInBookmarks", _alreadyFetchedPresentInBookmarks);
			info.AddValue("_messages", (!this.MarkedForDeletion?_messages:null));
			info.AddValue("_alwaysFetchMessages", _alwaysFetchMessages);
			info.AddValue("_alreadyFetchedMessages", _alreadyFetchedMessages);
			info.AddValue("_threadSubscription", (!this.MarkedForDeletion?_threadSubscription:null));
			info.AddValue("_alwaysFetchThreadSubscription", _alwaysFetchThreadSubscription);
			info.AddValue("_alreadyFetchedThreadSubscription", _alreadyFetchedThreadSubscription);
			info.AddValue("_usersWhoBookmarkedThread", (!this.MarkedForDeletion?_usersWhoBookmarkedThread:null));
			info.AddValue("_alwaysFetchUsersWhoBookmarkedThread", _alwaysFetchUsersWhoBookmarkedThread);
			info.AddValue("_alreadyFetchedUsersWhoBookmarkedThread", _alreadyFetchedUsersWhoBookmarkedThread);
			info.AddValue("_usersWhoPostedInThread", (!this.MarkedForDeletion?_usersWhoPostedInThread:null));
			info.AddValue("_alwaysFetchUsersWhoPostedInThread", _alwaysFetchUsersWhoPostedInThread);
			info.AddValue("_alreadyFetchedUsersWhoPostedInThread", _alreadyFetchedUsersWhoPostedInThread);
			info.AddValue("_usersWhoSubscribedThread", (!this.MarkedForDeletion?_usersWhoSubscribedThread:null));
			info.AddValue("_alwaysFetchUsersWhoSubscribedThread", _alwaysFetchUsersWhoSubscribedThread);
			info.AddValue("_alreadyFetchedUsersWhoSubscribedThread", _alreadyFetchedUsersWhoSubscribedThread);
			info.AddValue("_forum", (!this.MarkedForDeletion?_forum:null));
			info.AddValue("_forumReturnsNewIfNotFound", _forumReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchForum", _alwaysFetchForum);
			info.AddValue("_alreadyFetchedForum", _alreadyFetchedForum);
			info.AddValue("_userWhoStartedThread", (!this.MarkedForDeletion?_userWhoStartedThread:null));
			info.AddValue("_userWhoStartedThreadReturnsNewIfNotFound", _userWhoStartedThreadReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchUserWhoStartedThread", _alwaysFetchUserWhoStartedThread);
			info.AddValue("_alreadyFetchedUserWhoStartedThread", _alreadyFetchedUserWhoStartedThread);

			info.AddValue("_supportQueueThread", (!this.MarkedForDeletion?_supportQueueThread:null));
			info.AddValue("_supportQueueThreadReturnsNewIfNotFound", _supportQueueThreadReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchSupportQueueThread", _alwaysFetchSupportQueueThread);
			info.AddValue("_alreadyFetchedSupportQueueThread", _alreadyFetchedSupportQueueThread);

			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "Forum":
					_alreadyFetchedForum = true;
					this.Forum = (ForumEntity)entity;
					break;
				case "UserWhoStartedThread":
					_alreadyFetchedUserWhoStartedThread = true;
					this.UserWhoStartedThread = (UserEntity)entity;
					break;
				case "AuditDataThreadRelated":
					_alreadyFetchedAuditDataThreadRelated = true;
					if(entity!=null)
					{
						this.AuditDataThreadRelated.Add((AuditDataThreadRelatedEntity)entity);
					}
					break;
				case "PresentInBookmarks":
					_alreadyFetchedPresentInBookmarks = true;
					if(entity!=null)
					{
						this.PresentInBookmarks.Add((BookmarkEntity)entity);
					}
					break;
				case "Messages":
					_alreadyFetchedMessages = true;
					if(entity!=null)
					{
						this.Messages.Add((MessageEntity)entity);
					}
					break;
				case "ThreadSubscription":
					_alreadyFetchedThreadSubscription = true;
					if(entity!=null)
					{
						this.ThreadSubscription.Add((ThreadSubscriptionEntity)entity);
					}
					break;
				case "UsersWhoBookmarkedThread":
					_alreadyFetchedUsersWhoBookmarkedThread = true;
					if(entity!=null)
					{
						this.UsersWhoBookmarkedThread.Add((UserEntity)entity);
					}
					break;
				case "UsersWhoPostedInThread":
					_alreadyFetchedUsersWhoPostedInThread = true;
					if(entity!=null)
					{
						this.UsersWhoPostedInThread.Add((UserEntity)entity);
					}
					break;
				case "UsersWhoSubscribedThread":
					_alreadyFetchedUsersWhoSubscribedThread = true;
					if(entity!=null)
					{
						this.UsersWhoSubscribedThread.Add((UserEntity)entity);
					}
					break;
				case "SupportQueueThread":
					_alreadyFetchedSupportQueueThread = true;
					this.SupportQueueThread = (SupportQueueThreadEntity)entity;
					break;
				default:
					this.OnSetRelatedEntityProperty(propertyName, entity);
					break;
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "Forum":
					SetupSyncForum(relatedEntity);
					break;
				case "UserWhoStartedThread":
					SetupSyncUserWhoStartedThread(relatedEntity);
					break;
				case "AuditDataThreadRelated":
					_auditDataThreadRelated.Add((AuditDataThreadRelatedEntity)relatedEntity);
					break;
				case "PresentInBookmarks":
					_presentInBookmarks.Add((BookmarkEntity)relatedEntity);
					break;
				case "Messages":
					_messages.Add((MessageEntity)relatedEntity);
					break;
				case "ThreadSubscription":
					_threadSubscription.Add((ThreadSubscriptionEntity)relatedEntity);
					break;
				case "SupportQueueThread":
					SetupSyncSupportQueueThread(relatedEntity);
					break;
				default:
					break;
			}
		}
		
		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void UnsetRelatedEntity(IEntityCore relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "Forum":
					DesetupSyncForum(false, true);
					break;
				case "UserWhoStartedThread":
					DesetupSyncUserWhoStartedThread(false, true);
					break;
				case "AuditDataThreadRelated":
					this.PerformRelatedEntityRemoval(_auditDataThreadRelated, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PresentInBookmarks":
					this.PerformRelatedEntityRemoval(_presentInBookmarks, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Messages":
					this.PerformRelatedEntityRemoval(_messages, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ThreadSubscription":
					this.PerformRelatedEntityRemoval(_threadSubscription, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportQueueThread":
					DesetupSyncSupportQueueThread(false, true);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_supportQueueThread!=null)
			{
				toReturn.Add(_supportQueueThread);
			}
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_forum!=null)
			{
				toReturn.Add(_forum);
			}
			if(_userWhoStartedThread!=null)
			{
				toReturn.Add(_userWhoStartedThread);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_auditDataThreadRelated);
			toReturn.Add(_presentInBookmarks);
			toReturn.Add(_messages);
			toReturn.Add(_threadSubscription);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 threadID)
		{
			return FetchUsingPK(threadID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 threadID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(threadID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(threadID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(threadID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.ThreadID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ThreadRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'AuditDataThreadRelatedEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'AuditDataThreadRelatedEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection GetMultiAuditDataThreadRelated(bool forceFetch)
		{
			return GetMultiAuditDataThreadRelated(forceFetch, _auditDataThreadRelated.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataThreadRelatedEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'AuditDataThreadRelatedEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection GetMultiAuditDataThreadRelated(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiAuditDataThreadRelated(forceFetch, _auditDataThreadRelated.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataThreadRelatedEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection GetMultiAuditDataThreadRelated(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiAuditDataThreadRelated(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataThreadRelatedEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection GetMultiAuditDataThreadRelated(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedAuditDataThreadRelated || forceFetch || _alwaysFetchAuditDataThreadRelated) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_auditDataThreadRelated);
				_auditDataThreadRelated.SuppressClearInGetMulti=!forceFetch;
				_auditDataThreadRelated.EntityFactoryToUse = entityFactoryToUse;
				_auditDataThreadRelated.GetMultiManyToOne(null, this, null, filter);
				_auditDataThreadRelated.SuppressClearInGetMulti=false;
				_alreadyFetchedAuditDataThreadRelated = true;
			}
			return _auditDataThreadRelated;
		}

		/// <summary> Sets the collection parameters for the collection for 'AuditDataThreadRelated'. These settings will be taken into account
		/// when the property AuditDataThreadRelated is requested or GetMultiAuditDataThreadRelated is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersAuditDataThreadRelated(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_auditDataThreadRelated.SortClauses=sortClauses;
			_auditDataThreadRelated.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'BookmarkEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.BookmarkCollection GetMultiPresentInBookmarks(bool forceFetch)
		{
			return GetMultiPresentInBookmarks(forceFetch, _presentInBookmarks.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'BookmarkEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.BookmarkCollection GetMultiPresentInBookmarks(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiPresentInBookmarks(forceFetch, _presentInBookmarks.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.BookmarkCollection GetMultiPresentInBookmarks(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiPresentInBookmarks(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.BookmarkCollection GetMultiPresentInBookmarks(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedPresentInBookmarks || forceFetch || _alwaysFetchPresentInBookmarks) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_presentInBookmarks);
				_presentInBookmarks.SuppressClearInGetMulti=!forceFetch;
				_presentInBookmarks.EntityFactoryToUse = entityFactoryToUse;
				_presentInBookmarks.GetMultiManyToOne(this, null, filter);
				_presentInBookmarks.SuppressClearInGetMulti=false;
				_alreadyFetchedPresentInBookmarks = true;
			}
			return _presentInBookmarks;
		}

		/// <summary> Sets the collection parameters for the collection for 'PresentInBookmarks'. These settings will be taken into account
		/// when the property PresentInBookmarks is requested or GetMultiPresentInBookmarks is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersPresentInBookmarks(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_presentInBookmarks.SortClauses=sortClauses;
			_presentInBookmarks.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'MessageEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.MessageCollection GetMultiMessages(bool forceFetch)
		{
			return GetMultiMessages(forceFetch, _messages.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'MessageEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.MessageCollection GetMultiMessages(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiMessages(forceFetch, _messages.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.MessageCollection GetMultiMessages(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiMessages(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.MessageCollection GetMultiMessages(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedMessages || forceFetch || _alwaysFetchMessages) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_messages);
				_messages.SuppressClearInGetMulti=!forceFetch;
				_messages.EntityFactoryToUse = entityFactoryToUse;
				_messages.GetMultiManyToOne(this, null, filter);
				_messages.SuppressClearInGetMulti=false;
				_alreadyFetchedMessages = true;
			}
			return _messages;
		}

		/// <summary> Sets the collection parameters for the collection for 'Messages'. These settings will be taken into account
		/// when the property Messages is requested or GetMultiMessages is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersMessages(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_messages.SortClauses=sortClauses;
			_messages.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ThreadSubscriptionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ThreadSubscriptionEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection GetMultiThreadSubscription(bool forceFetch)
		{
			return GetMultiThreadSubscription(forceFetch, _threadSubscription.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ThreadSubscriptionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ThreadSubscriptionEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection GetMultiThreadSubscription(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiThreadSubscription(forceFetch, _threadSubscription.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ThreadSubscriptionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection GetMultiThreadSubscription(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiThreadSubscription(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ThreadSubscriptionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection GetMultiThreadSubscription(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedThreadSubscription || forceFetch || _alwaysFetchThreadSubscription) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_threadSubscription);
				_threadSubscription.SuppressClearInGetMulti=!forceFetch;
				_threadSubscription.EntityFactoryToUse = entityFactoryToUse;
				_threadSubscription.GetMultiManyToOne(this, null, filter);
				_threadSubscription.SuppressClearInGetMulti=false;
				_alreadyFetchedThreadSubscription = true;
			}
			return _threadSubscription;
		}

		/// <summary> Sets the collection parameters for the collection for 'ThreadSubscription'. These settings will be taken into account
		/// when the property ThreadSubscription is requested or GetMultiThreadSubscription is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersThreadSubscription(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_threadSubscription.SortClauses=sortClauses;
			_threadSubscription.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsersWhoBookmarkedThread(bool forceFetch)
		{
			return GetMultiUsersWhoBookmarkedThread(forceFetch, _usersWhoBookmarkedThread.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsersWhoBookmarkedThread(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedUsersWhoBookmarkedThread || forceFetch || _alwaysFetchUsersWhoBookmarkedThread) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_usersWhoBookmarkedThread);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(ThreadFields.ThreadID, ComparisonOperator.Equal, this.ThreadID, "ThreadEntity__"));
				_usersWhoBookmarkedThread.SuppressClearInGetMulti=!forceFetch;
				_usersWhoBookmarkedThread.EntityFactoryToUse = entityFactoryToUse;
				_usersWhoBookmarkedThread.GetMulti(filter, GetRelationsForField("UsersWhoBookmarkedThread"));
				_usersWhoBookmarkedThread.SuppressClearInGetMulti=false;
				_alreadyFetchedUsersWhoBookmarkedThread = true;
			}
			return _usersWhoBookmarkedThread;
		}

		/// <summary> Sets the collection parameters for the collection for 'UsersWhoBookmarkedThread'. These settings will be taken into account
		/// when the property UsersWhoBookmarkedThread is requested or GetMultiUsersWhoBookmarkedThread is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUsersWhoBookmarkedThread(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_usersWhoBookmarkedThread.SortClauses=sortClauses;
			_usersWhoBookmarkedThread.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsersWhoPostedInThread(bool forceFetch)
		{
			return GetMultiUsersWhoPostedInThread(forceFetch, _usersWhoPostedInThread.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsersWhoPostedInThread(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedUsersWhoPostedInThread || forceFetch || _alwaysFetchUsersWhoPostedInThread) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_usersWhoPostedInThread);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(ThreadFields.ThreadID, ComparisonOperator.Equal, this.ThreadID, "ThreadEntity__"));
				_usersWhoPostedInThread.SuppressClearInGetMulti=!forceFetch;
				_usersWhoPostedInThread.EntityFactoryToUse = entityFactoryToUse;
				_usersWhoPostedInThread.GetMulti(filter, GetRelationsForField("UsersWhoPostedInThread"));
				_usersWhoPostedInThread.SuppressClearInGetMulti=false;
				_alreadyFetchedUsersWhoPostedInThread = true;
			}
			return _usersWhoPostedInThread;
		}

		/// <summary> Sets the collection parameters for the collection for 'UsersWhoPostedInThread'. These settings will be taken into account
		/// when the property UsersWhoPostedInThread is requested or GetMultiUsersWhoPostedInThread is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUsersWhoPostedInThread(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_usersWhoPostedInThread.SortClauses=sortClauses;
			_usersWhoPostedInThread.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsersWhoSubscribedThread(bool forceFetch)
		{
			return GetMultiUsersWhoSubscribedThread(forceFetch, _usersWhoSubscribedThread.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsersWhoSubscribedThread(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedUsersWhoSubscribedThread || forceFetch || _alwaysFetchUsersWhoSubscribedThread) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_usersWhoSubscribedThread);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(ThreadFields.ThreadID, ComparisonOperator.Equal, this.ThreadID, "ThreadEntity__"));
				_usersWhoSubscribedThread.SuppressClearInGetMulti=!forceFetch;
				_usersWhoSubscribedThread.EntityFactoryToUse = entityFactoryToUse;
				_usersWhoSubscribedThread.GetMulti(filter, GetRelationsForField("UsersWhoSubscribedThread"));
				_usersWhoSubscribedThread.SuppressClearInGetMulti=false;
				_alreadyFetchedUsersWhoSubscribedThread = true;
			}
			return _usersWhoSubscribedThread;
		}

		/// <summary> Sets the collection parameters for the collection for 'UsersWhoSubscribedThread'. These settings will be taken into account
		/// when the property UsersWhoSubscribedThread is requested or GetMultiUsersWhoSubscribedThread is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUsersWhoSubscribedThread(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_usersWhoSubscribedThread.SortClauses=sortClauses;
			_usersWhoSubscribedThread.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves the related entity of type 'ForumEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ForumEntity' which is related to this entity.</returns>
		public ForumEntity GetSingleForum()
		{
			return GetSingleForum(false);
		}

		/// <summary> Retrieves the related entity of type 'ForumEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ForumEntity' which is related to this entity.</returns>
		public virtual ForumEntity GetSingleForum(bool forceFetch)
		{
			if( ( !_alreadyFetchedForum || forceFetch || _alwaysFetchForum) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.ForumEntityUsingForumID);
				ForumEntity newEntity = new ForumEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.ForumID);
				}
				if(fetchResult)
				{
					newEntity = (ForumEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_forumReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Forum = newEntity;
				_alreadyFetchedForum = fetchResult;
			}
			return _forum;
		}


		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public UserEntity GetSingleUserWhoStartedThread()
		{
			return GetSingleUserWhoStartedThread(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSingleUserWhoStartedThread(bool forceFetch)
		{
			if( ( !_alreadyFetchedUserWhoStartedThread || forceFetch || _alwaysFetchUserWhoStartedThread) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserEntityUsingStartedByUserID);
				UserEntity newEntity = new UserEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.StartedByUserID);
				}
				if(fetchResult)
				{
					newEntity = (UserEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_userWhoStartedThreadReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.UserWhoStartedThread = newEntity;
				_alreadyFetchedUserWhoStartedThread = fetchResult;
			}
			return _userWhoStartedThread;
		}

		/// <summary> Retrieves the related entity of type 'SupportQueueThreadEntity', using a relation of type '1:1'</summary>
		/// <returns>A fetched entity of type 'SupportQueueThreadEntity' which is related to this entity.</returns>
		public SupportQueueThreadEntity GetSingleSupportQueueThread()
		{
			return GetSingleSupportQueueThread(false);
		}
		
		/// <summary> Retrieves the related entity of type 'SupportQueueThreadEntity', using a relation of type '1:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'SupportQueueThreadEntity' which is related to this entity.</returns>
		public virtual SupportQueueThreadEntity GetSingleSupportQueueThread(bool forceFetch)
		{
			if( ( !_alreadyFetchedSupportQueueThread || forceFetch || _alwaysFetchSupportQueueThread) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode )
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.SupportQueueThreadEntityUsingThreadID);
				SupportQueueThreadEntity newEntity = new SupportQueueThreadEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingUCThreadID(this.ThreadID);
				}
				if(fetchResult)
				{
					newEntity = (SupportQueueThreadEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_supportQueueThreadReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.SupportQueueThread = newEntity;
				_alreadyFetchedSupportQueueThread = fetchResult;
			}
			return _supportQueueThread;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Forum", _forum);
			toReturn.Add("UserWhoStartedThread", _userWhoStartedThread);
			toReturn.Add("AuditDataThreadRelated", _auditDataThreadRelated);
			toReturn.Add("PresentInBookmarks", _presentInBookmarks);
			toReturn.Add("Messages", _messages);
			toReturn.Add("ThreadSubscription", _threadSubscription);
			toReturn.Add("UsersWhoBookmarkedThread", _usersWhoBookmarkedThread);
			toReturn.Add("UsersWhoPostedInThread", _usersWhoPostedInThread);
			toReturn.Add("UsersWhoSubscribedThread", _usersWhoSubscribedThread);
			toReturn.Add("SupportQueueThread", _supportQueueThread);
			return toReturn;
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		private void InitClassEmpty(IValidator validatorToUse)
		{
			OnInitializing();
			this.Fields = CreateFields();
			this.Validator = validatorToUse;
			InitClassMembers();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="validator">The validator object for this ThreadEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 threadID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(threadID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_auditDataThreadRelated = new SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection();
			_auditDataThreadRelated.SetContainingEntityInfo(this, "Thread");

			_presentInBookmarks = new SD.HnD.DAL.CollectionClasses.BookmarkCollection();
			_presentInBookmarks.SetContainingEntityInfo(this, "Thread");

			_messages = new SD.HnD.DAL.CollectionClasses.MessageCollection();
			_messages.SetContainingEntityInfo(this, "Thread");

			_threadSubscription = new SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection();
			_threadSubscription.SetContainingEntityInfo(this, "Thread");
			_usersWhoBookmarkedThread = new SD.HnD.DAL.CollectionClasses.UserCollection();
			_usersWhoPostedInThread = new SD.HnD.DAL.CollectionClasses.UserCollection();
			_usersWhoSubscribedThread = new SD.HnD.DAL.CollectionClasses.UserCollection();
			_forumReturnsNewIfNotFound = true;
			_userWhoStartedThreadReturnsNewIfNotFound = true;
			_supportQueueThreadReturnsNewIfNotFound = true;
			PerformDependencyInjection();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();
			Dictionary<string, string> fieldHashtable;
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ForumID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Subject", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("StartedByUserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ThreadLastPostingDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsSticky", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsClosed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MarkedAsDone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NumberOfViews", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Memo", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _forum</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncForum(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _forum, new PropertyChangedEventHandler( OnForumPropertyChanged ), "Forum", SD.HnD.DAL.RelationClasses.StaticThreadRelations.ForumEntityUsingForumIDStatic, true, signalRelatedEntity, "Threads", resetFKFields, new int[] { (int)ThreadFieldIndex.ForumID } );		
			_forum = null;
		}
		
		/// <summary> setups the sync logic for member _forum</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncForum(IEntityCore relatedEntity)
		{
			if(_forum!=relatedEntity)
			{		
				DesetupSyncForum(true, true);
				_forum = (ForumEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _forum, new PropertyChangedEventHandler( OnForumPropertyChanged ), "Forum", SD.HnD.DAL.RelationClasses.StaticThreadRelations.ForumEntityUsingForumIDStatic, true, ref _alreadyFetchedForum, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnForumPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _userWhoStartedThread</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUserWhoStartedThread(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _userWhoStartedThread, new PropertyChangedEventHandler( OnUserWhoStartedThreadPropertyChanged ), "UserWhoStartedThread", SD.HnD.DAL.RelationClasses.StaticThreadRelations.UserEntityUsingStartedByUserIDStatic, true, signalRelatedEntity, "StartedThreads", resetFKFields, new int[] { (int)ThreadFieldIndex.StartedByUserID } );		
			_userWhoStartedThread = null;
		}
		
		/// <summary> setups the sync logic for member _userWhoStartedThread</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUserWhoStartedThread(IEntityCore relatedEntity)
		{
			if(_userWhoStartedThread!=relatedEntity)
			{		
				DesetupSyncUserWhoStartedThread(true, true);
				_userWhoStartedThread = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _userWhoStartedThread, new PropertyChangedEventHandler( OnUserWhoStartedThreadPropertyChanged ), "UserWhoStartedThread", SD.HnD.DAL.RelationClasses.StaticThreadRelations.UserEntityUsingStartedByUserIDStatic, true, ref _alreadyFetchedUserWhoStartedThread, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserWhoStartedThreadPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _supportQueueThread</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSupportQueueThread(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _supportQueueThread, new PropertyChangedEventHandler( OnSupportQueueThreadPropertyChanged ), "SupportQueueThread", SD.HnD.DAL.RelationClasses.StaticThreadRelations.SupportQueueThreadEntityUsingThreadIDStatic, false, signalRelatedEntity, "Thread", false, new int[] { (int)ThreadFieldIndex.ThreadID } );
			_supportQueueThread = null;
		}
	
		/// <summary> setups the sync logic for member _supportQueueThread</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSupportQueueThread(IEntityCore relatedEntity)
		{
			if(_supportQueueThread!=relatedEntity)
			{
				DesetupSyncSupportQueueThread(true, true);
				_supportQueueThread = (SupportQueueThreadEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _supportQueueThread, new PropertyChangedEventHandler( OnSupportQueueThreadPropertyChanged ), "SupportQueueThread", SD.HnD.DAL.RelationClasses.StaticThreadRelations.SupportQueueThreadEntityUsingThreadIDStatic, false, ref _alreadyFetchedSupportQueueThread, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSupportQueueThreadPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)ThreadFieldIndex.ThreadID].ForcedCurrentValueWrite(threadID);
				CreateDAOInstance().FetchExisting(this, this.Transaction, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (this.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}

		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateThreadDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ThreadEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ThreadRelations Relations
		{
			get	{ return new ThreadRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'AuditDataThreadRelated' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAuditDataThreadRelated
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection(), (IEntityRelation)GetRelationsForField("AuditDataThreadRelated")[0], (int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.AuditDataThreadRelatedEntity, 0, null, null, null, "AuditDataThreadRelated", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Bookmark' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPresentInBookmarks
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.BookmarkCollection(), (IEntityRelation)GetRelationsForField("PresentInBookmarks")[0], (int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.BookmarkEntity, 0, null, null, null, "PresentInBookmarks", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Message' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathMessages
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.MessageCollection(), (IEntityRelation)GetRelationsForField("Messages")[0], (int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.MessageEntity, 0, null, null, null, "Messages", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ThreadSubscription' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThreadSubscription
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection(), (IEntityRelation)GetRelationsForField("ThreadSubscription")[0], (int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.ThreadSubscriptionEntity, 0, null, null, null, "ThreadSubscription", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUsersWhoBookmarkedThread
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.BookmarkEntityUsingThreadID;
				intermediateRelation.SetAliases(string.Empty, "Bookmark_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, GetRelationsForField("UsersWhoBookmarkedThread"), "UsersWhoBookmarkedThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUsersWhoPostedInThread
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.MessageEntityUsingThreadID;
				intermediateRelation.SetAliases(string.Empty, "Message_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, GetRelationsForField("UsersWhoPostedInThread"), "UsersWhoPostedInThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUsersWhoSubscribedThread
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ThreadSubscriptionEntityUsingThreadID;
				intermediateRelation.SetAliases(string.Empty, "ThreadSubscription_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, GetRelationsForField("UsersWhoSubscribedThread"), "UsersWhoSubscribedThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Forum'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathForum
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ForumCollection(), (IEntityRelation)GetRelationsForField("Forum")[0], (int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.ForumEntity, 0, null, null, null, "Forum", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserWhoStartedThread
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("UserWhoStartedThread")[0], (int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, null, "UserWhoStartedThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportQueueThread'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupportQueueThread
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection(), (IEntityRelation)GetRelationsForField("SupportQueueThread")[0], (int)SD.HnD.DAL.EntityType.ThreadEntity, (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity, 0, null, null, null, "SupportQueueThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);	}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return FieldsCustomProperties;}
		}

		/// <summary> The ThreadID property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."ThreadID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)ThreadFieldIndex.ThreadID, true); }
			set	{ SetValue((int)ThreadFieldIndex.ThreadID, value, true); }
		}

		/// <summary> The ForumID property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."ForumID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ForumID
		{
			get { return (System.Int32)GetValue((int)ThreadFieldIndex.ForumID, true); }
			set	{ SetValue((int)ThreadFieldIndex.ForumID, value, true); }
		}

		/// <summary> The Subject property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."Subject"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Subject
		{
			get { return (System.String)GetValue((int)ThreadFieldIndex.Subject, true); }
			set	{ SetValue((int)ThreadFieldIndex.Subject, value, true); }
		}

		/// <summary> The StartedByUserID property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."StartedByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 StartedByUserID
		{
			get { return (System.Int32)GetValue((int)ThreadFieldIndex.StartedByUserID, true); }
			set	{ SetValue((int)ThreadFieldIndex.StartedByUserID, value, true); }
		}

		/// <summary> The ThreadLastPostingDate property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."ThreadLastPostingDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ThreadLastPostingDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ThreadFieldIndex.ThreadLastPostingDate, false); }
			set	{ SetValue((int)ThreadFieldIndex.ThreadLastPostingDate, value, true); }
		}

		/// <summary> The IsSticky property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."IsSticky"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSticky
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.IsSticky, true); }
			set	{ SetValue((int)ThreadFieldIndex.IsSticky, value, true); }
		}

		/// <summary> The IsClosed property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."IsClosed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsClosed
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.IsClosed, true); }
			set	{ SetValue((int)ThreadFieldIndex.IsClosed, value, true); }
		}

		/// <summary> The MarkedAsDone property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."MarkedAsDone"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean MarkedAsDone
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.MarkedAsDone, true); }
			set	{ SetValue((int)ThreadFieldIndex.MarkedAsDone, value, true); }
		}

		/// <summary> The NumberOfViews property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."NumberOfViews"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NumberOfViews
		{
			get { return (Nullable<System.Int32>)GetValue((int)ThreadFieldIndex.NumberOfViews, false); }
			set	{ SetValue((int)ThreadFieldIndex.NumberOfViews, value, true); }
		}

		/// <summary> The Memo property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."Memo"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Memo
		{
			get { return (System.String)GetValue((int)ThreadFieldIndex.Memo, true); }
			set	{ SetValue((int)ThreadFieldIndex.Memo, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'AuditDataThreadRelatedEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiAuditDataThreadRelated()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.AuditDataThreadRelatedCollection AuditDataThreadRelated
		{
			get	{ return GetMultiAuditDataThreadRelated(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for AuditDataThreadRelated. When set to true, AuditDataThreadRelated is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time AuditDataThreadRelated is accessed. You can always execute/ a forced fetch by calling GetMultiAuditDataThreadRelated(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAuditDataThreadRelated
		{
			get	{ return _alwaysFetchAuditDataThreadRelated; }
			set	{ _alwaysFetchAuditDataThreadRelated = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property AuditDataThreadRelated already has been fetched. Setting this property to false when AuditDataThreadRelated has been fetched
		/// will clear the AuditDataThreadRelated collection well. Setting this property to true while AuditDataThreadRelated hasn't been fetched disables lazy loading for AuditDataThreadRelated</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAuditDataThreadRelated
		{
			get { return _alreadyFetchedAuditDataThreadRelated;}
			set 
			{
				if(_alreadyFetchedAuditDataThreadRelated && !value && (_auditDataThreadRelated != null))
				{
					_auditDataThreadRelated.Clear();
				}
				_alreadyFetchedAuditDataThreadRelated = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiPresentInBookmarks()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.BookmarkCollection PresentInBookmarks
		{
			get	{ return GetMultiPresentInBookmarks(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for PresentInBookmarks. When set to true, PresentInBookmarks is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time PresentInBookmarks is accessed. You can always execute/ a forced fetch by calling GetMultiPresentInBookmarks(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPresentInBookmarks
		{
			get	{ return _alwaysFetchPresentInBookmarks; }
			set	{ _alwaysFetchPresentInBookmarks = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property PresentInBookmarks already has been fetched. Setting this property to false when PresentInBookmarks has been fetched
		/// will clear the PresentInBookmarks collection well. Setting this property to true while PresentInBookmarks hasn't been fetched disables lazy loading for PresentInBookmarks</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPresentInBookmarks
		{
			get { return _alreadyFetchedPresentInBookmarks;}
			set 
			{
				if(_alreadyFetchedPresentInBookmarks && !value && (_presentInBookmarks != null))
				{
					_presentInBookmarks.Clear();
				}
				_alreadyFetchedPresentInBookmarks = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiMessages()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.MessageCollection Messages
		{
			get	{ return GetMultiMessages(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Messages. When set to true, Messages is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Messages is accessed. You can always execute/ a forced fetch by calling GetMultiMessages(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchMessages
		{
			get	{ return _alwaysFetchMessages; }
			set	{ _alwaysFetchMessages = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Messages already has been fetched. Setting this property to false when Messages has been fetched
		/// will clear the Messages collection well. Setting this property to true while Messages hasn't been fetched disables lazy loading for Messages</summary>
		[Browsable(false)]
		public bool AlreadyFetchedMessages
		{
			get { return _alreadyFetchedMessages;}
			set 
			{
				if(_alreadyFetchedMessages && !value && (_messages != null))
				{
					_messages.Clear();
				}
				_alreadyFetchedMessages = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'ThreadSubscriptionEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiThreadSubscription()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection ThreadSubscription
		{
			get	{ return GetMultiThreadSubscription(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ThreadSubscription. When set to true, ThreadSubscription is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ThreadSubscription is accessed. You can always execute/ a forced fetch by calling GetMultiThreadSubscription(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchThreadSubscription
		{
			get	{ return _alwaysFetchThreadSubscription; }
			set	{ _alwaysFetchThreadSubscription = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property ThreadSubscription already has been fetched. Setting this property to false when ThreadSubscription has been fetched
		/// will clear the ThreadSubscription collection well. Setting this property to true while ThreadSubscription hasn't been fetched disables lazy loading for ThreadSubscription</summary>
		[Browsable(false)]
		public bool AlreadyFetchedThreadSubscription
		{
			get { return _alreadyFetchedThreadSubscription;}
			set 
			{
				if(_alreadyFetchedThreadSubscription && !value && (_threadSubscription != null))
				{
					_threadSubscription.Clear();
				}
				_alreadyFetchedThreadSubscription = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUsersWhoBookmarkedThread()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.UserCollection UsersWhoBookmarkedThread
		{
			get { return GetMultiUsersWhoBookmarkedThread(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UsersWhoBookmarkedThread. When set to true, UsersWhoBookmarkedThread is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UsersWhoBookmarkedThread is accessed. You can always execute a forced fetch by calling GetMultiUsersWhoBookmarkedThread(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUsersWhoBookmarkedThread
		{
			get	{ return _alwaysFetchUsersWhoBookmarkedThread; }
			set	{ _alwaysFetchUsersWhoBookmarkedThread = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property UsersWhoBookmarkedThread already has been fetched. Setting this property to false when UsersWhoBookmarkedThread has been fetched
		/// will clear the UsersWhoBookmarkedThread collection well. Setting this property to true while UsersWhoBookmarkedThread hasn't been fetched disables lazy loading for UsersWhoBookmarkedThread</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUsersWhoBookmarkedThread
		{
			get { return _alreadyFetchedUsersWhoBookmarkedThread;}
			set 
			{
				if(_alreadyFetchedUsersWhoBookmarkedThread && !value && (_usersWhoBookmarkedThread != null))
				{
					_usersWhoBookmarkedThread.Clear();
				}
				_alreadyFetchedUsersWhoBookmarkedThread = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUsersWhoPostedInThread()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.UserCollection UsersWhoPostedInThread
		{
			get { return GetMultiUsersWhoPostedInThread(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UsersWhoPostedInThread. When set to true, UsersWhoPostedInThread is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UsersWhoPostedInThread is accessed. You can always execute a forced fetch by calling GetMultiUsersWhoPostedInThread(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUsersWhoPostedInThread
		{
			get	{ return _alwaysFetchUsersWhoPostedInThread; }
			set	{ _alwaysFetchUsersWhoPostedInThread = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property UsersWhoPostedInThread already has been fetched. Setting this property to false when UsersWhoPostedInThread has been fetched
		/// will clear the UsersWhoPostedInThread collection well. Setting this property to true while UsersWhoPostedInThread hasn't been fetched disables lazy loading for UsersWhoPostedInThread</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUsersWhoPostedInThread
		{
			get { return _alreadyFetchedUsersWhoPostedInThread;}
			set 
			{
				if(_alreadyFetchedUsersWhoPostedInThread && !value && (_usersWhoPostedInThread != null))
				{
					_usersWhoPostedInThread.Clear();
				}
				_alreadyFetchedUsersWhoPostedInThread = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUsersWhoSubscribedThread()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.UserCollection UsersWhoSubscribedThread
		{
			get { return GetMultiUsersWhoSubscribedThread(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UsersWhoSubscribedThread. When set to true, UsersWhoSubscribedThread is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UsersWhoSubscribedThread is accessed. You can always execute a forced fetch by calling GetMultiUsersWhoSubscribedThread(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUsersWhoSubscribedThread
		{
			get	{ return _alwaysFetchUsersWhoSubscribedThread; }
			set	{ _alwaysFetchUsersWhoSubscribedThread = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property UsersWhoSubscribedThread already has been fetched. Setting this property to false when UsersWhoSubscribedThread has been fetched
		/// will clear the UsersWhoSubscribedThread collection well. Setting this property to true while UsersWhoSubscribedThread hasn't been fetched disables lazy loading for UsersWhoSubscribedThread</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUsersWhoSubscribedThread
		{
			get { return _alreadyFetchedUsersWhoSubscribedThread;}
			set 
			{
				if(_alreadyFetchedUsersWhoSubscribedThread && !value && (_usersWhoSubscribedThread != null))
				{
					_usersWhoSubscribedThread.Clear();
				}
				_alreadyFetchedUsersWhoSubscribedThread = value;
			}
		}

		/// <summary> Gets / sets related entity of type 'ForumEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleForum()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual ForumEntity Forum
		{
			get	{ return GetSingleForum(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncForum(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Threads", "Forum", _forum, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Forum. When set to true, Forum is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Forum is accessed. You can always execute a forced fetch by calling GetSingleForum(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchForum
		{
			get	{ return _alwaysFetchForum; }
			set	{ _alwaysFetchForum = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Forum already has been fetched. Setting this property to false when Forum has been fetched
		/// will set Forum to null as well. Setting this property to true while Forum hasn't been fetched disables lazy loading for Forum</summary>
		[Browsable(false)]
		public bool AlreadyFetchedForum
		{
			get { return _alreadyFetchedForum;}
			set 
			{
				if(_alreadyFetchedForum && !value)
				{
					this.Forum = null;
				}
				_alreadyFetchedForum = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Forum is not found
		/// in the database. When set to true, Forum will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool ForumReturnsNewIfNotFound
		{
			get	{ return _forumReturnsNewIfNotFound; }
			set { _forumReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleUserWhoStartedThread()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual UserEntity UserWhoStartedThread
		{
			get	{ return GetSingleUserWhoStartedThread(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncUserWhoStartedThread(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "StartedThreads", "UserWhoStartedThread", _userWhoStartedThread, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for UserWhoStartedThread. When set to true, UserWhoStartedThread is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserWhoStartedThread is accessed. You can always execute a forced fetch by calling GetSingleUserWhoStartedThread(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserWhoStartedThread
		{
			get	{ return _alwaysFetchUserWhoStartedThread; }
			set	{ _alwaysFetchUserWhoStartedThread = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property UserWhoStartedThread already has been fetched. Setting this property to false when UserWhoStartedThread has been fetched
		/// will set UserWhoStartedThread to null as well. Setting this property to true while UserWhoStartedThread hasn't been fetched disables lazy loading for UserWhoStartedThread</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserWhoStartedThread
		{
			get { return _alreadyFetchedUserWhoStartedThread;}
			set 
			{
				if(_alreadyFetchedUserWhoStartedThread && !value)
				{
					this.UserWhoStartedThread = null;
				}
				_alreadyFetchedUserWhoStartedThread = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property UserWhoStartedThread is not found
		/// in the database. When set to true, UserWhoStartedThread will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool UserWhoStartedThreadReturnsNewIfNotFound
		{
			get	{ return _userWhoStartedThreadReturnsNewIfNotFound; }
			set { _userWhoStartedThreadReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'SupportQueueThreadEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/></summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleSupportQueueThread()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual SupportQueueThreadEntity SupportQueueThread
		{
			get	{ return GetSingleSupportQueueThread(false); }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncSupportQueueThread(value);
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_supportQueueThread !=null);
						DesetupSyncSupportQueueThread(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("SupportQueueThread");
						}
					}
					else
					{
						if(_supportQueueThread!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "Thread");
							SetupSyncSupportQueueThread(value);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for SupportQueueThread. When set to true, SupportQueueThread is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SupportQueueThread is accessed. You can always execute a forced fetch by calling GetSingleSupportQueueThread(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupportQueueThread
		{
			get	{ return _alwaysFetchSupportQueueThread; }
			set	{ _alwaysFetchSupportQueueThread = value; }	
		}
		
		/// <summary>Gets / Sets the lazy loading flag if the property SupportQueueThread already has been fetched. Setting this property to false when SupportQueueThread has been fetched
		/// will set SupportQueueThread to null as well. Setting this property to true while SupportQueueThread hasn't been fetched disables lazy loading for SupportQueueThread</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupportQueueThread
		{
			get { return _alreadyFetchedSupportQueueThread;}
			set 
			{
				if(_alreadyFetchedSupportQueueThread && !value)
				{
					this.SupportQueueThread = null;
				}
				_alreadyFetchedSupportQueueThread = value;
			}
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property SupportQueueThread is not found
		/// in the database. When set to true, SupportQueueThread will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool SupportQueueThreadReturnsNewIfNotFound
		{
			get	{ return _supportQueueThreadReturnsNewIfNotFound; }
			set	{ _supportQueueThreadReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}

		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		[System.ComponentModel.Browsable(false), XmlIgnore]
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary>Returns the SD.HnD.DAL.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)SD.HnD.DAL.EntityType.ThreadEntity; }
		}

		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
