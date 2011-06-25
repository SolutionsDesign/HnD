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
	/// <summary>Entity base class which represents the base class for the entity 'AuditDataThreadRelated'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public  partial class AuditDataThreadRelatedEntityBase : AuditDataCoreEntity
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private ThreadEntity _thread;
		private bool	_alwaysFetchThread, _alreadyFetchedThread, _threadReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static new partial class MemberNames
		{
			/// <summary>Member name AuditAction</summary>
			public static readonly string AuditAction = "AuditAction";
			/// <summary>Member name Thread</summary>
			public static readonly string Thread = "Thread";
			/// <summary>Member name UserAudited</summary>
			public static readonly string UserAudited = "UserAudited";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AuditDataThreadRelatedEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		protected AuditDataThreadRelatedEntityBase() : base()
		{
			InitClassEmpty(null);
		}

		/// <summary>CTor</summary>
		/// <param name="auditDataID">PK value for AuditDataThreadRelated which data should be fetched into this AuditDataThreadRelated object</param>
		protected AuditDataThreadRelatedEntityBase(System.Int32 auditDataID):base(auditDataID)
		{
			InitClassFetch(auditDataID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="auditDataID">PK value for AuditDataThreadRelated which data should be fetched into this AuditDataThreadRelated object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected AuditDataThreadRelatedEntityBase(System.Int32 auditDataID, IPrefetchPath prefetchPathToUse):base(auditDataID, prefetchPathToUse)
		{
			InitClassFetch(auditDataID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="auditDataID">PK value for AuditDataThreadRelated which data should be fetched into this AuditDataThreadRelated object</param>
		/// <param name="validator">The custom validator object for this AuditDataThreadRelatedEntity</param>
		protected AuditDataThreadRelatedEntityBase(System.Int32 auditDataID, IValidator validator):base(auditDataID, validator)
		{
			InitClassFetch(auditDataID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AuditDataThreadRelatedEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
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
			switch((AuditDataThreadRelatedFieldIndex)fieldIndex)
			{
				case AuditDataThreadRelatedFieldIndex.ThreadID:
					DesetupSyncThread(true, false);
					_alreadyFetchedThread = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{
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
		internal static new RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Thread":
					toReturn.Add(Relations.ThreadEntityUsingThreadID);
					break;
				default:
					toReturn = AuditDataCoreEntity.GetRelationsForField(fieldName);
					break;				
			}
			return toReturn;
		}

		/// <summary>Gets a predicateexpression which filters on this entity</summary>
		/// <returns>ready to use predicateexpression</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public new static IPredicateExpression GetEntityTypeFilter()
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter("AuditDataThreadRelatedEntity", false);
		}
		
		/// <summary>Gets a predicateexpression which filters on this entity</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <returns>ready to use predicateexpression</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public new static IPredicateExpression GetEntityTypeFilter(bool negate)
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter("AuditDataThreadRelatedEntity", negate);
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
				case "Thread":
					_alreadyFetchedThread = true;
					this.Thread = (ThreadEntity)entity;
					break;
				default:
					base.SetRelatedEntityProperty(propertyName, entity);
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
				case "Thread":
					SetupSyncThread(relatedEntity);
					break;
				default:
					base.SetRelatedEntity(relatedEntity, fieldName);
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
				case "Thread":
					DesetupSyncThread(false, true);
					break;
				default:
					base.UnsetRelatedEntity(relatedEntity, fieldName, signalRelatedEntityManyToOne);
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			toReturn.AddRange(base.GetDependingRelatedEntities());
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
			toReturn.AddRange(base.GetDependentRelatedEntities());
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();

			toReturn.AddRange(base.GetMemberEntityCollections());
			return toReturn;
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key specified in a polymorphic way, so the entity returned  could be of a subtype of the current entity or the current entity.</summary>
		/// <param name="transactionToUse">transaction to use during fetch</param>
		/// <param name="auditDataID">PK value for AuditDataThreadRelated which data should be fetched into this AuditDataThreadRelated object</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <returns>Fetched entity of the type of this entity or a subtype, or an empty entity of that type if not found.</returns>
		/// <remarks>Creates a new instance, doesn't fill <i>this</i> entity instance</remarks>
		public static new AuditDataThreadRelatedEntity FetchPolymorphic(ITransaction transactionToUse, System.Int32 auditDataID, Context contextToUse)
		{
			return FetchPolymorphic(transactionToUse, auditDataID, contextToUse, null);
		}
				
		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key specified in a polymorphic way, so the entity returned  could be of a subtype of the current entity or the current entity.</summary>
		/// <param name="transactionToUse">transaction to use during fetch</param>
		/// <param name="auditDataID">PK value for AuditDataThreadRelated which data should be fetched into this AuditDataThreadRelated object</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>Fetched entity of the type of this entity or a subtype, or an empty entity of that type if not found.</returns>
		/// <remarks>Creates a new instance, doesn't fill <i>this</i> entity instance</remarks>
		public static new AuditDataThreadRelatedEntity FetchPolymorphic(ITransaction transactionToUse, System.Int32 auditDataID, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			IEntityFields fields = EntityFieldsFactory.CreateEntityFieldsObject(SD.HnD.DAL.EntityType.AuditDataThreadRelatedEntity);
			fields[(int)AuditDataThreadRelatedFieldIndex.AuditDataID].ForcedCurrentValueWrite(auditDataID);
			return (AuditDataThreadRelatedEntity)new AuditDataThreadRelatedDAO().FetchExistingPolymorphic(transactionToUse, fields, contextToUse, excludedIncludedFields);
		}


		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the SD.HnD.DAL.EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckIfIsSubTypeOf(int typeOfEntity)
		{
			return InheritanceInfoProviderSingleton.GetInstance().CheckIfIsSubTypeOf("AuditDataThreadRelatedEntity", ((SD.HnD.DAL.EntityType)typeOfEntity).ToString());
		}
				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new AuditDataThreadRelatedRelations().GetAllRelations();
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


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = base.GetRelatedData();
			toReturn.Add("Thread", _thread);
			return toReturn;
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		private void InitClassEmpty(IValidator validatorToUse)
		{
			InitClassMembers();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

		}		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="auditDataID">PK value for AuditDataThreadRelated which data should be fetched into this AuditDataThreadRelated object</param>
		/// <param name="validator">The validator object for this AuditDataThreadRelatedEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 auditDataID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			InitClassMembers();	

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_threadReturnsNewIfNotFound = true;

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END

		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();
			Dictionary<string, string> fieldHashtable;
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _thread</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncThread(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DAL.RelationClasses.StaticAuditDataThreadRelatedRelations.ThreadEntityUsingThreadIDStatic, true, signalRelatedEntity, "AuditDataThreadRelated", resetFKFields, new int[] { (int)AuditDataThreadRelatedFieldIndex.ThreadID } );		
			_thread = null;
		}
		
		/// <summary> setups the sync logic for member _thread</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncThread(IEntity relatedEntity)
		{
			if(_thread!=relatedEntity)
			{		
				DesetupSyncThread(true, true);
				_thread = (ThreadEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _thread, new PropertyChangedEventHandler( OnThreadPropertyChanged ), "Thread", SD.HnD.DAL.RelationClasses.StaticAuditDataThreadRelatedRelations.ThreadEntityUsingThreadIDStatic, true, ref _alreadyFetchedThread, new string[] {  } );
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

		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateAuditDataThreadRelatedDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new AuditDataThreadRelatedEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public new static AuditDataThreadRelatedRelations Relations
		{
			get	{ return new AuditDataThreadRelatedRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public new static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Thread'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathThread
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ThreadCollection(), (IEntityRelation)GetRelationsForField("Thread")[0], (int)SD.HnD.DAL.EntityType.AuditDataThreadRelatedEntity, (int)SD.HnD.DAL.EntityType.ThreadEntity, 0, null, null, null, "Thread", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override string LLBLGenProEntityName
		{
			get { return "AuditDataThreadRelatedEntity";}
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
		public new static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
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

		/// <summary> The ThreadID property of the Entity AuditDataThreadRelated<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AuditDataThreadRelated"."ThreadID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)AuditDataThreadRelatedFieldIndex.ThreadID, true); }
			set	{ SetValue((int)AuditDataThreadRelatedFieldIndex.ThreadID, value, true); }
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
					SetSingleRelatedEntityNavigator(value, "AuditDataThreadRelated", "Thread", _thread, true); 
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


		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return true;}
		}

		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		[System.ComponentModel.Browsable(false), XmlIgnore]
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.TargetPerEntity;}
		}
		
		/// <summary>Returns the SD.HnD.DAL.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)SD.HnD.DAL.EntityType.AuditDataThreadRelatedEntity; }
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
