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

	/// <summary>Entity class which represents the entity 'SupportQueueThread'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SupportQueueThreadEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SupportQueueEntity _supportQueue;
		private bool	_alwaysFetchSupportQueue, _alreadyFetchedSupportQueue, _supportQueueReturnsNewIfNotFound;
		private UserEntity _claimedByUser;
		private bool	_alwaysFetchClaimedByUser, _alreadyFetchedClaimedByUser, _claimedByUserReturnsNewIfNotFound;
		private UserEntity _placedInQueueByUser;
		private bool	_alwaysFetchPlacedInQueueByUser, _alreadyFetchedPlacedInQueueByUser, _placedInQueueByUserReturnsNewIfNotFound;
		private ThreadEntity _thread;
		private bool	_alwaysFetchThread, _alreadyFetchedThread, _threadReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name SupportQueue</summary>
			public static readonly string SupportQueue = "SupportQueue";
			/// <summary>Member name ClaimedByUser</summary>
			public static readonly string ClaimedByUser = "ClaimedByUser";
			/// <summary>Member name PlacedInQueueByUser</summary>
			public static readonly string PlacedInQueueByUser = "PlacedInQueueByUser";
			/// <summary>Member name Thread</summary>
			public static readonly string Thread = "Thread";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SupportQueueThreadEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public SupportQueueThreadEntity() :base("SupportQueueThreadEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID):base("SupportQueueThreadEntity")
		{
			InitClassFetch(queueID, threadID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID, IPrefetchPath prefetchPathToUse):base("SupportQueueThreadEntity")
		{
			InitClassFetch(queueID, threadID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="validator">The custom validator object for this SupportQueueThreadEntity</param>
		public SupportQueueThreadEntity(System.Int32 queueID, System.Int32 threadID, IValidator validator):base("SupportQueueThreadEntity")
		{
			InitClassFetch(queueID, threadID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SupportQueueThreadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_supportQueue = (SupportQueueEntity)info.GetValue("_supportQueue", typeof(SupportQueueEntity));
			if(_supportQueue!=null)
			{
				_supportQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_supportQueueReturnsNewIfNotFound = info.GetBoolean("_supportQueueReturnsNewIfNotFound");
			_alwaysFetchSupportQueue = info.GetBoolean("_alwaysFetchSupportQueue");
			_alreadyFetchedSupportQueue = info.GetBoolean("_alreadyFetchedSupportQueue");

			_claimedByUser = (UserEntity)info.GetValue("_claimedByUser", typeof(UserEntity));
			if(_claimedByUser!=null)
			{
				_claimedByUser.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_claimedByUserReturnsNewIfNotFound = info.GetBoolean("_claimedByUserReturnsNewIfNotFound");
			_alwaysFetchClaimedByUser = info.GetBoolean("_alwaysFetchClaimedByUser");
			_alreadyFetchedClaimedByUser = info.GetBoolean("_alreadyFetchedClaimedByUser");

			_placedInQueueByUser = (UserEntity)info.GetValue("_placedInQueueByUser", typeof(UserEntity));
			if(_placedInQueueByUser!=null)
			{
				_placedInQueueByUser.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_placedInQueueByUserReturnsNewIfNotFound = info.GetBoolean("_placedInQueueByUserReturnsNewIfNotFound");
			_alwaysFetchPlacedInQueueByUser = info.GetBoolean("_alwaysFetchPlacedInQueueByUser");
			_alreadyFetchedPlacedInQueueByUser = info.GetBoolean("_alreadyFetchedPlacedInQueueByUser");
			_thread = (ThreadEntity)info.GetValue("_thread", typeof(ThreadEntity));
			if(_thread!=null)
			{
				_thread.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_threadReturnsNewIfNotFound = info.GetBoolean("_threadReturnsNewIfNotFound");
			_alwaysFetchThread = info.GetBoolean("_alwaysFetchThread");
			_alreadyFetchedThread = info.GetBoolean("_alreadyFetchedThread");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((SupportQueueThreadFieldIndex)fieldIndex)
			{
				case SupportQueueThreadFieldIndex.QueueID:
					DesetupSyncSupportQueue(true, false);
					_alreadyFetchedSupportQueue = false;
					break;
				case SupportQueueThreadFieldIndex.ThreadID:
					DesetupSyncThread(true, false);
					_alreadyFetchedThread = false;
					break;
				case SupportQueueThreadFieldIndex.PlacedInQueueByUserID:
					DesetupSyncPlacedInQueueByUser(true, false);
					_alreadyFetchedPlacedInQueueByUser = false;
					break;
				case SupportQueueThreadFieldIndex.ClaimedByUserID:
					DesetupSyncClaimedByUser(true, false);
					_alreadyFetchedClaimedByUser = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedSupportQueue = (_supportQueue != null);
			_alreadyFetchedClaimedByUser = (_claimedByUser != null);
			_alreadyFetchedPlacedInQueueByUser = (_placedInQueueByUser != null);
			_alreadyFetchedThread = (_thread != null);
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
				case "SupportQueue":
					toReturn.Add(Relations.SupportQueueEntityUsingQueueID);
					break;
				case "ClaimedByUser":
					toReturn.Add(Relations.UserEntityUsingClaimedByUserID);
					break;
				case "PlacedInQueueByUser":
					toReturn.Add(Relations.UserEntityUsingPlacedInQueueByUserID);
					break;
				case "Thread":
					toReturn.Add(Relations.ThreadEntityUsingThreadID);
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
			info.AddValue("_supportQueue", (!this.MarkedForDeletion?_supportQueue:null));
			info.AddValue("_supportQueueReturnsNewIfNotFound", _supportQueueReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchSupportQueue", _alwaysFetchSupportQueue);
			info.AddValue("_alreadyFetchedSupportQueue", _alreadyFetchedSupportQueue);
			info.AddValue("_claimedByUser", (!this.MarkedForDeletion?_claimedByUser:null));
			info.AddValue("_claimedByUserReturnsNewIfNotFound", _claimedByUserReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchClaimedByUser", _alwaysFetchClaimedByUser);
			info.AddValue("_alreadyFetchedClaimedByUser", _alreadyFetchedClaimedByUser);
			info.AddValue("_placedInQueueByUser", (!this.MarkedForDeletion?_placedInQueueByUser:null));
			info.AddValue("_placedInQueueByUserReturnsNewIfNotFound", _placedInQueueByUserReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchPlacedInQueueByUser", _alwaysFetchPlacedInQueueByUser);
			info.AddValue("_alreadyFetchedPlacedInQueueByUser", _alreadyFetchedPlacedInQueueByUser);

			info.AddValue("_thread", (!this.MarkedForDeletion?_thread:null));
			info.AddValue("_threadReturnsNewIfNotFound", _threadReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchThread", _alwaysFetchThread);
			info.AddValue("_alreadyFetchedThread", _alreadyFetchedThread);

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
				case "SupportQueue":
					_alreadyFetchedSupportQueue = true;
					this.SupportQueue = (SupportQueueEntity)entity;
					break;
				case "ClaimedByUser":
					_alreadyFetchedClaimedByUser = true;
					this.ClaimedByUser = (UserEntity)entity;
					break;
				case "PlacedInQueueByUser":
					_alreadyFetchedPlacedInQueueByUser = true;
					this.PlacedInQueueByUser = (UserEntity)entity;
					break;
				case "Thread":
					_alreadyFetchedThread = true;
					this.Thread = (ThreadEntity)entity;
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
				case "SupportQueue":
					SetupSyncSupportQueue(relatedEntity);
					break;
				case "ClaimedByUser":
					SetupSyncClaimedByUser(relatedEntity);
					break;
				case "PlacedInQueueByUser":
					SetupSyncPlacedInQueueByUser(relatedEntity);
					break;
				case "Thread":
					SetupSyncThread(relatedEntity);
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
				case "SupportQueue":
					DesetupSyncSupportQueue(false, true);
					break;
				case "ClaimedByUser":
					DesetupSyncClaimedByUser(false, true);
					break;
				case "PlacedInQueueByUser":
					DesetupSyncPlacedInQueueByUser(false, true);
					break;
				case "Thread":
					DesetupSyncThread(false, true);
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
			if(_supportQueue!=null)
			{
				toReturn.Add(_supportQueue);
			}
			if(_claimedByUser!=null)
			{
				toReturn.Add(_claimedByUser);
			}
			if(_placedInQueueByUser!=null)
			{
				toReturn.Add(_placedInQueueByUser);
			}
			if(_thread!=null)
			{
				toReturn.Add(_thread);
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

		/// <summary> Method which will try to fetch the contents for this entity using a unique constraint. </summary>
		/// <remarks>All contents of the entity is lost.</remarks>
		/// <param name="threadID">Value for a field in the UniqueConstraint, which is used to retrieve the contents.</param>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public bool FetchUsingUCThreadID(System.Int32 threadID)
		{
			return FetchUsingUCThreadID( threadID, null, null, null);
		}

		/// <summary> Method which will try to fetch the contents for this entity using a unique constraint. </summary>
		/// <remarks>All contents of the entity is lost.</remarks>
		/// <param name="threadID">Value for a field in the UniqueConstraint, which is used to retrieve the contents.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public bool FetchUsingUCThreadID(System.Int32 threadID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingUCThreadID( threadID, prefetchPathToUse, null, null);
		}
	
		/// <summary> Method which will try to fetch the contents for this entity using a unique constraint. </summary>
		/// <remarks>All contents of the entity is lost.</remarks>
		/// <param name="threadID">Value for a field in the UniqueConstraint, which is used to retrieve the contents.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public bool FetchUsingUCThreadID(System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingUCThreadID( threadID, prefetchPathToUse, contextToUse, null);
		}
	
		/// <summary> Method which will try to fetch the contents for this entity using a unique constraint. </summary>
		/// <remarks>All contents of the entity is lost.</remarks>
		/// <param name="threadID">Value for a field in the UniqueConstraint, which is used to retrieve the contents.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public bool FetchUsingUCThreadID(System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				((SupportQueueThreadDAO)CreateDAOInstance()).FetchSupportQueueThreadUsingUCThreadID(this, this.Transaction, threadID, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (this.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 queueID, System.Int32 threadID)
		{
			return FetchUsingPK(queueID, threadID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 queueID, System.Int32 threadID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(queueID, threadID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 queueID, System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(queueID, threadID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 queueID, System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(queueID, threadID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.QueueID, this.ThreadID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new SupportQueueThreadRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'SupportQueueEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'SupportQueueEntity' which is related to this entity.</returns>
		public SupportQueueEntity GetSingleSupportQueue()
		{
			return GetSingleSupportQueue(false);
		}

		/// <summary> Retrieves the related entity of type 'SupportQueueEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'SupportQueueEntity' which is related to this entity.</returns>
		public virtual SupportQueueEntity GetSingleSupportQueue(bool forceFetch)
		{
			if( ( !_alreadyFetchedSupportQueue || forceFetch || _alwaysFetchSupportQueue) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.SupportQueueEntityUsingQueueID);
				SupportQueueEntity newEntity = new SupportQueueEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.QueueID);
				}
				if(fetchResult)
				{
					newEntity = (SupportQueueEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_supportQueueReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.SupportQueue = newEntity;
				_alreadyFetchedSupportQueue = fetchResult;
			}
			return _supportQueue;
		}


		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public UserEntity GetSingleClaimedByUser()
		{
			return GetSingleClaimedByUser(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSingleClaimedByUser(bool forceFetch)
		{
			if( ( !_alreadyFetchedClaimedByUser || forceFetch || _alwaysFetchClaimedByUser) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserEntityUsingClaimedByUserID);
				UserEntity newEntity = new UserEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.ClaimedByUserID.GetValueOrDefault());
				}
				if(fetchResult)
				{
					newEntity = (UserEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_claimedByUserReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.ClaimedByUser = newEntity;
				_alreadyFetchedClaimedByUser = fetchResult;
			}
			return _claimedByUser;
		}


		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public UserEntity GetSinglePlacedInQueueByUser()
		{
			return GetSinglePlacedInQueueByUser(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSinglePlacedInQueueByUser(bool forceFetch)
		{
			if( ( !_alreadyFetchedPlacedInQueueByUser || forceFetch || _alwaysFetchPlacedInQueueByUser) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserEntityUsingPlacedInQueueByUserID);
				UserEntity newEntity = new UserEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.PlacedInQueueByUserID);
				}
				if(fetchResult)
				{
					newEntity = (UserEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_placedInQueueByUserReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.PlacedInQueueByUser = newEntity;
				_alreadyFetchedPlacedInQueueByUser = fetchResult;
			}
			return _placedInQueueByUser;
		}

		/// <summary> Retrieves the related entity of type 'ThreadEntity', using a relation of type '1:1'</summary>
		/// <returns>A fetched entity of type 'ThreadEntity' which is related to this entity.</returns>
		public ThreadEntity GetSingleThread()
		{
			return GetSingleThread(false);
		}
		
		/// <summary> Retrieves the related entity of type 'ThreadEntity', using a relation of type '1:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ThreadEntity' which is related to this entity.</returns>
		public virtual ThreadEntity GetSingleThread(bool forceFetch)
		{
			if( ( !_alreadyFetchedThread || forceFetch || _alwaysFetchThread) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode )
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


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("SupportQueue", _supportQueue);
			toReturn.Add("ClaimedByUser", _claimedByUser);
			toReturn.Add("PlacedInQueueByUser", _placedInQueueByUser);
			toReturn.Add("Thread", _thread);
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
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="validator">The validator object for this SupportQueueThreadEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 queueID, System.Int32 threadID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(queueID, threadID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_supportQueueReturnsNewIfNotFound = true;
			_claimedByUserReturnsNewIfNotFound = true;
			_placedInQueueByUserReturnsNewIfNotFound = true;
			_threadReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("QueueID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PlacedInQueueByUserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PlacedInQueueOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ClaimedByUserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ClaimedOn", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _supportQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSupportQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _supportQueue, new PropertyChangedEventHandler( OnSupportQueuePropertyChanged ), "SupportQueue", SD.HnD.DAL.RelationClasses.StaticSupportQueueThreadRelations.SupportQueueEntityUsingQueueIDStatic, true, signalRelatedEntity, "SupportQueueThreads", resetFKFields, new int[] { (int)SupportQueueThreadFieldIndex.QueueID } );		
			_supportQueue = null;
		}
		
		/// <summary> setups the sync logic for member _supportQueue</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSupportQueue(IEntityCore relatedEntity)
		{
			if(_supportQueue!=relatedEntity)
			{		
				DesetupSyncSupportQueue(true, true);
				_supportQueue = (SupportQueueEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _supportQueue, new PropertyChangedEventHandler( OnSupportQueuePropertyChanged ), "SupportQueue", SD.HnD.DAL.RelationClasses.StaticSupportQueueThreadRelations.SupportQueueEntityUsingQueueIDStatic, true, ref _alreadyFetchedSupportQueue, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSupportQueuePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _claimedByUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncClaimedByUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _claimedByUser, new PropertyChangedEventHandler( OnClaimedByUserPropertyChanged ), "ClaimedByUser", SD.HnD.DAL.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingClaimedByUserIDStatic, true, signalRelatedEntity, "SupportQueueThreadsClaimed", resetFKFields, new int[] { (int)SupportQueueThreadFieldIndex.ClaimedByUserID } );		
			_claimedByUser = null;
		}
		
		/// <summary> setups the sync logic for member _claimedByUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncClaimedByUser(IEntityCore relatedEntity)
		{
			if(_claimedByUser!=relatedEntity)
			{		
				DesetupSyncClaimedByUser(true, true);
				_claimedByUser = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _claimedByUser, new PropertyChangedEventHandler( OnClaimedByUserPropertyChanged ), "ClaimedByUser", SD.HnD.DAL.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingClaimedByUserIDStatic, true, ref _alreadyFetchedClaimedByUser, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnClaimedByUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _placedInQueueByUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPlacedInQueueByUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _placedInQueueByUser, new PropertyChangedEventHandler( OnPlacedInQueueByUserPropertyChanged ), "PlacedInQueueByUser", SD.HnD.DAL.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingPlacedInQueueByUserIDStatic, true, signalRelatedEntity, "SupportQueueThreadsPlaced", resetFKFields, new int[] { (int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID } );		
			_placedInQueueByUser = null;
		}
		
		/// <summary> setups the sync logic for member _placedInQueueByUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPlacedInQueueByUser(IEntityCore relatedEntity)
		{
			if(_placedInQueueByUser!=relatedEntity)
			{		
				DesetupSyncPlacedInQueueByUser(true, true);
				_placedInQueueByUser = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _placedInQueueByUser, new PropertyChangedEventHandler( OnPlacedInQueueByUserPropertyChanged ), "PlacedInQueueByUser", SD.HnD.DAL.RelationClasses.StaticSupportQueueThreadRelations.UserEntityUsingPlacedInQueueByUserIDStatic, true, ref _alreadyFetchedPlacedInQueueByUser, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPlacedInQueueByUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _thread</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncThread(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DAL.RelationClasses.StaticSupportQueueThreadRelations.ThreadEntityUsingThreadIDStatic, true, signalRelatedEntity, "SupportQueueThread", resetFKFields, new int[] { (int)SupportQueueThreadFieldIndex.ThreadID } );
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
				this.PerformSetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DAL.RelationClasses.StaticSupportQueueThreadRelations.ThreadEntityUsingThreadIDStatic, true, ref _alreadyFetchedThread, new string[] {  } );
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

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="queueID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="threadID">PK value for SupportQueueThread which data should be fetched into this SupportQueueThread object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 queueID, System.Int32 threadID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)SupportQueueThreadFieldIndex.QueueID].ForcedCurrentValueWrite(queueID);
				this.Fields[(int)SupportQueueThreadFieldIndex.ThreadID].ForcedCurrentValueWrite(threadID);
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
			return DAOFactory.CreateSupportQueueThreadDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new SupportQueueThreadEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static SupportQueueThreadRelations Relations
		{
			get	{ return new SupportQueueThreadRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportQueue'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupportQueue
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SupportQueueCollection(), (IEntityRelation)GetRelationsForField("SupportQueue")[0], (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity, (int)SD.HnD.DAL.EntityType.SupportQueueEntity, 0, null, null, null, "SupportQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathClaimedByUser
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("ClaimedByUser")[0], (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, null, "ClaimedByUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPlacedInQueueByUser
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("PlacedInQueueByUser")[0], (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, null, "PlacedInQueueByUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThread
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), (IEntityRelation)GetRelationsForField("Thread")[0], (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, null, "Thread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);	}
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

		/// <summary> The QueueID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."QueueID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 QueueID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.QueueID, true); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.QueueID, value, true); }
		}

		/// <summary> The ThreadID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ThreadID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.ThreadID, true); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.ThreadID, value, true); }
		}

		/// <summary> The PlacedInQueueByUserID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."PlacedInQueueByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PlacedInQueueByUserID
		{
			get { return (System.Int32)GetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID, true); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueByUserID, value, true); }
		}

		/// <summary> The PlacedInQueueOn property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."PlacedInQueueOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime PlacedInQueueOn
		{
			get { return (System.DateTime)GetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueOn, true); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.PlacedInQueueOn, value, true); }
		}

		/// <summary> The ClaimedByUserID property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ClaimedByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ClaimedByUserID
		{
			get { return (Nullable<System.Int32>)GetValue((int)SupportQueueThreadFieldIndex.ClaimedByUserID, false); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.ClaimedByUserID, value, true); }
		}

		/// <summary> The ClaimedOn property of the Entity SupportQueueThread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportQueueThread"."ClaimedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ClaimedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)SupportQueueThreadFieldIndex.ClaimedOn, false); }
			set	{ SetValue((int)SupportQueueThreadFieldIndex.ClaimedOn, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'SupportQueueEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleSupportQueue()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual SupportQueueEntity SupportQueue
		{
			get	{ return GetSingleSupportQueue(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncSupportQueue(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportQueueThreads", "SupportQueue", _supportQueue, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for SupportQueue. When set to true, SupportQueue is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SupportQueue is accessed. You can always execute a forced fetch by calling GetSingleSupportQueue(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupportQueue
		{
			get	{ return _alwaysFetchSupportQueue; }
			set	{ _alwaysFetchSupportQueue = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property SupportQueue already has been fetched. Setting this property to false when SupportQueue has been fetched
		/// will set SupportQueue to null as well. Setting this property to true while SupportQueue hasn't been fetched disables lazy loading for SupportQueue</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupportQueue
		{
			get { return _alreadyFetchedSupportQueue;}
			set 
			{
				if(_alreadyFetchedSupportQueue && !value)
				{
					this.SupportQueue = null;
				}
				_alreadyFetchedSupportQueue = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property SupportQueue is not found
		/// in the database. When set to true, SupportQueue will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool SupportQueueReturnsNewIfNotFound
		{
			get	{ return _supportQueueReturnsNewIfNotFound; }
			set { _supportQueueReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleClaimedByUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual UserEntity ClaimedByUser
		{
			get	{ return GetSingleClaimedByUser(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncClaimedByUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportQueueThreadsClaimed", "ClaimedByUser", _claimedByUser, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for ClaimedByUser. When set to true, ClaimedByUser is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ClaimedByUser is accessed. You can always execute a forced fetch by calling GetSingleClaimedByUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchClaimedByUser
		{
			get	{ return _alwaysFetchClaimedByUser; }
			set	{ _alwaysFetchClaimedByUser = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property ClaimedByUser already has been fetched. Setting this property to false when ClaimedByUser has been fetched
		/// will set ClaimedByUser to null as well. Setting this property to true while ClaimedByUser hasn't been fetched disables lazy loading for ClaimedByUser</summary>
		[Browsable(false)]
		public bool AlreadyFetchedClaimedByUser
		{
			get { return _alreadyFetchedClaimedByUser;}
			set 
			{
				if(_alreadyFetchedClaimedByUser && !value)
				{
					this.ClaimedByUser = null;
				}
				_alreadyFetchedClaimedByUser = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property ClaimedByUser is not found
		/// in the database. When set to true, ClaimedByUser will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool ClaimedByUserReturnsNewIfNotFound
		{
			get	{ return _claimedByUserReturnsNewIfNotFound; }
			set { _claimedByUserReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSinglePlacedInQueueByUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual UserEntity PlacedInQueueByUser
		{
			get	{ return GetSinglePlacedInQueueByUser(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncPlacedInQueueByUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportQueueThreadsPlaced", "PlacedInQueueByUser", _placedInQueueByUser, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for PlacedInQueueByUser. When set to true, PlacedInQueueByUser is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time PlacedInQueueByUser is accessed. You can always execute a forced fetch by calling GetSinglePlacedInQueueByUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPlacedInQueueByUser
		{
			get	{ return _alwaysFetchPlacedInQueueByUser; }
			set	{ _alwaysFetchPlacedInQueueByUser = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property PlacedInQueueByUser already has been fetched. Setting this property to false when PlacedInQueueByUser has been fetched
		/// will set PlacedInQueueByUser to null as well. Setting this property to true while PlacedInQueueByUser hasn't been fetched disables lazy loading for PlacedInQueueByUser</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPlacedInQueueByUser
		{
			get { return _alreadyFetchedPlacedInQueueByUser;}
			set 
			{
				if(_alreadyFetchedPlacedInQueueByUser && !value)
				{
					this.PlacedInQueueByUser = null;
				}
				_alreadyFetchedPlacedInQueueByUser = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property PlacedInQueueByUser is not found
		/// in the database. When set to true, PlacedInQueueByUser will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool PlacedInQueueByUserReturnsNewIfNotFound
		{
			get	{ return _placedInQueueByUserReturnsNewIfNotFound; }
			set { _placedInQueueByUserReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'ThreadEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/></summary>
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
					if(value==null)
					{
						bool raisePropertyChanged = (_thread !=null);
						DesetupSyncThread(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("Thread");
						}
					}
					else
					{
						if(_thread!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "SupportQueueThread");
							SetupSyncThread(value);
						}
					}
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
			set	{ _threadReturnsNewIfNotFound = value; }	
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
			get { return (int)SD.HnD.DAL.EntityType.SupportQueueThreadEntity; }
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
