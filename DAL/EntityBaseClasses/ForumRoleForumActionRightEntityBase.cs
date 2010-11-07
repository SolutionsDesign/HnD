///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
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
	/// <summary>Entity base class which represents the base class for the entity 'ForumRoleForumActionRight'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class ForumRoleForumActionRightEntityBase : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private ActionRightEntity _actionRight;
		private bool	_alwaysFetchActionRight, _alreadyFetchedActionRight, _actionRightReturnsNewIfNotFound;
		private ForumEntity _forum;
		private bool	_alwaysFetchForum, _alreadyFetchedForum, _forumReturnsNewIfNotFound;
		private RoleEntity _role;
		private bool	_alwaysFetchRole, _alreadyFetchedRole, _roleReturnsNewIfNotFound;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name ActionRight</summary>
			public static readonly string ActionRight = "ActionRight";
			/// <summary>Member name Forum</summary>
			public static readonly string Forum = "Forum";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";



		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ForumRoleForumActionRightEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ForumRoleForumActionRightEntityBase()
		{
			InitClassEmpty(null);
		}

	
		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		public ForumRoleForumActionRightEntityBase(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID)
		{
			InitClassFetch(forumID, roleID, actionRightID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ForumRoleForumActionRightEntityBase(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(forumID, roleID, actionRightID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="validator">The custom validator object for this ForumRoleForumActionRightEntity</param>
		public ForumRoleForumActionRightEntityBase(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID, IValidator validator)
		{
			InitClassFetch(forumID, roleID, actionRightID, validator, null);
		}
	

		/// <summary>Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ForumRoleForumActionRightEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{


			_actionRight = (ActionRightEntity)info.GetValue("_actionRight", typeof(ActionRightEntity));
			if(_actionRight!=null)
			{
				_actionRight.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_actionRightReturnsNewIfNotFound = info.GetBoolean("_actionRightReturnsNewIfNotFound");
			_alwaysFetchActionRight = info.GetBoolean("_alwaysFetchActionRight");
			_alreadyFetchedActionRight = info.GetBoolean("_alreadyFetchedActionRight");
			_forum = (ForumEntity)info.GetValue("_forum", typeof(ForumEntity));
			if(_forum!=null)
			{
				_forum.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_forumReturnsNewIfNotFound = info.GetBoolean("_forumReturnsNewIfNotFound");
			_alwaysFetchForum = info.GetBoolean("_alwaysFetchForum");
			_alreadyFetchedForum = info.GetBoolean("_alreadyFetchedForum");
			_role = (RoleEntity)info.GetValue("_role", typeof(RoleEntity));
			if(_role!=null)
			{
				_role.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_roleReturnsNewIfNotFound = info.GetBoolean("_roleReturnsNewIfNotFound");
			_alwaysFetchRole = info.GetBoolean("_alwaysFetchRole");
			_alreadyFetchedRole = info.GetBoolean("_alreadyFetchedRole");

			base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ForumRoleForumActionRightFieldIndex)fieldIndex)
			{
				case ForumRoleForumActionRightFieldIndex.ForumID:
					DesetupSyncForum(true, false);
					_alreadyFetchedForum = false;
					break;
				case ForumRoleForumActionRightFieldIndex.RoleID:
					DesetupSyncRole(true, false);
					_alreadyFetchedRole = false;
					break;
				case ForumRoleForumActionRightFieldIndex.ActionRightID:
					DesetupSyncActionRight(true, false);
					_alreadyFetchedActionRight = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
		
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{


			_alreadyFetchedActionRight = (_actionRight != null);
			_alreadyFetchedForum = (_forum != null);
			_alreadyFetchedRole = (_role != null);

		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return ForumRoleForumActionRightEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "ActionRight":
					toReturn.Add(ForumRoleForumActionRightEntity.Relations.ActionRightEntityUsingActionRightID);
					break;
				case "Forum":
					toReturn.Add(ForumRoleForumActionRightEntity.Relations.ForumEntityUsingForumID);
					break;
				case "Role":
					toReturn.Add(ForumRoleForumActionRightEntity.Relations.RoleEntityUsingRoleID);
					break;



				default:

					break;				
			}
			return toReturn;
		}



		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{


			info.AddValue("_actionRight", (!this.MarkedForDeletion?_actionRight:null));
			info.AddValue("_actionRightReturnsNewIfNotFound", _actionRightReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchActionRight", _alwaysFetchActionRight);
			info.AddValue("_alreadyFetchedActionRight", _alreadyFetchedActionRight);
			info.AddValue("_forum", (!this.MarkedForDeletion?_forum:null));
			info.AddValue("_forumReturnsNewIfNotFound", _forumReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchForum", _alwaysFetchForum);
			info.AddValue("_alreadyFetchedForum", _alreadyFetchedForum);
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
		public override void SetRelatedEntityProperty(string propertyName, IEntity entity)
		{
			switch(propertyName)
			{
				case "ActionRight":
					_alreadyFetchedActionRight = true;
					this.ActionRight = (ActionRightEntity)entity;
					break;
				case "Forum":
					_alreadyFetchedForum = true;
					this.Forum = (ForumEntity)entity;
					break;
				case "Role":
					_alreadyFetchedRole = true;
					this.Role = (RoleEntity)entity;
					break;



				default:

					break;
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "ActionRight":
					SetupSyncActionRight(relatedEntity);
					break;
				case "Forum":
					SetupSyncForum(relatedEntity);
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
		public override void UnsetRelatedEntity(IEntity relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "ActionRight":
					DesetupSyncActionRight(false, true);
					break;
				case "Forum":
					DesetupSyncForum(false, true);
					break;
				case "Role":
					DesetupSyncRole(false, true);
					break;


				default:

					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();


			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		public override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_actionRight!=null)
			{
				toReturn.Add(_actionRight);
			}
			if(_forum!=null)
			{
				toReturn.Add(_forum);
			}
			if(_role!=null)
			{
				toReturn.Add(_role);
			}


			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. The contents of the ArrayList is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		public override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();


			return toReturn;
		}

		

		

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID)
		{
			return FetchUsingPK(forumID, roleID, actionRightID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(forumID, roleID, actionRightID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return Fetch(forumID, roleID, actionRightID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(forumID, roleID, actionRightID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.ForumID, this.RoleID, this.ActionRightID, null, null, null);
		}

		/// <summary> Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ForumRoleForumActionRightFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ForumRoleForumActionRightFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ForumRoleForumActionRightRelations().GetAllRelations();
		}




		/// <summary> Retrieves the related entity of type 'ActionRightEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ActionRightEntity' which is related to this entity.</returns>
		public ActionRightEntity GetSingleActionRight()
		{
			return GetSingleActionRight(false);
		}

		/// <summary> Retrieves the related entity of type 'ActionRightEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ActionRightEntity' which is related to this entity.</returns>
		public virtual ActionRightEntity GetSingleActionRight(bool forceFetch)
		{
			if( ( !_alreadyFetchedActionRight || forceFetch || _alwaysFetchActionRight) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(ForumRoleForumActionRightEntity.Relations.ActionRightEntityUsingActionRightID);

				ActionRightEntity newEntity = new ActionRightEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.ActionRightID);
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (ActionRightEntity)base.ActiveContext.Get(newEntity);
					}
					this.ActionRight = newEntity;
				}
				else
				{
					if(_actionRightReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_actionRight == null)))
						{
							this.ActionRight = newEntity;
						}
					}
					else
					{
						this.ActionRight = null;
					}
				}
				_alreadyFetchedActionRight = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _actionRight;
		}

		/// <summary> Retrieves the related entity of type 'ForumEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ForumEntity' which is related to this entity.</returns>
		public ForumEntity GetSingleForum()
		{
			return GetSingleForum(false);
		}

		/// <summary> Retrieves the related entity of type 'ForumEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ForumEntity' which is related to this entity.</returns>
		public virtual ForumEntity GetSingleForum(bool forceFetch)
		{
			if( ( !_alreadyFetchedForum || forceFetch || _alwaysFetchForum) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(ForumRoleForumActionRightEntity.Relations.ForumEntityUsingForumID);

				ForumEntity newEntity = new ForumEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.ForumID);
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (ForumEntity)base.ActiveContext.Get(newEntity);
					}
					this.Forum = newEntity;
				}
				else
				{
					if(_forumReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_forum == null)))
						{
							this.Forum = newEntity;
						}
					}
					else
					{
						this.Forum = null;
					}
				}
				_alreadyFetchedForum = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _forum;
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
			if( ( !_alreadyFetchedRole || forceFetch || _alwaysFetchRole) && !base.IsSerializing && !base.IsDeserializing  && !base.InDesignMode)			
			{
				bool performLazyLoading = base.CheckIfLazyLoadingShouldOccur(ForumRoleForumActionRightEntity.Relations.RoleEntityUsingRoleID);

				RoleEntity newEntity = new RoleEntity();
				if(base.ParticipatesInTransaction)
				{
					base.Transaction.Add(newEntity);
				}
				bool fetchResult = false;
				if(performLazyLoading)
				{
					fetchResult = newEntity.FetchUsingPK(this.RoleID);
				}
				if(fetchResult)
				{
					if(base.ActiveContext!=null)
					{
						newEntity = (RoleEntity)base.ActiveContext.Get(newEntity);
					}
					this.Role = newEntity;
				}
				else
				{
					if(_roleReturnsNewIfNotFound)
					{
						if(performLazyLoading || (!performLazyLoading && (_role == null)))
						{
							this.Role = newEntity;
						}
					}
					else
					{
						this.Role = null;
					}
				}
				_alreadyFetchedRole = fetchResult;
				if(base.ParticipatesInTransaction && !fetchResult)
				{
					base.Transaction.Remove(newEntity);
				}
			}
			return _role;
		}


		/// <summary> Performs the insert action of a new Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool InsertEntity()
		{
			ForumRoleForumActionRightDAO dao = (ForumRoleForumActionRightDAO)CreateDAOInstance();
			return dao.AddNew(base.Fields, base.Transaction);
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_actionRight!=null)
			{
				_actionRight.ActiveContext = base.ActiveContext;
			}
			if(_forum!=null)
			{
				_forum.ActiveContext = base.ActiveContext;
			}
			if(_role!=null)
			{
				_role.ActiveContext = base.ActiveContext;
			}


		}


		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity()
		{
			ForumRoleForumActionRightDAO dao = (ForumRoleForumActionRightDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction);
		}
		
		/// <summary> Performs the update action of an existing Entity to the persistent storage.</summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if succeeded, false otherwise</returns>
		protected override bool UpdateEntity(IPredicate updateRestriction)
		{
			ForumRoleForumActionRightDAO dao = (ForumRoleForumActionRightDAO)CreateDAOInstance();
			return dao.UpdateExisting(base.Fields, base.Transaction, updateRestriction);
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		protected virtual void InitClassEmpty(IValidator validatorToUse)
		{
			OnInitializing();
			base.Fields = CreateFields();
			base.IsNew=true;
			base.Validator = validatorToUse;

			InitClassMembers();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity);
		}
		
		/// <summary>Creates a new transaction object</summary>
		/// <param name="levelOfIsolation">The level of isolation.</param>
		/// <param name="name">The name.</param>
		protected override ITransaction CreateTransaction( IsolationLevel levelOfIsolation, string name )
		{
			return new Transaction(levelOfIsolation, name);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ActionRight", _actionRight);
			toReturn.Add("Forum", _forum);
			toReturn.Add("Role", _role);



			return toReturn;
		}
		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="validator">The validator object for this ForumRoleForumActionRightEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected virtual void InitClassFetch(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			base.Validator = validator;
			InitClassMembers();
			base.Fields = CreateFields();
			bool wasSuccesful = Fetch(forumID, roleID, actionRightID, prefetchPathToUse, null, null);
			base.IsNew = !wasSuccesful;

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{


			_actionRight = null;
			_actionRightReturnsNewIfNotFound = true;
			_alwaysFetchActionRight = false;
			_alreadyFetchedActionRight = false;
			_forum = null;
			_forumReturnsNewIfNotFound = true;
			_alwaysFetchForum = false;
			_alreadyFetchedForum = false;
			_role = null;
			_roleReturnsNewIfNotFound = true;
			_alwaysFetchRole = false;
			_alreadyFetchedRole = false;


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

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ForumID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoleID", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActionRightID", fieldHashtable);
		}
		#endregion


		/// <summary> Removes the sync logic for member _actionRight</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncActionRight(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _actionRight, new PropertyChangedEventHandler( OnActionRightPropertyChanged ), "ActionRight", ForumRoleForumActionRightEntity.Relations.ActionRightEntityUsingActionRightID, true, signalRelatedEntity, "ForumRoleForumActionRights", resetFKFields, new int[] { (int)ForumRoleForumActionRightFieldIndex.ActionRightID } );		
			_actionRight = null;
		}
		
		/// <summary> setups the sync logic for member _actionRight</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncActionRight(IEntity relatedEntity)
		{
			if(_actionRight!=relatedEntity)
			{		
				DesetupSyncActionRight(true, true);
				_actionRight = (ActionRightEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _actionRight, new PropertyChangedEventHandler( OnActionRightPropertyChanged ), "ActionRight", ForumRoleForumActionRightEntity.Relations.ActionRightEntityUsingActionRightID, true, ref _alreadyFetchedActionRight, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnActionRightPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _forum</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncForum(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _forum, new PropertyChangedEventHandler( OnForumPropertyChanged ), "Forum", ForumRoleForumActionRightEntity.Relations.ForumEntityUsingForumID, true, signalRelatedEntity, "ForumRoleForumActionRights", resetFKFields, new int[] { (int)ForumRoleForumActionRightFieldIndex.ForumID } );		
			_forum = null;
		}
		
		/// <summary> setups the sync logic for member _forum</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncForum(IEntity relatedEntity)
		{
			if(_forum!=relatedEntity)
			{		
				DesetupSyncForum(true, true);
				_forum = (ForumEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _forum, new PropertyChangedEventHandler( OnForumPropertyChanged ), "Forum", ForumRoleForumActionRightEntity.Relations.ForumEntityUsingForumID, true, ref _alreadyFetchedForum, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnForumPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", ForumRoleForumActionRightEntity.Relations.RoleEntityUsingRoleID, true, signalRelatedEntity, "ForumRoleForumActionRights", resetFKFields, new int[] { (int)ForumRoleForumActionRightFieldIndex.RoleID } );		
			_role = null;
		}
		
		/// <summary> setups the sync logic for member _role</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRole(IEntity relatedEntity)
		{
			if(_role!=relatedEntity)
			{		
				DesetupSyncRole(true, true);
				_role = (RoleEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", ForumRoleForumActionRightEntity.Relations.RoleEntityUsingRoleID, true, ref _alreadyFetchedRole, new string[] {  } );
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
		/// <param name="forumID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="roleID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="actionRightID">PK value for ForumRoleForumActionRight which data should be fetched into this ForumRoleForumActionRight object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 forumID, System.Int32 roleID, System.Int32 actionRightID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				IDao dao = this.CreateDAOInstance();
				base.Fields[(int)ForumRoleForumActionRightFieldIndex.ForumID].ForcedCurrentValueWrite(forumID);
				base.Fields[(int)ForumRoleForumActionRightFieldIndex.RoleID].ForcedCurrentValueWrite(roleID);
				base.Fields[(int)ForumRoleForumActionRightFieldIndex.ActionRightID].ForcedCurrentValueWrite(actionRightID);
				dao.FetchExisting(this, base.Transaction, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (base.Fields.State == EntityState.Fetched);
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
			return DAOFactory.CreateForumRoleForumActionRightDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ForumRoleForumActionRightEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ForumRoleForumActionRightRelations Relations
		{
			get	{ return new ForumRoleForumActionRightRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}




		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ActionRight' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathActionRight
		{
			get
			{
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ActionRightCollection(),
					(IEntityRelation)GetRelationsForField("ActionRight")[0], (int)SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity, (int)SD.HnD.DAL.EntityType.ActionRightEntity, 0, null, null, null, "ActionRight", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Forum' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathForum
		{
			get
			{
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ForumCollection(),
					(IEntityRelation)GetRelationsForField("Forum")[0], (int)SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity, (int)SD.HnD.DAL.EntityType.ForumEntity, 0, null, null, null, "Forum", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRole
		{
			get
			{
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleCollection(),
					(IEntityRelation)GetRelationsForField("Role")[0], (int)SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity, (int)SD.HnD.DAL.EntityType.RoleEntity, 0, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override string LLBLGenProEntityName
		{
			get { return "ForumRoleForumActionRightEntity";}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ForumRoleForumActionRightEntity.CustomProperties;}
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
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return ForumRoleForumActionRightEntity.FieldsCustomProperties;}
		}

		/// <summary> The ForumID property of the Entity ForumRoleForumActionRight<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ForumRoleForumActionRight"."ForumID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ForumID
		{
			get { return (System.Int32)GetValue((int)ForumRoleForumActionRightFieldIndex.ForumID, true); }
			set	{ SetValue((int)ForumRoleForumActionRightFieldIndex.ForumID, value, true); }
		}
		/// <summary> The RoleID property of the Entity ForumRoleForumActionRight<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ForumRoleForumActionRight"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 RoleID
		{
			get { return (System.Int32)GetValue((int)ForumRoleForumActionRightFieldIndex.RoleID, true); }
			set	{ SetValue((int)ForumRoleForumActionRightFieldIndex.RoleID, value, true); }
		}
		/// <summary> The ActionRightID property of the Entity ForumRoleForumActionRight<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ForumRoleForumActionRight"."ActionRightID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 ActionRightID
		{
			get { return (System.Int32)GetValue((int)ForumRoleForumActionRightFieldIndex.ActionRightID, true); }
			set	{ SetValue((int)ForumRoleForumActionRightFieldIndex.ActionRightID, value, true); }
		}



		/// <summary> Gets / sets related entity of type 'ActionRightEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleActionRight()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual ActionRightEntity ActionRight
		{
			get	{ return GetSingleActionRight(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncActionRight(value);
				}
				else
				{
					if(value==null)
					{
						if(_actionRight != null)
						{
							_actionRight.UnsetRelatedEntity(this, "ForumRoleForumActionRights");
						}
					}
					else
					{
						if(_actionRight!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "ForumRoleForumActionRights");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for ActionRight. When set to true, ActionRight is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ActionRight is accessed. You can always execute
		/// a forced fetch by calling GetSingleActionRight(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchActionRight
		{
			get	{ return _alwaysFetchActionRight; }
			set	{ _alwaysFetchActionRight = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property ActionRight already has been fetched. Setting this property to false when ActionRight has been fetched
		/// will set ActionRight to null as well. Setting this property to true while ActionRight hasn't been fetched disables lazy loading for ActionRight</summary>
		[Browsable(false)]
		public bool AlreadyFetchedActionRight
		{
			get { return _alreadyFetchedActionRight;}
			set 
			{
				if(_alreadyFetchedActionRight && !value)
				{
					this.ActionRight = null;
				}
				_alreadyFetchedActionRight = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property ActionRight is not found
		/// in the database. When set to true, ActionRight will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool ActionRightReturnsNewIfNotFound
		{
			get	{ return _actionRightReturnsNewIfNotFound; }
			set { _actionRightReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'ForumEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleForum()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual ForumEntity Forum
		{
			get	{ return GetSingleForum(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncForum(value);
				}
				else
				{
					if(value==null)
					{
						if(_forum != null)
						{
							_forum.UnsetRelatedEntity(this, "ForumRoleForumActionRights");
						}
					}
					else
					{
						if(_forum!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "ForumRoleForumActionRights");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Forum. When set to true, Forum is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Forum is accessed. You can always execute
		/// a forced fetch by calling GetSingleForum(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchForum
		{
			get	{ return _alwaysFetchForum; }
			set	{ _alwaysFetchForum = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Forum already has been fetched. Setting this property to false when Forum has been fetched
		/// will set Forum to null as well. Setting this property to true while Forum hasn't been fetched disables lazy loading for Forum</summary>
		[Browsable(false)]
		public bool AlreadyFetchedForum
		{
			get { return _alreadyFetchedForum;}
			set 
			{
				if(_alreadyFetchedForum && !value)
				{
					this.Forum = null;
				}
				_alreadyFetchedForum = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Forum is not found
		/// in the database. When set to true, Forum will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: true.</summary>
		[Browsable(false)]
		public bool ForumReturnsNewIfNotFound
		{
			get	{ return _forumReturnsNewIfNotFound; }
			set { _forumReturnsNewIfNotFound = value; }	
		}
		/// <summary> Gets / sets related entity of type 'RoleEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.</summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleRole()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual RoleEntity Role
		{
			get	{ return GetSingleRole(false); }
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncRole(value);
				}
				else
				{
					if(value==null)
					{
						if(_role != null)
						{
							_role.UnsetRelatedEntity(this, "ForumRoleForumActionRights");
						}
					}
					else
					{
						if(_role!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "ForumRoleForumActionRights");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Role. When set to true, Role is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Role is accessed. You can always execute
		/// a forced fetch by calling GetSingleRole(true).</summary>
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
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity; }
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
