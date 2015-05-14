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

	/// <summary>Entity class which represents the entity 'AuditAction'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AuditActionEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection	_auditDataCore;
		private bool	_alwaysFetchAuditDataCore, _alreadyFetchedAuditDataCore;
		private SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection	_roleAuditActions;
		private bool	_alwaysFetchRoleAuditActions, _alreadyFetchedRoleAuditActions;
		private SD.HnD.DAL.CollectionClasses.RoleCollection _rolesWithAuditAction;
		private bool	_alwaysFetchRolesWithAuditAction, _alreadyFetchedRolesWithAuditAction;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AuditDataCore</summary>
			public static readonly string AuditDataCore = "AuditDataCore";
			/// <summary>Member name RoleAuditActions</summary>
			public static readonly string RoleAuditActions = "RoleAuditActions";
			/// <summary>Member name RolesWithAuditAction</summary>
			public static readonly string RolesWithAuditAction = "RolesWithAuditAction";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AuditActionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public AuditActionEntity() :base("AuditActionEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		public AuditActionEntity(System.Int32 auditActionID):base("AuditActionEntity")
		{
			InitClassFetch(auditActionID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public AuditActionEntity(System.Int32 auditActionID, IPrefetchPath prefetchPathToUse):base("AuditActionEntity")
		{
			InitClassFetch(auditActionID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		/// <param name="validator">The custom validator object for this AuditActionEntity</param>
		public AuditActionEntity(System.Int32 auditActionID, IValidator validator):base("AuditActionEntity")
		{
			InitClassFetch(auditActionID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AuditActionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_auditDataCore = (SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection)info.GetValue("_auditDataCore", typeof(SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection));
			_alwaysFetchAuditDataCore = info.GetBoolean("_alwaysFetchAuditDataCore");
			_alreadyFetchedAuditDataCore = info.GetBoolean("_alreadyFetchedAuditDataCore");

			_roleAuditActions = (SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection)info.GetValue("_roleAuditActions", typeof(SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection));
			_alwaysFetchRoleAuditActions = info.GetBoolean("_alwaysFetchRoleAuditActions");
			_alreadyFetchedRoleAuditActions = info.GetBoolean("_alreadyFetchedRoleAuditActions");
			_rolesWithAuditAction = (SD.HnD.DAL.CollectionClasses.RoleCollection)info.GetValue("_rolesWithAuditAction", typeof(SD.HnD.DAL.CollectionClasses.RoleCollection));
			_alwaysFetchRolesWithAuditAction = info.GetBoolean("_alwaysFetchRolesWithAuditAction");
			_alreadyFetchedRolesWithAuditAction = info.GetBoolean("_alreadyFetchedRolesWithAuditAction");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedAuditDataCore = (_auditDataCore.Count > 0);
			_alreadyFetchedRoleAuditActions = (_roleAuditActions.Count > 0);
			_alreadyFetchedRolesWithAuditAction = (_rolesWithAuditAction.Count > 0);
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
				case "AuditDataCore":
					toReturn.Add(Relations.AuditDataCoreEntityUsingAuditActionID);
					break;
				case "RoleAuditActions":
					toReturn.Add(Relations.RoleAuditActionEntityUsingAuditActionID);
					break;
				case "RolesWithAuditAction":
					toReturn.Add(Relations.RoleAuditActionEntityUsingAuditActionID, "AuditActionEntity__", "RoleAuditAction_", JoinHint.None);
					toReturn.Add(RoleAuditActionEntity.Relations.RoleEntityUsingRoleID, "RoleAuditAction_", string.Empty, JoinHint.None);
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
			info.AddValue("_auditDataCore", (!this.MarkedForDeletion?_auditDataCore:null));
			info.AddValue("_alwaysFetchAuditDataCore", _alwaysFetchAuditDataCore);
			info.AddValue("_alreadyFetchedAuditDataCore", _alreadyFetchedAuditDataCore);
			info.AddValue("_roleAuditActions", (!this.MarkedForDeletion?_roleAuditActions:null));
			info.AddValue("_alwaysFetchRoleAuditActions", _alwaysFetchRoleAuditActions);
			info.AddValue("_alreadyFetchedRoleAuditActions", _alreadyFetchedRoleAuditActions);
			info.AddValue("_rolesWithAuditAction", (!this.MarkedForDeletion?_rolesWithAuditAction:null));
			info.AddValue("_alwaysFetchRolesWithAuditAction", _alwaysFetchRolesWithAuditAction);
			info.AddValue("_alreadyFetchedRolesWithAuditAction", _alreadyFetchedRolesWithAuditAction);

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
				case "AuditDataCore":
					_alreadyFetchedAuditDataCore = true;
					if(entity!=null)
					{
						this.AuditDataCore.Add((AuditDataCoreEntity)entity);
					}
					break;
				case "RoleAuditActions":
					_alreadyFetchedRoleAuditActions = true;
					if(entity!=null)
					{
						this.RoleAuditActions.Add((RoleAuditActionEntity)entity);
					}
					break;
				case "RolesWithAuditAction":
					_alreadyFetchedRolesWithAuditAction = true;
					if(entity!=null)
					{
						this.RolesWithAuditAction.Add((RoleEntity)entity);
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
				case "AuditDataCore":
					_auditDataCore.Add((AuditDataCoreEntity)relatedEntity);
					break;
				case "RoleAuditActions":
					_roleAuditActions.Add((RoleAuditActionEntity)relatedEntity);
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
				case "AuditDataCore":
					this.PerformRelatedEntityRemoval(_auditDataCore, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleAuditActions":
					this.PerformRelatedEntityRemoval(_roleAuditActions, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(_auditDataCore);
			toReturn.Add(_roleAuditActions);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditActionID)
		{
			return FetchUsingPK(auditActionID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditActionID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(auditActionID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditActionID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(auditActionID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditActionID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(auditActionID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.AuditActionID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new AuditActionRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'AuditDataCoreEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection GetMultiAuditDataCore(bool forceFetch)
		{
			return GetMultiAuditDataCore(forceFetch, _auditDataCore.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'AuditDataCoreEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection GetMultiAuditDataCore(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiAuditDataCore(forceFetch, _auditDataCore.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection GetMultiAuditDataCore(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiAuditDataCore(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection GetMultiAuditDataCore(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedAuditDataCore || forceFetch || _alwaysFetchAuditDataCore) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_auditDataCore);
				_auditDataCore.SuppressClearInGetMulti=!forceFetch;
				_auditDataCore.EntityFactoryToUse = entityFactoryToUse;
				_auditDataCore.GetMultiManyToOne(this, null, filter);
				_auditDataCore.SuppressClearInGetMulti=false;
				_alreadyFetchedAuditDataCore = true;
			}
			return _auditDataCore;
		}

		/// <summary> Sets the collection parameters for the collection for 'AuditDataCore'. These settings will be taken into account
		/// when the property AuditDataCore is requested or GetMultiAuditDataCore is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersAuditDataCore(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_auditDataCore.SortClauses=sortClauses;
			_auditDataCore.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'RoleAuditActionEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection GetMultiRoleAuditActions(bool forceFetch)
		{
			return GetMultiRoleAuditActions(forceFetch, _roleAuditActions.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'RoleAuditActionEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection GetMultiRoleAuditActions(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiRoleAuditActions(forceFetch, _roleAuditActions.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection GetMultiRoleAuditActions(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiRoleAuditActions(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection GetMultiRoleAuditActions(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedRoleAuditActions || forceFetch || _alwaysFetchRoleAuditActions) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_roleAuditActions);
				_roleAuditActions.SuppressClearInGetMulti=!forceFetch;
				_roleAuditActions.EntityFactoryToUse = entityFactoryToUse;
				_roleAuditActions.GetMultiManyToOne(this, null, filter);
				_roleAuditActions.SuppressClearInGetMulti=false;
				_alreadyFetchedRoleAuditActions = true;
			}
			return _roleAuditActions;
		}

		/// <summary> Sets the collection parameters for the collection for 'RoleAuditActions'. These settings will be taken into account
		/// when the property RoleAuditActions is requested or GetMultiRoleAuditActions is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersRoleAuditActions(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_roleAuditActions.SortClauses=sortClauses;
			_roleAuditActions.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'RoleEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleCollection GetMultiRolesWithAuditAction(bool forceFetch)
		{
			return GetMultiRolesWithAuditAction(forceFetch, _rolesWithAuditAction.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.RoleCollection GetMultiRolesWithAuditAction(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedRolesWithAuditAction || forceFetch || _alwaysFetchRolesWithAuditAction) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_rolesWithAuditAction);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(AuditActionFields.AuditActionID, ComparisonOperator.Equal, this.AuditActionID, "AuditActionEntity__"));
				_rolesWithAuditAction.SuppressClearInGetMulti=!forceFetch;
				_rolesWithAuditAction.EntityFactoryToUse = entityFactoryToUse;
				_rolesWithAuditAction.GetMulti(filter, GetRelationsForField("RolesWithAuditAction"));
				_rolesWithAuditAction.SuppressClearInGetMulti=false;
				_alreadyFetchedRolesWithAuditAction = true;
			}
			return _rolesWithAuditAction;
		}

		/// <summary> Sets the collection parameters for the collection for 'RolesWithAuditAction'. These settings will be taken into account
		/// when the property RolesWithAuditAction is requested or GetMultiRolesWithAuditAction is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersRolesWithAuditAction(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_rolesWithAuditAction.SortClauses=sortClauses;
			_rolesWithAuditAction.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AuditDataCore", _auditDataCore);
			toReturn.Add("RoleAuditActions", _roleAuditActions);
			toReturn.Add("RolesWithAuditAction", _rolesWithAuditAction);
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
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		/// <param name="validator">The validator object for this AuditActionEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 auditActionID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(auditActionID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_auditDataCore = new SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection();
			_auditDataCore.SetContainingEntityInfo(this, "AuditAction");

			_roleAuditActions = new SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection();
			_roleAuditActions.SetContainingEntityInfo(this, "AuditAction");
			_rolesWithAuditAction = new SD.HnD.DAL.CollectionClasses.RoleCollection();
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
			_fieldsCustomProperties.Add("AuditActionID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AuditActionDescription", fieldHashtable);
		}
		#endregion

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="auditActionID">PK value for AuditAction which data should be fetched into this AuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 auditActionID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)AuditActionFieldIndex.AuditActionID].ForcedCurrentValueWrite(auditActionID);
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
			return DAOFactory.CreateAuditActionDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new AuditActionEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AuditActionRelations Relations
		{
			get	{ return new AuditActionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'AuditDataCore' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAuditDataCore
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection(), (IEntityRelation)GetRelationsForField("AuditDataCore")[0], (int)SD.HnD.DAL.EntityType.AuditActionEntity, (int)SD.HnD.DAL.EntityType.AuditDataCoreEntity, 0, null, null, null, "AuditDataCore", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'RoleAuditAction' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoleAuditActions
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection(), (IEntityRelation)GetRelationsForField("RoleAuditActions")[0], (int)SD.HnD.DAL.EntityType.AuditActionEntity, (int)SD.HnD.DAL.EntityType.RoleAuditActionEntity, 0, null, null, null, "RoleAuditActions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Role'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRolesWithAuditAction
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleAuditActionEntityUsingAuditActionID;
				intermediateRelation.SetAliases(string.Empty, "RoleAuditAction_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.AuditActionEntity, (int)SD.HnD.DAL.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RolesWithAuditAction"), "RolesWithAuditAction", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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

		/// <summary> The AuditActionID property of the Entity AuditAction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AuditAction"."AuditActionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 AuditActionID
		{
			get { return (System.Int32)GetValue((int)AuditActionFieldIndex.AuditActionID, true); }
			set	{ SetValue((int)AuditActionFieldIndex.AuditActionID, value, true); }
		}

		/// <summary> The AuditActionDescription property of the Entity AuditAction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AuditAction"."AuditActionDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String AuditActionDescription
		{
			get { return (System.String)GetValue((int)AuditActionFieldIndex.AuditActionDescription, true); }
			set	{ SetValue((int)AuditActionFieldIndex.AuditActionDescription, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'AuditDataCoreEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiAuditDataCore()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.AuditDataCoreCollection AuditDataCore
		{
			get	{ return GetMultiAuditDataCore(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for AuditDataCore. When set to true, AuditDataCore is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time AuditDataCore is accessed. You can always execute/ a forced fetch by calling GetMultiAuditDataCore(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAuditDataCore
		{
			get	{ return _alwaysFetchAuditDataCore; }
			set	{ _alwaysFetchAuditDataCore = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property AuditDataCore already has been fetched. Setting this property to false when AuditDataCore has been fetched
		/// will clear the AuditDataCore collection well. Setting this property to true while AuditDataCore hasn't been fetched disables lazy loading for AuditDataCore</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAuditDataCore
		{
			get { return _alreadyFetchedAuditDataCore;}
			set 
			{
				if(_alreadyFetchedAuditDataCore && !value && (_auditDataCore != null))
				{
					_auditDataCore.Clear();
				}
				_alreadyFetchedAuditDataCore = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiRoleAuditActions()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection RoleAuditActions
		{
			get	{ return GetMultiRoleAuditActions(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for RoleAuditActions. When set to true, RoleAuditActions is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time RoleAuditActions is accessed. You can always execute/ a forced fetch by calling GetMultiRoleAuditActions(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoleAuditActions
		{
			get	{ return _alwaysFetchRoleAuditActions; }
			set	{ _alwaysFetchRoleAuditActions = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property RoleAuditActions already has been fetched. Setting this property to false when RoleAuditActions has been fetched
		/// will clear the RoleAuditActions collection well. Setting this property to true while RoleAuditActions hasn't been fetched disables lazy loading for RoleAuditActions</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoleAuditActions
		{
			get { return _alreadyFetchedRoleAuditActions;}
			set 
			{
				if(_alreadyFetchedRoleAuditActions && !value && (_roleAuditActions != null))
				{
					_roleAuditActions.Clear();
				}
				_alreadyFetchedRoleAuditActions = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'RoleEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiRolesWithAuditAction()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.RoleCollection RolesWithAuditAction
		{
			get { return GetMultiRolesWithAuditAction(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for RolesWithAuditAction. When set to true, RolesWithAuditAction is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time RolesWithAuditAction is accessed. You can always execute a forced fetch by calling GetMultiRolesWithAuditAction(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRolesWithAuditAction
		{
			get	{ return _alwaysFetchRolesWithAuditAction; }
			set	{ _alwaysFetchRolesWithAuditAction = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property RolesWithAuditAction already has been fetched. Setting this property to false when RolesWithAuditAction has been fetched
		/// will clear the RolesWithAuditAction collection well. Setting this property to true while RolesWithAuditAction hasn't been fetched disables lazy loading for RolesWithAuditAction</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRolesWithAuditAction
		{
			get { return _alreadyFetchedRolesWithAuditAction;}
			set 
			{
				if(_alreadyFetchedRolesWithAuditAction && !value && (_rolesWithAuditAction != null))
				{
					_rolesWithAuditAction.Clear();
				}
				_alreadyFetchedRolesWithAuditAction = value;
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
			get { return (int)SD.HnD.DAL.EntityType.AuditActionEntity; }
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
