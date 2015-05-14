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

	/// <summary>Entity class which represents the entity 'Message'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MessageEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SD.HnD.DAL.CollectionClasses.AttachmentCollection	_attachments;
		private bool	_alwaysFetchAttachments, _alreadyFetchedAttachments;
		private SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection	_auditDataMessageRelated;
		private bool	_alwaysFetchAuditDataMessageRelated, _alreadyFetchedAuditDataMessageRelated;
		private ThreadEntity _thread;
		private bool	_alwaysFetchThread, _alreadyFetchedThread, _threadReturnsNewIfNotFound;
		private UserEntity _postedByUser;
		private bool	_alwaysFetchPostedByUser, _alreadyFetchedPostedByUser, _postedByUserReturnsNewIfNotFound;

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
			/// <summary>Member name PostedByUser</summary>
			public static readonly string PostedByUser = "PostedByUser";
			/// <summary>Member name Attachments</summary>
			public static readonly string Attachments = "Attachments";
			/// <summary>Member name AuditDataMessageRelated</summary>
			public static readonly string AuditDataMessageRelated = "AuditDataMessageRelated";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MessageEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public MessageEntity() :base("MessageEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		public MessageEntity(System.Int32 messageID):base("MessageEntity")
		{
			InitClassFetch(messageID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public MessageEntity(System.Int32 messageID, IPrefetchPath prefetchPathToUse):base("MessageEntity")
		{
			InitClassFetch(messageID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <param name="validator">The custom validator object for this MessageEntity</param>
		public MessageEntity(System.Int32 messageID, IValidator validator):base("MessageEntity")
		{
			InitClassFetch(messageID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MessageEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_attachments = (SD.HnD.DAL.CollectionClasses.AttachmentCollection)info.GetValue("_attachments", typeof(SD.HnD.DAL.CollectionClasses.AttachmentCollection));
			_alwaysFetchAttachments = info.GetBoolean("_alwaysFetchAttachments");
			_alreadyFetchedAttachments = info.GetBoolean("_alreadyFetchedAttachments");

			_auditDataMessageRelated = (SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection)info.GetValue("_auditDataMessageRelated", typeof(SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection));
			_alwaysFetchAuditDataMessageRelated = info.GetBoolean("_alwaysFetchAuditDataMessageRelated");
			_alreadyFetchedAuditDataMessageRelated = info.GetBoolean("_alreadyFetchedAuditDataMessageRelated");
			_thread = (ThreadEntity)info.GetValue("_thread", typeof(ThreadEntity));
			if(_thread!=null)
			{
				_thread.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_threadReturnsNewIfNotFound = info.GetBoolean("_threadReturnsNewIfNotFound");
			_alwaysFetchThread = info.GetBoolean("_alwaysFetchThread");
			_alreadyFetchedThread = info.GetBoolean("_alreadyFetchedThread");

			_postedByUser = (UserEntity)info.GetValue("_postedByUser", typeof(UserEntity));
			if(_postedByUser!=null)
			{
				_postedByUser.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_postedByUserReturnsNewIfNotFound = info.GetBoolean("_postedByUserReturnsNewIfNotFound");
			_alwaysFetchPostedByUser = info.GetBoolean("_alwaysFetchPostedByUser");
			_alreadyFetchedPostedByUser = info.GetBoolean("_alreadyFetchedPostedByUser");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((MessageFieldIndex)fieldIndex)
			{
				case MessageFieldIndex.PostedByUserID:
					DesetupSyncPostedByUser(true, false);
					_alreadyFetchedPostedByUser = false;
					break;
				case MessageFieldIndex.ThreadID:
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
			_alreadyFetchedAttachments = (_attachments.Count > 0);
			_alreadyFetchedAuditDataMessageRelated = (_auditDataMessageRelated.Count > 0);
			_alreadyFetchedThread = (_thread != null);
			_alreadyFetchedPostedByUser = (_postedByUser != null);
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
				case "PostedByUser":
					toReturn.Add(Relations.UserEntityUsingPostedByUserID);
					break;
				case "Attachments":
					toReturn.Add(Relations.AttachmentEntityUsingMessageID);
					break;
				case "AuditDataMessageRelated":
					toReturn.Add(Relations.AuditDataMessageRelatedEntityUsingMessageID);
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
			info.AddValue("_attachments", (!this.MarkedForDeletion?_attachments:null));
			info.AddValue("_alwaysFetchAttachments", _alwaysFetchAttachments);
			info.AddValue("_alreadyFetchedAttachments", _alreadyFetchedAttachments);
			info.AddValue("_auditDataMessageRelated", (!this.MarkedForDeletion?_auditDataMessageRelated:null));
			info.AddValue("_alwaysFetchAuditDataMessageRelated", _alwaysFetchAuditDataMessageRelated);
			info.AddValue("_alreadyFetchedAuditDataMessageRelated", _alreadyFetchedAuditDataMessageRelated);
			info.AddValue("_thread", (!this.MarkedForDeletion?_thread:null));
			info.AddValue("_threadReturnsNewIfNotFound", _threadReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchThread", _alwaysFetchThread);
			info.AddValue("_alreadyFetchedThread", _alreadyFetchedThread);
			info.AddValue("_postedByUser", (!this.MarkedForDeletion?_postedByUser:null));
			info.AddValue("_postedByUserReturnsNewIfNotFound", _postedByUserReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchPostedByUser", _alwaysFetchPostedByUser);
			info.AddValue("_alreadyFetchedPostedByUser", _alreadyFetchedPostedByUser);

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
				case "PostedByUser":
					_alreadyFetchedPostedByUser = true;
					this.PostedByUser = (UserEntity)entity;
					break;
				case "Attachments":
					_alreadyFetchedAttachments = true;
					if(entity!=null)
					{
						this.Attachments.Add((AttachmentEntity)entity);
					}
					break;
				case "AuditDataMessageRelated":
					_alreadyFetchedAuditDataMessageRelated = true;
					if(entity!=null)
					{
						this.AuditDataMessageRelated.Add((AuditDataMessageRelatedEntity)entity);
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
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "Thread":
					SetupSyncThread(relatedEntity);
					break;
				case "PostedByUser":
					SetupSyncPostedByUser(relatedEntity);
					break;
				case "Attachments":
					_attachments.Add((AttachmentEntity)relatedEntity);
					break;
				case "AuditDataMessageRelated":
					_auditDataMessageRelated.Add((AuditDataMessageRelatedEntity)relatedEntity);
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
				case "PostedByUser":
					DesetupSyncPostedByUser(false, true);
					break;
				case "Attachments":
					this.PerformRelatedEntityRemoval(_attachments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AuditDataMessageRelated":
					this.PerformRelatedEntityRemoval(_auditDataMessageRelated, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_postedByUser!=null)
			{
				toReturn.Add(_postedByUser);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_attachments);
			toReturn.Add(_auditDataMessageRelated);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 messageID)
		{
			return FetchUsingPK(messageID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 messageID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(messageID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 messageID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(messageID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 messageID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(messageID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.MessageID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new MessageRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'AttachmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'AttachmentEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AttachmentCollection GetMultiAttachments(bool forceFetch)
		{
			return GetMultiAttachments(forceFetch, _attachments.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AttachmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'AttachmentEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AttachmentCollection GetMultiAttachments(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiAttachments(forceFetch, _attachments.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'AttachmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.AttachmentCollection GetMultiAttachments(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiAttachments(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AttachmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.AttachmentCollection GetMultiAttachments(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedAttachments || forceFetch || _alwaysFetchAttachments) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_attachments);
				_attachments.SuppressClearInGetMulti=!forceFetch;
				_attachments.EntityFactoryToUse = entityFactoryToUse;
				_attachments.GetMultiManyToOne(this, filter);
				_attachments.SuppressClearInGetMulti=false;
				_alreadyFetchedAttachments = true;
			}
			return _attachments;
		}

		/// <summary> Sets the collection parameters for the collection for 'Attachments'. These settings will be taken into account
		/// when the property Attachments is requested or GetMultiAttachments is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersAttachments(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_attachments.SortClauses=sortClauses;
			_attachments.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'AuditDataMessageRelatedEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'AuditDataMessageRelatedEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection GetMultiAuditDataMessageRelated(bool forceFetch)
		{
			return GetMultiAuditDataMessageRelated(forceFetch, _auditDataMessageRelated.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataMessageRelatedEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'AuditDataMessageRelatedEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection GetMultiAuditDataMessageRelated(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiAuditDataMessageRelated(forceFetch, _auditDataMessageRelated.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataMessageRelatedEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection GetMultiAuditDataMessageRelated(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiAuditDataMessageRelated(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataMessageRelatedEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection GetMultiAuditDataMessageRelated(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedAuditDataMessageRelated || forceFetch || _alwaysFetchAuditDataMessageRelated) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_auditDataMessageRelated);
				_auditDataMessageRelated.SuppressClearInGetMulti=!forceFetch;
				_auditDataMessageRelated.EntityFactoryToUse = entityFactoryToUse;
				_auditDataMessageRelated.GetMultiManyToOne(null, this, null, filter);
				_auditDataMessageRelated.SuppressClearInGetMulti=false;
				_alreadyFetchedAuditDataMessageRelated = true;
			}
			return _auditDataMessageRelated;
		}

		/// <summary> Sets the collection parameters for the collection for 'AuditDataMessageRelated'. These settings will be taken into account
		/// when the property AuditDataMessageRelated is requested or GetMultiAuditDataMessageRelated is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersAuditDataMessageRelated(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_auditDataMessageRelated.SortClauses=sortClauses;
			_auditDataMessageRelated.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
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
		public UserEntity GetSinglePostedByUser()
		{
			return GetSinglePostedByUser(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSinglePostedByUser(bool forceFetch)
		{
			if( ( !_alreadyFetchedPostedByUser || forceFetch || _alwaysFetchPostedByUser) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserEntityUsingPostedByUserID);
				UserEntity newEntity = new UserEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.PostedByUserID);
				}
				if(fetchResult)
				{
					newEntity = (UserEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_postedByUserReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.PostedByUser = newEntity;
				_alreadyFetchedPostedByUser = fetchResult;
			}
			return _postedByUser;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Thread", _thread);
			toReturn.Add("PostedByUser", _postedByUser);
			toReturn.Add("Attachments", _attachments);
			toReturn.Add("AuditDataMessageRelated", _auditDataMessageRelated);
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
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <param name="validator">The validator object for this MessageEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 messageID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(messageID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_attachments = new SD.HnD.DAL.CollectionClasses.AttachmentCollection();
			_attachments.SetContainingEntityInfo(this, "BelongsToMessage");

			_auditDataMessageRelated = new SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection();
			_auditDataMessageRelated.SetContainingEntityInfo(this, "Message");
			_threadReturnsNewIfNotFound = true;
			_postedByUserReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("MessageID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PostingDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PostedByUserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PostedFromIP", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ChangeTrackerStamp", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MessageText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MessageTextAsHTML", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MessageTextAsXml", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _thread</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncThread(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DAL.RelationClasses.StaticMessageRelations.ThreadEntityUsingThreadIDStatic, true, signalRelatedEntity, "Messages", resetFKFields, new int[] { (int)MessageFieldIndex.ThreadID } );		
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
				this.PerformSetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DAL.RelationClasses.StaticMessageRelations.ThreadEntityUsingThreadIDStatic, true, ref _alreadyFetchedThread, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _postedByUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPostedByUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _postedByUser, new PropertyChangedEventHandler( OnPostedByUserPropertyChanged ), "PostedByUser", SD.HnD.DAL.RelationClasses.StaticMessageRelations.UserEntityUsingPostedByUserIDStatic, true, signalRelatedEntity, "PostedMessages", resetFKFields, new int[] { (int)MessageFieldIndex.PostedByUserID } );		
			_postedByUser = null;
		}
		
		/// <summary> setups the sync logic for member _postedByUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPostedByUser(IEntityCore relatedEntity)
		{
			if(_postedByUser!=relatedEntity)
			{		
				DesetupSyncPostedByUser(true, true);
				_postedByUser = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _postedByUser, new PropertyChangedEventHandler( OnPostedByUserPropertyChanged ), "PostedByUser", SD.HnD.DAL.RelationClasses.StaticMessageRelations.UserEntityUsingPostedByUserIDStatic, true, ref _alreadyFetchedPostedByUser, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPostedByUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="messageID">PK value for Message which data should be fetched into this Message object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 messageID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)MessageFieldIndex.MessageID].ForcedCurrentValueWrite(messageID);
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
			return DAOFactory.CreateMessageDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new MessageEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static MessageRelations Relations
		{
			get	{ return new MessageRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Attachment' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAttachments
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.AttachmentCollection(), (IEntityRelation)GetRelationsForField("Attachments")[0], (int)SD.HnD.DAL.EntityType.MessageEntity, (int)SD.HnD.DAL.EntityType.AttachmentEntity, 0, null, null, null, "Attachments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'AuditDataMessageRelated' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAuditDataMessageRelated
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection(), (IEntityRelation)GetRelationsForField("AuditDataMessageRelated")[0], (int)SD.HnD.DAL.EntityType.MessageEntity, (int)SD.HnD.DAL.EntityType.AuditDataMessageRelatedEntity, 0, null, null, null, "AuditDataMessageRelated", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThread
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), (IEntityRelation)GetRelationsForField("Thread")[0], (int)SD.HnD.DAL.EntityType.MessageEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, null, "Thread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPostedByUser
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("PostedByUser")[0], (int)SD.HnD.DAL.EntityType.MessageEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, null, "PostedByUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The MessageID property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."MessageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 MessageID
		{
			get { return (System.Int32)GetValue((int)MessageFieldIndex.MessageID, true); }
			set	{ SetValue((int)MessageFieldIndex.MessageID, value, true); }
		}

		/// <summary> The PostingDate property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."PostingDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime PostingDate
		{
			get { return (System.DateTime)GetValue((int)MessageFieldIndex.PostingDate, true); }
			set	{ SetValue((int)MessageFieldIndex.PostingDate, value, true); }
		}

		/// <summary> The PostedByUserID property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."PostedByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PostedByUserID
		{
			get { return (System.Int32)GetValue((int)MessageFieldIndex.PostedByUserID, true); }
			set	{ SetValue((int)MessageFieldIndex.PostedByUserID, value, true); }
		}

		/// <summary> The ThreadID property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."ThreadID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)MessageFieldIndex.ThreadID, true); }
			set	{ SetValue((int)MessageFieldIndex.ThreadID, value, true); }
		}

		/// <summary> The PostedFromIP property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."PostedFromIP"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 25<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PostedFromIP
		{
			get { return (System.String)GetValue((int)MessageFieldIndex.PostedFromIP, true); }
			set	{ SetValue((int)MessageFieldIndex.PostedFromIP, value, true); }
		}

		/// <summary> The ChangeTrackerStamp property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."ChangeTrackerStamp"<br/>
		/// Table field type characteristics (type, precision, scale, length): Timestamp, 0, 0, 8<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte[] ChangeTrackerStamp
		{
			get { return (System.Byte[])GetValue((int)MessageFieldIndex.ChangeTrackerStamp, true); }

		}

		/// <summary> The MessageText property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."MessageText"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MessageText
		{
			get { return (System.String)GetValue((int)MessageFieldIndex.MessageText, true); }
			set	{ SetValue((int)MessageFieldIndex.MessageText, value, true); }
		}

		/// <summary> The MessageTextAsHTML property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."MessageTextAsHTML"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MessageTextAsHTML
		{
			get { return (System.String)GetValue((int)MessageFieldIndex.MessageTextAsHTML, true); }
			set	{ SetValue((int)MessageFieldIndex.MessageTextAsHTML, value, true); }
		}

		/// <summary> The MessageTextAsXml property of the Entity Message<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Message"."MessageTextAsXml"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MessageTextAsXml
		{
			get { return (System.String)GetValue((int)MessageFieldIndex.MessageTextAsXml, true); }
			set	{ SetValue((int)MessageFieldIndex.MessageTextAsXml, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'AttachmentEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiAttachments()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.AttachmentCollection Attachments
		{
			get	{ return GetMultiAttachments(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Attachments. When set to true, Attachments is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Attachments is accessed. You can always execute/ a forced fetch by calling GetMultiAttachments(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAttachments
		{
			get	{ return _alwaysFetchAttachments; }
			set	{ _alwaysFetchAttachments = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Attachments already has been fetched. Setting this property to false when Attachments has been fetched
		/// will clear the Attachments collection well. Setting this property to true while Attachments hasn't been fetched disables lazy loading for Attachments</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAttachments
		{
			get { return _alreadyFetchedAttachments;}
			set 
			{
				if(_alreadyFetchedAttachments && !value && (_attachments != null))
				{
					_attachments.Clear();
				}
				_alreadyFetchedAttachments = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'AuditDataMessageRelatedEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiAuditDataMessageRelated()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.AuditDataMessageRelatedCollection AuditDataMessageRelated
		{
			get	{ return GetMultiAuditDataMessageRelated(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for AuditDataMessageRelated. When set to true, AuditDataMessageRelated is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time AuditDataMessageRelated is accessed. You can always execute/ a forced fetch by calling GetMultiAuditDataMessageRelated(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAuditDataMessageRelated
		{
			get	{ return _alwaysFetchAuditDataMessageRelated; }
			set	{ _alwaysFetchAuditDataMessageRelated = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property AuditDataMessageRelated already has been fetched. Setting this property to false when AuditDataMessageRelated has been fetched
		/// will clear the AuditDataMessageRelated collection well. Setting this property to true while AuditDataMessageRelated hasn't been fetched disables lazy loading for AuditDataMessageRelated</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAuditDataMessageRelated
		{
			get { return _alreadyFetchedAuditDataMessageRelated;}
			set 
			{
				if(_alreadyFetchedAuditDataMessageRelated && !value && (_auditDataMessageRelated != null))
				{
					_auditDataMessageRelated.Clear();
				}
				_alreadyFetchedAuditDataMessageRelated = value;
			}
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
					SetSingleRelatedEntityNavigator(value, "Messages", "Thread", _thread, true); 
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
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSinglePostedByUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual UserEntity PostedByUser
		{
			get	{ return GetSinglePostedByUser(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncPostedByUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "PostedMessages", "PostedByUser", _postedByUser, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for PostedByUser. When set to true, PostedByUser is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time PostedByUser is accessed. You can always execute a forced fetch by calling GetSinglePostedByUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPostedByUser
		{
			get	{ return _alwaysFetchPostedByUser; }
			set	{ _alwaysFetchPostedByUser = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property PostedByUser already has been fetched. Setting this property to false when PostedByUser has been fetched
		/// will set PostedByUser to null as well. Setting this property to true while PostedByUser hasn't been fetched disables lazy loading for PostedByUser</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPostedByUser
		{
			get { return _alreadyFetchedPostedByUser;}
			set 
			{
				if(_alreadyFetchedPostedByUser && !value)
				{
					this.PostedByUser = null;
				}
				_alreadyFetchedPostedByUser = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property PostedByUser is not found
		/// in the database. When set to true, PostedByUser will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool PostedByUserReturnsNewIfNotFound
		{
			get	{ return _postedByUserReturnsNewIfNotFound; }
			set { _postedByUserReturnsNewIfNotFound = value; }	
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
			get { return (int)SD.HnD.DAL.EntityType.MessageEntity; }
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
