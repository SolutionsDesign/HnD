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
#if !CF
using System.Runtime.Serialization;
#endif
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
	
	/// <summary>Entity class which represents the entity 'User'.<br/><br/></summary>
	[Serializable]
	public partial class UserEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END
			
	{
		#region Class Member Declarations
		private EntityCollection<AuditDataCoreEntity> _loggedAudits;
		private EntityCollection<BookmarkEntity> _bookmarks;
		private EntityCollection<IPBanEntity> _iPBansSet;
		private EntityCollection<MessageEntity> _postedMessages;
		private EntityCollection<RoleUserEntity> _roleUser;
		private EntityCollection<SupportQueueThreadEntity> _supportQueueThreadsClaimed;
		private EntityCollection<SupportQueueThreadEntity> _supportQueueThreadsPlaced;
		private EntityCollection<ThreadEntity> _startedThreads;
		private EntityCollection<ThreadSubscriptionEntity> _threadSubscription;
		private EntityCollection<ForumEntity> _startedThreadsInForums;
		private EntityCollection<RoleEntity> _roles;
		private EntityCollection<ThreadEntity> _threadsInBookmarks;
		private EntityCollection<ThreadEntity> _postedMessagesInThreads;
		private EntityCollection<ThreadEntity> _threadCollectionViaThreadSubscription;
		private UserTitleEntity _userTitle;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name UserTitle</summary>
			public static readonly string UserTitle = "UserTitle";
			/// <summary>Member name LoggedAudits</summary>
			public static readonly string LoggedAudits = "LoggedAudits";
			/// <summary>Member name Bookmarks</summary>
			public static readonly string Bookmarks = "Bookmarks";
			/// <summary>Member name IPBansSet</summary>
			public static readonly string IPBansSet = "IPBansSet";
			/// <summary>Member name PostedMessages</summary>
			public static readonly string PostedMessages = "PostedMessages";
			/// <summary>Member name RoleUser</summary>
			public static readonly string RoleUser = "RoleUser";
			/// <summary>Member name SupportQueueThreadsClaimed</summary>
			public static readonly string SupportQueueThreadsClaimed = "SupportQueueThreadsClaimed";
			/// <summary>Member name SupportQueueThreadsPlaced</summary>
			public static readonly string SupportQueueThreadsPlaced = "SupportQueueThreadsPlaced";
			/// <summary>Member name StartedThreads</summary>
			public static readonly string StartedThreads = "StartedThreads";
			/// <summary>Member name ThreadSubscription</summary>
			public static readonly string ThreadSubscription = "ThreadSubscription";
			/// <summary>Member name StartedThreadsInForums</summary>
			public static readonly string StartedThreadsInForums = "StartedThreadsInForums";
			/// <summary>Member name Roles</summary>
			public static readonly string Roles = "Roles";
			/// <summary>Member name ThreadsInBookmarks</summary>
			public static readonly string ThreadsInBookmarks = "ThreadsInBookmarks";
			/// <summary>Member name PostedMessagesInThreads</summary>
			public static readonly string PostedMessagesInThreads = "PostedMessagesInThreads";
			/// <summary>Member name ThreadCollectionViaThreadSubscription</summary>
			public static readonly string ThreadCollectionViaThreadSubscription = "ThreadCollectionViaThreadSubscription";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static UserEntity()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary> CTor</summary>
		public UserEntity():base("UserEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public UserEntity(IEntityFields2 fields):base("UserEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(IValidator validator):base("UserEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UserEntity(System.Int32 userID):base("UserEntity")
		{
			InitClassEmpty(null, null);
			this.UserID = userID;
		}

		/// <summary> CTor</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public UserEntity(System.Int32 userID, IValidator validator):base("UserEntity")
		{
			InitClassEmpty(validator, null);
			this.UserID = userID;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected UserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_loggedAudits = (EntityCollection<AuditDataCoreEntity>)info.GetValue("_loggedAudits", typeof(EntityCollection<AuditDataCoreEntity>));
				_bookmarks = (EntityCollection<BookmarkEntity>)info.GetValue("_bookmarks", typeof(EntityCollection<BookmarkEntity>));
				_iPBansSet = (EntityCollection<IPBanEntity>)info.GetValue("_iPBansSet", typeof(EntityCollection<IPBanEntity>));
				_postedMessages = (EntityCollection<MessageEntity>)info.GetValue("_postedMessages", typeof(EntityCollection<MessageEntity>));
				_roleUser = (EntityCollection<RoleUserEntity>)info.GetValue("_roleUser", typeof(EntityCollection<RoleUserEntity>));
				_supportQueueThreadsClaimed = (EntityCollection<SupportQueueThreadEntity>)info.GetValue("_supportQueueThreadsClaimed", typeof(EntityCollection<SupportQueueThreadEntity>));
				_supportQueueThreadsPlaced = (EntityCollection<SupportQueueThreadEntity>)info.GetValue("_supportQueueThreadsPlaced", typeof(EntityCollection<SupportQueueThreadEntity>));
				_startedThreads = (EntityCollection<ThreadEntity>)info.GetValue("_startedThreads", typeof(EntityCollection<ThreadEntity>));
				_threadSubscription = (EntityCollection<ThreadSubscriptionEntity>)info.GetValue("_threadSubscription", typeof(EntityCollection<ThreadSubscriptionEntity>));
				_startedThreadsInForums = (EntityCollection<ForumEntity>)info.GetValue("_startedThreadsInForums", typeof(EntityCollection<ForumEntity>));
				_roles = (EntityCollection<RoleEntity>)info.GetValue("_roles", typeof(EntityCollection<RoleEntity>));
				_threadsInBookmarks = (EntityCollection<ThreadEntity>)info.GetValue("_threadsInBookmarks", typeof(EntityCollection<ThreadEntity>));
				_postedMessagesInThreads = (EntityCollection<ThreadEntity>)info.GetValue("_postedMessagesInThreads", typeof(EntityCollection<ThreadEntity>));
				_threadCollectionViaThreadSubscription = (EntityCollection<ThreadEntity>)info.GetValue("_threadCollectionViaThreadSubscription", typeof(EntityCollection<ThreadEntity>));
				_userTitle = (UserTitleEntity)info.GetValue("_userTitle", typeof(UserTitleEntity));
				if(_userTitle!=null)
				{
					_userTitle.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((UserFieldIndex)fieldIndex)
			{
				case UserFieldIndex.UserTitleID:
					DesetupSyncUserTitle(true, false);
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
				case "UserTitle":
					this.UserTitle = (UserTitleEntity)entity;
					break;
				case "LoggedAudits":
					this.LoggedAudits.Add((AuditDataCoreEntity)entity);
					break;
				case "Bookmarks":
					this.Bookmarks.Add((BookmarkEntity)entity);
					break;
				case "IPBansSet":
					this.IPBansSet.Add((IPBanEntity)entity);
					break;
				case "PostedMessages":
					this.PostedMessages.Add((MessageEntity)entity);
					break;
				case "RoleUser":
					this.RoleUser.Add((RoleUserEntity)entity);
					break;
				case "SupportQueueThreadsClaimed":
					this.SupportQueueThreadsClaimed.Add((SupportQueueThreadEntity)entity);
					break;
				case "SupportQueueThreadsPlaced":
					this.SupportQueueThreadsPlaced.Add((SupportQueueThreadEntity)entity);
					break;
				case "StartedThreads":
					this.StartedThreads.Add((ThreadEntity)entity);
					break;
				case "ThreadSubscription":
					this.ThreadSubscription.Add((ThreadSubscriptionEntity)entity);
					break;
				case "StartedThreadsInForums":
					this.StartedThreadsInForums.IsReadOnly = false;
					this.StartedThreadsInForums.Add((ForumEntity)entity);
					this.StartedThreadsInForums.IsReadOnly = true;
					break;
				case "Roles":
					this.Roles.IsReadOnly = false;
					this.Roles.Add((RoleEntity)entity);
					this.Roles.IsReadOnly = true;
					break;
				case "ThreadsInBookmarks":
					this.ThreadsInBookmarks.IsReadOnly = false;
					this.ThreadsInBookmarks.Add((ThreadEntity)entity);
					this.ThreadsInBookmarks.IsReadOnly = true;
					break;
				case "PostedMessagesInThreads":
					this.PostedMessagesInThreads.IsReadOnly = false;
					this.PostedMessagesInThreads.Add((ThreadEntity)entity);
					this.PostedMessagesInThreads.IsReadOnly = true;
					break;
				case "ThreadCollectionViaThreadSubscription":
					this.ThreadCollectionViaThreadSubscription.IsReadOnly = false;
					this.ThreadCollectionViaThreadSubscription.Add((ThreadEntity)entity);
					this.ThreadCollectionViaThreadSubscription.IsReadOnly = true;
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
				case "UserTitle":
					toReturn.Add(Relations.UserTitleEntityUsingUserTitleID);
					break;
				case "LoggedAudits":
					toReturn.Add(Relations.AuditDataCoreEntityUsingUserID);
					break;
				case "Bookmarks":
					toReturn.Add(Relations.BookmarkEntityUsingUserID);
					break;
				case "IPBansSet":
					toReturn.Add(Relations.IPBanEntityUsingIPBanSetByUserID);
					break;
				case "PostedMessages":
					toReturn.Add(Relations.MessageEntityUsingPostedByUserID);
					break;
				case "RoleUser":
					toReturn.Add(Relations.RoleUserEntityUsingUserID);
					break;
				case "SupportQueueThreadsClaimed":
					toReturn.Add(Relations.SupportQueueThreadEntityUsingClaimedByUserID);
					break;
				case "SupportQueueThreadsPlaced":
					toReturn.Add(Relations.SupportQueueThreadEntityUsingPlacedInQueueByUserID);
					break;
				case "StartedThreads":
					toReturn.Add(Relations.ThreadEntityUsingStartedByUserID);
					break;
				case "ThreadSubscription":
					toReturn.Add(Relations.ThreadSubscriptionEntityUsingUserID);
					break;
				case "StartedThreadsInForums":
					toReturn.Add(Relations.ThreadEntityUsingStartedByUserID, "UserEntity__", "Thread_", JoinHint.None);
					toReturn.Add(ThreadEntity.Relations.ForumEntityUsingForumID, "Thread_", string.Empty, JoinHint.None);
					break;
				case "Roles":
					toReturn.Add(Relations.RoleUserEntityUsingUserID, "UserEntity__", "RoleUser_", JoinHint.None);
					toReturn.Add(RoleUserEntity.Relations.RoleEntityUsingRoleID, "RoleUser_", string.Empty, JoinHint.None);
					break;
				case "ThreadsInBookmarks":
					toReturn.Add(Relations.BookmarkEntityUsingUserID, "UserEntity__", "Bookmark_", JoinHint.None);
					toReturn.Add(BookmarkEntity.Relations.ThreadEntityUsingThreadID, "Bookmark_", string.Empty, JoinHint.None);
					break;
				case "PostedMessagesInThreads":
					toReturn.Add(Relations.MessageEntityUsingPostedByUserID, "UserEntity__", "Message_", JoinHint.None);
					toReturn.Add(MessageEntity.Relations.ThreadEntityUsingThreadID, "Message_", string.Empty, JoinHint.None);
					break;
				case "ThreadCollectionViaThreadSubscription":
					toReturn.Add(Relations.ThreadSubscriptionEntityUsingUserID, "UserEntity__", "ThreadSubscription_", JoinHint.None);
					toReturn.Add(ThreadSubscriptionEntity.Relations.ThreadEntityUsingThreadID, "ThreadSubscription_", string.Empty, JoinHint.None);
					break;
				default:
					break;				
			}
			return toReturn;
		}
#if !CF
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
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "UserTitle":
					SetupSyncUserTitle(relatedEntity);
					break;
				case "LoggedAudits":
					this.LoggedAudits.Add((AuditDataCoreEntity)relatedEntity);
					break;
				case "Bookmarks":
					this.Bookmarks.Add((BookmarkEntity)relatedEntity);
					break;
				case "IPBansSet":
					this.IPBansSet.Add((IPBanEntity)relatedEntity);
					break;
				case "PostedMessages":
					this.PostedMessages.Add((MessageEntity)relatedEntity);
					break;
				case "RoleUser":
					this.RoleUser.Add((RoleUserEntity)relatedEntity);
					break;
				case "SupportQueueThreadsClaimed":
					this.SupportQueueThreadsClaimed.Add((SupportQueueThreadEntity)relatedEntity);
					break;
				case "SupportQueueThreadsPlaced":
					this.SupportQueueThreadsPlaced.Add((SupportQueueThreadEntity)relatedEntity);
					break;
				case "StartedThreads":
					this.StartedThreads.Add((ThreadEntity)relatedEntity);
					break;
				case "ThreadSubscription":
					this.ThreadSubscription.Add((ThreadSubscriptionEntity)relatedEntity);
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
				case "UserTitle":
					DesetupSyncUserTitle(false, true);
					break;
				case "LoggedAudits":
					this.PerformRelatedEntityRemoval(this.LoggedAudits, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Bookmarks":
					this.PerformRelatedEntityRemoval(this.Bookmarks, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "IPBansSet":
					this.PerformRelatedEntityRemoval(this.IPBansSet, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PostedMessages":
					this.PerformRelatedEntityRemoval(this.PostedMessages, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleUser":
					this.PerformRelatedEntityRemoval(this.RoleUser, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportQueueThreadsClaimed":
					this.PerformRelatedEntityRemoval(this.SupportQueueThreadsClaimed, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportQueueThreadsPlaced":
					this.PerformRelatedEntityRemoval(this.SupportQueueThreadsPlaced, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "StartedThreads":
					this.PerformRelatedEntityRemoval(this.StartedThreads, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ThreadSubscription":
					this.PerformRelatedEntityRemoval(this.ThreadSubscription, relatedEntity, signalRelatedEntityManyToOne);
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
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_userTitle!=null)
			{
				toReturn.Add(_userTitle);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.LoggedAudits);
			toReturn.Add(this.Bookmarks);
			toReturn.Add(this.IPBansSet);
			toReturn.Add(this.PostedMessages);
			toReturn.Add(this.RoleUser);
			toReturn.Add(this.SupportQueueThreadsClaimed);
			toReturn.Add(this.SupportQueueThreadsPlaced);
			toReturn.Add(this.StartedThreads);
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
				info.AddValue("_loggedAudits", ((_loggedAudits!=null) && (_loggedAudits.Count>0) && !this.MarkedForDeletion)?_loggedAudits:null);
				info.AddValue("_bookmarks", ((_bookmarks!=null) && (_bookmarks.Count>0) && !this.MarkedForDeletion)?_bookmarks:null);
				info.AddValue("_iPBansSet", ((_iPBansSet!=null) && (_iPBansSet.Count>0) && !this.MarkedForDeletion)?_iPBansSet:null);
				info.AddValue("_postedMessages", ((_postedMessages!=null) && (_postedMessages.Count>0) && !this.MarkedForDeletion)?_postedMessages:null);
				info.AddValue("_roleUser", ((_roleUser!=null) && (_roleUser.Count>0) && !this.MarkedForDeletion)?_roleUser:null);
				info.AddValue("_supportQueueThreadsClaimed", ((_supportQueueThreadsClaimed!=null) && (_supportQueueThreadsClaimed.Count>0) && !this.MarkedForDeletion)?_supportQueueThreadsClaimed:null);
				info.AddValue("_supportQueueThreadsPlaced", ((_supportQueueThreadsPlaced!=null) && (_supportQueueThreadsPlaced.Count>0) && !this.MarkedForDeletion)?_supportQueueThreadsPlaced:null);
				info.AddValue("_startedThreads", ((_startedThreads!=null) && (_startedThreads.Count>0) && !this.MarkedForDeletion)?_startedThreads:null);
				info.AddValue("_threadSubscription", ((_threadSubscription!=null) && (_threadSubscription.Count>0) && !this.MarkedForDeletion)?_threadSubscription:null);
				info.AddValue("_startedThreadsInForums", ((_startedThreadsInForums!=null) && (_startedThreadsInForums.Count>0) && !this.MarkedForDeletion)?_startedThreadsInForums:null);
				info.AddValue("_roles", ((_roles!=null) && (_roles.Count>0) && !this.MarkedForDeletion)?_roles:null);
				info.AddValue("_threadsInBookmarks", ((_threadsInBookmarks!=null) && (_threadsInBookmarks.Count>0) && !this.MarkedForDeletion)?_threadsInBookmarks:null);
				info.AddValue("_postedMessagesInThreads", ((_postedMessagesInThreads!=null) && (_postedMessagesInThreads.Count>0) && !this.MarkedForDeletion)?_postedMessagesInThreads:null);
				info.AddValue("_threadCollectionViaThreadSubscription", ((_threadCollectionViaThreadSubscription!=null) && (_threadCollectionViaThreadSubscription.Count>0) && !this.MarkedForDeletion)?_threadCollectionViaThreadSubscription:null);
				info.AddValue("_userTitle", (!this.MarkedForDeletion?_userTitle:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// NickName .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCNickName()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(SD.HnD.DALAdapter.HelperClasses.UserFields.NickName == this.Fields.GetCurrentValue((int)UserFieldIndex.NickName));
 			return filter;
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new UserRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'AuditDataCore' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLoggedAudits()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AuditDataCoreFields.UserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Bookmark' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBookmarks()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BookmarkFields.UserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'IPBan' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoIPBansSet()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(IPBanFields.IPBanSetByUserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Message' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPostedMessages()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MessageFields.PostedByUserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'RoleUser' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleUserFields.UserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'SupportQueueThread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSupportQueueThreadsClaimed()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SupportQueueThreadFields.ClaimedByUserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'SupportQueueThread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSupportQueueThreadsPlaced()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SupportQueueThreadFields.PlacedInQueueByUserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStartedThreads()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ThreadFields.StartedByUserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ThreadSubscription' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThreadSubscription()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ThreadSubscriptionFields.UserID, null, ComparisonOperator.Equal, this.UserID));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Forum' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStartedThreadsInForums()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StartedThreadsInForums"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Role' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoles()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("Roles"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThreadsInBookmarks()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ThreadsInBookmarks"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPostedMessagesInThreads()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PostedMessagesInThreads"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThreadCollectionViaThreadSubscription()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ThreadCollectionViaThreadSubscription"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.UserID, null, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'UserTitle' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserTitle()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserTitleFields.UserTitleID, null, ComparisonOperator.Equal, this.UserTitleID));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._loggedAudits);
			collectionsQueue.Enqueue(this._bookmarks);
			collectionsQueue.Enqueue(this._iPBansSet);
			collectionsQueue.Enqueue(this._postedMessages);
			collectionsQueue.Enqueue(this._roleUser);
			collectionsQueue.Enqueue(this._supportQueueThreadsClaimed);
			collectionsQueue.Enqueue(this._supportQueueThreadsPlaced);
			collectionsQueue.Enqueue(this._startedThreads);
			collectionsQueue.Enqueue(this._threadSubscription);
			collectionsQueue.Enqueue(this._startedThreadsInForums);
			collectionsQueue.Enqueue(this._roles);
			collectionsQueue.Enqueue(this._threadsInBookmarks);
			collectionsQueue.Enqueue(this._postedMessagesInThreads);
			collectionsQueue.Enqueue(this._threadCollectionViaThreadSubscription);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._loggedAudits = (EntityCollection<AuditDataCoreEntity>) collectionsQueue.Dequeue();
			this._bookmarks = (EntityCollection<BookmarkEntity>) collectionsQueue.Dequeue();
			this._iPBansSet = (EntityCollection<IPBanEntity>) collectionsQueue.Dequeue();
			this._postedMessages = (EntityCollection<MessageEntity>) collectionsQueue.Dequeue();
			this._roleUser = (EntityCollection<RoleUserEntity>) collectionsQueue.Dequeue();
			this._supportQueueThreadsClaimed = (EntityCollection<SupportQueueThreadEntity>) collectionsQueue.Dequeue();
			this._supportQueueThreadsPlaced = (EntityCollection<SupportQueueThreadEntity>) collectionsQueue.Dequeue();
			this._startedThreads = (EntityCollection<ThreadEntity>) collectionsQueue.Dequeue();
			this._threadSubscription = (EntityCollection<ThreadSubscriptionEntity>) collectionsQueue.Dequeue();
			this._startedThreadsInForums = (EntityCollection<ForumEntity>) collectionsQueue.Dequeue();
			this._roles = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._threadsInBookmarks = (EntityCollection<ThreadEntity>) collectionsQueue.Dequeue();
			this._postedMessagesInThreads = (EntityCollection<ThreadEntity>) collectionsQueue.Dequeue();
			this._threadCollectionViaThreadSubscription = (EntityCollection<ThreadEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._loggedAudits != null);
			toReturn |=(this._bookmarks != null);
			toReturn |=(this._iPBansSet != null);
			toReturn |=(this._postedMessages != null);
			toReturn |=(this._roleUser != null);
			toReturn |=(this._supportQueueThreadsClaimed != null);
			toReturn |=(this._supportQueueThreadsPlaced != null);
			toReturn |=(this._startedThreads != null);
			toReturn |=(this._threadSubscription != null);
			toReturn |= (this._startedThreadsInForums != null);
			toReturn |= (this._roles != null);
			toReturn |= (this._threadsInBookmarks != null);
			toReturn |= (this._postedMessagesInThreads != null);
			toReturn |= (this._threadCollectionViaThreadSubscription != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AuditDataCoreEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AuditDataCoreEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BookmarkEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BookmarkEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<IPBanEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IPBanEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MessageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SupportQueueThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SupportQueueThreadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SupportQueueThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SupportQueueThreadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ThreadSubscriptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadSubscriptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ForumEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ForumEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))) : null);
		}
#endif
		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("UserTitle", _userTitle);
			toReturn.Add("LoggedAudits", _loggedAudits);
			toReturn.Add("Bookmarks", _bookmarks);
			toReturn.Add("IPBansSet", _iPBansSet);
			toReturn.Add("PostedMessages", _postedMessages);
			toReturn.Add("RoleUser", _roleUser);
			toReturn.Add("SupportQueueThreadsClaimed", _supportQueueThreadsClaimed);
			toReturn.Add("SupportQueueThreadsPlaced", _supportQueueThreadsPlaced);
			toReturn.Add("StartedThreads", _startedThreads);
			toReturn.Add("ThreadSubscription", _threadSubscription);
			toReturn.Add("StartedThreadsInForums", _startedThreadsInForums);
			toReturn.Add("Roles", _roles);
			toReturn.Add("ThreadsInBookmarks", _threadsInBookmarks);
			toReturn.Add("PostedMessagesInThreads", _postedMessagesInThreads);
			toReturn.Add("ThreadCollectionViaThreadSubscription", _threadCollectionViaThreadSubscription);
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
			_fieldsCustomProperties.Add("UserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NickName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Password", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsBanned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Signature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IconURL", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EmailAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UserTitleID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DateOfBirth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Occupation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Location", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Website", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SignatureAsHTML", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("JoinDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AmountOfPostings", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EmailAddressIsPublic", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastVisitedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AutoSubscribeToThread", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultNumberOfMessagesPerPage", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _userTitle</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUserTitle(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _userTitle, new PropertyChangedEventHandler( OnUserTitlePropertyChanged ), "UserTitle", SD.HnD.DALAdapter.RelationClasses.StaticUserRelations.UserTitleEntityUsingUserTitleIDStatic, true, signalRelatedEntity, "Users", resetFKFields, new int[] { (int)UserFieldIndex.UserTitleID } );
			_userTitle = null;
		}

		/// <summary> setups the sync logic for member _userTitle</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUserTitle(IEntityCore relatedEntity)
		{
			if(_userTitle!=relatedEntity)
			{
				DesetupSyncUserTitle(true, true);
				_userTitle = (UserTitleEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _userTitle, new PropertyChangedEventHandler( OnUserTitlePropertyChanged ), "UserTitle", SD.HnD.DALAdapter.RelationClasses.StaticUserRelations.UserTitleEntityUsingUserTitleIDStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserTitlePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this UserEntity</param>
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
		public  static UserRelations Relations
		{
			get	{ return new UserRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AuditDataCore' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLoggedAudits
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<AuditDataCoreEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AuditDataCoreEntityFactory))), (IEntityRelation)GetRelationsForField("LoggedAudits")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.AuditDataCoreEntity, 0, null, null, null, null, "LoggedAudits", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Bookmark' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBookmarks
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<BookmarkEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BookmarkEntityFactory))), (IEntityRelation)GetRelationsForField("Bookmarks")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.BookmarkEntity, 0, null, null, null, null, "Bookmarks", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'IPBan' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathIPBansSet
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<IPBanEntity>(EntityFactoryCache2.GetEntityFactory(typeof(IPBanEntityFactory))), (IEntityRelation)GetRelationsForField("IPBansSet")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.IPBanEntity, 0, null, null, null, null, "IPBansSet", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Message' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPostedMessages
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<MessageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MessageEntityFactory))), (IEntityRelation)GetRelationsForField("PostedMessages")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.MessageEntity, 0, null, null, null, null, "PostedMessages", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RoleUser' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleUser
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<RoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleUserEntityFactory))), (IEntityRelation)GetRelationsForField("RoleUser")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.RoleUserEntity, 0, null, null, null, null, "RoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SupportQueueThread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSupportQueueThreadsClaimed
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<SupportQueueThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SupportQueueThreadEntityFactory))), (IEntityRelation)GetRelationsForField("SupportQueueThreadsClaimed")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, 0, null, null, null, null, "SupportQueueThreadsClaimed", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SupportQueueThread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSupportQueueThreadsPlaced
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<SupportQueueThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SupportQueueThreadEntityFactory))), (IEntityRelation)GetRelationsForField("SupportQueueThreadsPlaced")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity, 0, null, null, null, null, "SupportQueueThreadsPlaced", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStartedThreads
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))), (IEntityRelation)GetRelationsForField("StartedThreads")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, 0, null, null, null, null, "StartedThreads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ThreadSubscription' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThreadSubscription
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<ThreadSubscriptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadSubscriptionEntityFactory))), (IEntityRelation)GetRelationsForField("ThreadSubscription")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadSubscriptionEntity, 0, null, null, null, null, "ThreadSubscription", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Forum' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStartedThreadsInForums
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ThreadEntityUsingStartedByUserID;
				intermediateRelation.SetAliases(string.Empty, "Thread_");
				return new PrefetchPathElement2(new EntityCollection<ForumEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ForumEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.ForumEntity, 0, null, null, GetRelationsForField("StartedThreadsInForums"), null, "StartedThreadsInForums", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoles
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleUserEntityUsingUserID;
				intermediateRelation.SetAliases(string.Empty, "RoleUser_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.RoleEntity, 0, null, null, GetRelationsForField("Roles"), null, "Roles", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThreadsInBookmarks
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.BookmarkEntityUsingUserID;
				intermediateRelation.SetAliases(string.Empty, "Bookmark_");
				return new PrefetchPathElement2(new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, 0, null, null, GetRelationsForField("ThreadsInBookmarks"), null, "ThreadsInBookmarks", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPostedMessagesInThreads
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.MessageEntityUsingPostedByUserID;
				intermediateRelation.SetAliases(string.Empty, "Message_");
				return new PrefetchPathElement2(new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, 0, null, null, GetRelationsForField("PostedMessagesInThreads"), null, "PostedMessagesInThreads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThreadCollectionViaThreadSubscription
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ThreadSubscriptionEntityUsingUserID;
				intermediateRelation.SetAliases(string.Empty, "ThreadSubscription_");
				return new PrefetchPathElement2(new EntityCollection<ThreadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ThreadEntityFactory))), intermediateRelation,
					(int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, 0, null, null, GetRelationsForField("ThreadCollectionViaThreadSubscription"), null, "ThreadCollectionViaThreadSubscription", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UserTitle' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserTitle
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(UserTitleEntityFactory))),	(IEntityRelation)GetRelationsForField("UserTitle")[0], (int)SD.HnD.DALAdapter.EntityType.UserEntity, (int)SD.HnD.DALAdapter.EntityType.UserTitleEntity, 0, null, null, null, null, "UserTitle", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The UserID property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."UserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 UserID
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.UserID, true); }
			set	{ SetValue((int)UserFieldIndex.UserID, value); }
		}

		/// <summary> The NickName property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."NickName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String NickName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.NickName, true); }
			set	{ SetValue((int)UserFieldIndex.NickName, value); }
		}

		/// <summary> The Password property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Password"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 30<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Password
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Password, true); }
			set	{ SetValue((int)UserFieldIndex.Password, value); }
		}

		/// <summary> The IsBanned property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."IsBanned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsBanned
		{
			get { return (System.Boolean)GetValue((int)UserFieldIndex.IsBanned, true); }
			set	{ SetValue((int)UserFieldIndex.IsBanned, value); }
		}

		/// <summary> The IPNumber property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."IPNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 25<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String IPNumber
		{
			get { return (System.String)GetValue((int)UserFieldIndex.IPNumber, true); }
			set	{ SetValue((int)UserFieldIndex.IPNumber, value); }
		}

		/// <summary> The Signature property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Signature"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Signature
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Signature, true); }
			set	{ SetValue((int)UserFieldIndex.Signature, value); }
		}

		/// <summary> The IconURL property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."IconURL"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IconURL
		{
			get { return (System.String)GetValue((int)UserFieldIndex.IconURL, true); }
			set	{ SetValue((int)UserFieldIndex.IconURL, value); }
		}

		/// <summary> The EmailAddress property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."EmailAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmailAddress
		{
			get { return (System.String)GetValue((int)UserFieldIndex.EmailAddress, true); }
			set	{ SetValue((int)UserFieldIndex.EmailAddress, value); }
		}

		/// <summary> The UserTitleID property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."UserTitleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 UserTitleID
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.UserTitleID, true); }
			set	{ SetValue((int)UserFieldIndex.UserTitleID, value); }
		}

		/// <summary> The DateOfBirth property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."DateOfBirth"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateOfBirth
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.DateOfBirth, false); }
			set	{ SetValue((int)UserFieldIndex.DateOfBirth, value); }
		}

		/// <summary> The Occupation property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Occupation"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Occupation
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Occupation, true); }
			set	{ SetValue((int)UserFieldIndex.Occupation, value); }
		}

		/// <summary> The Location property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Location"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Location
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Location, true); }
			set	{ SetValue((int)UserFieldIndex.Location, value); }
		}

		/// <summary> The Website property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Website"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Website
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Website, true); }
			set	{ SetValue((int)UserFieldIndex.Website, value); }
		}

		/// <summary> The SignatureAsHTML property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."SignatureAsHTML"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SignatureAsHTML
		{
			get { return (System.String)GetValue((int)UserFieldIndex.SignatureAsHTML, true); }
			set	{ SetValue((int)UserFieldIndex.SignatureAsHTML, value); }
		}

		/// <summary> The JoinDate property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."JoinDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> JoinDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.JoinDate, false); }
			set	{ SetValue((int)UserFieldIndex.JoinDate, value); }
		}

		/// <summary> The AmountOfPostings property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."AmountOfPostings"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AmountOfPostings
		{
			get { return (Nullable<System.Int32>)GetValue((int)UserFieldIndex.AmountOfPostings, false); }
			set	{ SetValue((int)UserFieldIndex.AmountOfPostings, value); }
		}

		/// <summary> The EmailAddressIsPublic property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."EmailAddressIsPublic"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> EmailAddressIsPublic
		{
			get { return (Nullable<System.Boolean>)GetValue((int)UserFieldIndex.EmailAddressIsPublic, false); }
			set	{ SetValue((int)UserFieldIndex.EmailAddressIsPublic, value); }
		}

		/// <summary> The LastVisitedDate property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastVisitedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastVisitedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.LastVisitedDate, false); }
			set	{ SetValue((int)UserFieldIndex.LastVisitedDate, value); }
		}

		/// <summary> The AutoSubscribeToThread property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."AutoSubscribeToThread"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Boolean AutoSubscribeToThread
		{
			get { return (System.Boolean)GetValue((int)UserFieldIndex.AutoSubscribeToThread, true); }
			set	{ SetValue((int)UserFieldIndex.AutoSubscribeToThread, value); }
		}

		/// <summary> The DefaultNumberOfMessagesPerPage property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."DefaultNumberOfMessagesPerPage"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int16 DefaultNumberOfMessagesPerPage
		{
			get { return (System.Int16)GetValue((int)UserFieldIndex.DefaultNumberOfMessagesPerPage, true); }
			set	{ SetValue((int)UserFieldIndex.DefaultNumberOfMessagesPerPage, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AuditDataCoreEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(AuditDataCoreEntity))]
		public virtual EntityCollection<AuditDataCoreEntity> LoggedAudits
		{
			get { return GetOrCreateEntityCollection<AuditDataCoreEntity, AuditDataCoreEntityFactory>("UserAudited", true, false, ref _loggedAudits);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BookmarkEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(BookmarkEntity))]
		public virtual EntityCollection<BookmarkEntity> Bookmarks
		{
			get { return GetOrCreateEntityCollection<BookmarkEntity, BookmarkEntityFactory>("User", true, false, ref _bookmarks);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'IPBanEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(IPBanEntity))]
		public virtual EntityCollection<IPBanEntity> IPBansSet
		{
			get { return GetOrCreateEntityCollection<IPBanEntity, IPBanEntityFactory>("SetByUser", true, false, ref _iPBansSet);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MessageEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(MessageEntity))]
		public virtual EntityCollection<MessageEntity> PostedMessages
		{
			get { return GetOrCreateEntityCollection<MessageEntity, MessageEntityFactory>("PostedByUser", true, false, ref _postedMessages);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleUserEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(RoleUserEntity))]
		public virtual EntityCollection<RoleUserEntity> RoleUser
		{
			get { return GetOrCreateEntityCollection<RoleUserEntity, RoleUserEntityFactory>("User", true, false, ref _roleUser);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SupportQueueThreadEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(SupportQueueThreadEntity))]
		public virtual EntityCollection<SupportQueueThreadEntity> SupportQueueThreadsClaimed
		{
			get { return GetOrCreateEntityCollection<SupportQueueThreadEntity, SupportQueueThreadEntityFactory>("ClaimedByUser", true, false, ref _supportQueueThreadsClaimed);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SupportQueueThreadEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(SupportQueueThreadEntity))]
		public virtual EntityCollection<SupportQueueThreadEntity> SupportQueueThreadsPlaced
		{
			get { return GetOrCreateEntityCollection<SupportQueueThreadEntity, SupportQueueThreadEntityFactory>("PlacedInQueueByUser", true, false, ref _supportQueueThreadsPlaced);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ThreadEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadEntity))]
		public virtual EntityCollection<ThreadEntity> StartedThreads
		{
			get { return GetOrCreateEntityCollection<ThreadEntity, ThreadEntityFactory>("UserWhoStartedThread", true, false, ref _startedThreads);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ThreadSubscriptionEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadSubscriptionEntity))]
		public virtual EntityCollection<ThreadSubscriptionEntity> ThreadSubscription
		{
			get { return GetOrCreateEntityCollection<ThreadSubscriptionEntity, ThreadSubscriptionEntityFactory>("User", true, false, ref _threadSubscription);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ForumEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ForumEntity))]
		public virtual EntityCollection<ForumEntity> StartedThreadsInForums
		{
			get { return GetOrCreateEntityCollection<ForumEntity, ForumEntityFactory>("UsersWhoStartedThreads", false, true, ref _startedThreadsInForums);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> Roles
		{
			get { return GetOrCreateEntityCollection<RoleEntity, RoleEntityFactory>("Users", false, true, ref _roles);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ThreadEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadEntity))]
		public virtual EntityCollection<ThreadEntity> ThreadsInBookmarks
		{
			get { return GetOrCreateEntityCollection<ThreadEntity, ThreadEntityFactory>("UsersWhoBookmarkedThread", false, true, ref _threadsInBookmarks);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ThreadEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadEntity))]
		public virtual EntityCollection<ThreadEntity> PostedMessagesInThreads
		{
			get { return GetOrCreateEntityCollection<ThreadEntity, ThreadEntityFactory>("UsersWhoPostedInThread", false, true, ref _postedMessagesInThreads);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ThreadEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadEntity))]
		public virtual EntityCollection<ThreadEntity> ThreadCollectionViaThreadSubscription
		{
			get { return GetOrCreateEntityCollection<ThreadEntity, ThreadEntityFactory>("UsersWhoSubscribedThread", false, true, ref _threadCollectionViaThreadSubscription);	}
		}

		/// <summary> Gets / sets related entity of type 'UserTitleEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserTitleEntity UserTitle
		{
			get	{ return _userTitle; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncUserTitle(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Users", "UserTitle", _userTitle, true); 
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
			get { return (int)SD.HnD.DALAdapter.EntityType.UserEntity; }
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
