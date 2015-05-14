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

	/// <summary>Entity class which represents the entity 'RoleAuditAction'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class RoleAuditActionEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private AuditActionEntity _auditAction;
		private bool	_alwaysFetchAuditAction, _alreadyFetchedAuditAction, _auditActionReturnsNewIfNotFound;
		private RoleEntity _role;
		private bool	_alwaysFetchRole, _alreadyFetchedRole, _roleReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name AuditAction</summary>
			public static readonly string AuditAction = "AuditAction";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static RoleAuditActionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public RoleAuditActionEntity() :base("RoleAuditActionEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		public RoleAuditActionEntity(System.Int32 auditActionID, System.Int32 roleID):base("RoleAuditActionEntity")
		{
			InitClassFetch(auditActionID, roleID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public RoleAuditActionEntity(System.Int32 auditActionID, System.Int32 roleID, IPrefetchPath prefetchPathToUse):base("RoleAuditActionEntity")
		{
			InitClassFetch(auditActionID, roleID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="validator">The custom validator object for this RoleAuditActionEntity</param>
		public RoleAuditActionEntity(System.Int32 auditActionID, System.Int32 roleID, IValidator validator):base("RoleAuditActionEntity")
		{
			InitClassFetch(auditActionID, roleID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected RoleAuditActionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_auditAction = (AuditActionEntity)info.GetValue("_auditAction", typeof(AuditActionEntity));
			if(_auditAction!=null)
			{
				_auditAction.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_auditActionReturnsNewIfNotFound = info.GetBoolean("_auditActionReturnsNewIfNotFound");
			_alwaysFetchAuditAction = info.GetBoolean("_alwaysFetchAuditAction");
			_alreadyFetchedAuditAction = info.GetBoolean("_alreadyFetchedAuditAction");

			_role = (RoleEntity)info.GetValue("_role", typeof(RoleEntity));
			if(_role!=null)
			{
				_role.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_roleReturnsNewIfNotFound = info.GetBoolean("_roleReturnsNewIfNotFound");
			_alwaysFetchRole = info.GetBoolean("_alwaysFetchRole");
			_alreadyFetchedRole = info.GetBoolean("_alreadyFetchedRole");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((RoleAuditActionFieldIndex)fieldIndex)
			{
				case RoleAuditActionFieldIndex.AuditActionID:
					DesetupSyncAuditAction(true, false);
					_alreadyFetchedAuditAction = false;
					break;
				case RoleAuditActionFieldIndex.RoleID:
					DesetupSyncRole(true, false);
					_alreadyFetchedRole = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedAuditAction = (_auditAction != null);
			_alreadyFetchedRole = (_role != null);
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
				case "AuditAction":
					toReturn.Add(Relations.AuditActionEntityUsingAuditActionID);
					break;
				case "Role":
					toReturn.Add(Relations.RoleEntityUsingRoleID);
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
			info.AddValue("_auditAction", (!this.MarkedForDeletion?_auditAction:null));
			info.AddValue("_auditActionReturnsNewIfNotFound", _auditActionReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchAuditAction", _alwaysFetchAuditAction);
			info.AddValue("_alreadyFetchedAuditAction", _alreadyFetchedAuditAction);
			info.AddValue("_role", (!this.MarkedForDeletion?_role:null));
			info.AddValue("_roleReturnsNewIfNotFound", _roleReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchRole", _alwaysFetchRole);
			info.AddValue("_alreadyFetchedRole", _alreadyFetchedRole);

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
				case "AuditAction":
					_alreadyFetchedAuditAction = true;
					this.AuditAction = (AuditActionEntity)entity;
					break;
				case "Role":
					_alreadyFetchedRole = true;
					this.Role = (RoleEntity)entity;
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
				case "AuditAction":
					SetupSyncAuditAction(relatedEntity);
					break;
				case "Role":
					SetupSyncRole(relatedEntity);
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
				case "AuditAction":
					DesetupSyncAuditAction(false, true);
					break;
				case "Role":
					DesetupSyncRole(false, true);
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
			if(_auditAction!=null)
			{
				toReturn.Add(_auditAction);
			}
			if(_role!=null)
			{
				toReturn.Add(_role);
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
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditActionID, System.Int32 roleID)
		{
			return FetchUsingPK(auditActionID, roleID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditActionID, System.Int32 roleID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(auditActionID, roleID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditActionID, System.Int32 roleID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(auditActionID, roleID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 auditActionID, System.Int32 roleID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(auditActionID, roleID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.AuditActionID, this.RoleID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new RoleAuditActionRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'AuditActionEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'AuditActionEntity' which is related to this entity.</returns>
		public AuditActionEntity GetSingleAuditAction()
		{
			return GetSingleAuditAction(false);
		}

		/// <summary> Retrieves the related entity of type 'AuditActionEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'AuditActionEntity' which is related to this entity.</returns>
		public virtual AuditActionEntity GetSingleAuditAction(bool forceFetch)
		{
			if( ( !_alreadyFetchedAuditAction || forceFetch || _alwaysFetchAuditAction) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.AuditActionEntityUsingAuditActionID);
				AuditActionEntity newEntity = new AuditActionEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.AuditActionID);
				}
				if(fetchResult)
				{
					newEntity = (AuditActionEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_auditActionReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.AuditAction = newEntity;
				_alreadyFetchedAuditAction = fetchResult;
			}
			return _auditAction;
		}


		/// <summary> Retrieves the related entity of type 'RoleEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'RoleEntity' which is related to this entity.</returns>
		public RoleEntity GetSingleRole()
		{
			return GetSingleRole(false);
		}

		/// <summary> Retrieves the related entity of type 'RoleEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'RoleEntity' which is related to this entity.</returns>
		public virtual RoleEntity GetSingleRole(bool forceFetch)
		{
			if( ( !_alreadyFetchedRole || forceFetch || _alwaysFetchRole) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.RoleEntityUsingRoleID);
				RoleEntity newEntity = new RoleEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.RoleID);
				}
				if(fetchResult)
				{
					newEntity = (RoleEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_roleReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Role = newEntity;
				_alreadyFetchedRole = fetchResult;
			}
			return _role;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("AuditAction", _auditAction);
			toReturn.Add("Role", _role);
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
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="validator">The validator object for this RoleAuditActionEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 auditActionID, System.Int32 roleID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(auditActionID, roleID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END
			

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_auditActionReturnsNewIfNotFound = true;
			_roleReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("RoleID", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _auditAction</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAuditAction(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _auditAction, new PropertyChangedEventHandler( OnAuditActionPropertyChanged ), "AuditAction", SD.HnD.DAL.RelationClasses.StaticRoleAuditActionRelations.AuditActionEntityUsingAuditActionIDStatic, true, signalRelatedEntity, "RoleAuditActions", resetFKFields, new int[] { (int)RoleAuditActionFieldIndex.AuditActionID } );		
			_auditAction = null;
		}
		
		/// <summary> setups the sync logic for member _auditAction</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAuditAction(IEntityCore relatedEntity)
		{
			if(_auditAction!=relatedEntity)
			{		
				DesetupSyncAuditAction(true, true);
				_auditAction = (AuditActionEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _auditAction, new PropertyChangedEventHandler( OnAuditActionPropertyChanged ), "AuditAction", SD.HnD.DAL.RelationClasses.StaticRoleAuditActionRelations.AuditActionEntityUsingAuditActionIDStatic, true, ref _alreadyFetchedAuditAction, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAuditActionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _role</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRole(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", SD.HnD.DAL.RelationClasses.StaticRoleAuditActionRelations.RoleEntityUsingRoleIDStatic, true, signalRelatedEntity, "RoleAuditAction", resetFKFields, new int[] { (int)RoleAuditActionFieldIndex.RoleID } );		
			_role = null;
		}
		
		/// <summary> setups the sync logic for member _role</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRole(IEntityCore relatedEntity)
		{
			if(_role!=relatedEntity)
			{		
				DesetupSyncRole(true, true);
				_role = (RoleEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", SD.HnD.DAL.RelationClasses.StaticRoleAuditActionRelations.RoleEntityUsingRoleIDStatic, true, ref _alreadyFetchedRole, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRolePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="auditActionID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="roleID">PK value for RoleAuditAction which data should be fetched into this RoleAuditAction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 auditActionID, System.Int32 roleID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)RoleAuditActionFieldIndex.AuditActionID].ForcedCurrentValueWrite(auditActionID);
				this.Fields[(int)RoleAuditActionFieldIndex.RoleID].ForcedCurrentValueWrite(roleID);
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
			return DAOFactory.CreateRoleAuditActionDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new RoleAuditActionEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static RoleAuditActionRelations Relations
		{
			get	{ return new RoleAuditActionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'AuditAction'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAuditAction
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.AuditActionCollection(), (IEntityRelation)GetRelationsForField("AuditAction")[0], (int)SD.HnD.DAL.EntityType.RoleAuditActionEntity, (int)SD.HnD.DAL.EntityType.AuditActionEntity, 0, null, null, null, "AuditAction", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Role'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRole
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleCollection(), (IEntityRelation)GetRelationsForField("Role")[0], (int)SD.HnD.DAL.EntityType.RoleAuditActionEntity, (int)SD.HnD.DAL.EntityType.RoleEntity, 0, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The AuditActionID property of the Entity RoleAuditAction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "RoleAuditAction"."AuditActionID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 AuditActionID
		{
			get { return (System.Int32)GetValue((int)RoleAuditActionFieldIndex.AuditActionID, true); }
			set	{ SetValue((int)RoleAuditActionFieldIndex.AuditActionID, value, true); }
		}

		/// <summary> The RoleID property of the Entity RoleAuditAction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "RoleAuditAction"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 RoleID
		{
			get { return (System.Int32)GetValue((int)RoleAuditActionFieldIndex.RoleID, true); }
			set	{ SetValue((int)RoleAuditActionFieldIndex.RoleID, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'AuditActionEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleAuditAction()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual AuditActionEntity AuditAction
		{
			get	{ return GetSingleAuditAction(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncAuditAction(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "RoleAuditActions", "AuditAction", _auditAction, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for AuditAction. When set to true, AuditAction is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time AuditAction is accessed. You can always execute a forced fetch by calling GetSingleAuditAction(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAuditAction
		{
			get	{ return _alwaysFetchAuditAction; }
			set	{ _alwaysFetchAuditAction = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property AuditAction already has been fetched. Setting this property to false when AuditAction has been fetched
		/// will set AuditAction to null as well. Setting this property to true while AuditAction hasn't been fetched disables lazy loading for AuditAction</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAuditAction
		{
			get { return _alreadyFetchedAuditAction;}
			set 
			{
				if(_alreadyFetchedAuditAction && !value)
				{
					this.AuditAction = null;
				}
				_alreadyFetchedAuditAction = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property AuditAction is not found
		/// in the database. When set to true, AuditAction will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool AuditActionReturnsNewIfNotFound
		{
			get	{ return _auditActionReturnsNewIfNotFound; }
			set { _auditActionReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleRole()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual RoleEntity Role
		{
			get	{ return GetSingleRole(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncRole(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "RoleAuditAction", "Role", _role, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Role. When set to true, Role is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Role is accessed. You can always execute a forced fetch by calling GetSingleRole(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRole
		{
			get	{ return _alwaysFetchRole; }
			set	{ _alwaysFetchRole = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Role already has been fetched. Setting this property to false when Role has been fetched
		/// will set Role to null as well. Setting this property to true while Role hasn't been fetched disables lazy loading for Role</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRole
		{
			get { return _alreadyFetchedRole;}
			set 
			{
				if(_alreadyFetchedRole && !value)
				{
					this.Role = null;
				}
				_alreadyFetchedRole = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Role is not found
		/// in the database. When set to true, Role will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool RoleReturnsNewIfNotFound
		{
			get	{ return _roleReturnsNewIfNotFound; }
			set { _roleReturnsNewIfNotFound = value; }	
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
			get { return (int)SD.HnD.DAL.EntityType.RoleAuditActionEntity; }
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
