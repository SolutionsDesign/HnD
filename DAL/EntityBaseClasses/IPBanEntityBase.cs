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
	/// <summary>Entity base class which represents the base class for the entity 'IPBan'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class IPBanEntityBase : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private UserEntity _setByUser;
		private bool	_alwaysFetchSetByUser, _alreadyFetchedSetByUser, _setByUserReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name SetByUser</summary>
			public static readonly string SetByUser = "SetByUser";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static IPBanEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		protected IPBanEntityBase() : base()
		{
			InitClassEmpty(null);
		}

		/// <summary>CTor</summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		protected IPBanEntityBase(System.Int32 iPBanID)
		{
			InitClassFetch(iPBanID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected IPBanEntityBase(System.Int32 iPBanID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(iPBanID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <param name="validator">The custom validator object for this IPBanEntity</param>
		protected IPBanEntityBase(System.Int32 iPBanID, IValidator validator)
		{
			InitClassFetch(iPBanID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected IPBanEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_setByUser = (UserEntity)info.GetValue("_setByUser", typeof(UserEntity));
			if(_setByUser!=null)
			{
				_setByUser.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_setByUserReturnsNewIfNotFound = info.GetBoolean("_setByUserReturnsNewIfNotFound");
			_alwaysFetchSetByUser = info.GetBoolean("_alwaysFetchSetByUser");
			_alreadyFetchedSetByUser = info.GetBoolean("_alreadyFetchedSetByUser");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}	
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((IPBanFieldIndex)fieldIndex)
			{
				case IPBanFieldIndex.IPBanSetByUserID:
					DesetupSyncSetByUser(true, false);
					_alreadyFetchedSetByUser = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{
			_alreadyFetchedSetByUser = (_setByUser != null);
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
				case "SetByUser":
					toReturn.Add(Relations.UserEntityUsingIPBanSetByUserID);
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
			info.AddValue("_setByUser", (!this.MarkedForDeletion?_setByUser:null));
			info.AddValue("_setByUserReturnsNewIfNotFound", _setByUserReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchSetByUser", _alwaysFetchSetByUser);
			info.AddValue("_alreadyFetchedSetByUser", _alreadyFetchedSetByUser);

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
				case "SetByUser":
					_alreadyFetchedSetByUser = true;
					this.SetByUser = (UserEntity)entity;
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
				case "SetByUser":
					SetupSyncSetByUser(relatedEntity);
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
				case "SetByUser":
					DesetupSyncSetByUser(false, true);
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
			if(_setByUser!=null)
			{
				toReturn.Add(_setByUser);
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
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 iPBanID)
		{
			return FetchUsingPK(iPBanID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 iPBanID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(iPBanID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 iPBanID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(iPBanID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 iPBanID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(iPBanID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.IPBanID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new IPBanRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public UserEntity GetSingleSetByUser()
		{
			return GetSingleSetByUser(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSingleSetByUser(bool forceFetch)
		{
			if( ( !_alreadyFetchedSetByUser || forceFetch || _alwaysFetchSetByUser) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserEntityUsingIPBanSetByUserID);
				UserEntity newEntity = new UserEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.IPBanSetByUserID);
				}
				if(fetchResult)
				{
					newEntity = (UserEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_setByUserReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.SetByUser = newEntity;
				_alreadyFetchedSetByUser = fetchResult;
			}
			return _setByUser;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("SetByUser", _setByUser);
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
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <param name="validator">The validator object for this IPBanEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 iPBanID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(iPBanID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_setByUserReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("IPBanID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPBanSetByUserID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPBanSetOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPSegment1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPSegment2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPSegment3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPSegment4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Range", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Reason", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _setByUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSetByUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _setByUser, new PropertyChangedEventHandler( OnSetByUserPropertyChanged ), "SetByUser", SD.HnD.DAL.RelationClasses.StaticIPBanRelations.UserEntityUsingIPBanSetByUserIDStatic, true, signalRelatedEntity, "IPBansSet", resetFKFields, new int[] { (int)IPBanFieldIndex.IPBanSetByUserID } );		
			_setByUser = null;
		}
		
		/// <summary> setups the sync logic for member _setByUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSetByUser(IEntity relatedEntity)
		{
			if(_setByUser!=relatedEntity)
			{		
				DesetupSyncSetByUser(true, true);
				_setByUser = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _setByUser, new PropertyChangedEventHandler( OnSetByUserPropertyChanged ), "SetByUser", SD.HnD.DAL.RelationClasses.StaticIPBanRelations.UserEntityUsingIPBanSetByUserIDStatic, true, ref _alreadyFetchedSetByUser, new string[] { "SetByUserNickName" } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSetByUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				case "NickName":
					this.OnPropertyChanged("SetByUserNickName");
					break;
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="iPBanID">PK value for IPBan which data should be fetched into this IPBan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 iPBanID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)IPBanFieldIndex.IPBanID].ForcedCurrentValueWrite(iPBanID);
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
			return DAOFactory.CreateIPBanDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new IPBanEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static IPBanRelations Relations
		{
			get	{ return new IPBanRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSetByUser
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("SetByUser")[0], (int)SD.HnD.DAL.EntityType.IPBanEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, null, "SetByUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override string LLBLGenProEntityName
		{
			get { return "IPBanEntity";}
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

		/// <summary> The IPBanID property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPBanID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 IPBanID
		{
			get { return (System.Int32)GetValue((int)IPBanFieldIndex.IPBanID, true); }
			set	{ SetValue((int)IPBanFieldIndex.IPBanID, value, true); }
		}

		/// <summary> The IPBanSetByUserID property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPBanSetByUserID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 IPBanSetByUserID
		{
			get { return (System.Int32)GetValue((int)IPBanFieldIndex.IPBanSetByUserID, true); }
			set	{ SetValue((int)IPBanFieldIndex.IPBanSetByUserID, value, true); }
		}

		/// <summary> The IPBanSetOn property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPBanSetOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime IPBanSetOn
		{
			get { return (System.DateTime)GetValue((int)IPBanFieldIndex.IPBanSetOn, true); }
			set	{ SetValue((int)IPBanFieldIndex.IPBanSetOn, value, true); }
		}

		/// <summary> The IPSegment1 property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPSegment1"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte IPSegment1
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.IPSegment1, true); }
			set	{ SetValue((int)IPBanFieldIndex.IPSegment1, value, true); }
		}

		/// <summary> The IPSegment2 property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPSegment2"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte IPSegment2
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.IPSegment2, true); }
			set	{ SetValue((int)IPBanFieldIndex.IPSegment2, value, true); }
		}

		/// <summary> The IPSegment3 property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPSegment3"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte IPSegment3
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.IPSegment3, true); }
			set	{ SetValue((int)IPBanFieldIndex.IPSegment3, value, true); }
		}

		/// <summary> The IPSegment4 property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."IPSegment4"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte IPSegment4
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.IPSegment4, true); }
			set	{ SetValue((int)IPBanFieldIndex.IPSegment4, value, true); }
		}

		/// <summary> The Range property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."Range"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte Range
		{
			get { return (System.Byte)GetValue((int)IPBanFieldIndex.Range, true); }
			set	{ SetValue((int)IPBanFieldIndex.Range, value, true); }
		}

		/// <summary> The Reason property of the Entity IPBan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "IPBan"."Reason"<br/>
		/// Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Reason
		{
			get { return (System.String)GetValue((int)IPBanFieldIndex.Reason, true); }
			set	{ SetValue((int)IPBanFieldIndex.Reason, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleSetByUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual UserEntity SetByUser
		{
			get	{ return GetSingleSetByUser(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncSetByUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "IPBansSet", "SetByUser", _setByUser, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for SetByUser. When set to true, SetByUser is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SetByUser is accessed. You can always execute a forced fetch by calling GetSingleSetByUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSetByUser
		{
			get	{ return _alwaysFetchSetByUser; }
			set	{ _alwaysFetchSetByUser = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property SetByUser already has been fetched. Setting this property to false when SetByUser has been fetched
		/// will set SetByUser to null as well. Setting this property to true while SetByUser hasn't been fetched disables lazy loading for SetByUser</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSetByUser
		{
			get { return _alreadyFetchedSetByUser;}
			set 
			{
				if(_alreadyFetchedSetByUser && !value)
				{
					this.SetByUser = null;
				}
				_alreadyFetchedSetByUser = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property SetByUser is not found
		/// in the database. When set to true, SetByUser will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool SetByUserReturnsNewIfNotFound
		{
			get	{ return _setByUserReturnsNewIfNotFound; }
			set { _setByUserReturnsNewIfNotFound = value; }	
		}

 
		/// <summary> Gets / Sets the value of the related field this.SetByUser.NickName.<br/><br/></summary>
		public virtual System.String SetByUserNickName
		{
			get
			{
				UserEntity relatedEntity = this.SetByUser;
				return relatedEntity==null ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : relatedEntity.NickName;
			}
			set
			{
				UserEntity relatedEntity = this.SetByUser;
				if(relatedEntity!=null)
				{
					relatedEntity.NickName = value;
				}				
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
			get { return (int)SD.HnD.DAL.EntityType.IPBanEntity; }
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
