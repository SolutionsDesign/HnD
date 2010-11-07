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
	/// <summary>Entity base class which represents the base class for the entity 'User'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class UserEntityBase : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection	_loggedAudits;
		private bool	_alwaysFetchLoggedAudits, _alreadyFetchedLoggedAudits;
		private SD.HnD.DAL.CollectionClasses.BookmarkCollection	_bookmarks;
		private bool	_alwaysFetchBookmarks, _alreadyFetchedBookmarks;
		private SD.HnD.DAL.CollectionClasses.IPBanCollection	_iPBansSet;
		private bool	_alwaysFetchIPBansSet, _alreadyFetchedIPBansSet;
		private SD.HnD.DAL.CollectionClasses.MessageCollection	_postedMessages;
		private bool	_alwaysFetchPostedMessages, _alreadyFetchedPostedMessages;
		private SD.HnD.DAL.CollectionClasses.RoleUserCollection	_roleUser;
		private bool	_alwaysFetchRoleUser, _alreadyFetchedRoleUser;
		private SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection	_supportQueueThreadsClaimed;
		private bool	_alwaysFetchSupportQueueThreadsClaimed, _alreadyFetchedSupportQueueThreadsClaimed;
		private SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection	_supportQueueThreadsPlaced;
		private bool	_alwaysFetchSupportQueueThreadsPlaced, _alreadyFetchedSupportQueueThreadsPlaced;
		private SD.HnD.DAL.CollectionClasses.ThreadCollection	_startedThreads;
		private bool	_alwaysFetchStartedThreads, _alreadyFetchedStartedThreads;
		private SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection	_threadSubscription;
		private bool	_alwaysFetchThreadSubscription, _alreadyFetchedThreadSubscription;
		private SD.HnD.DAL.CollectionClasses.ForumCollection _startedThreadsInForums;
		private bool	_alwaysFetchStartedThreadsInForums, _alreadyFetchedStartedThreadsInForums;
		private SD.HnD.DAL.CollectionClasses.RoleCollection _roles;
		private bool	_alwaysFetchRoles, _alreadyFetchedRoles;
		private SD.HnD.DAL.CollectionClasses.ThreadCollection _threadsInBookmarks;
		private bool	_alwaysFetchThreadsInBookmarks, _alreadyFetchedThreadsInBookmarks;
		private SD.HnD.DAL.CollectionClasses.ThreadCollection _postedMessagesInThreads;
		private bool	_alwaysFetchPostedMessagesInThreads, _alreadyFetchedPostedMessagesInThreads;
		private SD.HnD.DAL.CollectionClasses.ThreadCollection _threadCollectionViaThreadSubscription;
		private bool	_alwaysFetchThreadCollectionViaThreadSubscription, _alreadyFetchedThreadCollectionViaThreadSubscription;
		private UserTitleEntity _userTitle;
		private bool	_alwaysFetchUserTitle, _alreadyFetchedUserTitle, _userTitleReturnsNewIfNotFound;

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
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static UserEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		protected UserEntityBase() : base()
		{
			InitClassEmpty(null);
		}

		/// <summary>CTor</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		protected UserEntityBase(System.Int32 userID)
		{
			InitClassFetch(userID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected UserEntityBase(System.Int32 userID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(userID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		protected UserEntityBase(System.Int32 userID, IValidator validator)
		{
			InitClassFetch(userID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected UserEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_loggedAudits = (SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection)info.GetValue("_loggedAudits", typeof(SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection));
			_alwaysFetchLoggedAudits = info.GetBoolean("_alwaysFetchLoggedAudits");
			_alreadyFetchedLoggedAudits = info.GetBoolean("_alreadyFetchedLoggedAudits");

			_bookmarks = (SD.HnD.DAL.CollectionClasses.BookmarkCollection)info.GetValue("_bookmarks", typeof(SD.HnD.DAL.CollectionClasses.BookmarkCollection));
			_alwaysFetchBookmarks = info.GetBoolean("_alwaysFetchBookmarks");
			_alreadyFetchedBookmarks = info.GetBoolean("_alreadyFetchedBookmarks");

			_iPBansSet = (SD.HnD.DAL.CollectionClasses.IPBanCollection)info.GetValue("_iPBansSet", typeof(SD.HnD.DAL.CollectionClasses.IPBanCollection));
			_alwaysFetchIPBansSet = info.GetBoolean("_alwaysFetchIPBansSet");
			_alreadyFetchedIPBansSet = info.GetBoolean("_alreadyFetchedIPBansSet");

			_postedMessages = (SD.HnD.DAL.CollectionClasses.MessageCollection)info.GetValue("_postedMessages", typeof(SD.HnD.DAL.CollectionClasses.MessageCollection));
			_alwaysFetchPostedMessages = info.GetBoolean("_alwaysFetchPostedMessages");
			_alreadyFetchedPostedMessages = info.GetBoolean("_alreadyFetchedPostedMessages");

			_roleUser = (SD.HnD.DAL.CollectionClasses.RoleUserCollection)info.GetValue("_roleUser", typeof(SD.HnD.DAL.CollectionClasses.RoleUserCollection));
			_alwaysFetchRoleUser = info.GetBoolean("_alwaysFetchRoleUser");
			_alreadyFetchedRoleUser = info.GetBoolean("_alreadyFetchedRoleUser");

			_supportQueueThreadsClaimed = (SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection)info.GetValue("_supportQueueThreadsClaimed", typeof(SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection));
			_alwaysFetchSupportQueueThreadsClaimed = info.GetBoolean("_alwaysFetchSupportQueueThreadsClaimed");
			_alreadyFetchedSupportQueueThreadsClaimed = info.GetBoolean("_alreadyFetchedSupportQueueThreadsClaimed");

			_supportQueueThreadsPlaced = (SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection)info.GetValue("_supportQueueThreadsPlaced", typeof(SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection));
			_alwaysFetchSupportQueueThreadsPlaced = info.GetBoolean("_alwaysFetchSupportQueueThreadsPlaced");
			_alreadyFetchedSupportQueueThreadsPlaced = info.GetBoolean("_alreadyFetchedSupportQueueThreadsPlaced");

			_startedThreads = (SD.HnD.DAL.CollectionClasses.ThreadCollection)info.GetValue("_startedThreads", typeof(SD.HnD.DAL.CollectionClasses.ThreadCollection));
			_alwaysFetchStartedThreads = info.GetBoolean("_alwaysFetchStartedThreads");
			_alreadyFetchedStartedThreads = info.GetBoolean("_alreadyFetchedStartedThreads");

			_threadSubscription = (SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection)info.GetValue("_threadSubscription", typeof(SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection));
			_alwaysFetchThreadSubscription = info.GetBoolean("_alwaysFetchThreadSubscription");
			_alreadyFetchedThreadSubscription = info.GetBoolean("_alreadyFetchedThreadSubscription");
			_startedThreadsInForums = (SD.HnD.DAL.CollectionClasses.ForumCollection)info.GetValue("_startedThreadsInForums", typeof(SD.HnD.DAL.CollectionClasses.ForumCollection));
			_alwaysFetchStartedThreadsInForums = info.GetBoolean("_alwaysFetchStartedThreadsInForums");
			_alreadyFetchedStartedThreadsInForums = info.GetBoolean("_alreadyFetchedStartedThreadsInForums");

			_roles = (SD.HnD.DAL.CollectionClasses.RoleCollection)info.GetValue("_roles", typeof(SD.HnD.DAL.CollectionClasses.RoleCollection));
			_alwaysFetchRoles = info.GetBoolean("_alwaysFetchRoles");
			_alreadyFetchedRoles = info.GetBoolean("_alreadyFetchedRoles");

			_threadsInBookmarks = (SD.HnD.DAL.CollectionClasses.ThreadCollection)info.GetValue("_threadsInBookmarks", typeof(SD.HnD.DAL.CollectionClasses.ThreadCollection));
			_alwaysFetchThreadsInBookmarks = info.GetBoolean("_alwaysFetchThreadsInBookmarks");
			_alreadyFetchedThreadsInBookmarks = info.GetBoolean("_alreadyFetchedThreadsInBookmarks");

			_postedMessagesInThreads = (SD.HnD.DAL.CollectionClasses.ThreadCollection)info.GetValue("_postedMessagesInThreads", typeof(SD.HnD.DAL.CollectionClasses.ThreadCollection));
			_alwaysFetchPostedMessagesInThreads = info.GetBoolean("_alwaysFetchPostedMessagesInThreads");
			_alreadyFetchedPostedMessagesInThreads = info.GetBoolean("_alreadyFetchedPostedMessagesInThreads");

			_threadCollectionViaThreadSubscription = (SD.HnD.DAL.CollectionClasses.ThreadCollection)info.GetValue("_threadCollectionViaThreadSubscription", typeof(SD.HnD.DAL.CollectionClasses.ThreadCollection));
			_alwaysFetchThreadCollectionViaThreadSubscription = info.GetBoolean("_alwaysFetchThreadCollectionViaThreadSubscription");
			_alreadyFetchedThreadCollectionViaThreadSubscription = info.GetBoolean("_alreadyFetchedThreadCollectionViaThreadSubscription");
			_userTitle = (UserTitleEntity)info.GetValue("_userTitle", typeof(UserTitleEntity));
			if(_userTitle!=null)
			{
				_userTitle.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_userTitleReturnsNewIfNotFound = info.GetBoolean("_userTitleReturnsNewIfNotFound");
			_alwaysFetchUserTitle = info.GetBoolean("_alwaysFetchUserTitle");
			_alreadyFetchedUserTitle = info.GetBoolean("_alreadyFetchedUserTitle");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
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
					_alreadyFetchedUserTitle = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{
			_alreadyFetchedLoggedAudits = (_loggedAudits.Count > 0);
			_alreadyFetchedBookmarks = (_bookmarks.Count > 0);
			_alreadyFetchedIPBansSet = (_iPBansSet.Count > 0);
			_alreadyFetchedPostedMessages = (_postedMessages.Count > 0);
			_alreadyFetchedRoleUser = (_roleUser.Count > 0);
			_alreadyFetchedSupportQueueThreadsClaimed = (_supportQueueThreadsClaimed.Count > 0);
			_alreadyFetchedSupportQueueThreadsPlaced = (_supportQueueThreadsPlaced.Count > 0);
			_alreadyFetchedStartedThreads = (_startedThreads.Count > 0);
			_alreadyFetchedThreadSubscription = (_threadSubscription.Count > 0);
			_alreadyFetchedStartedThreadsInForums = (_startedThreadsInForums.Count > 0);
			_alreadyFetchedRoles = (_roles.Count > 0);
			_alreadyFetchedThreadsInBookmarks = (_threadsInBookmarks.Count > 0);
			_alreadyFetchedPostedMessagesInThreads = (_postedMessagesInThreads.Count > 0);
			_alreadyFetchedThreadCollectionViaThreadSubscription = (_threadCollectionViaThreadSubscription.Count > 0);
			_alreadyFetchedUserTitle = (_userTitle != null);
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



		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_loggedAudits", (!this.MarkedForDeletion?_loggedAudits:null));
			info.AddValue("_alwaysFetchLoggedAudits", _alwaysFetchLoggedAudits);
			info.AddValue("_alreadyFetchedLoggedAudits", _alreadyFetchedLoggedAudits);
			info.AddValue("_bookmarks", (!this.MarkedForDeletion?_bookmarks:null));
			info.AddValue("_alwaysFetchBookmarks", _alwaysFetchBookmarks);
			info.AddValue("_alreadyFetchedBookmarks", _alreadyFetchedBookmarks);
			info.AddValue("_iPBansSet", (!this.MarkedForDeletion?_iPBansSet:null));
			info.AddValue("_alwaysFetchIPBansSet", _alwaysFetchIPBansSet);
			info.AddValue("_alreadyFetchedIPBansSet", _alreadyFetchedIPBansSet);
			info.AddValue("_postedMessages", (!this.MarkedForDeletion?_postedMessages:null));
			info.AddValue("_alwaysFetchPostedMessages", _alwaysFetchPostedMessages);
			info.AddValue("_alreadyFetchedPostedMessages", _alreadyFetchedPostedMessages);
			info.AddValue("_roleUser", (!this.MarkedForDeletion?_roleUser:null));
			info.AddValue("_alwaysFetchRoleUser", _alwaysFetchRoleUser);
			info.AddValue("_alreadyFetchedRoleUser", _alreadyFetchedRoleUser);
			info.AddValue("_supportQueueThreadsClaimed", (!this.MarkedForDeletion?_supportQueueThreadsClaimed:null));
			info.AddValue("_alwaysFetchSupportQueueThreadsClaimed", _alwaysFetchSupportQueueThreadsClaimed);
			info.AddValue("_alreadyFetchedSupportQueueThreadsClaimed", _alreadyFetchedSupportQueueThreadsClaimed);
			info.AddValue("_supportQueueThreadsPlaced", (!this.MarkedForDeletion?_supportQueueThreadsPlaced:null));
			info.AddValue("_alwaysFetchSupportQueueThreadsPlaced", _alwaysFetchSupportQueueThreadsPlaced);
			info.AddValue("_alreadyFetchedSupportQueueThreadsPlaced", _alreadyFetchedSupportQueueThreadsPlaced);
			info.AddValue("_startedThreads", (!this.MarkedForDeletion?_startedThreads:null));
			info.AddValue("_alwaysFetchStartedThreads", _alwaysFetchStartedThreads);
			info.AddValue("_alreadyFetchedStartedThreads", _alreadyFetchedStartedThreads);
			info.AddValue("_threadSubscription", (!this.MarkedForDeletion?_threadSubscription:null));
			info.AddValue("_alwaysFetchThreadSubscription", _alwaysFetchThreadSubscription);
			info.AddValue("_alreadyFetchedThreadSubscription", _alreadyFetchedThreadSubscription);
			info.AddValue("_startedThreadsInForums", (!this.MarkedForDeletion?_startedThreadsInForums:null));
			info.AddValue("_alwaysFetchStartedThreadsInForums", _alwaysFetchStartedThreadsInForums);
			info.AddValue("_alreadyFetchedStartedThreadsInForums", _alreadyFetchedStartedThreadsInForums);
			info.AddValue("_roles", (!this.MarkedForDeletion?_roles:null));
			info.AddValue("_alwaysFetchRoles", _alwaysFetchRoles);
			info.AddValue("_alreadyFetchedRoles", _alreadyFetchedRoles);
			info.AddValue("_threadsInBookmarks", (!this.MarkedForDeletion?_threadsInBookmarks:null));
			info.AddValue("_alwaysFetchThreadsInBookmarks", _alwaysFetchThreadsInBookmarks);
			info.AddValue("_alreadyFetchedThreadsInBookmarks", _alreadyFetchedThreadsInBookmarks);
			info.AddValue("_postedMessagesInThreads", (!this.MarkedForDeletion?_postedMessagesInThreads:null));
			info.AddValue("_alwaysFetchPostedMessagesInThreads", _alwaysFetchPostedMessagesInThreads);
			info.AddValue("_alreadyFetchedPostedMessagesInThreads", _alreadyFetchedPostedMessagesInThreads);
			info.AddValue("_threadCollectionViaThreadSubscription", (!this.MarkedForDeletion?_threadCollectionViaThreadSubscription:null));
			info.AddValue("_alwaysFetchThreadCollectionViaThreadSubscription", _alwaysFetchThreadCollectionViaThreadSubscription);
			info.AddValue("_alreadyFetchedThreadCollectionViaThreadSubscription", _alreadyFetchedThreadCollectionViaThreadSubscription);
			info.AddValue("_userTitle", (!this.MarkedForDeletion?_userTitle:null));
			info.AddValue("_userTitleReturnsNewIfNotFound", _userTitleReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchUserTitle", _alwaysFetchUserTitle);
			info.AddValue("_alreadyFetchedUserTitle", _alreadyFetchedUserTitle);

			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void SetRelatedEntityProperty(string propertyName, IEntity entity)
		{
			switch(propertyName)
			{
				case "UserTitle":
					_alreadyFetchedUserTitle = true;
					this.UserTitle = (UserTitleEntity)entity;
					break;
				case "LoggedAudits":
					_alreadyFetchedLoggedAudits = true;
					if(entity!=null)
					{
						this.LoggedAudits.Add((AuditDataCoreEntity)entity);
					}
					break;
				case "Bookmarks":
					_alreadyFetchedBookmarks = true;
					if(entity!=null)
					{
						this.Bookmarks.Add((BookmarkEntity)entity);
					}
					break;
				case "IPBansSet":
					_alreadyFetchedIPBansSet = true;
					if(entity!=null)
					{
						this.IPBansSet.Add((IPBanEntity)entity);
					}
					break;
				case "PostedMessages":
					_alreadyFetchedPostedMessages = true;
					if(entity!=null)
					{
						this.PostedMessages.Add((MessageEntity)entity);
					}
					break;
				case "RoleUser":
					_alreadyFetchedRoleUser = true;
					if(entity!=null)
					{
						this.RoleUser.Add((RoleUserEntity)entity);
					}
					break;
				case "SupportQueueThreadsClaimed":
					_alreadyFetchedSupportQueueThreadsClaimed = true;
					if(entity!=null)
					{
						this.SupportQueueThreadsClaimed.Add((SupportQueueThreadEntity)entity);
					}
					break;
				case "SupportQueueThreadsPlaced":
					_alreadyFetchedSupportQueueThreadsPlaced = true;
					if(entity!=null)
					{
						this.SupportQueueThreadsPlaced.Add((SupportQueueThreadEntity)entity);
					}
					break;
				case "StartedThreads":
					_alreadyFetchedStartedThreads = true;
					if(entity!=null)
					{
						this.StartedThreads.Add((ThreadEntity)entity);
					}
					break;
				case "ThreadSubscription":
					_alreadyFetchedThreadSubscription = true;
					if(entity!=null)
					{
						this.ThreadSubscription.Add((ThreadSubscriptionEntity)entity);
					}
					break;
				case "StartedThreadsInForums":
					_alreadyFetchedStartedThreadsInForums = true;
					if(entity!=null)
					{
						this.StartedThreadsInForums.Add((ForumEntity)entity);
					}
					break;
				case "Roles":
					_alreadyFetchedRoles = true;
					if(entity!=null)
					{
						this.Roles.Add((RoleEntity)entity);
					}
					break;
				case "ThreadsInBookmarks":
					_alreadyFetchedThreadsInBookmarks = true;
					if(entity!=null)
					{
						this.ThreadsInBookmarks.Add((ThreadEntity)entity);
					}
					break;
				case "PostedMessagesInThreads":
					_alreadyFetchedPostedMessagesInThreads = true;
					if(entity!=null)
					{
						this.PostedMessagesInThreads.Add((ThreadEntity)entity);
					}
					break;
				case "ThreadCollectionViaThreadSubscription":
					_alreadyFetchedThreadCollectionViaThreadSubscription = true;
					if(entity!=null)
					{
						this.ThreadCollectionViaThreadSubscription.Add((ThreadEntity)entity);
					}
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
		protected override void SetRelatedEntity(IEntity relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "UserTitle":
					SetupSyncUserTitle(relatedEntity);
					break;
				case "LoggedAudits":
					_loggedAudits.Add((AuditDataCoreEntity)relatedEntity);
					break;
				case "Bookmarks":
					_bookmarks.Add((BookmarkEntity)relatedEntity);
					break;
				case "IPBansSet":
					_iPBansSet.Add((IPBanEntity)relatedEntity);
					break;
				case "PostedMessages":
					_postedMessages.Add((MessageEntity)relatedEntity);
					break;
				case "RoleUser":
					_roleUser.Add((RoleUserEntity)relatedEntity);
					break;
				case "SupportQueueThreadsClaimed":
					_supportQueueThreadsClaimed.Add((SupportQueueThreadEntity)relatedEntity);
					break;
				case "SupportQueueThreadsPlaced":
					_supportQueueThreadsPlaced.Add((SupportQueueThreadEntity)relatedEntity);
					break;
				case "StartedThreads":
					_startedThreads.Add((ThreadEntity)relatedEntity);
					break;
				case "ThreadSubscription":
					_threadSubscription.Add((ThreadSubscriptionEntity)relatedEntity);
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
		protected override void UnsetRelatedEntity(IEntity relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "UserTitle":
					DesetupSyncUserTitle(false, true);
					break;
				case "LoggedAudits":
					this.PerformRelatedEntityRemoval(_loggedAudits, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Bookmarks":
					this.PerformRelatedEntityRemoval(_bookmarks, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "IPBansSet":
					this.PerformRelatedEntityRemoval(_iPBansSet, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PostedMessages":
					this.PerformRelatedEntityRemoval(_postedMessages, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleUser":
					this.PerformRelatedEntityRemoval(_roleUser, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportQueueThreadsClaimed":
					this.PerformRelatedEntityRemoval(_supportQueueThreadsClaimed, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportQueueThreadsPlaced":
					this.PerformRelatedEntityRemoval(_supportQueueThreadsPlaced, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "StartedThreads":
					this.PerformRelatedEntityRemoval(_startedThreads, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ThreadSubscription":
					this.PerformRelatedEntityRemoval(_threadSubscription, relatedEntity, signalRelatedEntityManyToOne);
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
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_userTitle!=null)
			{
				toReturn.Add(_userTitle);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_loggedAudits);
			toReturn.Add(_bookmarks);
			toReturn.Add(_iPBansSet);
			toReturn.Add(_postedMessages);
			toReturn.Add(_roleUser);
			toReturn.Add(_supportQueueThreadsClaimed);
			toReturn.Add(_supportQueueThreadsPlaced);
			toReturn.Add(_startedThreads);
			toReturn.Add(_threadSubscription);

			return toReturn;
		}

		/// <summary> Method which will try to fetch the contents for this entity using a unique constraint. </summary>
		/// <remarks>All contents of the entity is lost.</remarks>
		/// <param name="nickName">Value for a field in the UniqueConstraint, which is used to retrieve the contents.</param>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public bool FetchUsingUCNickName(System.String nickName)
		{
			return FetchUsingUCNickName( nickName, null, null, null);
		}

		/// <summary> Method which will try to fetch the contents for this entity using a unique constraint. </summary>
		/// <remarks>All contents of the entity is lost.</remarks>
		/// <param name="nickName">Value for a field in the UniqueConstraint, which is used to retrieve the contents.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public bool FetchUsingUCNickName(System.String nickName, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingUCNickName( nickName, prefetchPathToUse, null, null);
		}
	
		/// <summary> Method which will try to fetch the contents for this entity using a unique constraint. </summary>
		/// <remarks>All contents of the entity is lost.</remarks>
		/// <param name="nickName">Value for a field in the UniqueConstraint, which is used to retrieve the contents.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public bool FetchUsingUCNickName(System.String nickName, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingUCNickName( nickName, prefetchPathToUse, contextToUse, null);
		}
	
		/// <summary> Method which will try to fetch the contents for this entity using a unique constraint. </summary>
		/// <remarks>All contents of the entity is lost.</remarks>
		/// <param name="nickName">Value for a field in the UniqueConstraint, which is used to retrieve the contents.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public bool FetchUsingUCNickName(System.String nickName, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				((UserDAO)CreateDAOInstance()).FetchUserUsingUCNickName(this, this.Transaction, nickName, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (this.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userID)
		{
			return FetchUsingPK(userID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(userID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(userID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(userID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.UserID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new UserRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'AuditDataCoreEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection GetMultiLoggedAudits(bool forceFetch)
		{
			return GetMultiLoggedAudits(forceFetch, _loggedAudits.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'AuditDataCoreEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection GetMultiLoggedAudits(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiLoggedAudits(forceFetch, _loggedAudits.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection GetMultiLoggedAudits(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiLoggedAudits(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection GetMultiLoggedAudits(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedLoggedAudits || forceFetch || _alwaysFetchLoggedAudits) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_loggedAudits);
				_loggedAudits.SuppressClearInGetMulti=!forceFetch;
				_loggedAudits.EntityFactoryToUse = entityFactoryToUse;
				_loggedAudits.GetMultiManyToOne(null, this, filter);
				_loggedAudits.SuppressClearInGetMulti=false;
				_alreadyFetchedLoggedAudits = true;
			}
			return _loggedAudits;
		}

		/// <summary> Sets the collection parameters for the collection for 'LoggedAudits'. These settings will be taken into account
		/// when the property LoggedAudits is requested or GetMultiLoggedAudits is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLoggedAudits(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_loggedAudits.SortClauses=sortClauses;
			_loggedAudits.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'BookmarkEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.BookmarkCollection GetMultiBookmarks(bool forceFetch)
		{
			return GetMultiBookmarks(forceFetch, _bookmarks.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'BookmarkEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.BookmarkCollection GetMultiBookmarks(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiBookmarks(forceFetch, _bookmarks.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.BookmarkCollection GetMultiBookmarks(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiBookmarks(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.BookmarkCollection GetMultiBookmarks(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedBookmarks || forceFetch || _alwaysFetchBookmarks) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_bookmarks);
				_bookmarks.SuppressClearInGetMulti=!forceFetch;
				_bookmarks.EntityFactoryToUse = entityFactoryToUse;
				_bookmarks.GetMultiManyToOne(null, this, filter);
				_bookmarks.SuppressClearInGetMulti=false;
				_alreadyFetchedBookmarks = true;
			}
			return _bookmarks;
		}

		/// <summary> Sets the collection parameters for the collection for 'Bookmarks'. These settings will be taken into account
		/// when the property Bookmarks is requested or GetMultiBookmarks is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersBookmarks(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_bookmarks.SortClauses=sortClauses;
			_bookmarks.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'IPBanEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'IPBanEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.IPBanCollection GetMultiIPBansSet(bool forceFetch)
		{
			return GetMultiIPBansSet(forceFetch, _iPBansSet.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'IPBanEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'IPBanEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.IPBanCollection GetMultiIPBansSet(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiIPBansSet(forceFetch, _iPBansSet.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'IPBanEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.IPBanCollection GetMultiIPBansSet(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiIPBansSet(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'IPBanEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.IPBanCollection GetMultiIPBansSet(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedIPBansSet || forceFetch || _alwaysFetchIPBansSet) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_iPBansSet);
				_iPBansSet.SuppressClearInGetMulti=!forceFetch;
				_iPBansSet.EntityFactoryToUse = entityFactoryToUse;
				_iPBansSet.GetMultiManyToOne(this, filter);
				_iPBansSet.SuppressClearInGetMulti=false;
				_alreadyFetchedIPBansSet = true;
			}
			return _iPBansSet;
		}

		/// <summary> Sets the collection parameters for the collection for 'IPBansSet'. These settings will be taken into account
		/// when the property IPBansSet is requested or GetMultiIPBansSet is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersIPBansSet(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_iPBansSet.SortClauses=sortClauses;
			_iPBansSet.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'MessageEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.MessageCollection GetMultiPostedMessages(bool forceFetch)
		{
			return GetMultiPostedMessages(forceFetch, _postedMessages.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'MessageEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.MessageCollection GetMultiPostedMessages(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiPostedMessages(forceFetch, _postedMessages.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.MessageCollection GetMultiPostedMessages(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiPostedMessages(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.MessageCollection GetMultiPostedMessages(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedPostedMessages || forceFetch || _alwaysFetchPostedMessages) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_postedMessages);
				_postedMessages.SuppressClearInGetMulti=!forceFetch;
				_postedMessages.EntityFactoryToUse = entityFactoryToUse;
				_postedMessages.GetMultiManyToOne(null, this, filter);
				_postedMessages.SuppressClearInGetMulti=false;
				_alreadyFetchedPostedMessages = true;
			}
			return _postedMessages;
		}

		/// <summary> Sets the collection parameters for the collection for 'PostedMessages'. These settings will be taken into account
		/// when the property PostedMessages is requested or GetMultiPostedMessages is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersPostedMessages(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_postedMessages.SortClauses=sortClauses;
			_postedMessages.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'RoleUserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleUserCollection GetMultiRoleUser(bool forceFetch)
		{
			return GetMultiRoleUser(forceFetch, _roleUser.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'RoleUserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleUserCollection GetMultiRoleUser(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiRoleUser(forceFetch, _roleUser.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.RoleUserCollection GetMultiRoleUser(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiRoleUser(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.RoleUserCollection GetMultiRoleUser(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedRoleUser || forceFetch || _alwaysFetchRoleUser) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_roleUser);
				_roleUser.SuppressClearInGetMulti=!forceFetch;
				_roleUser.EntityFactoryToUse = entityFactoryToUse;
				_roleUser.GetMultiManyToOne(null, this, filter);
				_roleUser.SuppressClearInGetMulti=false;
				_alreadyFetchedRoleUser = true;
			}
			return _roleUser;
		}

		/// <summary> Sets the collection parameters for the collection for 'RoleUser'. These settings will be taken into account
		/// when the property RoleUser is requested or GetMultiRoleUser is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersRoleUser(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_roleUser.SortClauses=sortClauses;
			_roleUser.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SupportQueueThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreadsClaimed(bool forceFetch)
		{
			return GetMultiSupportQueueThreadsClaimed(forceFetch, _supportQueueThreadsClaimed.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'SupportQueueThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreadsClaimed(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSupportQueueThreadsClaimed(forceFetch, _supportQueueThreadsClaimed.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreadsClaimed(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSupportQueueThreadsClaimed(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreadsClaimed(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSupportQueueThreadsClaimed || forceFetch || _alwaysFetchSupportQueueThreadsClaimed) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_supportQueueThreadsClaimed);
				_supportQueueThreadsClaimed.SuppressClearInGetMulti=!forceFetch;
				_supportQueueThreadsClaimed.EntityFactoryToUse = entityFactoryToUse;
				_supportQueueThreadsClaimed.GetMultiManyToOne(null, this, null, filter);
				_supportQueueThreadsClaimed.SuppressClearInGetMulti=false;
				_alreadyFetchedSupportQueueThreadsClaimed = true;
			}
			return _supportQueueThreadsClaimed;
		}

		/// <summary> Sets the collection parameters for the collection for 'SupportQueueThreadsClaimed'. These settings will be taken into account
		/// when the property SupportQueueThreadsClaimed is requested or GetMultiSupportQueueThreadsClaimed is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSupportQueueThreadsClaimed(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_supportQueueThreadsClaimed.SortClauses=sortClauses;
			_supportQueueThreadsClaimed.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SupportQueueThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreadsPlaced(bool forceFetch)
		{
			return GetMultiSupportQueueThreadsPlaced(forceFetch, _supportQueueThreadsPlaced.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'SupportQueueThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreadsPlaced(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSupportQueueThreadsPlaced(forceFetch, _supportQueueThreadsPlaced.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreadsPlaced(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSupportQueueThreadsPlaced(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection GetMultiSupportQueueThreadsPlaced(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSupportQueueThreadsPlaced || forceFetch || _alwaysFetchSupportQueueThreadsPlaced) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_supportQueueThreadsPlaced);
				_supportQueueThreadsPlaced.SuppressClearInGetMulti=!forceFetch;
				_supportQueueThreadsPlaced.EntityFactoryToUse = entityFactoryToUse;
				_supportQueueThreadsPlaced.GetMultiManyToOne(null, null, this, filter);
				_supportQueueThreadsPlaced.SuppressClearInGetMulti=false;
				_alreadyFetchedSupportQueueThreadsPlaced = true;
			}
			return _supportQueueThreadsPlaced;
		}

		/// <summary> Sets the collection parameters for the collection for 'SupportQueueThreadsPlaced'. These settings will be taken into account
		/// when the property SupportQueueThreadsPlaced is requested or GetMultiSupportQueueThreadsPlaced is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSupportQueueThreadsPlaced(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_supportQueueThreadsPlaced.SortClauses=sortClauses;
			_supportQueueThreadsPlaced.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiStartedThreads(bool forceFetch)
		{
			return GetMultiStartedThreads(forceFetch, _startedThreads.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiStartedThreads(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiStartedThreads(forceFetch, _startedThreads.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiStartedThreads(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiStartedThreads(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiStartedThreads(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedStartedThreads || forceFetch || _alwaysFetchStartedThreads) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_startedThreads);
				_startedThreads.SuppressClearInGetMulti=!forceFetch;
				_startedThreads.EntityFactoryToUse = entityFactoryToUse;
				_startedThreads.GetMultiManyToOne(null, this, filter);
				_startedThreads.SuppressClearInGetMulti=false;
				_alreadyFetchedStartedThreads = true;
			}
			return _startedThreads;
		}

		/// <summary> Sets the collection parameters for the collection for 'StartedThreads'. These settings will be taken into account
		/// when the property StartedThreads is requested or GetMultiStartedThreads is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersStartedThreads(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_startedThreads.SortClauses=sortClauses;
			_startedThreads.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
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
				_threadSubscription.GetMultiManyToOne(null, this, filter);
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

		/// <summary> Retrieves all related entities of type 'ForumEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ForumEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ForumCollection GetMultiStartedThreadsInForums(bool forceFetch)
		{
			return GetMultiStartedThreadsInForums(forceFetch, _startedThreadsInForums.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'ForumEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ForumCollection GetMultiStartedThreadsInForums(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedStartedThreadsInForums || forceFetch || _alwaysFetchStartedThreadsInForums) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_startedThreadsInForums);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(UserFields.UserID, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
				_startedThreadsInForums.SuppressClearInGetMulti=!forceFetch;
				_startedThreadsInForums.EntityFactoryToUse = entityFactoryToUse;
				_startedThreadsInForums.GetMulti(filter, GetRelationsForField("StartedThreadsInForums"));
				_startedThreadsInForums.SuppressClearInGetMulti=false;
				_alreadyFetchedStartedThreadsInForums = true;
			}
			return _startedThreadsInForums;
		}

		/// <summary> Sets the collection parameters for the collection for 'StartedThreadsInForums'. These settings will be taken into account
		/// when the property StartedThreadsInForums is requested or GetMultiStartedThreadsInForums is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersStartedThreadsInForums(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_startedThreadsInForums.SortClauses=sortClauses;
			_startedThreadsInForums.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'RoleEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleCollection GetMultiRoles(bool forceFetch)
		{
			return GetMultiRoles(forceFetch, _roles.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.RoleCollection GetMultiRoles(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedRoles || forceFetch || _alwaysFetchRoles) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_roles);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(UserFields.UserID, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
				_roles.SuppressClearInGetMulti=!forceFetch;
				_roles.EntityFactoryToUse = entityFactoryToUse;
				_roles.GetMulti(filter, GetRelationsForField("Roles"));
				_roles.SuppressClearInGetMulti=false;
				_alreadyFetchedRoles = true;
			}
			return _roles;
		}

		/// <summary> Sets the collection parameters for the collection for 'Roles'. These settings will be taken into account
		/// when the property Roles is requested or GetMultiRoles is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersRoles(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_roles.SortClauses=sortClauses;
			_roles.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiThreadsInBookmarks(bool forceFetch)
		{
			return GetMultiThreadsInBookmarks(forceFetch, _threadsInBookmarks.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiThreadsInBookmarks(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedThreadsInBookmarks || forceFetch || _alwaysFetchThreadsInBookmarks) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_threadsInBookmarks);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(UserFields.UserID, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
				_threadsInBookmarks.SuppressClearInGetMulti=!forceFetch;
				_threadsInBookmarks.EntityFactoryToUse = entityFactoryToUse;
				_threadsInBookmarks.GetMulti(filter, GetRelationsForField("ThreadsInBookmarks"));
				_threadsInBookmarks.SuppressClearInGetMulti=false;
				_alreadyFetchedThreadsInBookmarks = true;
			}
			return _threadsInBookmarks;
		}

		/// <summary> Sets the collection parameters for the collection for 'ThreadsInBookmarks'. These settings will be taken into account
		/// when the property ThreadsInBookmarks is requested or GetMultiThreadsInBookmarks is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersThreadsInBookmarks(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_threadsInBookmarks.SortClauses=sortClauses;
			_threadsInBookmarks.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiPostedMessagesInThreads(bool forceFetch)
		{
			return GetMultiPostedMessagesInThreads(forceFetch, _postedMessagesInThreads.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiPostedMessagesInThreads(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedPostedMessagesInThreads || forceFetch || _alwaysFetchPostedMessagesInThreads) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_postedMessagesInThreads);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(UserFields.UserID, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
				_postedMessagesInThreads.SuppressClearInGetMulti=!forceFetch;
				_postedMessagesInThreads.EntityFactoryToUse = entityFactoryToUse;
				_postedMessagesInThreads.GetMulti(filter, GetRelationsForField("PostedMessagesInThreads"));
				_postedMessagesInThreads.SuppressClearInGetMulti=false;
				_alreadyFetchedPostedMessagesInThreads = true;
			}
			return _postedMessagesInThreads;
		}

		/// <summary> Sets the collection parameters for the collection for 'PostedMessagesInThreads'. These settings will be taken into account
		/// when the property PostedMessagesInThreads is requested or GetMultiPostedMessagesInThreads is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersPostedMessagesInThreads(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_postedMessagesInThreads.SortClauses=sortClauses;
			_postedMessagesInThreads.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiThreadCollectionViaThreadSubscription(bool forceFetch)
		{
			return GetMultiThreadCollectionViaThreadSubscription(forceFetch, _threadCollectionViaThreadSubscription.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiThreadCollectionViaThreadSubscription(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedThreadCollectionViaThreadSubscription || forceFetch || _alwaysFetchThreadCollectionViaThreadSubscription) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_threadCollectionViaThreadSubscription);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(UserFields.UserID, ComparisonOperator.Equal, this.UserID, "UserEntity__"));
				_threadCollectionViaThreadSubscription.SuppressClearInGetMulti=!forceFetch;
				_threadCollectionViaThreadSubscription.EntityFactoryToUse = entityFactoryToUse;
				_threadCollectionViaThreadSubscription.GetMulti(filter, GetRelationsForField("ThreadCollectionViaThreadSubscription"));
				_threadCollectionViaThreadSubscription.SuppressClearInGetMulti=false;
				_alreadyFetchedThreadCollectionViaThreadSubscription = true;
			}
			return _threadCollectionViaThreadSubscription;
		}

		/// <summary> Sets the collection parameters for the collection for 'ThreadCollectionViaThreadSubscription'. These settings will be taken into account
		/// when the property ThreadCollectionViaThreadSubscription is requested or GetMultiThreadCollectionViaThreadSubscription is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersThreadCollectionViaThreadSubscription(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_threadCollectionViaThreadSubscription.SortClauses=sortClauses;
			_threadCollectionViaThreadSubscription.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves the related entity of type 'UserTitleEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserTitleEntity' which is related to this entity.</returns>
		public UserTitleEntity GetSingleUserTitle()
		{
			return GetSingleUserTitle(false);
		}

		/// <summary> Retrieves the related entity of type 'UserTitleEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserTitleEntity' which is related to this entity.</returns>
		public virtual UserTitleEntity GetSingleUserTitle(bool forceFetch)
		{
			if( ( !_alreadyFetchedUserTitle || forceFetch || _alwaysFetchUserTitle) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserTitleEntityUsingUserTitleID);
				UserTitleEntity newEntity = new UserTitleEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.UserTitleID);
				}
				if(fetchResult)
				{
					newEntity = (UserTitleEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_userTitleReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.UserTitle = newEntity;
				_alreadyFetchedUserTitle = fetchResult;
			}
			return _userTitle;
		}

		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_loggedAudits.ActiveContext = this.ActiveContext;
			_bookmarks.ActiveContext = this.ActiveContext;
			_iPBansSet.ActiveContext = this.ActiveContext;
			_postedMessages.ActiveContext = this.ActiveContext;
			_roleUser.ActiveContext = this.ActiveContext;
			_supportQueueThreadsClaimed.ActiveContext = this.ActiveContext;
			_supportQueueThreadsPlaced.ActiveContext = this.ActiveContext;
			_startedThreads.ActiveContext = this.ActiveContext;
			_threadSubscription.ActiveContext = this.ActiveContext;
			_startedThreadsInForums.ActiveContext = this.ActiveContext;
			_roles.ActiveContext = this.ActiveContext;
			_threadsInBookmarks.ActiveContext = this.ActiveContext;
			_postedMessagesInThreads.ActiveContext = this.ActiveContext;
			_threadCollectionViaThreadSubscription.ActiveContext = this.ActiveContext;
			if(_userTitle!=null)
			{
				_userTitle.ActiveContext = this.ActiveContext;
			}
		}

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
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The validator object for this UserEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 userID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(userID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_loggedAudits = new SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection();
			_loggedAudits.SetContainingEntityInfo(this, "UserAudited");

			_bookmarks = new SD.HnD.DAL.CollectionClasses.BookmarkCollection();
			_bookmarks.SetContainingEntityInfo(this, "User");

			_iPBansSet = new SD.HnD.DAL.CollectionClasses.IPBanCollection();
			_iPBansSet.SetContainingEntityInfo(this, "SetByUser");

			_postedMessages = new SD.HnD.DAL.CollectionClasses.MessageCollection();
			_postedMessages.SetContainingEntityInfo(this, "PostedByUser");

			_roleUser = new SD.HnD.DAL.CollectionClasses.RoleUserCollection();
			_roleUser.SetContainingEntityInfo(this, "User");

			_supportQueueThreadsClaimed = new SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection();
			_supportQueueThreadsClaimed.SetContainingEntityInfo(this, "ClaimedByUser");

			_supportQueueThreadsPlaced = new SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection();
			_supportQueueThreadsPlaced.SetContainingEntityInfo(this, "PlacedInQueueByUser");

			_startedThreads = new SD.HnD.DAL.CollectionClasses.ThreadCollection();
			_startedThreads.SetContainingEntityInfo(this, "UserWhoStartedThread");

			_threadSubscription = new SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection();
			_threadSubscription.SetContainingEntityInfo(this, "User");
			_startedThreadsInForums = new SD.HnD.DAL.CollectionClasses.ForumCollection();
			_roles = new SD.HnD.DAL.CollectionClasses.RoleCollection();
			_threadsInBookmarks = new SD.HnD.DAL.CollectionClasses.ThreadCollection();
			_postedMessagesInThreads = new SD.HnD.DAL.CollectionClasses.ThreadCollection();
			_threadCollectionViaThreadSubscription = new SD.HnD.DAL.CollectionClasses.ThreadCollection();
			_userTitleReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("AmountOfPostings", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AutoSubscribeToThread", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DateOfBirth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultNumberOfMessagesPerPage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EmailAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EmailAddressIsPublic", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IconURL", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsBanned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("JoinDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastVisitedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Location", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NickName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Occupation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Password", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Signature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SignatureAsHTML", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UserTitleID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Website", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _userTitle</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUserTitle(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _userTitle, new PropertyChangedEventHandler( OnUserTitlePropertyChanged ), "UserTitle", UserEntity.Relations.UserTitleEntityUsingUserTitleID, true, signalRelatedEntity, "Users", resetFKFields, new int[] { (int)UserFieldIndex.UserTitleID } );		
			_userTitle = null;
		}
		
		/// <summary> setups the sync logic for member _userTitle</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUserTitle(IEntity relatedEntity)
		{
			if(_userTitle!=relatedEntity)
			{		
				DesetupSyncUserTitle(true, true);
				_userTitle = (UserTitleEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _userTitle, new PropertyChangedEventHandler( OnUserTitlePropertyChanged ), "UserTitle", UserEntity.Relations.UserTitleEntityUsingUserTitleID, true, ref _alreadyFetchedUserTitle, new string[] {  } );
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

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="userID">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 userID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)UserFieldIndex.UserID].ForcedCurrentValueWrite(userID);
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
			return DAOFactory.CreateUserDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new UserEntityFactory();
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

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'AuditDataCore' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLoggedAudits
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection(), (IEntityRelation)GetRelationsForField("LoggedAudits")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.AuditDataCoreEntity, 0, null, null, null, "LoggedAudits", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Bookmark' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathBookmarks
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.BookmarkCollection(), (IEntityRelation)GetRelationsForField("Bookmarks")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.BookmarkEntity, 0, null, null, null, "Bookmarks", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'IPBan' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathIPBansSet
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.IPBanCollection(), (IEntityRelation)GetRelationsForField("IPBansSet")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.IPBanEntity, 0, null, null, null, "IPBansSet", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Message' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPostedMessages
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.MessageCollection(), (IEntityRelation)GetRelationsForField("PostedMessages")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.MessageEntity, 0, null, null, null, "PostedMessages", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'RoleUser' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoleUser
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleUserCollection(), (IEntityRelation)GetRelationsForField("RoleUser")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.RoleUserEntity, 0, null, null, null, "RoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportQueueThread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupportQueueThreadsClaimed
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection(), (IEntityRelation)GetRelationsForField("SupportQueueThreadsClaimed")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity, 0, null, null, null, "SupportQueueThreadsClaimed", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportQueueThread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupportQueueThreadsPlaced
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection(), (IEntityRelation)GetRelationsForField("SupportQueueThreadsPlaced")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity, 0, null, null, null, "SupportQueueThreadsPlaced", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathStartedThreads
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), (IEntityRelation)GetRelationsForField("StartedThreads")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, null, "StartedThreads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ThreadSubscription' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThreadSubscription
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadSubscriptionCollection(), (IEntityRelation)GetRelationsForField("ThreadSubscription")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.ThreadSubscriptionEntity, 0, null, null, null, "ThreadSubscription", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Forum'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathStartedThreadsInForums
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ThreadEntityUsingStartedByUserID;
				intermediateRelation.SetAliases(string.Empty, "Thread_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ForumCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.ForumEntity, 0, null, null, GetRelationsForField("StartedThreadsInForums"), "StartedThreadsInForums", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Role'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoles
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleUserEntityUsingUserID;
				intermediateRelation.SetAliases(string.Empty, "RoleUser_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.RoleEntity, 0, null, null, GetRelationsForField("Roles"), "Roles", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThreadsInBookmarks
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.BookmarkEntityUsingUserID;
				intermediateRelation.SetAliases(string.Empty, "Bookmark_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, GetRelationsForField("ThreadsInBookmarks"), "ThreadsInBookmarks", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPostedMessagesInThreads
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.MessageEntityUsingPostedByUserID;
				intermediateRelation.SetAliases(string.Empty, "Message_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, GetRelationsForField("PostedMessagesInThreads"), "PostedMessagesInThreads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThreadCollectionViaThreadSubscription
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ThreadSubscriptionEntityUsingUserID;
				intermediateRelation.SetAliases(string.Empty, "ThreadSubscription_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, GetRelationsForField("ThreadCollectionViaThreadSubscription"), "ThreadCollectionViaThreadSubscription", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserTitle'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserTitle
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserTitleCollection(), (IEntityRelation)GetRelationsForField("UserTitle")[0], (int)SD.HnD.DAL.EntityType.UserEntity, (int)SD.HnD.DAL.EntityType.UserTitleEntity, 0, null, null, null, "UserTitle", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override string LLBLGenProEntityName
		{
			get { return "UserEntity";}
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

		/// <summary> The AmountOfPostings property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."AmountOfPostings"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> AmountOfPostings
		{
			get { return (Nullable<System.Int32>)GetValue((int)UserFieldIndex.AmountOfPostings, false); }
			set	{ SetValue((int)UserFieldIndex.AmountOfPostings, value, true); }
		}

		/// <summary> The AutoSubscribeToThread property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."AutoSubscribeToThread"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Boolean AutoSubscribeToThread
		{
			get { return (System.Boolean)GetValue((int)UserFieldIndex.AutoSubscribeToThread, true); }
			set	{ SetValue((int)UserFieldIndex.AutoSubscribeToThread, value, true); }
		}

		/// <summary> The DateOfBirth property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."DateOfBirth"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateOfBirth
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.DateOfBirth, false); }
			set	{ SetValue((int)UserFieldIndex.DateOfBirth, value, true); }
		}

		/// <summary> The DefaultNumberOfMessagesPerPage property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."DefaultNumberOfMessagesPerPage"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int16 DefaultNumberOfMessagesPerPage
		{
			get { return (System.Int16)GetValue((int)UserFieldIndex.DefaultNumberOfMessagesPerPage, true); }
			set	{ SetValue((int)UserFieldIndex.DefaultNumberOfMessagesPerPage, value, true); }
		}

		/// <summary> The EmailAddress property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."EmailAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmailAddress
		{
			get { return (System.String)GetValue((int)UserFieldIndex.EmailAddress, true); }
			set	{ SetValue((int)UserFieldIndex.EmailAddress, value, true); }
		}

		/// <summary> The EmailAddressIsPublic property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."EmailAddressIsPublic"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> EmailAddressIsPublic
		{
			get { return (Nullable<System.Boolean>)GetValue((int)UserFieldIndex.EmailAddressIsPublic, false); }
			set	{ SetValue((int)UserFieldIndex.EmailAddressIsPublic, value, true); }
		}

		/// <summary> The IconURL property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."IconURL"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String IconURL
		{
			get { return (System.String)GetValue((int)UserFieldIndex.IconURL, true); }
			set	{ SetValue((int)UserFieldIndex.IconURL, value, true); }
		}

		/// <summary> The IPNumber property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."IPNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 25<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String IPNumber
		{
			get { return (System.String)GetValue((int)UserFieldIndex.IPNumber, true); }
			set	{ SetValue((int)UserFieldIndex.IPNumber, value, true); }
		}

		/// <summary> The IsBanned property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."IsBanned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsBanned
		{
			get { return (System.Boolean)GetValue((int)UserFieldIndex.IsBanned, true); }
			set	{ SetValue((int)UserFieldIndex.IsBanned, value, true); }
		}

		/// <summary> The JoinDate property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."JoinDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> JoinDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.JoinDate, false); }
			set	{ SetValue((int)UserFieldIndex.JoinDate, value, true); }
		}

		/// <summary> The LastVisitedDate property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastVisitedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastVisitedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.LastVisitedDate, false); }
			set	{ SetValue((int)UserFieldIndex.LastVisitedDate, value, true); }
		}

		/// <summary> The Location property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Location"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Location
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Location, true); }
			set	{ SetValue((int)UserFieldIndex.Location, value, true); }
		}

		/// <summary> The NickName property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."NickName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String NickName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.NickName, true); }
			set	{ SetValue((int)UserFieldIndex.NickName, value, true); }
		}

		/// <summary> The Occupation property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Occupation"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Occupation
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Occupation, true); }
			set	{ SetValue((int)UserFieldIndex.Occupation, value, true); }
		}

		/// <summary> The Password property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Password"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 30<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Password
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Password, true); }
			set	{ SetValue((int)UserFieldIndex.Password, value, true); }
		}

		/// <summary> The Signature property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Signature"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Signature
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Signature, true); }
			set	{ SetValue((int)UserFieldIndex.Signature, value, true); }
		}

		/// <summary> The SignatureAsHTML property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."SignatureAsHTML"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SignatureAsHTML
		{
			get { return (System.String)GetValue((int)UserFieldIndex.SignatureAsHTML, true); }
			set	{ SetValue((int)UserFieldIndex.SignatureAsHTML, value, true); }
		}

		/// <summary> The UserID property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."UserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 UserID
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.UserID, true); }
			set	{ SetValue((int)UserFieldIndex.UserID, value, true); }
		}

		/// <summary> The UserTitleID property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."UserTitleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 UserTitleID
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.UserTitleID, true); }
			set	{ SetValue((int)UserFieldIndex.UserTitleID, value, true); }
		}

		/// <summary> The Website property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Website"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Website
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Website, true); }
			set	{ SetValue((int)UserFieldIndex.Website, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLoggedAudits()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection LoggedAudits
		{
			get	{ return GetMultiLoggedAudits(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for LoggedAudits. When set to true, LoggedAudits is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LoggedAudits is accessed. You can always execute/ a forced fetch by calling GetMultiLoggedAudits(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLoggedAudits
		{
			get	{ return _alwaysFetchLoggedAudits; }
			set	{ _alwaysFetchLoggedAudits = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property LoggedAudits already has been fetched. Setting this property to false when LoggedAudits has been fetched
		/// will clear the LoggedAudits collection well. Setting this property to true while LoggedAudits hasn't been fetched disables lazy loading for LoggedAudits</summary>
		[Browsable(false)]
		public bool AlreadyFetchedLoggedAudits
		{
			get { return _alreadyFetchedLoggedAudits;}
			set 
			{
				if(_alreadyFetchedLoggedAudits && !value && (_loggedAudits != null))
				{
					_loggedAudits.Clear();
				}
				_alreadyFetchedLoggedAudits = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'BookmarkEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiBookmarks()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.BookmarkCollection Bookmarks
		{
			get	{ return GetMultiBookmarks(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Bookmarks. When set to true, Bookmarks is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Bookmarks is accessed. You can always execute/ a forced fetch by calling GetMultiBookmarks(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchBookmarks
		{
			get	{ return _alwaysFetchBookmarks; }
			set	{ _alwaysFetchBookmarks = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Bookmarks already has been fetched. Setting this property to false when Bookmarks has been fetched
		/// will clear the Bookmarks collection well. Setting this property to true while Bookmarks hasn't been fetched disables lazy loading for Bookmarks</summary>
		[Browsable(false)]
		public bool AlreadyFetchedBookmarks
		{
			get { return _alreadyFetchedBookmarks;}
			set 
			{
				if(_alreadyFetchedBookmarks && !value && (_bookmarks != null))
				{
					_bookmarks.Clear();
				}
				_alreadyFetchedBookmarks = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'IPBanEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiIPBansSet()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.IPBanCollection IPBansSet
		{
			get	{ return GetMultiIPBansSet(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for IPBansSet. When set to true, IPBansSet is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time IPBansSet is accessed. You can always execute/ a forced fetch by calling GetMultiIPBansSet(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchIPBansSet
		{
			get	{ return _alwaysFetchIPBansSet; }
			set	{ _alwaysFetchIPBansSet = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property IPBansSet already has been fetched. Setting this property to false when IPBansSet has been fetched
		/// will clear the IPBansSet collection well. Setting this property to true while IPBansSet hasn't been fetched disables lazy loading for IPBansSet</summary>
		[Browsable(false)]
		public bool AlreadyFetchedIPBansSet
		{
			get { return _alreadyFetchedIPBansSet;}
			set 
			{
				if(_alreadyFetchedIPBansSet && !value && (_iPBansSet != null))
				{
					_iPBansSet.Clear();
				}
				_alreadyFetchedIPBansSet = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'MessageEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiPostedMessages()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.MessageCollection PostedMessages
		{
			get	{ return GetMultiPostedMessages(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for PostedMessages. When set to true, PostedMessages is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time PostedMessages is accessed. You can always execute/ a forced fetch by calling GetMultiPostedMessages(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPostedMessages
		{
			get	{ return _alwaysFetchPostedMessages; }
			set	{ _alwaysFetchPostedMessages = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property PostedMessages already has been fetched. Setting this property to false when PostedMessages has been fetched
		/// will clear the PostedMessages collection well. Setting this property to true while PostedMessages hasn't been fetched disables lazy loading for PostedMessages</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPostedMessages
		{
			get { return _alreadyFetchedPostedMessages;}
			set 
			{
				if(_alreadyFetchedPostedMessages && !value && (_postedMessages != null))
				{
					_postedMessages.Clear();
				}
				_alreadyFetchedPostedMessages = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiRoleUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.RoleUserCollection RoleUser
		{
			get	{ return GetMultiRoleUser(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for RoleUser. When set to true, RoleUser is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time RoleUser is accessed. You can always execute/ a forced fetch by calling GetMultiRoleUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoleUser
		{
			get	{ return _alwaysFetchRoleUser; }
			set	{ _alwaysFetchRoleUser = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property RoleUser already has been fetched. Setting this property to false when RoleUser has been fetched
		/// will clear the RoleUser collection well. Setting this property to true while RoleUser hasn't been fetched disables lazy loading for RoleUser</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoleUser
		{
			get { return _alreadyFetchedRoleUser;}
			set 
			{
				if(_alreadyFetchedRoleUser && !value && (_roleUser != null))
				{
					_roleUser.Clear();
				}
				_alreadyFetchedRoleUser = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSupportQueueThreadsClaimed()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection SupportQueueThreadsClaimed
		{
			get	{ return GetMultiSupportQueueThreadsClaimed(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SupportQueueThreadsClaimed. When set to true, SupportQueueThreadsClaimed is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SupportQueueThreadsClaimed is accessed. You can always execute/ a forced fetch by calling GetMultiSupportQueueThreadsClaimed(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupportQueueThreadsClaimed
		{
			get	{ return _alwaysFetchSupportQueueThreadsClaimed; }
			set	{ _alwaysFetchSupportQueueThreadsClaimed = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property SupportQueueThreadsClaimed already has been fetched. Setting this property to false when SupportQueueThreadsClaimed has been fetched
		/// will clear the SupportQueueThreadsClaimed collection well. Setting this property to true while SupportQueueThreadsClaimed hasn't been fetched disables lazy loading for SupportQueueThreadsClaimed</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupportQueueThreadsClaimed
		{
			get { return _alreadyFetchedSupportQueueThreadsClaimed;}
			set 
			{
				if(_alreadyFetchedSupportQueueThreadsClaimed && !value && (_supportQueueThreadsClaimed != null))
				{
					_supportQueueThreadsClaimed.Clear();
				}
				_alreadyFetchedSupportQueueThreadsClaimed = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'SupportQueueThreadEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSupportQueueThreadsPlaced()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.SupportQueueThreadCollection SupportQueueThreadsPlaced
		{
			get	{ return GetMultiSupportQueueThreadsPlaced(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SupportQueueThreadsPlaced. When set to true, SupportQueueThreadsPlaced is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SupportQueueThreadsPlaced is accessed. You can always execute/ a forced fetch by calling GetMultiSupportQueueThreadsPlaced(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupportQueueThreadsPlaced
		{
			get	{ return _alwaysFetchSupportQueueThreadsPlaced; }
			set	{ _alwaysFetchSupportQueueThreadsPlaced = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property SupportQueueThreadsPlaced already has been fetched. Setting this property to false when SupportQueueThreadsPlaced has been fetched
		/// will clear the SupportQueueThreadsPlaced collection well. Setting this property to true while SupportQueueThreadsPlaced hasn't been fetched disables lazy loading for SupportQueueThreadsPlaced</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupportQueueThreadsPlaced
		{
			get { return _alreadyFetchedSupportQueueThreadsPlaced;}
			set 
			{
				if(_alreadyFetchedSupportQueueThreadsPlaced && !value && (_supportQueueThreadsPlaced != null))
				{
					_supportQueueThreadsPlaced.Clear();
				}
				_alreadyFetchedSupportQueueThreadsPlaced = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiStartedThreads()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadCollection StartedThreads
		{
			get	{ return GetMultiStartedThreads(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for StartedThreads. When set to true, StartedThreads is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time StartedThreads is accessed. You can always execute/ a forced fetch by calling GetMultiStartedThreads(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchStartedThreads
		{
			get	{ return _alwaysFetchStartedThreads; }
			set	{ _alwaysFetchStartedThreads = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property StartedThreads already has been fetched. Setting this property to false when StartedThreads has been fetched
		/// will clear the StartedThreads collection well. Setting this property to true while StartedThreads hasn't been fetched disables lazy loading for StartedThreads</summary>
		[Browsable(false)]
		public bool AlreadyFetchedStartedThreads
		{
			get { return _alreadyFetchedStartedThreads;}
			set 
			{
				if(_alreadyFetchedStartedThreads && !value && (_startedThreads != null))
				{
					_startedThreads.Clear();
				}
				_alreadyFetchedStartedThreads = value;
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

		/// <summary> Retrieves all related entities of type 'ForumEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiStartedThreadsInForums()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ForumCollection StartedThreadsInForums
		{
			get { return GetMultiStartedThreadsInForums(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for StartedThreadsInForums. When set to true, StartedThreadsInForums is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time StartedThreadsInForums is accessed. You can always execute a forced fetch by calling GetMultiStartedThreadsInForums(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchStartedThreadsInForums
		{
			get	{ return _alwaysFetchStartedThreadsInForums; }
			set	{ _alwaysFetchStartedThreadsInForums = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property StartedThreadsInForums already has been fetched. Setting this property to false when StartedThreadsInForums has been fetched
		/// will clear the StartedThreadsInForums collection well. Setting this property to true while StartedThreadsInForums hasn't been fetched disables lazy loading for StartedThreadsInForums</summary>
		[Browsable(false)]
		public bool AlreadyFetchedStartedThreadsInForums
		{
			get { return _alreadyFetchedStartedThreadsInForums;}
			set 
			{
				if(_alreadyFetchedStartedThreadsInForums && !value && (_startedThreadsInForums != null))
				{
					_startedThreadsInForums.Clear();
				}
				_alreadyFetchedStartedThreadsInForums = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiRoles()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.RoleCollection Roles
		{
			get { return GetMultiRoles(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Roles. When set to true, Roles is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Roles is accessed. You can always execute a forced fetch by calling GetMultiRoles(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoles
		{
			get	{ return _alwaysFetchRoles; }
			set	{ _alwaysFetchRoles = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Roles already has been fetched. Setting this property to false when Roles has been fetched
		/// will clear the Roles collection well. Setting this property to true while Roles hasn't been fetched disables lazy loading for Roles</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoles
		{
			get { return _alreadyFetchedRoles;}
			set 
			{
				if(_alreadyFetchedRoles && !value && (_roles != null))
				{
					_roles.Clear();
				}
				_alreadyFetchedRoles = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiThreadsInBookmarks()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadCollection ThreadsInBookmarks
		{
			get { return GetMultiThreadsInBookmarks(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ThreadsInBookmarks. When set to true, ThreadsInBookmarks is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ThreadsInBookmarks is accessed. You can always execute a forced fetch by calling GetMultiThreadsInBookmarks(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchThreadsInBookmarks
		{
			get	{ return _alwaysFetchThreadsInBookmarks; }
			set	{ _alwaysFetchThreadsInBookmarks = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property ThreadsInBookmarks already has been fetched. Setting this property to false when ThreadsInBookmarks has been fetched
		/// will clear the ThreadsInBookmarks collection well. Setting this property to true while ThreadsInBookmarks hasn't been fetched disables lazy loading for ThreadsInBookmarks</summary>
		[Browsable(false)]
		public bool AlreadyFetchedThreadsInBookmarks
		{
			get { return _alreadyFetchedThreadsInBookmarks;}
			set 
			{
				if(_alreadyFetchedThreadsInBookmarks && !value && (_threadsInBookmarks != null))
				{
					_threadsInBookmarks.Clear();
				}
				_alreadyFetchedThreadsInBookmarks = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiPostedMessagesInThreads()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadCollection PostedMessagesInThreads
		{
			get { return GetMultiPostedMessagesInThreads(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for PostedMessagesInThreads. When set to true, PostedMessagesInThreads is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time PostedMessagesInThreads is accessed. You can always execute a forced fetch by calling GetMultiPostedMessagesInThreads(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPostedMessagesInThreads
		{
			get	{ return _alwaysFetchPostedMessagesInThreads; }
			set	{ _alwaysFetchPostedMessagesInThreads = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property PostedMessagesInThreads already has been fetched. Setting this property to false when PostedMessagesInThreads has been fetched
		/// will clear the PostedMessagesInThreads collection well. Setting this property to true while PostedMessagesInThreads hasn't been fetched disables lazy loading for PostedMessagesInThreads</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPostedMessagesInThreads
		{
			get { return _alreadyFetchedPostedMessagesInThreads;}
			set 
			{
				if(_alreadyFetchedPostedMessagesInThreads && !value && (_postedMessagesInThreads != null))
				{
					_postedMessagesInThreads.Clear();
				}
				_alreadyFetchedPostedMessagesInThreads = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiThreadCollectionViaThreadSubscription()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadCollection ThreadCollectionViaThreadSubscription
		{
			get { return GetMultiThreadCollectionViaThreadSubscription(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ThreadCollectionViaThreadSubscription. When set to true, ThreadCollectionViaThreadSubscription is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ThreadCollectionViaThreadSubscription is accessed. You can always execute a forced fetch by calling GetMultiThreadCollectionViaThreadSubscription(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchThreadCollectionViaThreadSubscription
		{
			get	{ return _alwaysFetchThreadCollectionViaThreadSubscription; }
			set	{ _alwaysFetchThreadCollectionViaThreadSubscription = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property ThreadCollectionViaThreadSubscription already has been fetched. Setting this property to false when ThreadCollectionViaThreadSubscription has been fetched
		/// will clear the ThreadCollectionViaThreadSubscription collection well. Setting this property to true while ThreadCollectionViaThreadSubscription hasn't been fetched disables lazy loading for ThreadCollectionViaThreadSubscription</summary>
		[Browsable(false)]
		public bool AlreadyFetchedThreadCollectionViaThreadSubscription
		{
			get { return _alreadyFetchedThreadCollectionViaThreadSubscription;}
			set 
			{
				if(_alreadyFetchedThreadCollectionViaThreadSubscription && !value && (_threadCollectionViaThreadSubscription != null))
				{
					_threadCollectionViaThreadSubscription.Clear();
				}
				_alreadyFetchedThreadCollectionViaThreadSubscription = value;
			}
		}

		/// <summary> Gets / sets related entity of type 'UserTitleEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleUserTitle()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual UserTitleEntity UserTitle
		{
			get	{ return GetSingleUserTitle(false); }
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

		/// <summary> Gets / sets the lazy loading flag for UserTitle. When set to true, UserTitle is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserTitle is accessed. You can always execute a forced fetch by calling GetSingleUserTitle(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserTitle
		{
			get	{ return _alwaysFetchUserTitle; }
			set	{ _alwaysFetchUserTitle = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property UserTitle already has been fetched. Setting this property to false when UserTitle has been fetched
		/// will set UserTitle to null as well. Setting this property to true while UserTitle hasn't been fetched disables lazy loading for UserTitle</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserTitle
		{
			get { return _alreadyFetchedUserTitle;}
			set 
			{
				if(_alreadyFetchedUserTitle && !value)
				{
					this.UserTitle = null;
				}
				_alreadyFetchedUserTitle = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property UserTitle is not found
		/// in the database. When set to true, UserTitle will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool UserTitleReturnsNewIfNotFound
		{
			get	{ return _userTitleReturnsNewIfNotFound; }
			set { _userTitleReturnsNewIfNotFound = value; }	
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
			get { return (int)SD.HnD.DAL.EntityType.UserEntity; }
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
