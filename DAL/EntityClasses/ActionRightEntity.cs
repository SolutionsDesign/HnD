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

	/// <summary>Entity class which represents the entity 'ActionRight'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ActionRightEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection	_forumRoleForumActionRights;
		private bool	_alwaysFetchForumRoleForumActionRights, _alreadyFetchedForumRoleForumActionRights;
		private SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection	_roleSystemActionRights;
		private bool	_alwaysFetchRoleSystemActionRights, _alreadyFetchedRoleSystemActionRights;
		private SD.HnD.DAL.CollectionClasses.RoleCollection _systemRightAssignedToRoles;
		private bool	_alwaysFetchSystemRightAssignedToRoles, _alreadyFetchedSystemRightAssignedToRoles;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ForumRoleForumActionRights</summary>
			public static readonly string ForumRoleForumActionRights = "ForumRoleForumActionRights";
			/// <summary>Member name RoleSystemActionRights</summary>
			public static readonly string RoleSystemActionRights = "RoleSystemActionRights";
			/// <summary>Member name SystemRightAssignedToRoles</summary>
			public static readonly string SystemRightAssignedToRoles = "SystemRightAssignedToRoles";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ActionRightEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ActionRightEntity() :base("ActionRightEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		public ActionRightEntity(System.Int32 actionRightID):base("ActionRightEntity")
		{
			InitClassFetch(actionRightID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ActionRightEntity(System.Int32 actionRightID, IPrefetchPath prefetchPathToUse):base("ActionRightEntity")
		{
			InitClassFetch(actionRightID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <param name="validator">The custom validator object for this ActionRightEntity</param>
		public ActionRightEntity(System.Int32 actionRightID, IValidator validator):base("ActionRightEntity")
		{
			InitClassFetch(actionRightID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ActionRightEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_forumRoleForumActionRights = (SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection)info.GetValue("_forumRoleForumActionRights", typeof(SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection));
			_alwaysFetchForumRoleForumActionRights = info.GetBoolean("_alwaysFetchForumRoleForumActionRights");
			_alreadyFetchedForumRoleForumActionRights = info.GetBoolean("_alreadyFetchedForumRoleForumActionRights");

			_roleSystemActionRights = (SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection)info.GetValue("_roleSystemActionRights", typeof(SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection));
			_alwaysFetchRoleSystemActionRights = info.GetBoolean("_alwaysFetchRoleSystemActionRights");
			_alreadyFetchedRoleSystemActionRights = info.GetBoolean("_alreadyFetchedRoleSystemActionRights");
			_systemRightAssignedToRoles = (SD.HnD.DAL.CollectionClasses.RoleCollection)info.GetValue("_systemRightAssignedToRoles", typeof(SD.HnD.DAL.CollectionClasses.RoleCollection));
			_alwaysFetchSystemRightAssignedToRoles = info.GetBoolean("_alwaysFetchSystemRightAssignedToRoles");
			_alreadyFetchedSystemRightAssignedToRoles = info.GetBoolean("_alreadyFetchedSystemRightAssignedToRoles");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedForumRoleForumActionRights = (_forumRoleForumActionRights.Count > 0);
			_alreadyFetchedRoleSystemActionRights = (_roleSystemActionRights.Count > 0);
			_alreadyFetchedSystemRightAssignedToRoles = (_systemRightAssignedToRoles.Count > 0);
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
				case "ForumRoleForumActionRights":
					toReturn.Add(Relations.ForumRoleForumActionRightEntityUsingActionRightID);
					break;
				case "RoleSystemActionRights":
					toReturn.Add(Relations.RoleSystemActionRightEntityUsingActionRightID);
					break;
				case "SystemRightAssignedToRoles":
					toReturn.Add(Relations.RoleSystemActionRightEntityUsingActionRightID, "ActionRightEntity__", "RoleSystemActionRight_", JoinHint.None);
					toReturn.Add(RoleSystemActionRightEntity.Relations.RoleEntityUsingRoleID, "RoleSystemActionRight_", string.Empty, JoinHint.None);
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
			info.AddValue("_roleSystemActionRights", (!this.MarkedForDeletion?_roleSystemActionRights:null));
			info.AddValue("_alwaysFetchRoleSystemActionRights", _alwaysFetchRoleSystemActionRights);
			info.AddValue("_alreadyFetchedRoleSystemActionRights", _alreadyFetchedRoleSystemActionRights);
			info.AddValue("_systemRightAssignedToRoles", (!this.MarkedForDeletion?_systemRightAssignedToRoles:null));
			info.AddValue("_alwaysFetchSystemRightAssignedToRoles", _alwaysFetchSystemRightAssignedToRoles);
			info.AddValue("_alreadyFetchedSystemRightAssignedToRoles", _alreadyFetchedSystemRightAssignedToRoles);

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
				case "ForumRoleForumActionRights":
					_alreadyFetchedForumRoleForumActionRights = true;
					if(entity!=null)
					{
						this.ForumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)entity);
					}
					break;
				case "RoleSystemActionRights":
					_alreadyFetchedRoleSystemActionRights = true;
					if(entity!=null)
					{
						this.RoleSystemActionRights.Add((RoleSystemActionRightEntity)entity);
					}
					break;
				case "SystemRightAssignedToRoles":
					_alreadyFetchedSystemRightAssignedToRoles = true;
					if(entity!=null)
					{
						this.SystemRightAssignedToRoles.Add((RoleEntity)entity);
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
				case "ForumRoleForumActionRights":
					_forumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)relatedEntity);
					break;
				case "RoleSystemActionRights":
					_roleSystemActionRights.Add((RoleSystemActionRightEntity)relatedEntity);
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
				case "ForumRoleForumActionRights":
					this.PerformRelatedEntityRemoval(_forumRoleForumActionRights, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleSystemActionRights":
					this.PerformRelatedEntityRemoval(_roleSystemActionRights, relatedEntity, signalRelatedEntityManyToOne);
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
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_forumRoleForumActionRights);
			toReturn.Add(_roleSystemActionRights);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 actionRightID)
		{
			return FetchUsingPK(actionRightID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 actionRightID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(actionRightID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 actionRightID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(actionRightID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 actionRightID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(actionRightID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.ActionRightID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ActionRightRelations().GetAllRelations();
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
				_forumRoleForumActionRights.GetMultiManyToOne(this, null, null, filter);
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

		/// <summary> Retrieves all related entities of type 'RoleSystemActionRightEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'RoleSystemActionRightEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection GetMultiRoleSystemActionRights(bool forceFetch)
		{
			return GetMultiRoleSystemActionRights(forceFetch, _roleSystemActionRights.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleSystemActionRightEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'RoleSystemActionRightEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection GetMultiRoleSystemActionRights(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiRoleSystemActionRights(forceFetch, _roleSystemActionRights.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'RoleSystemActionRightEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection GetMultiRoleSystemActionRights(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiRoleSystemActionRights(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleSystemActionRightEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection GetMultiRoleSystemActionRights(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedRoleSystemActionRights || forceFetch || _alwaysFetchRoleSystemActionRights) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_roleSystemActionRights);
				_roleSystemActionRights.SuppressClearInGetMulti=!forceFetch;
				_roleSystemActionRights.EntityFactoryToUse = entityFactoryToUse;
				_roleSystemActionRights.GetMultiManyToOne(this, null, filter);
				_roleSystemActionRights.SuppressClearInGetMulti=false;
				_alreadyFetchedRoleSystemActionRights = true;
			}
			return _roleSystemActionRights;
		}

		/// <summary> Sets the collection parameters for the collection for 'RoleSystemActionRights'. These settings will be taken into account
		/// when the property RoleSystemActionRights is requested or GetMultiRoleSystemActionRights is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersRoleSystemActionRights(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_roleSystemActionRights.SortClauses=sortClauses;
			_roleSystemActionRights.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'RoleEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleCollection GetMultiSystemRightAssignedToRoles(bool forceFetch)
		{
			return GetMultiSystemRightAssignedToRoles(forceFetch, _systemRightAssignedToRoles.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.RoleCollection GetMultiSystemRightAssignedToRoles(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedSystemRightAssignedToRoles || forceFetch || _alwaysFetchSystemRightAssignedToRoles) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_systemRightAssignedToRoles);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(ActionRightFields.ActionRightID, ComparisonOperator.Equal, this.ActionRightID, "ActionRightEntity__"));
				_systemRightAssignedToRoles.SuppressClearInGetMulti=!forceFetch;
				_systemRightAssignedToRoles.EntityFactoryToUse = entityFactoryToUse;
				_systemRightAssignedToRoles.GetMulti(filter, GetRelationsForField("SystemRightAssignedToRoles"));
				_systemRightAssignedToRoles.SuppressClearInGetMulti=false;
				_alreadyFetchedSystemRightAssignedToRoles = true;
			}
			return _systemRightAssignedToRoles;
		}

		/// <summary> Sets the collection parameters for the collection for 'SystemRightAssignedToRoles'. These settings will be taken into account
		/// when the property SystemRightAssignedToRoles is requested or GetMultiSystemRightAssignedToRoles is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSystemRightAssignedToRoles(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_systemRightAssignedToRoles.SortClauses=sortClauses;
			_systemRightAssignedToRoles.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ForumRoleForumActionRights", _forumRoleForumActionRights);
			toReturn.Add("RoleSystemActionRights", _roleSystemActionRights);
			toReturn.Add("SystemRightAssignedToRoles", _systemRightAssignedToRoles);
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
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <param name="validator">The validator object for this ActionRightEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 actionRightID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(actionRightID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_forumRoleForumActionRights = new SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection();
			_forumRoleForumActionRights.SetContainingEntityInfo(this, "ActionRight");

			_roleSystemActionRights = new SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection();
			_roleSystemActionRights.SetContainingEntityInfo(this, "ActionRight");
			_systemRightAssignedToRoles = new SD.HnD.DAL.CollectionClasses.RoleCollection();
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
			_fieldsCustomProperties.Add("ActionRightID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ActionRightDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AppliesToForum", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AppliesToSystem", fieldHashtable);
		}
		#endregion

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="actionRightID">PK value for ActionRight which data should be fetched into this ActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 actionRightID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)ActionRightFieldIndex.ActionRightID].ForcedCurrentValueWrite(actionRightID);
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
			return DAOFactory.CreateActionRightDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ActionRightEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ActionRightRelations Relations
		{
			get	{ return new ActionRightRelations(); }
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
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection(), (IEntityRelation)GetRelationsForField("ForumRoleForumActionRights")[0], (int)SD.HnD.DAL.EntityType.ActionRightEntity, (int)SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity, 0, null, null, null, "ForumRoleForumActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'RoleSystemActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoleSystemActionRights
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection(), (IEntityRelation)GetRelationsForField("RoleSystemActionRights")[0], (int)SD.HnD.DAL.EntityType.ActionRightEntity, (int)SD.HnD.DAL.EntityType.RoleSystemActionRightEntity, 0, null, null, null, "RoleSystemActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Role'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSystemRightAssignedToRoles
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleSystemActionRightEntityUsingActionRightID;
				intermediateRelation.SetAliases(string.Empty, "RoleSystemActionRight_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.ActionRightEntity, (int)SD.HnD.DAL.EntityType.RoleEntity, 0, null, null, GetRelationsForField("SystemRightAssignedToRoles"), "SystemRightAssignedToRoles", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
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

		/// <summary> The ActionRightID property of the Entity ActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActionRight"."ActionRightID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ActionRightID
		{
			get { return (System.Int32)GetValue((int)ActionRightFieldIndex.ActionRightID, true); }
			set	{ SetValue((int)ActionRightFieldIndex.ActionRightID, value, true); }
		}

		/// <summary> The ActionRightDescription property of the Entity ActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActionRight"."ActionRightDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ActionRightDescription
		{
			get { return (System.String)GetValue((int)ActionRightFieldIndex.ActionRightDescription, true); }
			set	{ SetValue((int)ActionRightFieldIndex.ActionRightDescription, value, true); }
		}

		/// <summary> The AppliesToForum property of the Entity ActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActionRight"."AppliesToForum"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AppliesToForum
		{
			get { return (System.Boolean)GetValue((int)ActionRightFieldIndex.AppliesToForum, true); }
			set	{ SetValue((int)ActionRightFieldIndex.AppliesToForum, value, true); }
		}

		/// <summary> The AppliesToSystem property of the Entity ActionRight<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActionRight"."AppliesToSystem"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AppliesToSystem
		{
			get { return (System.Boolean)GetValue((int)ActionRightFieldIndex.AppliesToSystem, true); }
			set	{ SetValue((int)ActionRightFieldIndex.AppliesToSystem, value, true); }
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
		/// <summary> Retrieves all related entities of type 'RoleSystemActionRightEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiRoleSystemActionRights()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection RoleSystemActionRights
		{
			get	{ return GetMultiRoleSystemActionRights(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for RoleSystemActionRights. When set to true, RoleSystemActionRights is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time RoleSystemActionRights is accessed. You can always execute/ a forced fetch by calling GetMultiRoleSystemActionRights(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoleSystemActionRights
		{
			get	{ return _alwaysFetchRoleSystemActionRights; }
			set	{ _alwaysFetchRoleSystemActionRights = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property RoleSystemActionRights already has been fetched. Setting this property to false when RoleSystemActionRights has been fetched
		/// will clear the RoleSystemActionRights collection well. Setting this property to true while RoleSystemActionRights hasn't been fetched disables lazy loading for RoleSystemActionRights</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoleSystemActionRights
		{
			get { return _alreadyFetchedRoleSystemActionRights;}
			set 
			{
				if(_alreadyFetchedRoleSystemActionRights && !value && (_roleSystemActionRights != null))
				{
					_roleSystemActionRights.Clear();
				}
				_alreadyFetchedRoleSystemActionRights = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSystemRightAssignedToRoles()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.RoleCollection SystemRightAssignedToRoles
		{
			get { return GetMultiSystemRightAssignedToRoles(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SystemRightAssignedToRoles. When set to true, SystemRightAssignedToRoles is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SystemRightAssignedToRoles is accessed. You can always execute a forced fetch by calling GetMultiSystemRightAssignedToRoles(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSystemRightAssignedToRoles
		{
			get	{ return _alwaysFetchSystemRightAssignedToRoles; }
			set	{ _alwaysFetchSystemRightAssignedToRoles = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property SystemRightAssignedToRoles already has been fetched. Setting this property to false when SystemRightAssignedToRoles has been fetched
		/// will clear the SystemRightAssignedToRoles collection well. Setting this property to true while SystemRightAssignedToRoles hasn't been fetched disables lazy loading for SystemRightAssignedToRoles</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSystemRightAssignedToRoles
		{
			get { return _alreadyFetchedSystemRightAssignedToRoles;}
			set 
			{
				if(_alreadyFetchedSystemRightAssignedToRoles && !value && (_systemRightAssignedToRoles != null))
				{
					_systemRightAssignedToRoles.Clear();
				}
				_alreadyFetchedSystemRightAssignedToRoles = value;
			}
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
			get { return (int)SD.HnD.DAL.EntityType.ActionRightEntity; }
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
