///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
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
	/// <summary>Entity base class which represents the base class for the entity 'SystemData'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class SystemDataEntityBase : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private RoleEntity _roleForAnonymous;
		private bool	_alwaysFetchRoleForAnonymous, _alreadyFetchedRoleForAnonymous, _roleForAnonymousReturnsNewIfNotFound;
		private RoleEntity _roleForNewUser;
		private bool	_alwaysFetchRoleForNewUser, _alreadyFetchedRoleForNewUser, _roleForNewUserReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name RoleForAnonymous</summary>
			public static readonly string RoleForAnonymous = "RoleForAnonymous";
			/// <summary>Member name RoleForNewUser</summary>
			public static readonly string RoleForNewUser = "RoleForNewUser";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SystemDataEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		protected SystemDataEntityBase() : base()
		{
			InitClassEmpty(null);
		}

		/// <summary>CTor</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		protected SystemDataEntityBase(System.Int32 iD)
		{
			InitClassFetch(iD, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected SystemDataEntityBase(System.Int32 iD, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(iD, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="validator">The custom validator object for this SystemDataEntity</param>
		protected SystemDataEntityBase(System.Int32 iD, IValidator validator)
		{
			InitClassFetch(iD, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SystemDataEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_roleForAnonymous = (RoleEntity)info.GetValue("_roleForAnonymous", typeof(RoleEntity));
			if(_roleForAnonymous!=null)
			{
				_roleForAnonymous.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_roleForAnonymousReturnsNewIfNotFound = info.GetBoolean("_roleForAnonymousReturnsNewIfNotFound");
			_alwaysFetchRoleForAnonymous = info.GetBoolean("_alwaysFetchRoleForAnonymous");
			_alreadyFetchedRoleForAnonymous = info.GetBoolean("_alreadyFetchedRoleForAnonymous");

			_roleForNewUser = (RoleEntity)info.GetValue("_roleForNewUser", typeof(RoleEntity));
			if(_roleForNewUser!=null)
			{
				_roleForNewUser.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_roleForNewUserReturnsNewIfNotFound = info.GetBoolean("_roleForNewUserReturnsNewIfNotFound");
			_alwaysFetchRoleForNewUser = info.GetBoolean("_alwaysFetchRoleForNewUser");
			_alreadyFetchedRoleForNewUser = info.GetBoolean("_alreadyFetchedRoleForNewUser");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}	
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((SystemDataFieldIndex)fieldIndex)
			{
				case SystemDataFieldIndex.AnonymousRole:
					DesetupSyncRoleForAnonymous(true, false);
					_alreadyFetchedRoleForAnonymous = false;
					break;
				case SystemDataFieldIndex.DefaultRoleNewUser:
					DesetupSyncRoleForNewUser(true, false);
					_alreadyFetchedRoleForNewUser = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{
			_alreadyFetchedRoleForAnonymous = (_roleForAnonymous != null);
			_alreadyFetchedRoleForNewUser = (_roleForNewUser != null);
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
				case "RoleForAnonymous":
					toReturn.Add(Relations.RoleEntityUsingAnonymousRole);
					break;
				case "RoleForNewUser":
					toReturn.Add(Relations.RoleEntityUsingDefaultRoleNewUser);
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
			info.AddValue("_roleForAnonymous", (!this.MarkedForDeletion?_roleForAnonymous:null));
			info.AddValue("_roleForAnonymousReturnsNewIfNotFound", _roleForAnonymousReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchRoleForAnonymous", _alwaysFetchRoleForAnonymous);
			info.AddValue("_alreadyFetchedRoleForAnonymous", _alreadyFetchedRoleForAnonymous);
			info.AddValue("_roleForNewUser", (!this.MarkedForDeletion?_roleForNewUser:null));
			info.AddValue("_roleForNewUserReturnsNewIfNotFound", _roleForNewUserReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchRoleForNewUser", _alwaysFetchRoleForNewUser);
			info.AddValue("_alreadyFetchedRoleForNewUser", _alreadyFetchedRoleForNewUser);

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
				case "RoleForAnonymous":
					_alreadyFetchedRoleForAnonymous = true;
					this.RoleForAnonymous = (RoleEntity)entity;
					break;
				case "RoleForNewUser":
					_alreadyFetchedRoleForNewUser = true;
					this.RoleForNewUser = (RoleEntity)entity;
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
				case "RoleForAnonymous":
					SetupSyncRoleForAnonymous(relatedEntity);
					break;
				case "RoleForNewUser":
					SetupSyncRoleForNewUser(relatedEntity);
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
				case "RoleForAnonymous":
					DesetupSyncRoleForAnonymous(false, true);
					break;
				case "RoleForNewUser":
					DesetupSyncRoleForNewUser(false, true);
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
			if(_roleForAnonymous!=null)
			{
				toReturn.Add(_roleForAnonymous);
			}
			if(_roleForNewUser!=null)
			{
				toReturn.Add(_roleForNewUser);
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
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 iD)
		{
			return FetchUsingPK(iD, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 iD, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(iD, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 iD, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(iD, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 iD, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(iD, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.ID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new SystemDataRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'RoleEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'RoleEntity' which is related to this entity.</returns>
		public RoleEntity GetSingleRoleForAnonymous()
		{
			return GetSingleRoleForAnonymous(false);
		}

		/// <summary> Retrieves the related entity of type 'RoleEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'RoleEntity' which is related to this entity.</returns>
		public virtual RoleEntity GetSingleRoleForAnonymous(bool forceFetch)
		{
			if( ( !_alreadyFetchedRoleForAnonymous || forceFetch || _alwaysFetchRoleForAnonymous) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.RoleEntityUsingAnonymousRole);
				RoleEntity newEntity = new RoleEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.AnonymousRole);
				}
				if(fetchResult)
				{
					newEntity = (RoleEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_roleForAnonymousReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.RoleForAnonymous = newEntity;
				_alreadyFetchedRoleForAnonymous = fetchResult;
			}
			return _roleForAnonymous;
		}


		/// <summary> Retrieves the related entity of type 'RoleEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'RoleEntity' which is related to this entity.</returns>
		public RoleEntity GetSingleRoleForNewUser()
		{
			return GetSingleRoleForNewUser(false);
		}

		/// <summary> Retrieves the related entity of type 'RoleEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'RoleEntity' which is related to this entity.</returns>
		public virtual RoleEntity GetSingleRoleForNewUser(bool forceFetch)
		{
			if( ( !_alreadyFetchedRoleForNewUser || forceFetch || _alwaysFetchRoleForNewUser) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.RoleEntityUsingDefaultRoleNewUser);
				RoleEntity newEntity = new RoleEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.DefaultRoleNewUser);
				}
				if(fetchResult)
				{
					newEntity = (RoleEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_roleForNewUserReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.RoleForNewUser = newEntity;
				_alreadyFetchedRoleForNewUser = fetchResult;
			}
			return _roleForNewUser;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("RoleForAnonymous", _roleForAnonymous);
			toReturn.Add("RoleForNewUser", _roleForNewUser);
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
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="validator">The validator object for this SystemDataEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 iD, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(iD, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_roleForAnonymousReturnsNewIfNotFound = true;
			_roleForNewUserReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("AnonymousRole", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultRoleNewUser", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DefaultUserTitleNewUser", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("HoursThresholdForActiveThreads", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MinNumberOfNonStickyVisibleThreads", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MinNumberOfThreadsToFetch", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PageSizeSearchResults", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SendReplyNotifications", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _roleForAnonymous</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRoleForAnonymous(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _roleForAnonymous, new PropertyChangedEventHandler( OnRoleForAnonymousPropertyChanged ), "RoleForAnonymous", SD.HnD.DAL.RelationClasses.StaticSystemDataRelations.RoleEntityUsingAnonymousRoleStatic, true, signalRelatedEntity, "SystemDataAnonymousRole", resetFKFields, new int[] { (int)SystemDataFieldIndex.AnonymousRole } );		
			_roleForAnonymous = null;
		}
		
		/// <summary> setups the sync logic for member _roleForAnonymous</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRoleForAnonymous(IEntity relatedEntity)
		{
			if(_roleForAnonymous!=relatedEntity)
			{		
				DesetupSyncRoleForAnonymous(true, true);
				_roleForAnonymous = (RoleEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _roleForAnonymous, new PropertyChangedEventHandler( OnRoleForAnonymousPropertyChanged ), "RoleForAnonymous", SD.HnD.DAL.RelationClasses.StaticSystemDataRelations.RoleEntityUsingAnonymousRoleStatic, true, ref _alreadyFetchedRoleForAnonymous, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRoleForAnonymousPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _roleForNewUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRoleForNewUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _roleForNewUser, new PropertyChangedEventHandler( OnRoleForNewUserPropertyChanged ), "RoleForNewUser", SD.HnD.DAL.RelationClasses.StaticSystemDataRelations.RoleEntityUsingDefaultRoleNewUserStatic, true, signalRelatedEntity, "SystemDataDefaultRoleNewUser", resetFKFields, new int[] { (int)SystemDataFieldIndex.DefaultRoleNewUser } );		
			_roleForNewUser = null;
		}
		
		/// <summary> setups the sync logic for member _roleForNewUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRoleForNewUser(IEntity relatedEntity)
		{
			if(_roleForNewUser!=relatedEntity)
			{		
				DesetupSyncRoleForNewUser(true, true);
				_roleForNewUser = (RoleEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _roleForNewUser, new PropertyChangedEventHandler( OnRoleForNewUserPropertyChanged ), "RoleForNewUser", SD.HnD.DAL.RelationClasses.StaticSystemDataRelations.RoleEntityUsingDefaultRoleNewUserStatic, true, ref _alreadyFetchedRoleForNewUser, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRoleForNewUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="iD">PK value for SystemData which data should be fetched into this SystemData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 iD, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)SystemDataFieldIndex.ID].ForcedCurrentValueWrite(iD);
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
			return DAOFactory.CreateSystemDataDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new SystemDataEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static SystemDataRelations Relations
		{
			get	{ return new SystemDataRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Role'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoleForAnonymous
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleCollection(), (IEntityRelation)GetRelationsForField("RoleForAnonymous")[0], (int)SD.HnD.DAL.EntityType.SystemDataEntity, (int)SD.HnD.DAL.EntityType.RoleEntity, 0, null, null, null, "RoleForAnonymous", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Role'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoleForNewUser
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleCollection(), (IEntityRelation)GetRelationsForField("RoleForNewUser")[0], (int)SD.HnD.DAL.EntityType.SystemDataEntity, (int)SD.HnD.DAL.EntityType.RoleEntity, 0, null, null, null, "RoleForNewUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override string LLBLGenProEntityName
		{
			get { return "SystemDataEntity";}
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

		/// <summary> The AnonymousRole property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."AnonymousRole"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 AnonymousRole
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.AnonymousRole, true); }
			set	{ SetValue((int)SystemDataFieldIndex.AnonymousRole, value, true); }
		}

		/// <summary> The DefaultRoleNewUser property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."DefaultRoleNewUser"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 DefaultRoleNewUser
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.DefaultRoleNewUser, true); }
			set	{ SetValue((int)SystemDataFieldIndex.DefaultRoleNewUser, value, true); }
		}

		/// <summary> The DefaultUserTitleNewUser property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."DefaultUserTitleNewUser"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 DefaultUserTitleNewUser
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.DefaultUserTitleNewUser, true); }
			set	{ SetValue((int)SystemDataFieldIndex.DefaultUserTitleNewUser, value, true); }
		}

		/// <summary> The HoursThresholdForActiveThreads property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."HoursThresholdForActiveThreads"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 HoursThresholdForActiveThreads
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.HoursThresholdForActiveThreads, true); }
			set	{ SetValue((int)SystemDataFieldIndex.HoursThresholdForActiveThreads, value, true); }
		}

		/// <summary> The ID property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."ID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ID
		{
			get { return (System.Int32)GetValue((int)SystemDataFieldIndex.ID, true); }
			set	{ SetValue((int)SystemDataFieldIndex.ID, value, true); }
		}

		/// <summary> The MinNumberOfNonStickyVisibleThreads property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."MinNumberOfNonStickyVisibleThreads"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 MinNumberOfNonStickyVisibleThreads
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads, true); }
			set	{ SetValue((int)SystemDataFieldIndex.MinNumberOfNonStickyVisibleThreads, value, true); }
		}

		/// <summary> The MinNumberOfThreadsToFetch property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."MinNumberOfThreadsToFetch"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 MinNumberOfThreadsToFetch
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.MinNumberOfThreadsToFetch, true); }
			set	{ SetValue((int)SystemDataFieldIndex.MinNumberOfThreadsToFetch, value, true); }
		}

		/// <summary> The PageSizeSearchResults property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."PageSizeSearchResults"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 PageSizeSearchResults
		{
			get { return (System.Int16)GetValue((int)SystemDataFieldIndex.PageSizeSearchResults, true); }
			set	{ SetValue((int)SystemDataFieldIndex.PageSizeSearchResults, value, true); }
		}

		/// <summary> The SendReplyNotifications property of the Entity SystemData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SystemData"."SendReplyNotifications"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendReplyNotifications
		{
			get { return (System.Boolean)GetValue((int)SystemDataFieldIndex.SendReplyNotifications, true); }
			set	{ SetValue((int)SystemDataFieldIndex.SendReplyNotifications, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'RoleEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleRoleForAnonymous()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual RoleEntity RoleForAnonymous
		{
			get	{ return GetSingleRoleForAnonymous(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncRoleForAnonymous(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SystemDataAnonymousRole", "RoleForAnonymous", _roleForAnonymous, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for RoleForAnonymous. When set to true, RoleForAnonymous is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time RoleForAnonymous is accessed. You can always execute a forced fetch by calling GetSingleRoleForAnonymous(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoleForAnonymous
		{
			get	{ return _alwaysFetchRoleForAnonymous; }
			set	{ _alwaysFetchRoleForAnonymous = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property RoleForAnonymous already has been fetched. Setting this property to false when RoleForAnonymous has been fetched
		/// will set RoleForAnonymous to null as well. Setting this property to true while RoleForAnonymous hasn't been fetched disables lazy loading for RoleForAnonymous</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoleForAnonymous
		{
			get { return _alreadyFetchedRoleForAnonymous;}
			set 
			{
				if(_alreadyFetchedRoleForAnonymous && !value)
				{
					this.RoleForAnonymous = null;
				}
				_alreadyFetchedRoleForAnonymous = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property RoleForAnonymous is not found
		/// in the database. When set to true, RoleForAnonymous will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool RoleForAnonymousReturnsNewIfNotFound
		{
			get	{ return _roleForAnonymousReturnsNewIfNotFound; }
			set { _roleForAnonymousReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleRoleForNewUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual RoleEntity RoleForNewUser
		{
			get	{ return GetSingleRoleForNewUser(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncRoleForNewUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SystemDataDefaultRoleNewUser", "RoleForNewUser", _roleForNewUser, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for RoleForNewUser. When set to true, RoleForNewUser is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time RoleForNewUser is accessed. You can always execute a forced fetch by calling GetSingleRoleForNewUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoleForNewUser
		{
			get	{ return _alwaysFetchRoleForNewUser; }
			set	{ _alwaysFetchRoleForNewUser = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property RoleForNewUser already has been fetched. Setting this property to false when RoleForNewUser has been fetched
		/// will set RoleForNewUser to null as well. Setting this property to true while RoleForNewUser hasn't been fetched disables lazy loading for RoleForNewUser</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoleForNewUser
		{
			get { return _alreadyFetchedRoleForNewUser;}
			set 
			{
				if(_alreadyFetchedRoleForNewUser && !value)
				{
					this.RoleForNewUser = null;
				}
				_alreadyFetchedRoleForNewUser = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property RoleForNewUser is not found
		/// in the database. When set to true, RoleForNewUser will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool RoleForNewUserReturnsNewIfNotFound
		{
			get	{ return _roleForNewUserReturnsNewIfNotFound; }
			set { _roleForNewUserReturnsNewIfNotFound = value; }	
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
			get { return (int)SD.HnD.DAL.EntityType.SystemDataEntity; }
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
