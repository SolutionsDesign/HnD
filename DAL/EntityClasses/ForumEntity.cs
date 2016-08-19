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

	/// <summary>Entity class which represents the entity 'Forum'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ForumEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection	_forumRoleForumActionRights;
		private bool	_alwaysFetchForumRoleForumActionRights, _alreadyFetchedForumRoleForumActionRights;
		private SD.HnD.DAL.CollectionClasses.ThreadCollection	_threads;
		private bool	_alwaysFetchThreads, _alreadyFetchedThreads;
		private SD.HnD.DAL.CollectionClasses.UserCollection _usersWhoStartedThreads;
		private bool	_alwaysFetchUsersWhoStartedThreads, _alreadyFetchedUsersWhoStartedThreads;
		private SectionEntity _section;
		private bool	_alwaysFetchSection, _alreadyFetchedSection, _sectionReturnsNewIfNotFound;
		private SupportQueueEntity _defaultSupportQueue;
		private bool	_alwaysFetchDefaultSupportQueue, _alreadyFetchedDefaultSupportQueue, _defaultSupportQueueReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Section</summary>
			public static readonly string Section = "Section";
			/// <summary>Member name DefaultSupportQueue</summary>
			public static readonly string DefaultSupportQueue = "DefaultSupportQueue";
			/// <summary>Member name ForumRoleForumActionRights</summary>
			public static readonly string ForumRoleForumActionRights = "ForumRoleForumActionRights";
			/// <summary>Member name Threads</summary>
			public static readonly string Threads = "Threads";
			/// <summary>Member name UsersWhoStartedThreads</summary>
			public static readonly string UsersWhoStartedThreads = "UsersWhoStartedThreads";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ForumEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ForumEntity() :base("ForumEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		public ForumEntity(System.Int32 forumID):base("ForumEntity")
		{
			InitClassFetch(forumID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ForumEntity(System.Int32 forumID, IPrefetchPath prefetchPathToUse):base("ForumEntity")
		{
			InitClassFetch(forumID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="validator">The custom validator object for this ForumEntity</param>
		public ForumEntity(System.Int32 forumID, IValidator validator):base("ForumEntity")
		{
			InitClassFetch(forumID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ForumEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_forumRoleForumActionRights = (SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection)info.GetValue("_forumRoleForumActionRights", typeof(SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection));
			_alwaysFetchForumRoleForumActionRights = info.GetBoolean("_alwaysFetchForumRoleForumActionRights");
			_alreadyFetchedForumRoleForumActionRights = info.GetBoolean("_alreadyFetchedForumRoleForumActionRights");

			_threads = (SD.HnD.DAL.CollectionClasses.ThreadCollection)info.GetValue("_threads", typeof(SD.HnD.DAL.CollectionClasses.ThreadCollection));
			_alwaysFetchThreads = info.GetBoolean("_alwaysFetchThreads");
			_alreadyFetchedThreads = info.GetBoolean("_alreadyFetchedThreads");
			_usersWhoStartedThreads = (SD.HnD.DAL.CollectionClasses.UserCollection)info.GetValue("_usersWhoStartedThreads", typeof(SD.HnD.DAL.CollectionClasses.UserCollection));
			_alwaysFetchUsersWhoStartedThreads = info.GetBoolean("_alwaysFetchUsersWhoStartedThreads");
			_alreadyFetchedUsersWhoStartedThreads = info.GetBoolean("_alreadyFetchedUsersWhoStartedThreads");
			_section = (SectionEntity)info.GetValue("_section", typeof(SectionEntity));
			if(_section!=null)
			{
				_section.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_sectionReturnsNewIfNotFound = info.GetBoolean("_sectionReturnsNewIfNotFound");
			_alwaysFetchSection = info.GetBoolean("_alwaysFetchSection");
			_alreadyFetchedSection = info.GetBoolean("_alreadyFetchedSection");

			_defaultSupportQueue = (SupportQueueEntity)info.GetValue("_defaultSupportQueue", typeof(SupportQueueEntity));
			if(_defaultSupportQueue!=null)
			{
				_defaultSupportQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_defaultSupportQueueReturnsNewIfNotFound = info.GetBoolean("_defaultSupportQueueReturnsNewIfNotFound");
			_alwaysFetchDefaultSupportQueue = info.GetBoolean("_alwaysFetchDefaultSupportQueue");
			_alreadyFetchedDefaultSupportQueue = info.GetBoolean("_alreadyFetchedDefaultSupportQueue");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ForumFieldIndex)fieldIndex)
			{
				case ForumFieldIndex.SectionID:
					DesetupSyncSection(true, false);
					_alreadyFetchedSection = false;
					break;
				case ForumFieldIndex.DefaultSupportQueueID:
					DesetupSyncDefaultSupportQueue(true, false);
					_alreadyFetchedDefaultSupportQueue = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedForumRoleForumActionRights = (_forumRoleForumActionRights.Count > 0);
			_alreadyFetchedThreads = (_threads.Count > 0);
			_alreadyFetchedUsersWhoStartedThreads = (_usersWhoStartedThreads.Count > 0);
			_alreadyFetchedSection = (_section != null);
			_alreadyFetchedDefaultSupportQueue = (_defaultSupportQueue != null);
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
				case "Section":
					toReturn.Add(Relations.SectionEntityUsingSectionID);
					break;
				case "DefaultSupportQueue":
					toReturn.Add(Relations.SupportQueueEntityUsingDefaultSupportQueueID);
					break;
				case "ForumRoleForumActionRights":
					toReturn.Add(Relations.ForumRoleForumActionRightEntityUsingForumID);
					break;
				case "Threads":
					toReturn.Add(Relations.ThreadEntityUsingForumID);
					break;
				case "UsersWhoStartedThreads":
					toReturn.Add(Relations.ThreadEntityUsingForumID, "ForumEntity__", "Thread_", JoinHint.None);
					toReturn.Add(ThreadEntity.Relations.UserEntityUsingStartedByUserID, "Thread_", string.Empty, JoinHint.None);
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
			info.AddValue("_forumRoleForumActionRights", (!this.MarkedForDeletion?_forumRoleForumActionRights:null));
			info.AddValue("_alwaysFetchForumRoleForumActionRights", _alwaysFetchForumRoleForumActionRights);
			info.AddValue("_alreadyFetchedForumRoleForumActionRights", _alreadyFetchedForumRoleForumActionRights);
			info.AddValue("_threads", (!this.MarkedForDeletion?_threads:null));
			info.AddValue("_alwaysFetchThreads", _alwaysFetchThreads);
			info.AddValue("_alreadyFetchedThreads", _alreadyFetchedThreads);
			info.AddValue("_usersWhoStartedThreads", (!this.MarkedForDeletion?_usersWhoStartedThreads:null));
			info.AddValue("_alwaysFetchUsersWhoStartedThreads", _alwaysFetchUsersWhoStartedThreads);
			info.AddValue("_alreadyFetchedUsersWhoStartedThreads", _alreadyFetchedUsersWhoStartedThreads);
			info.AddValue("_section", (!this.MarkedForDeletion?_section:null));
			info.AddValue("_sectionReturnsNewIfNotFound", _sectionReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchSection", _alwaysFetchSection);
			info.AddValue("_alreadyFetchedSection", _alreadyFetchedSection);
			info.AddValue("_defaultSupportQueue", (!this.MarkedForDeletion?_defaultSupportQueue:null));
			info.AddValue("_defaultSupportQueueReturnsNewIfNotFound", _defaultSupportQueueReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchDefaultSupportQueue", _alwaysFetchDefaultSupportQueue);
			info.AddValue("_alreadyFetchedDefaultSupportQueue", _alreadyFetchedDefaultSupportQueue);

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
				case "Section":
					_alreadyFetchedSection = true;
					this.Section = (SectionEntity)entity;
					break;
				case "DefaultSupportQueue":
					_alreadyFetchedDefaultSupportQueue = true;
					this.DefaultSupportQueue = (SupportQueueEntity)entity;
					break;
				case "ForumRoleForumActionRights":
					_alreadyFetchedForumRoleForumActionRights = true;
					if(entity!=null)
					{
						this.ForumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)entity);
					}
					break;
				case "Threads":
					_alreadyFetchedThreads = true;
					if(entity!=null)
					{
						this.Threads.Add((ThreadEntity)entity);
					}
					break;
				case "UsersWhoStartedThreads":
					_alreadyFetchedUsersWhoStartedThreads = true;
					if(entity!=null)
					{
						this.UsersWhoStartedThreads.Add((UserEntity)entity);
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
				case "Section":
					SetupSyncSection(relatedEntity);
					break;
				case "DefaultSupportQueue":
					SetupSyncDefaultSupportQueue(relatedEntity);
					break;
				case "ForumRoleForumActionRights":
					_forumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)relatedEntity);
					break;
				case "Threads":
					_threads.Add((ThreadEntity)relatedEntity);
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
				case "Section":
					DesetupSyncSection(false, true);
					break;
				case "DefaultSupportQueue":
					DesetupSyncDefaultSupportQueue(false, true);
					break;
				case "ForumRoleForumActionRights":
					this.PerformRelatedEntityRemoval(_forumRoleForumActionRights, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Threads":
					this.PerformRelatedEntityRemoval(_threads, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_section!=null)
			{
				toReturn.Add(_section);
			}
			if(_defaultSupportQueue!=null)
			{
				toReturn.Add(_defaultSupportQueue);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_forumRoleForumActionRights);
			toReturn.Add(_threads);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 forumID)
		{
			return FetchUsingPK(forumID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 forumID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(forumID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 forumID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(forumID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 forumID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(forumID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.ForumID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ForumRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'ForumRoleForumActionRightEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ForumRoleForumActionRightEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection GetMultiForumRoleForumActionRights(bool forceFetch)
		{
			return GetMultiForumRoleForumActionRights(forceFetch, _forumRoleForumActionRights.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ForumRoleForumActionRightEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ForumRoleForumActionRightEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection GetMultiForumRoleForumActionRights(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiForumRoleForumActionRights(forceFetch, _forumRoleForumActionRights.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ForumRoleForumActionRightEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection GetMultiForumRoleForumActionRights(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiForumRoleForumActionRights(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ForumRoleForumActionRightEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection GetMultiForumRoleForumActionRights(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedForumRoleForumActionRights || forceFetch || _alwaysFetchForumRoleForumActionRights) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_forumRoleForumActionRights);
				_forumRoleForumActionRights.SuppressClearInGetMulti=!forceFetch;
				_forumRoleForumActionRights.EntityFactoryToUse = entityFactoryToUse;
				_forumRoleForumActionRights.GetMultiManyToOne(null, this, null, filter);
				_forumRoleForumActionRights.SuppressClearInGetMulti=false;
				_alreadyFetchedForumRoleForumActionRights = true;
			}
			return _forumRoleForumActionRights;
		}

		/// <summary> Sets the collection parameters for the collection for 'ForumRoleForumActionRights'. These settings will be taken into account
		/// when the property ForumRoleForumActionRights is requested or GetMultiForumRoleForumActionRights is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersForumRoleForumActionRights(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_forumRoleForumActionRights.SortClauses=sortClauses;
			_forumRoleForumActionRights.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiThreads(bool forceFetch)
		{
			return GetMultiThreads(forceFetch, _threads.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ThreadEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiThreads(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiThreads(forceFetch, _threads.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiThreads(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiThreads(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadCollection GetMultiThreads(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedThreads || forceFetch || _alwaysFetchThreads) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_threads);
				_threads.SuppressClearInGetMulti=!forceFetch;
				_threads.EntityFactoryToUse = entityFactoryToUse;
				_threads.GetMultiManyToOne(this, null, filter);
				_threads.SuppressClearInGetMulti=false;
				_alreadyFetchedThreads = true;
			}
			return _threads;
		}

		/// <summary> Sets the collection parameters for the collection for 'Threads'. These settings will be taken into account
		/// when the property Threads is requested or GetMultiThreads is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersThreads(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_threads.SortClauses=sortClauses;
			_threads.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsersWhoStartedThreads(bool forceFetch)
		{
			return GetMultiUsersWhoStartedThreads(forceFetch, _usersWhoStartedThreads.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsersWhoStartedThreads(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedUsersWhoStartedThreads || forceFetch || _alwaysFetchUsersWhoStartedThreads) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_usersWhoStartedThreads);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(ForumFields.ForumID, ComparisonOperator.Equal, this.ForumID, "ForumEntity__"));
				_usersWhoStartedThreads.SuppressClearInGetMulti=!forceFetch;
				_usersWhoStartedThreads.EntityFactoryToUse = entityFactoryToUse;
				_usersWhoStartedThreads.GetMulti(filter, GetRelationsForField("UsersWhoStartedThreads"));
				_usersWhoStartedThreads.SuppressClearInGetMulti=false;
				_alreadyFetchedUsersWhoStartedThreads = true;
			}
			return _usersWhoStartedThreads;
		}

		/// <summary> Sets the collection parameters for the collection for 'UsersWhoStartedThreads'. These settings will be taken into account
		/// when the property UsersWhoStartedThreads is requested or GetMultiUsersWhoStartedThreads is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUsersWhoStartedThreads(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_usersWhoStartedThreads.SortClauses=sortClauses;
			_usersWhoStartedThreads.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves the related entity of type 'SectionEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'SectionEntity' which is related to this entity.</returns>
		public SectionEntity GetSingleSection()
		{
			return GetSingleSection(false);
		}

		/// <summary> Retrieves the related entity of type 'SectionEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'SectionEntity' which is related to this entity.</returns>
		public virtual SectionEntity GetSingleSection(bool forceFetch)
		{
			if( ( !_alreadyFetchedSection || forceFetch || _alwaysFetchSection) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.SectionEntityUsingSectionID);
				SectionEntity newEntity = new SectionEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.SectionID);
				}
				if(fetchResult)
				{
					newEntity = (SectionEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_sectionReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Section = newEntity;
				_alreadyFetchedSection = fetchResult;
			}
			return _section;
		}


		/// <summary> Retrieves the related entity of type 'SupportQueueEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'SupportQueueEntity' which is related to this entity.</returns>
		public SupportQueueEntity GetSingleDefaultSupportQueue()
		{
			return GetSingleDefaultSupportQueue(false);
		}

		/// <summary> Retrieves the related entity of type 'SupportQueueEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'SupportQueueEntity' which is related to this entity.</returns>
		public virtual SupportQueueEntity GetSingleDefaultSupportQueue(bool forceFetch)
		{
			if( ( !_alreadyFetchedDefaultSupportQueue || forceFetch || _alwaysFetchDefaultSupportQueue) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.SupportQueueEntityUsingDefaultSupportQueueID);
				SupportQueueEntity newEntity = new SupportQueueEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.DefaultSupportQueueID.GetValueOrDefault());
				}
				if(fetchResult)
				{
					newEntity = (SupportQueueEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_defaultSupportQueueReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.DefaultSupportQueue = newEntity;
				_alreadyFetchedDefaultSupportQueue = fetchResult;
			}
			return _defaultSupportQueue;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Section", _section);
			toReturn.Add("DefaultSupportQueue", _defaultSupportQueue);
			toReturn.Add("ForumRoleForumActionRights", _forumRoleForumActionRights);
			toReturn.Add("Threads", _threads);
			toReturn.Add("UsersWhoStartedThreads", _usersWhoStartedThreads);
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
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="validator">The validator object for this ForumEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 forumID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(forumID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_forumRoleForumActionRights = new SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection();
			_forumRoleForumActionRights.SetContainingEntityInfo(this, "Forum");

			_threads = new SD.HnD.DAL.CollectionClasses.ThreadCollection();
			_threads.SetContainingEntityInfo(this, "Forum");
			_usersWhoStartedThreads = new SD.HnD.DAL.CollectionClasses.UserCollection();
			_sectionReturnsNewIfNotFound = true;
			_defaultSupportQueueReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("ForumID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SectionID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ForumName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ForumDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ForumLastPostingDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("HasRSSFeed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultSupportQueueID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultThreadListInterval", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrderNo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MaxAttachmentSize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MaxNoOfAttachmentsPerMessage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NewThreadWelcomeText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NewThreadWelcomeTextAsHTML", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _section</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSection(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _section, new PropertyChangedEventHandler( OnSectionPropertyChanged ), "Section", SD.HnD.DAL.RelationClasses.StaticForumRelations.SectionEntityUsingSectionIDStatic, true, signalRelatedEntity, "Forums", resetFKFields, new int[] { (int)ForumFieldIndex.SectionID } );		
			_section = null;
		}
		
		/// <summary> setups the sync logic for member _section</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSection(IEntityCore relatedEntity)
		{
			if(_section!=relatedEntity)
			{		
				DesetupSyncSection(true, true);
				_section = (SectionEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _section, new PropertyChangedEventHandler( OnSectionPropertyChanged ), "Section", SD.HnD.DAL.RelationClasses.StaticForumRelations.SectionEntityUsingSectionIDStatic, true, ref _alreadyFetchedSection, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSectionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _defaultSupportQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDefaultSupportQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _defaultSupportQueue, new PropertyChangedEventHandler( OnDefaultSupportQueuePropertyChanged ), "DefaultSupportQueue", SD.HnD.DAL.RelationClasses.StaticForumRelations.SupportQueueEntityUsingDefaultSupportQueueIDStatic, true, signalRelatedEntity, "DefaultForForums", resetFKFields, new int[] { (int)ForumFieldIndex.DefaultSupportQueueID } );		
			_defaultSupportQueue = null;
		}
		
		/// <summary> setups the sync logic for member _defaultSupportQueue</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDefaultSupportQueue(IEntityCore relatedEntity)
		{
			if(_defaultSupportQueue!=relatedEntity)
			{		
				DesetupSyncDefaultSupportQueue(true, true);
				_defaultSupportQueue = (SupportQueueEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _defaultSupportQueue, new PropertyChangedEventHandler( OnDefaultSupportQueuePropertyChanged ), "DefaultSupportQueue", SD.HnD.DAL.RelationClasses.StaticForumRelations.SupportQueueEntityUsingDefaultSupportQueueIDStatic, true, ref _alreadyFetchedDefaultSupportQueue, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDefaultSupportQueuePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="forumID">PK value for Forum which data should be fetched into this Forum object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 forumID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)ForumFieldIndex.ForumID].ForcedCurrentValueWrite(forumID);
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
			return DAOFactory.CreateForumDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ForumEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ForumRelations Relations
		{
			get	{ return new ForumRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ForumRoleForumActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathForumRoleForumActionRights
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection(), (IEntityRelation)GetRelationsForField("ForumRoleForumActionRights")[0], (int)SD.HnD.DAL.EntityType.ForumEntity, (int)SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity, 0, null, null, null, "ForumRoleForumActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThreads
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), (IEntityRelation)GetRelationsForField("Threads")[0], (int)SD.HnD.DAL.EntityType.ForumEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, null, "Threads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUsersWhoStartedThreads
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.ThreadEntityUsingForumID;
				intermediateRelation.SetAliases(string.Empty, "Thread_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.ForumEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, GetRelationsForField("UsersWhoStartedThreads"), "UsersWhoStartedThreads", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Section'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSection
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SectionCollection(), (IEntityRelation)GetRelationsForField("Section")[0], (int)SD.HnD.DAL.EntityType.ForumEntity, (int)SD.HnD.DAL.EntityType.SectionEntity, 0, null, null, null, "Section", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportQueue'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathDefaultSupportQueue
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SupportQueueCollection(), (IEntityRelation)GetRelationsForField("DefaultSupportQueue")[0], (int)SD.HnD.DAL.EntityType.ForumEntity, (int)SD.HnD.DAL.EntityType.SupportQueueEntity, 0, null, null, null, "DefaultSupportQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The ForumID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ForumID
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.ForumID, true); }
			set	{ SetValue((int)ForumFieldIndex.ForumID, value, true); }
		}

		/// <summary> The SectionID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."SectionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 SectionID
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.SectionID, true); }
			set	{ SetValue((int)ForumFieldIndex.SectionID, value, true); }
		}

		/// <summary> The ForumName property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ForumName
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.ForumName, true); }
			set	{ SetValue((int)ForumFieldIndex.ForumName, value, true); }
		}

		/// <summary> The ForumDescription property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ForumDescription
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.ForumDescription, true); }
			set	{ SetValue((int)ForumFieldIndex.ForumDescription, value, true); }
		}

		/// <summary> The ForumLastPostingDate property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."ForumLastPostingDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ForumLastPostingDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ForumFieldIndex.ForumLastPostingDate, false); }
			set	{ SetValue((int)ForumFieldIndex.ForumLastPostingDate, value, true); }
		}

		/// <summary> The HasRSSFeed property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."HasRSSFeed"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean HasRSSFeed
		{
			get { return (System.Boolean)GetValue((int)ForumFieldIndex.HasRSSFeed, true); }
			set	{ SetValue((int)ForumFieldIndex.HasRSSFeed, value, true); }
		}

		/// <summary> The DefaultSupportQueueID property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."DefaultSupportQueueID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> DefaultSupportQueueID
		{
			get { return (Nullable<System.Int32>)GetValue((int)ForumFieldIndex.DefaultSupportQueueID, false); }
			set	{ SetValue((int)ForumFieldIndex.DefaultSupportQueueID, value, true); }
		}

		/// <summary> The DefaultThreadListInterval property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."DefaultThreadListInterval"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte DefaultThreadListInterval
		{
			get { return (System.Byte)GetValue((int)ForumFieldIndex.DefaultThreadListInterval, true); }
			set	{ SetValue((int)ForumFieldIndex.DefaultThreadListInterval, value, true); }
		}

		/// <summary> The OrderNo property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."OrderNo"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 OrderNo
		{
			get { return (System.Int16)GetValue((int)ForumFieldIndex.OrderNo, true); }
			set	{ SetValue((int)ForumFieldIndex.OrderNo, value, true); }
		}

		/// <summary> The MaxAttachmentSize property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."MaxAttachmentSize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int32 MaxAttachmentSize
		{
			get { return (System.Int32)GetValue((int)ForumFieldIndex.MaxAttachmentSize, true); }
			set	{ SetValue((int)ForumFieldIndex.MaxAttachmentSize, value, true); }
		}

		/// <summary> The MaxNoOfAttachmentsPerMessage property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."MaxNoOfAttachmentsPerMessage"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Int16 MaxNoOfAttachmentsPerMessage
		{
			get { return (System.Int16)GetValue((int)ForumFieldIndex.MaxNoOfAttachmentsPerMessage, true); }
			set	{ SetValue((int)ForumFieldIndex.MaxNoOfAttachmentsPerMessage, value, true); }
		}

		/// <summary> The NewThreadWelcomeText property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."NewThreadWelcomeText"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String NewThreadWelcomeText
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.NewThreadWelcomeText, true); }
			set	{ SetValue((int)ForumFieldIndex.NewThreadWelcomeText, value, true); }
		}

		/// <summary> The NewThreadWelcomeTextAsHTML property of the Entity Forum<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Forum"."NewThreadWelcomeTextAsHTML"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String NewThreadWelcomeTextAsHTML
		{
			get { return (System.String)GetValue((int)ForumFieldIndex.NewThreadWelcomeTextAsHTML, true); }
			set	{ SetValue((int)ForumFieldIndex.NewThreadWelcomeTextAsHTML, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'ForumRoleForumActionRightEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiForumRoleForumActionRights()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection ForumRoleForumActionRights
		{
			get	{ return GetMultiForumRoleForumActionRights(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ForumRoleForumActionRights. When set to true, ForumRoleForumActionRights is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ForumRoleForumActionRights is accessed. You can always execute/ a forced fetch by calling GetMultiForumRoleForumActionRights(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchForumRoleForumActionRights
		{
			get	{ return _alwaysFetchForumRoleForumActionRights; }
			set	{ _alwaysFetchForumRoleForumActionRights = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property ForumRoleForumActionRights already has been fetched. Setting this property to false when ForumRoleForumActionRights has been fetched
		/// will clear the ForumRoleForumActionRights collection well. Setting this property to true while ForumRoleForumActionRights hasn't been fetched disables lazy loading for ForumRoleForumActionRights</summary>
		[Browsable(false)]
		public bool AlreadyFetchedForumRoleForumActionRights
		{
			get { return _alreadyFetchedForumRoleForumActionRights;}
			set 
			{
				if(_alreadyFetchedForumRoleForumActionRights && !value && (_forumRoleForumActionRights != null))
				{
					_forumRoleForumActionRights.Clear();
				}
				_alreadyFetchedForumRoleForumActionRights = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'ThreadEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiThreads()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ThreadCollection Threads
		{
			get	{ return GetMultiThreads(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Threads. When set to true, Threads is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Threads is accessed. You can always execute/ a forced fetch by calling GetMultiThreads(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchThreads
		{
			get	{ return _alwaysFetchThreads; }
			set	{ _alwaysFetchThreads = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Threads already has been fetched. Setting this property to false when Threads has been fetched
		/// will clear the Threads collection well. Setting this property to true while Threads hasn't been fetched disables lazy loading for Threads</summary>
		[Browsable(false)]
		public bool AlreadyFetchedThreads
		{
			get { return _alreadyFetchedThreads;}
			set 
			{
				if(_alreadyFetchedThreads && !value && (_threads != null))
				{
					_threads.Clear();
				}
				_alreadyFetchedThreads = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUsersWhoStartedThreads()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.UserCollection UsersWhoStartedThreads
		{
			get { return GetMultiUsersWhoStartedThreads(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UsersWhoStartedThreads. When set to true, UsersWhoStartedThreads is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UsersWhoStartedThreads is accessed. You can always execute a forced fetch by calling GetMultiUsersWhoStartedThreads(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUsersWhoStartedThreads
		{
			get	{ return _alwaysFetchUsersWhoStartedThreads; }
			set	{ _alwaysFetchUsersWhoStartedThreads = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property UsersWhoStartedThreads already has been fetched. Setting this property to false when UsersWhoStartedThreads has been fetched
		/// will clear the UsersWhoStartedThreads collection well. Setting this property to true while UsersWhoStartedThreads hasn't been fetched disables lazy loading for UsersWhoStartedThreads</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUsersWhoStartedThreads
		{
			get { return _alreadyFetchedUsersWhoStartedThreads;}
			set 
			{
				if(_alreadyFetchedUsersWhoStartedThreads && !value && (_usersWhoStartedThreads != null))
				{
					_usersWhoStartedThreads.Clear();
				}
				_alreadyFetchedUsersWhoStartedThreads = value;
			}
		}

		/// <summary> Gets / sets related entity of type 'SectionEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleSection()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual SectionEntity Section
		{
			get	{ return GetSingleSection(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncSection(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Forums", "Section", _section, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Section. When set to true, Section is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Section is accessed. You can always execute a forced fetch by calling GetSingleSection(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSection
		{
			get	{ return _alwaysFetchSection; }
			set	{ _alwaysFetchSection = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Section already has been fetched. Setting this property to false when Section has been fetched
		/// will set Section to null as well. Setting this property to true while Section hasn't been fetched disables lazy loading for Section</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSection
		{
			get { return _alreadyFetchedSection;}
			set 
			{
				if(_alreadyFetchedSection && !value)
				{
					this.Section = null;
				}
				_alreadyFetchedSection = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Section is not found
		/// in the database. When set to true, Section will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool SectionReturnsNewIfNotFound
		{
			get	{ return _sectionReturnsNewIfNotFound; }
			set { _sectionReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'SupportQueueEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleDefaultSupportQueue()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual SupportQueueEntity DefaultSupportQueue
		{
			get	{ return GetSingleDefaultSupportQueue(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncDefaultSupportQueue(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "DefaultForForums", "DefaultSupportQueue", _defaultSupportQueue, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for DefaultSupportQueue. When set to true, DefaultSupportQueue is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time DefaultSupportQueue is accessed. You can always execute a forced fetch by calling GetSingleDefaultSupportQueue(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchDefaultSupportQueue
		{
			get	{ return _alwaysFetchDefaultSupportQueue; }
			set	{ _alwaysFetchDefaultSupportQueue = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property DefaultSupportQueue already has been fetched. Setting this property to false when DefaultSupportQueue has been fetched
		/// will set DefaultSupportQueue to null as well. Setting this property to true while DefaultSupportQueue hasn't been fetched disables lazy loading for DefaultSupportQueue</summary>
		[Browsable(false)]
		public bool AlreadyFetchedDefaultSupportQueue
		{
			get { return _alreadyFetchedDefaultSupportQueue;}
			set 
			{
				if(_alreadyFetchedDefaultSupportQueue && !value)
				{
					this.DefaultSupportQueue = null;
				}
				_alreadyFetchedDefaultSupportQueue = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property DefaultSupportQueue is not found
		/// in the database. When set to true, DefaultSupportQueue will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool DefaultSupportQueueReturnsNewIfNotFound
		{
			get	{ return _defaultSupportQueueReturnsNewIfNotFound; }
			set { _defaultSupportQueueReturnsNewIfNotFound = value; }	
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
			get { return (int)SD.HnD.DAL.EntityType.ForumEntity; }
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
