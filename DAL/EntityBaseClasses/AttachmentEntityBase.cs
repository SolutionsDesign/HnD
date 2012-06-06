///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
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
	/// <summary>Entity base class which represents the base class for the entity 'Attachment'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class AttachmentEntityBase : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private MessageEntity _belongsToMessage;
		private bool	_alwaysFetchBelongsToMessage, _alreadyFetchedBelongsToMessage, _belongsToMessageReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name BelongsToMessage</summary>
			public static readonly string BelongsToMessage = "BelongsToMessage";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AttachmentEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		protected AttachmentEntityBase() :base("AttachmentEntity")
		{
			InitClassEmpty(null);
		}

		/// <summary>CTor</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		protected AttachmentEntityBase(System.Int32 attachmentID):base("AttachmentEntity")
		{
			InitClassFetch(attachmentID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected AttachmentEntityBase(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse): base("AttachmentEntity")
		{
			InitClassFetch(attachmentID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="validator">The custom validator object for this AttachmentEntity</param>
		protected AttachmentEntityBase(System.Int32 attachmentID, IValidator validator):base("AttachmentEntity")
		{
			InitClassFetch(attachmentID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AttachmentEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_belongsToMessage = (MessageEntity)info.GetValue("_belongsToMessage", typeof(MessageEntity));
			if(_belongsToMessage!=null)
			{
				_belongsToMessage.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_belongsToMessageReturnsNewIfNotFound = info.GetBoolean("_belongsToMessageReturnsNewIfNotFound");
			_alwaysFetchBelongsToMessage = info.GetBoolean("_alwaysFetchBelongsToMessage");
			_alreadyFetchedBelongsToMessage = info.GetBoolean("_alreadyFetchedBelongsToMessage");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}	
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((AttachmentFieldIndex)fieldIndex)
			{
				case AttachmentFieldIndex.MessageID:
					DesetupSyncBelongsToMessage(true, false);
					_alreadyFetchedBelongsToMessage = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedBelongsToMessage = (_belongsToMessage != null);
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
				case "BelongsToMessage":
					toReturn.Add(Relations.MessageEntityUsingMessageID);
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
			info.AddValue("_belongsToMessage", (!this.MarkedForDeletion?_belongsToMessage:null));
			info.AddValue("_belongsToMessageReturnsNewIfNotFound", _belongsToMessageReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchBelongsToMessage", _alwaysFetchBelongsToMessage);
			info.AddValue("_alreadyFetchedBelongsToMessage", _alreadyFetchedBelongsToMessage);

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
				case "BelongsToMessage":
					_alreadyFetchedBelongsToMessage = true;
					this.BelongsToMessage = (MessageEntity)entity;
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
				case "BelongsToMessage":
					SetupSyncBelongsToMessage(relatedEntity);
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
				case "BelongsToMessage":
					DesetupSyncBelongsToMessage(false, true);
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
			if(_belongsToMessage!=null)
			{
				toReturn.Add(_belongsToMessage);
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
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 attachmentID)
		{
			return FetchUsingPK(attachmentID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(attachmentID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(attachmentID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(attachmentID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.AttachmentID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new AttachmentRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'MessageEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'MessageEntity' which is related to this entity.</returns>
		public MessageEntity GetSingleBelongsToMessage()
		{
			return GetSingleBelongsToMessage(false);
		}

		/// <summary> Retrieves the related entity of type 'MessageEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'MessageEntity' which is related to this entity.</returns>
		public virtual MessageEntity GetSingleBelongsToMessage(bool forceFetch)
		{
			if( ( !_alreadyFetchedBelongsToMessage || forceFetch || _alwaysFetchBelongsToMessage) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.MessageEntityUsingMessageID);
				MessageEntity newEntity = new MessageEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.MessageID);
				}
				if(fetchResult)
				{
					newEntity = (MessageEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_belongsToMessageReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.BelongsToMessage = newEntity;
				_alreadyFetchedBelongsToMessage = fetchResult;
			}
			return _belongsToMessage;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BelongsToMessage", _belongsToMessage);
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
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="validator">The validator object for this AttachmentEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 attachmentID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(attachmentID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_belongsToMessageReturnsNewIfNotFound = true;
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
			_fieldsCustomProperties.Add("AttachmentID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MessageID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Filename", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Approved", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Filecontents", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Filesize", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AddedOn", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _belongsToMessage</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBelongsToMessage(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _belongsToMessage, new PropertyChangedEventHandler( OnBelongsToMessagePropertyChanged ), "BelongsToMessage", SD.HnD.DAL.RelationClasses.StaticAttachmentRelations.MessageEntityUsingMessageIDStatic, true, signalRelatedEntity, "Attachments", resetFKFields, new int[] { (int)AttachmentFieldIndex.MessageID } );		
			_belongsToMessage = null;
		}
		
		/// <summary> setups the sync logic for member _belongsToMessage</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBelongsToMessage(IEntityCore relatedEntity)
		{
			if(_belongsToMessage!=relatedEntity)
			{		
				DesetupSyncBelongsToMessage(true, true);
				_belongsToMessage = (MessageEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _belongsToMessage, new PropertyChangedEventHandler( OnBelongsToMessagePropertyChanged ), "BelongsToMessage", SD.HnD.DAL.RelationClasses.StaticAttachmentRelations.MessageEntityUsingMessageIDStatic, true, ref _alreadyFetchedBelongsToMessage, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBelongsToMessagePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="attachmentID">PK value for Attachment which data should be fetched into this Attachment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 attachmentID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)AttachmentFieldIndex.AttachmentID].ForcedCurrentValueWrite(attachmentID);
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
			return DAOFactory.CreateAttachmentDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new AttachmentEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AttachmentRelations Relations
		{
			get	{ return new AttachmentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Message'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathBelongsToMessage
		{
			get	{ return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.MessageCollection(), (IEntityRelation)GetRelationsForField("BelongsToMessage")[0], (int)SD.HnD.DAL.EntityType.AttachmentEntity, (int)SD.HnD.DAL.EntityType.MessageEntity, 0, null, null, null, "BelongsToMessage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The AttachmentID property of the Entity Attachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Attachment"."AttachmentID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AttachmentID
		{
			get { return (System.Int32)GetValue((int)AttachmentFieldIndex.AttachmentID, true); }
			set	{ SetValue((int)AttachmentFieldIndex.AttachmentID, value, true); }
		}

		/// <summary> The MessageID property of the Entity Attachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Attachment"."MessageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 MessageID
		{
			get { return (System.Int32)GetValue((int)AttachmentFieldIndex.MessageID, true); }
			set	{ SetValue((int)AttachmentFieldIndex.MessageID, value, true); }
		}

		/// <summary> The Filename property of the Entity Attachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Attachment"."Filename"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Filename
		{
			get { return (System.String)GetValue((int)AttachmentFieldIndex.Filename, true); }
			set	{ SetValue((int)AttachmentFieldIndex.Filename, value, true); }
		}

		/// <summary> The Approved property of the Entity Attachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Attachment"."Approved"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Approved
		{
			get { return (System.Boolean)GetValue((int)AttachmentFieldIndex.Approved, true); }
			set	{ SetValue((int)AttachmentFieldIndex.Approved, value, true); }
		}

		/// <summary> The Filecontents property of the Entity Attachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Attachment"."Filecontents"<br/>
		/// Table field type characteristics (type, precision, scale, length): Image, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte[] Filecontents
		{
			get { return (System.Byte[])GetValue((int)AttachmentFieldIndex.Filecontents, true); }
			set	{ SetValue((int)AttachmentFieldIndex.Filecontents, value, true); }
		}

		/// <summary> The Filesize property of the Entity Attachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Attachment"."Filesize"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Filesize
		{
			get { return (System.Int32)GetValue((int)AttachmentFieldIndex.Filesize, true); }
			set	{ SetValue((int)AttachmentFieldIndex.Filesize, value, true); }
		}

		/// <summary> The AddedOn property of the Entity Attachment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Attachment"."AddedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime AddedOn
		{
			get { return (System.DateTime)GetValue((int)AttachmentFieldIndex.AddedOn, true); }
			set	{ SetValue((int)AttachmentFieldIndex.AddedOn, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'MessageEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleBelongsToMessage()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(true)]
		public virtual MessageEntity BelongsToMessage
		{
			get	{ return GetSingleBelongsToMessage(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncBelongsToMessage(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Attachments", "BelongsToMessage", _belongsToMessage, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for BelongsToMessage. When set to true, BelongsToMessage is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time BelongsToMessage is accessed. You can always execute a forced fetch by calling GetSingleBelongsToMessage(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchBelongsToMessage
		{
			get	{ return _alwaysFetchBelongsToMessage; }
			set	{ _alwaysFetchBelongsToMessage = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property BelongsToMessage already has been fetched. Setting this property to false when BelongsToMessage has been fetched
		/// will set BelongsToMessage to null as well. Setting this property to true while BelongsToMessage hasn't been fetched disables lazy loading for BelongsToMessage</summary>
		[Browsable(false)]
		public bool AlreadyFetchedBelongsToMessage
		{
			get { return _alreadyFetchedBelongsToMessage;}
			set 
			{
				if(_alreadyFetchedBelongsToMessage && !value)
				{
					this.BelongsToMessage = null;
				}
				_alreadyFetchedBelongsToMessage = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property BelongsToMessage is not found
		/// in the database. When set to true, BelongsToMessage will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool BelongsToMessageReturnsNewIfNotFound
		{
			get	{ return _belongsToMessageReturnsNewIfNotFound; }
			set { _belongsToMessageReturnsNewIfNotFound = value; }	
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
			get { return (int)SD.HnD.DAL.EntityType.AttachmentEntity; }
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
