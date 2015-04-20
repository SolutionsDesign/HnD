///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.2
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
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
	/// <summary>Entity base class which represents the base class for the entity 'ThreadSubscription'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class ThreadSubscriptionEntityBase : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private ThreadEntity _thread;
		private bool	_alwaysFetchThread, _alreadyFetchedThread, _threadReturnsNewIfNotFound;
		private UserEntity _user;
		private bool	_alwaysFetchUser, _alreadyFetchedUser, _userReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Thread</summary>
			public static readonly string Thread = "Thread";
			/// <summary>Member name User</summary>
			public static readonly string User = "User";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ThreadSubscriptionEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		protected ThreadSubscriptionEntityBase() :base("ThreadSubscriptionEntity")
		{
			InitClassEmpty(null);
		}

		/// <summary>CTor</summary>
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		protected ThreadSubscriptionEntityBase(System.Int32 userID, System.Int32 threadID):base("ThreadSubscriptionEntity")
		{
			InitClassFetch(userID, threadID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected ThreadSubscriptionEntityBase(System.Int32 userID, System.Int32 threadID, IPrefetchPath prefetchPathToUse): base("ThreadSubscriptionEntity")
		{
			InitClassFetch(userID, threadID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="validator">The custom validator object for this ThreadSubscriptionEntity</param>
		protected ThreadSubscriptionEntityBase(System.Int32 userID, System.Int32 threadID, IValidator validator):base("ThreadSubscriptionEntity")
		{
			InitClassFetch(userID, threadID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ThreadSubscriptionEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_thread = (ThreadEntity)info.GetValue("_thread", typeof(ThreadEntity));
			if(_thread!=null)
			{
				_thread.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_threadReturnsNewIfNotFound = info.GetBoolean("_threadReturnsNewIfNotFound");
			_alwaysFetchThread = info.GetBoolean("_alwaysFetchThread");
			_alreadyFetchedThread = info.GetBoolean("_alreadyFetchedThread");

			_user = (UserEntity)info.GetValue("_user", typeof(UserEntity));
			if(_user!=null)
			{
				_user.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_userReturnsNewIfNotFound = info.GetBoolean("_userReturnsNewIfNotFound");
			_alwaysFetchUser = info.GetBoolean("_alwaysFetchUser");
			_alreadyFetchedUser = info.GetBoolean("_alreadyFetchedUser");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}	
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ThreadSubscriptionFieldIndex)fieldIndex)
			{
				case ThreadSubscriptionFieldIndex.UserID:
					DesetupSyncUser(true, false);
					_alreadyFetchedUser = false;
					break;
				case ThreadSubscriptionFieldIndex.ThreadID:
					DesetupSyncThread(true, false);
					_alreadyFetchedThread = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedThread = (_thread != null);
			_alreadyFetchedUser = (_user != null);
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
				case "Thread":
					toReturn.Add(Relations.ThreadEntityUsingThreadID);
					break;
				case "User":
					toReturn.Add(Relations.UserEntityUsingUserID);
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
			info.AddValue("_thread", (!this.MarkedForDeletion?_thread:null));
			info.AddValue("_threadReturnsNewIfNotFound", _threadReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchThread", _alwaysFetchThread);
			info.AddValue("_alreadyFetchedThread", _alreadyFetchedThread);
			info.AddValue("_user", (!this.MarkedForDeletion?_user:null));
			info.AddValue("_userReturnsNewIfNotFound", _userReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchUser", _alwaysFetchUser);
			info.AddValue("_alreadyFetchedUser", _alreadyFetchedUser);

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
				case "Thread":
					_alreadyFetchedThread = true;
					this.Thread = (ThreadEntity)entity;
					break;
				case "User":
					_alreadyFetchedUser = true;
					this.User = (UserEntity)entity;
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
				case "Thread":
					SetupSyncThread(relatedEntity);
					break;
				case "User":
					SetupSyncUser(relatedEntity);
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
				case "Thread":
					DesetupSyncThread(false, true);
					break;
				case "User":
					DesetupSyncUser(false, true);
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
			if(_thread!=null)
			{
				toReturn.Add(_thread);
			}
			if(_user!=null)
			{
				toReturn.Add(_user);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();


			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userID, System.Int32 threadID)
		{
			return FetchUsingPK(userID, threadID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userID, System.Int32 threadID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(userID, threadID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userID, System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(userID, threadID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userID, System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(userID, threadID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.UserID, this.ThreadID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ThreadSubscriptionRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'ThreadEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ThreadEntity' which is related to this entity.</returns>
		public ThreadEntity GetSingleThread()
		{
			return GetSingleThread(false);
		}

		/// <summary> Retrieves the related entity of type 'ThreadEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ThreadEntity' which is related to this entity.</returns>
		public virtual ThreadEntity GetSingleThread(bool forceFetch)
		{
			if( ( !_alreadyFetchedThread || forceFetch || _alwaysFetchThread) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.ThreadEntityUsingThreadID);
				ThreadEntity newEntity = new ThreadEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.ThreadID);
				}
				if(fetchResult)
				{
					newEntity = (ThreadEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_threadReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Thread = newEntity;
				_alreadyFetchedThread = fetchResult;
			}
			return _thread;
		}


		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public UserEntity GetSingleUser()
		{
			return GetSingleUser(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSingleUser(bool forceFetch)
		{
			if( ( !_alreadyFetchedUser || forceFetch || _alwaysFetchUser) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserEntityUsingUserID);
				UserEntity newEntity = new UserEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.UserID);
				}
				if(fetchResult)
				{
					newEntity = (UserEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_userReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.User = newEntity;
				_alreadyFetchedUser = fetchResult;
			}
			return _user;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Thread", _thread);
			toReturn.Add("User", _user);
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
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="validator">The validator object for this ThreadSubscriptionEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 userID, System.Int32 threadID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(userID, threadID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_threadReturnsNewIfNotFound = true;
			_userReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _thread</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncThread(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DAL.RelationClasses.StaticThreadSubscriptionRelations.ThreadEntityUsingThreadIDStatic, true, signalRelatedEntity, "ThreadSubscription", resetFKFields, new int[] { (int)ThreadSubscriptionFieldIndex.ThreadID } );		
			_thread = null;
		}
		
		/// <summary> setups the sync logic for member _thread</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncThread(IEntityCore relatedEntity)
		{
			if(_thread!=relatedEntity)
			{		
				DesetupSyncThread(true, true);
				_thread = (ThreadEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DAL.RelationClasses.StaticThreadSubscriptionRelations.ThreadEntityUsingThreadIDStatic, true, ref _alreadyFetchedThread, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnThreadPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _user</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _user, new PropertyChangedEventHandler( OnUserPropertyChanged ), "User", SD.HnD.DAL.RelationClasses.StaticThreadSubscriptionRelations.UserEntityUsingUserIDStatic, true, signalRelatedEntity, "ThreadSubscription", resetFKFields, new int[] { (int)ThreadSubscriptionFieldIndex.UserID } );		
			_user = null;
		}
		
		/// <summary> setups the sync logic for member _user</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUser(IEntityCore relatedEntity)
		{
			if(_user!=relatedEntity)
			{		
				DesetupSyncUser(true, true);
				_user = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _user, new PropertyChangedEventHandler( OnUserPropertyChanged ), "User", SD.HnD.DAL.RelationClasses.StaticThreadSubscriptionRelations.UserEntityUsingUserIDStatic, true, ref _alreadyFetchedUser, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="userID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="threadID">PK value for ThreadSubscription which data should be fetched into this ThreadSubscription object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 userID, System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)ThreadSubscriptionFieldIndex.UserID].ForcedCurrentValueWrite(userID);
				this.Fields[(int)ThreadSubscriptionFieldIndex.ThreadID].ForcedCurrentValueWrite(threadID);
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
			return DAOFactory.CreateThreadSubscriptionDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ThreadSubscriptionEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ThreadSubscriptionRelations Relations
		{
			get	{ return new ThreadSubscriptionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThread
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), (IEntityRelation)GetRelationsForField("Thread")[0], (int)SD.HnD.DAL.EntityType.ThreadSubscriptionEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, null, "Thread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUser
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("User")[0], (int)SD.HnD.DAL.EntityType.ThreadSubscriptionEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, null, "User", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The UserID property of the Entity ThreadSubscription<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ThreadSubscription"."UserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 UserID
		{
			get { return (System.Int32)GetValue((int)ThreadSubscriptionFieldIndex.UserID, true); }
			set	{ SetValue((int)ThreadSubscriptionFieldIndex.UserID, value, true); }
		}

		/// <summary> The ThreadID property of the Entity ThreadSubscription<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ThreadSubscription"."ThreadID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)ThreadSubscriptionFieldIndex.ThreadID, true); }
			set	{ SetValue((int)ThreadSubscriptionFieldIndex.ThreadID, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'ThreadEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleThread()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual ThreadEntity Thread
		{
			get	{ return GetSingleThread(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncThread(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ThreadSubscription", "Thread", _thread, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Thread. When set to true, Thread is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Thread is accessed. You can always execute a forced fetch by calling GetSingleThread(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchThread
		{
			get	{ return _alwaysFetchThread; }
			set	{ _alwaysFetchThread = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Thread already has been fetched. Setting this property to false when Thread has been fetched
		/// will set Thread to null as well. Setting this property to true while Thread hasn't been fetched disables lazy loading for Thread</summary>
		[Browsable(false)]
		public bool AlreadyFetchedThread
		{
			get { return _alreadyFetchedThread;}
			set 
			{
				if(_alreadyFetchedThread && !value)
				{
					this.Thread = null;
				}
				_alreadyFetchedThread = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Thread is not found
		/// in the database. When set to true, Thread will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool ThreadReturnsNewIfNotFound
		{
			get	{ return _threadReturnsNewIfNotFound; }
			set { _threadReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual UserEntity User
		{
			get	{ return GetSingleUser(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ThreadSubscription", "User", _user, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for User. When set to true, User is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time User is accessed. You can always execute a forced fetch by calling GetSingleUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUser
		{
			get	{ return _alwaysFetchUser; }
			set	{ _alwaysFetchUser = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property User already has been fetched. Setting this property to false when User has been fetched
		/// will set User to null as well. Setting this property to true while User hasn't been fetched disables lazy loading for User</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUser
		{
			get { return _alreadyFetchedUser;}
			set 
			{
				if(_alreadyFetchedUser && !value)
				{
					this.User = null;
				}
				_alreadyFetchedUser = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property User is not found
		/// in the database. When set to true, User will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool UserReturnsNewIfNotFound
		{
			get	{ return _userReturnsNewIfNotFound; }
			set { _userReturnsNewIfNotFound = value; }	
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
			get { return (int)SD.HnD.DAL.EntityType.ThreadSubscriptionEntity; }
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
