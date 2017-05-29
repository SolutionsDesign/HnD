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
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'Thread'.<br/><br/></summary>
	[Serializable]
	public partial class ThreadEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AuditDataThreadRelatedEntity> _auditDataThreadRelated;
		private EntityCollection<BookmarkEntity> _presentInBookmarks;
		private EntityCollection<MessageEntity> _messages;
		private EntityCollection<ThreadSubscriptionEntity> _threadSubscription;
		private EntityCollection<UserEntity> _usersWhoBookmarkedThread;
		private EntityCollection<UserEntity> _usersWhoPostedInThread;
		private EntityCollection<UserEntity> _usersWhoSubscribedThread;
		private ForumEntity _forum;
		private UserEntity _userWhoStartedThread;
		private SupportQueueThreadEntity _supportQueueThread;

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
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ThreadEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public ThreadEntity():base("ThreadEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ThreadEntity(IEntityFields2 fields):base("ThreadEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ThreadEntity</param>
		public ThreadEntity(IValidator validator):base("ThreadEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ThreadEntity(System.Int32 threadID):base("ThreadEntity")
		{
			InitClassEmpty(null, null);
			this.ThreadID = threadID;
		}

		/// <summary> CTor</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="validator">The custom validator object for this ThreadEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ThreadEntity(System.Int32 threadID, IValidator validator):base("ThreadEntity")
		{
			InitClassEmpty(validator, null);
			this.ThreadID = threadID;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ThreadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_auditDataThreadRelated = (EntityCollection<AuditDataThreadRelatedEntity>)info.GetValue("_auditDataThreadRelated", typeof(EntityCollection<AuditDataThreadRelatedEntity>));
				_presentInBookmarks = (EntityCollection<BookmarkEntity>)info.GetValue("_presentInBookmarks", typeof(EntityCollection<BookmarkEntity>));
				_messages = (EntityCollection<MessageEntity>)info.GetValue("_messages", typeof(EntityCollection<MessageEntity>));
				_threadSubscription = (EntityCollection<ThreadSubscriptionEntity>)info.GetValue("_threadSubscription", typeof(EntityCollection<ThreadSubscriptionEntity>));
				_usersWhoBookmarkedThread = (EntityCollection<UserEntity>)info.GetValue("_usersWhoBookmarkedThread", typeof(EntityCollection<UserEntity>));
				_usersWhoPostedInThread = (EntityCollection<UserEntity>)info.GetValue("_usersWhoPostedInThread", typeof(EntityCollection<UserEntity>));
				_usersWhoSubscribedThread = (EntityCollection<UserEntity>)info.GetValue("_usersWhoSubscribedThread", typeof(EntityCollection<UserEntity>));
				_forum = (ForumEntity)info.GetValue("_forum", typeof(ForumEntity));
				if(_forum!=null)
				{
					_forum.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_userWhoStartedThread = (UserEntity)info.GetValue("_userWhoStartedThread", typeof(UserEntity));
				if(_userWhoStartedThread!=null)
				{
					_userWhoStartedThread.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_supportQueueThread = (SupportQueueThreadEntity)info.GetValue("_supportQueueThread", typeof(SupportQueueThreadEntity));
				if(_supportQueueThread!=null)
				{
					_supportQueueThread.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
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
					break;
				case ThreadFieldIndex.StartedByUserID:
					DesetupSyncUserWhoStartedThread(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "Forum":
					this.Forum = (ForumEntity)entity;
					break;
				case "UserWhoStartedThread":
					this.UserWhoStartedThread = (UserEntity)entity;
					break;
				case "AuditDataThreadRelated":
					this.AuditDataThreadRelated.Add((AuditDataThreadRelatedEntity)entity);
					break;
				case "PresentInBookmarks":
					this.PresentInBookmarks.Add((BookmarkEntity)entity);
					break;
				case "Messages":
					this.Messages.Add((MessageEntity)entity);
					break;
				case "ThreadSubscription":
					this.ThreadSubscription.Add((ThreadSubscriptionEntity)entity);
					break;
				case "UsersWhoBookmarkedThread":
					this.UsersWhoBookmarkedThread.IsReadOnly = false;
					this.UsersWhoBookmarkedThread.Add((UserEntity)entity);
					this.UsersWhoBookmarkedThread.IsReadOnly = true;
					break;
				case "UsersWhoPostedInThread":
					this.UsersWhoPostedInThread.IsReadOnly = false;
					this.UsersWhoPostedInThread.Add((UserEntity)entity);
					this.UsersWhoPostedInThread.IsReadOnly = true;
					break;
				case "UsersWhoSubscribedThread":
					this.UsersWhoSubscribedThread.IsReadOnly = false;
					this.UsersWhoSubscribedThread.Add((UserEntity)entity);
					this.UsersWhoSubscribedThread.IsReadOnly = true;
					break;
				case "SupportQueueThread":
					this.SupportQueueThread = (SupportQueueThreadEntity)entity;
					break;
				default:
					this.OnSetRelatedEntityProperty(propertyName, entity);
					break;
			}
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

		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it/ will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		protected override bool CheckOneWayRelations(string propertyName)
		{
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));
				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
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
					this.AuditDataThreadRelated.Add((AuditDataThreadRelatedEntity)relatedEntity);
					break;
				case "PresentInBookmarks":
					this.PresentInBookmarks.Add((BookmarkEntity)relatedEntity);
					break;
				case "Messages":
					this.Messages.Add((MessageEntity)relatedEntity);
					break;
				case "ThreadSubscription":
					this.ThreadSubscription.Add((ThreadSubscriptionEntity)relatedEntity);
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
					this.PerformRelatedEntityRemoval(this.AuditDataThreadRelated, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PresentInBookmarks":
					this.PerformRelatedEntityRemoval(this.PresentInBookmarks, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Messages":
					this.PerformRelatedEntityRemoval(this.Messages, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ThreadSubscription":
					this.PerformRelatedEntityRemoval(this.ThreadSubscription, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportQueueThread":
					DesetupSyncSupportQueueThread(false, true);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();

			if(_supportQueueThread!=null)
			{
				toReturn.Add(_supportQueueThread);
			}
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
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
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AuditDataThreadRelated);
			toReturn.Add(this.PresentInBookmarks);
			toReturn.Add(this.Messages);
			toReturn.Add(this.ThreadSubscription);
			return toReturn;
		}

		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_auditDataThreadRelated", ((_auditDataThreadRelated!=null) && (_auditDataThreadRelated.Count>0) && !this.MarkedForDeletion)?_auditDataThreadRelated:null);
				info.AddValue("_presentInBookmarks", ((_presentInBookmarks!=null) && (_presentInBookmarks.Count>0) && !this.MarkedForDeletion)?_presentInBookmarks:null);
				info.AddValue("_messages", ((_messages!=null) && (_messages.Count>0) && !this.MarkedForDeletion)?_messages:null);
				info.AddValue("_threadSubscription", ((_threadSubscription!=null) && (_threadSubscription.Count>0) && !this.MarkedForDeletion)?_threadSubscription:null);
				info.AddValue("_usersWhoBookmarkedThread", ((_usersWhoBookmarkedThread!=null) && (_usersWhoBookmarkedThread.Count>0) && !this.MarkedForDeletion)?_usersWhoBookmarkedThread:null);
				info.AddValue("_usersWhoPostedInThread", ((_usersWhoPostedInThread!=null) && (_usersWhoPostedInThread.Count>0) && !this.MarkedForDeletion)?_usersWhoPostedInThread:null);
				info.AddValue("_usersWhoSubscribedThread", ((_usersWhoSubscribedThread!=null) && (_usersWhoSubscribedThread.Count>0) && !this.MarkedForDeletion)?_usersWhoSubscribedThread:null);
				info.AddValue("_forum", (!this.MarkedForDeletion?_forum:null));
				info.AddValue("_userWhoStartedThread", (!this.MarkedForDeletion?_userWhoStartedThread:null));
				info.AddValue("_supportQueueThread", (!this.MarkedForDeletion?_supportQueueThread:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ThreadRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'AuditDataThreadRelated' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAuditDataThreadRelated()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AuditDataThreadRelatedFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Bookmark' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPresentInBookmarks()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BookmarkFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Message' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMessages()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MessageFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ThreadSubscription' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThreadSubscription()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ThreadSubscriptionFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsersWhoBookmarkedThread()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UsersWhoBookmarkedThread"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ThreadFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID, "ThreadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsersWhoPostedInThread()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UsersWhoPostedInThread"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ThreadFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID, "ThreadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsersWhoSubscribedThread()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UsersWhoSubscribedThread"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ThreadFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID, "ThreadEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Forum' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoForum()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ForumFields.ForumID, null, ComparisonOperator.Equal, this.ForumID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserWhoStartedThread()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.StartedByUserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'SupportQueueThread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSupportQueueThread()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SupportQueueThreadFields.ThreadID, null, ComparisonOperator.Equal, this.ThreadID));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory));
		}

		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._auditDataThreadRelated);
			collectionsQueue.Enqueue(this._presentInBookmarks);
			collectionsQueue.Enqueue(this._messages);
			collectionsQueue.Enqueue(this._threadSubscription);
			collectionsQueue.Enqueue(this._usersWhoBookmarkedThread);
			collectionsQueue.Enqueue(this._usersWhoPostedInThread);
			collectionsQueue.Enqueue(this._usersWhoSubscribedThread);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._auditDataThreadRelated = (EntityCollection<AuditDataThreadRelatedEntity>) collectionsQueue.Dequeue();
			this._presentInBookmarks = (EntityCollection<BookmarkEntity>) collectionsQueue.Dequeue();
			this._messages = (EntityCollection<MessageEntity>) collectionsQueue.Dequeue();
			this._threadSubscription = (EntityCollection<ThreadSubscriptionEntity>) collectionsQueue.Dequeue();
			this._usersWhoBookmarkedThread = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();
			this._usersWhoPostedInThread = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();
			this._usersWhoSubscribedThread = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._auditDataThreadRelated != null);
			toReturn |=(this._presentInBookmarks != null);
			toReturn |=(this._messages != null);
			toReturn |=(this._threadSubscription != null);
			toReturn |= (this._usersWhoBookmarkedThread != null);
			toReturn |= (this._usersWhoPostedInThread != null);
			toReturn |= (this._usersWhoSubscribedThread != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AuditDataThreadRelatedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AuditDataThreadRelatedEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BookmarkEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BookmarkEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MessageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ThreadSubscriptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadSubscriptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
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

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
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
			this.PerformDesetupSyncRelatedEntity( _forum, new PropertyChangedEventHandler( OnForumPropertyChanged ), "Forum", SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.ForumEntityUsingForumIDStatic, true, signalRelatedEntity, "Threads", resetFKFields, new int[] { (int)ThreadFieldIndex.ForumID } );
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
				this.PerformSetupSyncRelatedEntity( _forum, new PropertyChangedEventHandler( OnForumPropertyChanged ), "Forum", SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.ForumEntityUsingForumIDStatic, true, new string[] {  } );
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
			this.PerformDesetupSyncRelatedEntity( _userWhoStartedThread, new PropertyChangedEventHandler( OnUserWhoStartedThreadPropertyChanged ), "UserWhoStartedThread", SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.UserEntityUsingStartedByUserIDStatic, true, signalRelatedEntity, "StartedThreads", resetFKFields, new int[] { (int)ThreadFieldIndex.StartedByUserID } );
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
				this.PerformSetupSyncRelatedEntity( _userWhoStartedThread, new PropertyChangedEventHandler( OnUserWhoStartedThreadPropertyChanged ), "UserWhoStartedThread", SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.UserEntityUsingStartedByUserIDStatic, true, new string[] {  } );
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
			this.PerformDesetupSyncRelatedEntity( _supportQueueThread, new PropertyChangedEventHandler( OnSupportQueueThreadPropertyChanged ), "SupportQueueThread", SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.SupportQueueThreadEntityUsingThreadIDStatic, false, signalRelatedEntity, "Thread", false, new int[] { (int)ThreadFieldIndex.ThreadID } );
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
				this.PerformSetupSyncRelatedEntity( _supportQueueThread, new PropertyChangedEventHandler( OnSupportQueueThreadPropertyChanged ), "SupportQueueThread", SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.SupportQueueThreadEntityUsingThreadIDStatic, false, new string[] {  } );
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

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ThreadEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();

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

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AuditDataThreadRelated' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAuditDataThreadRelated
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<AuditDataThreadRelatedEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AuditDataThreadRelatedEntityFactory))), (IEntityRelation)GetRelationsForField("AuditDataThreadRelated")[0], (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.AuditDataThreadRelatedEntity, 0, null, null, null, null, "AuditDataThreadRelated", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Bookmark' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPresentInBookmarks
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<BookmarkEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BookmarkEntityFactory))), (IEntityRelation)GetRelationsForField("PresentInBookmarks")[0], (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.BookmarkEntity, 0, null, null, null, null, "PresentInBookmarks", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Message' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMessages
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<MessageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageEntityFactory))), (IEntityRelation)GetRelationsForField("Messages")[0], (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.MessageEntity, 0, null, null, null, null, "Messages", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ThreadSubscription' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThreadSubscription
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<ThreadSubscriptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadSubscriptionEntityFactory))), (IEntityRelation)GetRelationsForField("ThreadSubscription")[0], (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadSubscriptionEntity, 0, null, null, null, null, "ThreadSubscription", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsersWhoBookmarkedThread
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.BookmarkEntityUsingThreadID;
				intermediateRelation.SetAliases(string.Empty, "Bookmark_");
				return new PrefetchPathElement2(new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, GetRelationsForField("UsersWhoBookmarkedThread"), null, "UsersWhoBookmarkedThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsersWhoPostedInThread
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.MessageEntityUsingThreadID;
				intermediateRelation.SetAliases(string.Empty, "Message_");
				return new PrefetchPathElement2(new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, GetRelationsForField("UsersWhoPostedInThread"), null, "UsersWhoPostedInThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsersWhoSubscribedThread
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ThreadSubscriptionEntityUsingThreadID;
				intermediateRelation.SetAliases(string.Empty, "ThreadSubscription_");
				return new PrefetchPathElement2(new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, GetRelationsForField("UsersWhoSubscribedThread"), null, "UsersWhoSubscribedThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Forum' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathForum
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ForumEntityFactory))),	(IEntityRelation)GetRelationsForField("Forum")[0], (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.ForumEntity, 0, null, null, null, null, "Forum", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserWhoStartedThread
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),	(IEntityRelation)GetRelationsForField("UserWhoStartedThread")[0], (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.UserEntity, 0, null, null, null, null, "UserWhoStartedThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SupportQueueThread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSupportQueueThread
		{
			get { return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SupportQueueThreadEntityFactory))), (IEntityRelation)GetRelationsForField("SupportQueueThread")[0], (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, 0, null, null, null, null, "SupportQueueThread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);	}
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
			set	{ SetValue((int)ThreadFieldIndex.ThreadID, value); }
		}

		/// <summary> The ForumID property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."ForumID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ForumID
		{
			get { return (System.Int32)GetValue((int)ThreadFieldIndex.ForumID, true); }
			set	{ SetValue((int)ThreadFieldIndex.ForumID, value); }
		}

		/// <summary> The Subject property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."Subject"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Subject
		{
			get { return (System.String)GetValue((int)ThreadFieldIndex.Subject, true); }
			set	{ SetValue((int)ThreadFieldIndex.Subject, value); }
		}

		/// <summary> The StartedByUserID property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."StartedByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 StartedByUserID
		{
			get { return (System.Int32)GetValue((int)ThreadFieldIndex.StartedByUserID, true); }
			set	{ SetValue((int)ThreadFieldIndex.StartedByUserID, value); }
		}

		/// <summary> The ThreadLastPostingDate property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."ThreadLastPostingDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ThreadLastPostingDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ThreadFieldIndex.ThreadLastPostingDate, false); }
			set	{ SetValue((int)ThreadFieldIndex.ThreadLastPostingDate, value); }
		}

		/// <summary> The IsSticky property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."IsSticky"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSticky
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.IsSticky, true); }
			set	{ SetValue((int)ThreadFieldIndex.IsSticky, value); }
		}

		/// <summary> The IsClosed property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."IsClosed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsClosed
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.IsClosed, true); }
			set	{ SetValue((int)ThreadFieldIndex.IsClosed, value); }
		}

		/// <summary> The MarkedAsDone property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."MarkedAsDone"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean MarkedAsDone
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.MarkedAsDone, true); }
			set	{ SetValue((int)ThreadFieldIndex.MarkedAsDone, value); }
		}

		/// <summary> The NumberOfViews property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."NumberOfViews"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> NumberOfViews
		{
			get { return (Nullable<System.Int32>)GetValue((int)ThreadFieldIndex.NumberOfViews, false); }
			set	{ SetValue((int)ThreadFieldIndex.NumberOfViews, value); }
		}

		/// <summary> The Memo property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."Memo"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Memo
		{
			get { return (System.String)GetValue((int)ThreadFieldIndex.Memo, true); }
			set	{ SetValue((int)ThreadFieldIndex.Memo, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AuditDataThreadRelatedEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(AuditDataThreadRelatedEntity))]
		public virtual EntityCollection<AuditDataThreadRelatedEntity> AuditDataThreadRelated
		{
			get { return GetOrCreateEntityCollection<AuditDataThreadRelatedEntity, AuditDataThreadRelatedEntityFactory>("Thread", true, false, ref _auditDataThreadRelated);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BookmarkEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(BookmarkEntity))]
		public virtual EntityCollection<BookmarkEntity> PresentInBookmarks
		{
			get { return GetOrCreateEntityCollection<BookmarkEntity, BookmarkEntityFactory>("Thread", true, false, ref _presentInBookmarks);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MessageEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(MessageEntity))]
		public virtual EntityCollection<MessageEntity> Messages
		{
			get { return GetOrCreateEntityCollection<MessageEntity, MessageEntityFactory>("Thread", true, false, ref _messages);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ThreadSubscriptionEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadSubscriptionEntity))]
		public virtual EntityCollection<ThreadSubscriptionEntity> ThreadSubscription
		{
			get { return GetOrCreateEntityCollection<ThreadSubscriptionEntity, ThreadSubscriptionEntityFactory>("Thread", true, false, ref _threadSubscription);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UsersWhoBookmarkedThread
		{
			get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("ThreadsInBookmarks", false, true, ref _usersWhoBookmarkedThread);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UsersWhoPostedInThread
		{
			get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("PostedMessagesInThreads", false, true, ref _usersWhoPostedInThread);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UsersWhoSubscribedThread
		{
			get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("ThreadCollectionViaThreadSubscription", false, true, ref _usersWhoSubscribedThread);	}
		}

		/// <summary> Gets / sets related entity of type 'ForumEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ForumEntity Forum
		{
			get	{ return _forum; }
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

		/// <summary> Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity UserWhoStartedThread
		{
			get	{ return _userWhoStartedThread; }
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

		/// <summary> Gets / sets related entity of type 'SupportQueueThreadEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned.<br/><br/>
		/// </summary>
		[Browsable(true)]
		public virtual SupportQueueThreadEntity SupportQueueThread
		{
			get { return _supportQueueThread; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncSupportQueueThread(value);
					CallSetRelatedEntityDuringDeserialization(value, "Thread");
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
							((IEntity2)value).SetRelatedEntity(this, "Thread");
							SetupSyncSupportQueueThread(value);
						}
					}
				}
			}
		}
	
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the SD.HnD.DALAdapter.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)SD.HnD.DALAdapter.EntityType.ThreadEntity; }
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
