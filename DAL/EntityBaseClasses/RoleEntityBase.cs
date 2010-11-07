///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.0
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
	/// <summary>Entity base class which represents the base class for the entity 'Role'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public abstract partial class RoleEntityBase : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection	_forumRoleForumActionRights;
		private bool	_alwaysFetchForumRoleForumActionRights, _alreadyFetchedForumRoleForumActionRights;
		private SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection	_roleAuditAction;
		private bool	_alwaysFetchRoleAuditAction, _alreadyFetchedRoleAuditAction;
		private SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection	_roleSystemActionRights;
		private bool	_alwaysFetchRoleSystemActionRights, _alreadyFetchedRoleSystemActionRights;
		private SD.HnD.DAL.CollectionClasses.RoleUserCollection	_roleUser;
		private bool	_alwaysFetchRoleUser, _alreadyFetchedRoleUser;
		private SD.HnD.DAL.CollectionClasses.SystemDataCollection	_systemDataAnonymousRole;
		private bool	_alwaysFetchSystemDataAnonymousRole, _alreadyFetchedSystemDataAnonymousRole;
		private SD.HnD.DAL.CollectionClasses.SystemDataCollection	_systemDataDefaultRoleNewUser;
		private bool	_alwaysFetchSystemDataDefaultRoleNewUser, _alreadyFetchedSystemDataDefaultRoleNewUser;
		private SD.HnD.DAL.CollectionClasses.ActionRightCollection _assignedSystemActionRights;
		private bool	_alwaysFetchAssignedSystemActionRights, _alreadyFetchedAssignedSystemActionRights;
		private SD.HnD.DAL.CollectionClasses.AuditActionCollection _assignedAuditActions;
		private bool	_alwaysFetchAssignedAuditActions, _alreadyFetchedAssignedAuditActions;
		private SD.HnD.DAL.CollectionClasses.UserCollection _users;
		private bool	_alwaysFetchUsers, _alreadyFetchedUsers;

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
			/// <summary>Member name RoleAuditAction</summary>
			public static readonly string RoleAuditAction = "RoleAuditAction";
			/// <summary>Member name RoleSystemActionRights</summary>
			public static readonly string RoleSystemActionRights = "RoleSystemActionRights";
			/// <summary>Member name RoleUser</summary>
			public static readonly string RoleUser = "RoleUser";
			/// <summary>Member name SystemDataAnonymousRole</summary>
			public static readonly string SystemDataAnonymousRole = "SystemDataAnonymousRole";
			/// <summary>Member name SystemDataDefaultRoleNewUser</summary>
			public static readonly string SystemDataDefaultRoleNewUser = "SystemDataDefaultRoleNewUser";
			/// <summary>Member name AssignedSystemActionRights</summary>
			public static readonly string AssignedSystemActionRights = "AssignedSystemActionRights";
			/// <summary>Member name AssignedAuditActions</summary>
			public static readonly string AssignedAuditActions = "AssignedAuditActions";
			/// <summary>Member name Users</summary>
			public static readonly string Users = "Users";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static RoleEntityBase()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		protected RoleEntityBase() : base()
		{
			InitClassEmpty(null);
		}

		/// <summary>CTor</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		protected RoleEntityBase(System.Int32 roleID)
		{
			InitClassFetch(roleID, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		protected RoleEntityBase(System.Int32 roleID, IPrefetchPath prefetchPathToUse)
		{
			InitClassFetch(roleID, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="validator">The custom validator object for this RoleEntity</param>
		protected RoleEntityBase(System.Int32 roleID, IValidator validator)
		{
			InitClassFetch(roleID, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected RoleEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_forumRoleForumActionRights = (SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection)info.GetValue("_forumRoleForumActionRights", typeof(SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection));
			_alwaysFetchForumRoleForumActionRights = info.GetBoolean("_alwaysFetchForumRoleForumActionRights");
			_alreadyFetchedForumRoleForumActionRights = info.GetBoolean("_alreadyFetchedForumRoleForumActionRights");

			_roleAuditAction = (SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection)info.GetValue("_roleAuditAction", typeof(SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection));
			_alwaysFetchRoleAuditAction = info.GetBoolean("_alwaysFetchRoleAuditAction");
			_alreadyFetchedRoleAuditAction = info.GetBoolean("_alreadyFetchedRoleAuditAction");

			_roleSystemActionRights = (SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection)info.GetValue("_roleSystemActionRights", typeof(SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection));
			_alwaysFetchRoleSystemActionRights = info.GetBoolean("_alwaysFetchRoleSystemActionRights");
			_alreadyFetchedRoleSystemActionRights = info.GetBoolean("_alreadyFetchedRoleSystemActionRights");

			_roleUser = (SD.HnD.DAL.CollectionClasses.RoleUserCollection)info.GetValue("_roleUser", typeof(SD.HnD.DAL.CollectionClasses.RoleUserCollection));
			_alwaysFetchRoleUser = info.GetBoolean("_alwaysFetchRoleUser");
			_alreadyFetchedRoleUser = info.GetBoolean("_alreadyFetchedRoleUser");

			_systemDataAnonymousRole = (SD.HnD.DAL.CollectionClasses.SystemDataCollection)info.GetValue("_systemDataAnonymousRole", typeof(SD.HnD.DAL.CollectionClasses.SystemDataCollection));
			_alwaysFetchSystemDataAnonymousRole = info.GetBoolean("_alwaysFetchSystemDataAnonymousRole");
			_alreadyFetchedSystemDataAnonymousRole = info.GetBoolean("_alreadyFetchedSystemDataAnonymousRole");

			_systemDataDefaultRoleNewUser = (SD.HnD.DAL.CollectionClasses.SystemDataCollection)info.GetValue("_systemDataDefaultRoleNewUser", typeof(SD.HnD.DAL.CollectionClasses.SystemDataCollection));
			_alwaysFetchSystemDataDefaultRoleNewUser = info.GetBoolean("_alwaysFetchSystemDataDefaultRoleNewUser");
			_alreadyFetchedSystemDataDefaultRoleNewUser = info.GetBoolean("_alreadyFetchedSystemDataDefaultRoleNewUser");
			_assignedSystemActionRights = (SD.HnD.DAL.CollectionClasses.ActionRightCollection)info.GetValue("_assignedSystemActionRights", typeof(SD.HnD.DAL.CollectionClasses.ActionRightCollection));
			_alwaysFetchAssignedSystemActionRights = info.GetBoolean("_alwaysFetchAssignedSystemActionRights");
			_alreadyFetchedAssignedSystemActionRights = info.GetBoolean("_alreadyFetchedAssignedSystemActionRights");

			_assignedAuditActions = (SD.HnD.DAL.CollectionClasses.AuditActionCollection)info.GetValue("_assignedAuditActions", typeof(SD.HnD.DAL.CollectionClasses.AuditActionCollection));
			_alwaysFetchAssignedAuditActions = info.GetBoolean("_alwaysFetchAssignedAuditActions");
			_alreadyFetchedAssignedAuditActions = info.GetBoolean("_alreadyFetchedAssignedAuditActions");

			_users = (SD.HnD.DAL.CollectionClasses.UserCollection)info.GetValue("_users", typeof(SD.HnD.DAL.CollectionClasses.UserCollection));
			_alwaysFetchUsers = info.GetBoolean("_alwaysFetchUsers");
			_alreadyFetchedUsers = info.GetBoolean("_alreadyFetchedUsers");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}	

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PostReadXmlFixups()
		{
			_alreadyFetchedForumRoleForumActionRights = (_forumRoleForumActionRights.Count > 0);
			_alreadyFetchedRoleAuditAction = (_roleAuditAction.Count > 0);
			_alreadyFetchedRoleSystemActionRights = (_roleSystemActionRights.Count > 0);
			_alreadyFetchedRoleUser = (_roleUser.Count > 0);
			_alreadyFetchedSystemDataAnonymousRole = (_systemDataAnonymousRole.Count > 0);
			_alreadyFetchedSystemDataDefaultRoleNewUser = (_systemDataDefaultRoleNewUser.Count > 0);
			_alreadyFetchedAssignedSystemActionRights = (_assignedSystemActionRights.Count > 0);
			_alreadyFetchedAssignedAuditActions = (_assignedAuditActions.Count > 0);
			_alreadyFetchedUsers = (_users.Count > 0);
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
					toReturn.Add(Relations.ForumRoleForumActionRightEntityUsingRoleID);
					break;
				case "RoleAuditAction":
					toReturn.Add(Relations.RoleAuditActionEntityUsingRoleID);
					break;
				case "RoleSystemActionRights":
					toReturn.Add(Relations.RoleSystemActionRightEntityUsingRoleID);
					break;
				case "RoleUser":
					toReturn.Add(Relations.RoleUserEntityUsingRoleID);
					break;
				case "SystemDataAnonymousRole":
					toReturn.Add(Relations.SystemDataEntityUsingAnonymousRole);
					break;
				case "SystemDataDefaultRoleNewUser":
					toReturn.Add(Relations.SystemDataEntityUsingDefaultRoleNewUser);
					break;
				case "AssignedSystemActionRights":
					toReturn.Add(Relations.RoleSystemActionRightEntityUsingRoleID, "RoleEntity__", "RoleSystemActionRight_", JoinHint.None);
					toReturn.Add(RoleSystemActionRightEntity.Relations.ActionRightEntityUsingActionRightID, "RoleSystemActionRight_", string.Empty, JoinHint.None);
					break;
				case "AssignedAuditActions":
					toReturn.Add(Relations.RoleAuditActionEntityUsingRoleID, "RoleEntity__", "RoleAuditAction_", JoinHint.None);
					toReturn.Add(RoleAuditActionEntity.Relations.AuditActionEntityUsingAuditActionID, "RoleAuditAction_", string.Empty, JoinHint.None);
					break;
				case "Users":
					toReturn.Add(Relations.RoleUserEntityUsingRoleID, "RoleEntity__", "RoleUser_", JoinHint.None);
					toReturn.Add(RoleUserEntity.Relations.UserEntityUsingUserID, "RoleUser_", string.Empty, JoinHint.None);
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
			info.AddValue("_roleAuditAction", (!this.MarkedForDeletion?_roleAuditAction:null));
			info.AddValue("_alwaysFetchRoleAuditAction", _alwaysFetchRoleAuditAction);
			info.AddValue("_alreadyFetchedRoleAuditAction", _alreadyFetchedRoleAuditAction);
			info.AddValue("_roleSystemActionRights", (!this.MarkedForDeletion?_roleSystemActionRights:null));
			info.AddValue("_alwaysFetchRoleSystemActionRights", _alwaysFetchRoleSystemActionRights);
			info.AddValue("_alreadyFetchedRoleSystemActionRights", _alreadyFetchedRoleSystemActionRights);
			info.AddValue("_roleUser", (!this.MarkedForDeletion?_roleUser:null));
			info.AddValue("_alwaysFetchRoleUser", _alwaysFetchRoleUser);
			info.AddValue("_alreadyFetchedRoleUser", _alreadyFetchedRoleUser);
			info.AddValue("_systemDataAnonymousRole", (!this.MarkedForDeletion?_systemDataAnonymousRole:null));
			info.AddValue("_alwaysFetchSystemDataAnonymousRole", _alwaysFetchSystemDataAnonymousRole);
			info.AddValue("_alreadyFetchedSystemDataAnonymousRole", _alreadyFetchedSystemDataAnonymousRole);
			info.AddValue("_systemDataDefaultRoleNewUser", (!this.MarkedForDeletion?_systemDataDefaultRoleNewUser:null));
			info.AddValue("_alwaysFetchSystemDataDefaultRoleNewUser", _alwaysFetchSystemDataDefaultRoleNewUser);
			info.AddValue("_alreadyFetchedSystemDataDefaultRoleNewUser", _alreadyFetchedSystemDataDefaultRoleNewUser);
			info.AddValue("_assignedSystemActionRights", (!this.MarkedForDeletion?_assignedSystemActionRights:null));
			info.AddValue("_alwaysFetchAssignedSystemActionRights", _alwaysFetchAssignedSystemActionRights);
			info.AddValue("_alreadyFetchedAssignedSystemActionRights", _alreadyFetchedAssignedSystemActionRights);
			info.AddValue("_assignedAuditActions", (!this.MarkedForDeletion?_assignedAuditActions:null));
			info.AddValue("_alwaysFetchAssignedAuditActions", _alwaysFetchAssignedAuditActions);
			info.AddValue("_alreadyFetchedAssignedAuditActions", _alreadyFetchedAssignedAuditActions);
			info.AddValue("_users", (!this.MarkedForDeletion?_users:null));
			info.AddValue("_alwaysFetchUsers", _alwaysFetchUsers);
			info.AddValue("_alreadyFetchedUsers", _alreadyFetchedUsers);

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
				case "ForumRoleForumActionRights":
					_alreadyFetchedForumRoleForumActionRights = true;
					if(entity!=null)
					{
						this.ForumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)entity);
					}
					break;
				case "RoleAuditAction":
					_alreadyFetchedRoleAuditAction = true;
					if(entity!=null)
					{
						this.RoleAuditAction.Add((RoleAuditActionEntity)entity);
					}
					break;
				case "RoleSystemActionRights":
					_alreadyFetchedRoleSystemActionRights = true;
					if(entity!=null)
					{
						this.RoleSystemActionRights.Add((RoleSystemActionRightEntity)entity);
					}
					break;
				case "RoleUser":
					_alreadyFetchedRoleUser = true;
					if(entity!=null)
					{
						this.RoleUser.Add((RoleUserEntity)entity);
					}
					break;
				case "SystemDataAnonymousRole":
					_alreadyFetchedSystemDataAnonymousRole = true;
					if(entity!=null)
					{
						this.SystemDataAnonymousRole.Add((SystemDataEntity)entity);
					}
					break;
				case "SystemDataDefaultRoleNewUser":
					_alreadyFetchedSystemDataDefaultRoleNewUser = true;
					if(entity!=null)
					{
						this.SystemDataDefaultRoleNewUser.Add((SystemDataEntity)entity);
					}
					break;
				case "AssignedSystemActionRights":
					_alreadyFetchedAssignedSystemActionRights = true;
					if(entity!=null)
					{
						this.AssignedSystemActionRights.Add((ActionRightEntity)entity);
					}
					break;
				case "AssignedAuditActions":
					_alreadyFetchedAssignedAuditActions = true;
					if(entity!=null)
					{
						this.AssignedAuditActions.Add((AuditActionEntity)entity);
					}
					break;
				case "Users":
					_alreadyFetchedUsers = true;
					if(entity!=null)
					{
						this.Users.Add((UserEntity)entity);
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
		protected override void SetRelatedEntity(IEntity relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "ForumRoleForumActionRights":
					_forumRoleForumActionRights.Add((ForumRoleForumActionRightEntity)relatedEntity);
					break;
				case "RoleAuditAction":
					_roleAuditAction.Add((RoleAuditActionEntity)relatedEntity);
					break;
				case "RoleSystemActionRights":
					_roleSystemActionRights.Add((RoleSystemActionRightEntity)relatedEntity);
					break;
				case "RoleUser":
					_roleUser.Add((RoleUserEntity)relatedEntity);
					break;
				case "SystemDataAnonymousRole":
					_systemDataAnonymousRole.Add((SystemDataEntity)relatedEntity);
					break;
				case "SystemDataDefaultRoleNewUser":
					_systemDataDefaultRoleNewUser.Add((SystemDataEntity)relatedEntity);
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
				case "ForumRoleForumActionRights":
					this.PerformRelatedEntityRemoval(_forumRoleForumActionRights, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleAuditAction":
					this.PerformRelatedEntityRemoval(_roleAuditAction, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleSystemActionRights":
					this.PerformRelatedEntityRemoval(_roleSystemActionRights, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleUser":
					this.PerformRelatedEntityRemoval(_roleUser, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SystemDataAnonymousRole":
					this.PerformRelatedEntityRemoval(_systemDataAnonymousRole, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SystemDataDefaultRoleNewUser":
					this.PerformRelatedEntityRemoval(_systemDataDefaultRoleNewUser, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(_roleAuditAction);
			toReturn.Add(_roleSystemActionRights);
			toReturn.Add(_roleUser);
			toReturn.Add(_systemDataAnonymousRole);
			toReturn.Add(_systemDataDefaultRoleNewUser);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 roleID)
		{
			return FetchUsingPK(roleID, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 roleID, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(roleID, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 roleID, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(roleID, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 roleID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(roleID, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.RoleID, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new RoleRelations().GetAllRelations();
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
				_forumRoleForumActionRights.GetMultiManyToOne(null, null, this, filter);
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

		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'RoleAuditActionEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection GetMultiRoleAuditAction(bool forceFetch)
		{
			return GetMultiRoleAuditAction(forceFetch, _roleAuditAction.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'RoleAuditActionEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection GetMultiRoleAuditAction(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiRoleAuditAction(forceFetch, _roleAuditAction.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection GetMultiRoleAuditAction(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiRoleAuditAction(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection GetMultiRoleAuditAction(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedRoleAuditAction || forceFetch || _alwaysFetchRoleAuditAction) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_roleAuditAction);
				_roleAuditAction.SuppressClearInGetMulti=!forceFetch;
				_roleAuditAction.EntityFactoryToUse = entityFactoryToUse;
				_roleAuditAction.GetMultiManyToOne(null, this, filter);
				_roleAuditAction.SuppressClearInGetMulti=false;
				_alreadyFetchedRoleAuditAction = true;
			}
			return _roleAuditAction;
		}

		/// <summary> Sets the collection parameters for the collection for 'RoleAuditAction'. These settings will be taken into account
		/// when the property RoleAuditAction is requested or GetMultiRoleAuditAction is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersRoleAuditAction(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_roleAuditAction.SortClauses=sortClauses;
			_roleAuditAction.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
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
				_roleSystemActionRights.GetMultiManyToOne(null, this, filter);
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

		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'RoleUserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleUserCollection GetMultiRoleUser(bool forceFetch)
		{
			return GetMultiRoleUser(forceFetch, _roleUser.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'RoleUserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.RoleUserCollection GetMultiRoleUser(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiRoleUser(forceFetch, _roleUser.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.RoleUserCollection GetMultiRoleUser(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiRoleUser(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.RoleUserCollection GetMultiRoleUser(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedRoleUser || forceFetch || _alwaysFetchRoleUser) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_roleUser);
				_roleUser.SuppressClearInGetMulti=!forceFetch;
				_roleUser.EntityFactoryToUse = entityFactoryToUse;
				_roleUser.GetMultiManyToOne(this, null, filter);
				_roleUser.SuppressClearInGetMulti=false;
				_alreadyFetchedRoleUser = true;
			}
			return _roleUser;
		}

		/// <summary> Sets the collection parameters for the collection for 'RoleUser'. These settings will be taken into account
		/// when the property RoleUser is requested or GetMultiRoleUser is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersRoleUser(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_roleUser.SortClauses=sortClauses;
			_roleUser.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SystemDataEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SystemDataCollection GetMultiSystemDataAnonymousRole(bool forceFetch)
		{
			return GetMultiSystemDataAnonymousRole(forceFetch, _systemDataAnonymousRole.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'SystemDataEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SystemDataCollection GetMultiSystemDataAnonymousRole(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSystemDataAnonymousRole(forceFetch, _systemDataAnonymousRole.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.SystemDataCollection GetMultiSystemDataAnonymousRole(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSystemDataAnonymousRole(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.SystemDataCollection GetMultiSystemDataAnonymousRole(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSystemDataAnonymousRole || forceFetch || _alwaysFetchSystemDataAnonymousRole) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_systemDataAnonymousRole);
				_systemDataAnonymousRole.SuppressClearInGetMulti=!forceFetch;
				_systemDataAnonymousRole.EntityFactoryToUse = entityFactoryToUse;
				_systemDataAnonymousRole.GetMultiManyToOne(this, null, filter);
				_systemDataAnonymousRole.SuppressClearInGetMulti=false;
				_alreadyFetchedSystemDataAnonymousRole = true;
			}
			return _systemDataAnonymousRole;
		}

		/// <summary> Sets the collection parameters for the collection for 'SystemDataAnonymousRole'. These settings will be taken into account
		/// when the property SystemDataAnonymousRole is requested or GetMultiSystemDataAnonymousRole is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSystemDataAnonymousRole(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_systemDataAnonymousRole.SortClauses=sortClauses;
			_systemDataAnonymousRole.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SystemDataEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SystemDataCollection GetMultiSystemDataDefaultRoleNewUser(bool forceFetch)
		{
			return GetMultiSystemDataDefaultRoleNewUser(forceFetch, _systemDataDefaultRoleNewUser.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'SystemDataEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.SystemDataCollection GetMultiSystemDataDefaultRoleNewUser(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSystemDataDefaultRoleNewUser(forceFetch, _systemDataDefaultRoleNewUser.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.SystemDataCollection GetMultiSystemDataDefaultRoleNewUser(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSystemDataDefaultRoleNewUser(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual SD.HnD.DAL.CollectionClasses.SystemDataCollection GetMultiSystemDataDefaultRoleNewUser(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSystemDataDefaultRoleNewUser || forceFetch || _alwaysFetchSystemDataDefaultRoleNewUser) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_systemDataDefaultRoleNewUser);
				_systemDataDefaultRoleNewUser.SuppressClearInGetMulti=!forceFetch;
				_systemDataDefaultRoleNewUser.EntityFactoryToUse = entityFactoryToUse;
				_systemDataDefaultRoleNewUser.GetMultiManyToOne(null, this, filter);
				_systemDataDefaultRoleNewUser.SuppressClearInGetMulti=false;
				_alreadyFetchedSystemDataDefaultRoleNewUser = true;
			}
			return _systemDataDefaultRoleNewUser;
		}

		/// <summary> Sets the collection parameters for the collection for 'SystemDataDefaultRoleNewUser'. These settings will be taken into account
		/// when the property SystemDataDefaultRoleNewUser is requested or GetMultiSystemDataDefaultRoleNewUser is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSystemDataDefaultRoleNewUser(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_systemDataDefaultRoleNewUser.SortClauses=sortClauses;
			_systemDataDefaultRoleNewUser.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ActionRightEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ActionRightEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.ActionRightCollection GetMultiAssignedSystemActionRights(bool forceFetch)
		{
			return GetMultiAssignedSystemActionRights(forceFetch, _assignedSystemActionRights.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'ActionRightEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.ActionRightCollection GetMultiAssignedSystemActionRights(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedAssignedSystemActionRights || forceFetch || _alwaysFetchAssignedSystemActionRights) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_assignedSystemActionRights);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(RoleFields.RoleID, ComparisonOperator.Equal, this.RoleID, "RoleEntity__"));
				_assignedSystemActionRights.SuppressClearInGetMulti=!forceFetch;
				_assignedSystemActionRights.EntityFactoryToUse = entityFactoryToUse;
				_assignedSystemActionRights.GetMulti(filter, GetRelationsForField("AssignedSystemActionRights"));
				_assignedSystemActionRights.SuppressClearInGetMulti=false;
				_alreadyFetchedAssignedSystemActionRights = true;
			}
			return _assignedSystemActionRights;
		}

		/// <summary> Sets the collection parameters for the collection for 'AssignedSystemActionRights'. These settings will be taken into account
		/// when the property AssignedSystemActionRights is requested or GetMultiAssignedSystemActionRights is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersAssignedSystemActionRights(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_assignedSystemActionRights.SortClauses=sortClauses;
			_assignedSystemActionRights.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'AuditActionEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'AuditActionEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.AuditActionCollection GetMultiAssignedAuditActions(bool forceFetch)
		{
			return GetMultiAssignedAuditActions(forceFetch, _assignedAuditActions.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'AuditActionEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.AuditActionCollection GetMultiAssignedAuditActions(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedAssignedAuditActions || forceFetch || _alwaysFetchAssignedAuditActions) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_assignedAuditActions);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(RoleFields.RoleID, ComparisonOperator.Equal, this.RoleID, "RoleEntity__"));
				_assignedAuditActions.SuppressClearInGetMulti=!forceFetch;
				_assignedAuditActions.EntityFactoryToUse = entityFactoryToUse;
				_assignedAuditActions.GetMulti(filter, GetRelationsForField("AssignedAuditActions"));
				_assignedAuditActions.SuppressClearInGetMulti=false;
				_alreadyFetchedAssignedAuditActions = true;
			}
			return _assignedAuditActions;
		}

		/// <summary> Sets the collection parameters for the collection for 'AssignedAuditActions'. These settings will be taken into account
		/// when the property AssignedAuditActions is requested or GetMultiAssignedAuditActions is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersAssignedAuditActions(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_assignedAuditActions.SortClauses=sortClauses;
			_assignedAuditActions.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserEntity'</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsers(bool forceFetch)
		{
			return GetMultiUsers(forceFetch, _users.EntityFactoryToUse);
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToMany() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public SD.HnD.DAL.CollectionClasses.UserCollection GetMultiUsers(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
 			if( ( !_alreadyFetchedUsers || forceFetch || _alwaysFetchUsers) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_users);
				IPredicateExpression filter = new PredicateExpression();
				filter.Add(new FieldCompareValuePredicate(RoleFields.RoleID, ComparisonOperator.Equal, this.RoleID, "RoleEntity__"));
				_users.SuppressClearInGetMulti=!forceFetch;
				_users.EntityFactoryToUse = entityFactoryToUse;
				_users.GetMulti(filter, GetRelationsForField("Users"));
				_users.SuppressClearInGetMulti=false;
				_alreadyFetchedUsers = true;
			}
			return _users;
		}

		/// <summary> Sets the collection parameters for the collection for 'Users'. These settings will be taken into account
		/// when the property Users is requested or GetMultiUsers is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUsers(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_users.SortClauses=sortClauses;
			_users.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			_forumRoleForumActionRights.ActiveContext = this.ActiveContext;
			_roleAuditAction.ActiveContext = this.ActiveContext;
			_roleSystemActionRights.ActiveContext = this.ActiveContext;
			_roleUser.ActiveContext = this.ActiveContext;
			_systemDataAnonymousRole.ActiveContext = this.ActiveContext;
			_systemDataDefaultRoleNewUser.ActiveContext = this.ActiveContext;
			_assignedSystemActionRights.ActiveContext = this.ActiveContext;
			_assignedAuditActions.ActiveContext = this.ActiveContext;
			_users.ActiveContext = this.ActiveContext;
		}

		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ForumRoleForumActionRights", _forumRoleForumActionRights);
			toReturn.Add("RoleAuditAction", _roleAuditAction);
			toReturn.Add("RoleSystemActionRights", _roleSystemActionRights);
			toReturn.Add("RoleUser", _roleUser);
			toReturn.Add("SystemDataAnonymousRole", _systemDataAnonymousRole);
			toReturn.Add("SystemDataDefaultRoleNewUser", _systemDataDefaultRoleNewUser);
			toReturn.Add("AssignedSystemActionRights", _assignedSystemActionRights);
			toReturn.Add("AssignedAuditActions", _assignedAuditActions);
			toReturn.Add("Users", _users);
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
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="validator">The validator object for this RoleEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 roleID, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(roleID, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_forumRoleForumActionRights = new SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection();
			_forumRoleForumActionRights.SetContainingEntityInfo(this, "Role");

			_roleAuditAction = new SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection();
			_roleAuditAction.SetContainingEntityInfo(this, "Role");

			_roleSystemActionRights = new SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection();
			_roleSystemActionRights.SetContainingEntityInfo(this, "Role");

			_roleUser = new SD.HnD.DAL.CollectionClasses.RoleUserCollection();
			_roleUser.SetContainingEntityInfo(this, "Role");

			_systemDataAnonymousRole = new SD.HnD.DAL.CollectionClasses.SystemDataCollection();
			_systemDataAnonymousRole.SetContainingEntityInfo(this, "RoleForAnonymous");

			_systemDataDefaultRoleNewUser = new SD.HnD.DAL.CollectionClasses.SystemDataCollection();
			_systemDataDefaultRoleNewUser.SetContainingEntityInfo(this, "RoleForNewUser");
			_assignedSystemActionRights = new SD.HnD.DAL.CollectionClasses.ActionRightCollection();
			_assignedAuditActions = new SD.HnD.DAL.CollectionClasses.AuditActionCollection();
			_users = new SD.HnD.DAL.CollectionClasses.UserCollection();
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
			_fieldsCustomProperties.Add("RoleDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RoleID", fieldHashtable);
		}
		#endregion

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="roleID">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 roleID, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)RoleFieldIndex.RoleID].ForcedCurrentValueWrite(roleID);
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
			return DAOFactory.CreateRoleDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new RoleEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static RoleRelations Relations
		{
			get	{ return new RoleRelations(); }
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
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ForumRoleForumActionRightCollection(), (IEntityRelation)GetRelationsForField("ForumRoleForumActionRights")[0], (int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity, 0, null, null, null, "ForumRoleForumActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'RoleAuditAction' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoleAuditAction
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection(), (IEntityRelation)GetRelationsForField("RoleAuditAction")[0], (int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.RoleAuditActionEntity, 0, null, null, null, "RoleAuditAction", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'RoleSystemActionRight' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoleSystemActionRights
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleSystemActionRightCollection(), (IEntityRelation)GetRelationsForField("RoleSystemActionRights")[0], (int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.RoleSystemActionRightEntity, 0, null, null, null, "RoleSystemActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'RoleUser' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoleUser
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.RoleUserCollection(), (IEntityRelation)GetRelationsForField("RoleUser")[0], (int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.RoleUserEntity, 0, null, null, null, "RoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SystemData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSystemDataAnonymousRole
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SystemDataCollection(), (IEntityRelation)GetRelationsForField("SystemDataAnonymousRole")[0], (int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.SystemDataEntity, 0, null, null, null, "SystemDataAnonymousRole", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SystemData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSystemDataDefaultRoleNewUser
		{
			get { return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.SystemDataCollection(), (IEntityRelation)GetRelationsForField("SystemDataDefaultRoleNewUser")[0], (int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.SystemDataEntity, 0, null, null, null, "SystemDataDefaultRoleNewUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ActionRight'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAssignedSystemActionRights
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleSystemActionRightEntityUsingRoleID;
				intermediateRelation.SetAliases(string.Empty, "RoleSystemActionRight_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.ActionRightCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.ActionRightEntity, 0, null, null, GetRelationsForField("AssignedSystemActionRights"), "AssignedSystemActionRights", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'AuditAction'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAssignedAuditActions
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleAuditActionEntityUsingRoleID;
				intermediateRelation.SetAliases(string.Empty, "RoleAuditAction_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.AuditActionCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.AuditActionEntity, 0, null, null, GetRelationsForField("AssignedAuditActions"), "AssignedAuditActions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUsers
		{
			get
			{
				IEntityRelation intermediateRelation = Relations.RoleUserEntityUsingRoleID;
				intermediateRelation.SetAliases(string.Empty, "RoleUser_");
				return new PrefetchPathElement(new SD.HnD.DAL.CollectionClasses.UserCollection(), intermediateRelation,	(int)SD.HnD.DAL.EntityType.RoleEntity, (int)SD.HnD.DAL.EntityType.UserEntity, 0, null, null, GetRelationsForField("Users"), "Users", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary>Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override string LLBLGenProEntityName
		{
			get { return "RoleEntity";}
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

		/// <summary> The RoleDescription property of the Entity Role<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Role"."RoleDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String RoleDescription
		{
			get { return (System.String)GetValue((int)RoleFieldIndex.RoleDescription, true); }
			set	{ SetValue((int)RoleFieldIndex.RoleDescription, value, true); }
		}

		/// <summary> The RoleID property of the Entity Role<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Role"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 RoleID
		{
			get { return (System.Int32)GetValue((int)RoleFieldIndex.RoleID, true); }
			set	{ SetValue((int)RoleFieldIndex.RoleID, value, true); }
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
		/// <summary> Retrieves all related entities of type 'RoleAuditActionEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiRoleAuditAction()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.RoleAuditActionCollection RoleAuditAction
		{
			get	{ return GetMultiRoleAuditAction(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for RoleAuditAction. When set to true, RoleAuditAction is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time RoleAuditAction is accessed. You can always execute/ a forced fetch by calling GetMultiRoleAuditAction(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoleAuditAction
		{
			get	{ return _alwaysFetchRoleAuditAction; }
			set	{ _alwaysFetchRoleAuditAction = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property RoleAuditAction already has been fetched. Setting this property to false when RoleAuditAction has been fetched
		/// will clear the RoleAuditAction collection well. Setting this property to true while RoleAuditAction hasn't been fetched disables lazy loading for RoleAuditAction</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoleAuditAction
		{
			get { return _alreadyFetchedRoleAuditAction;}
			set 
			{
				if(_alreadyFetchedRoleAuditAction && !value && (_roleAuditAction != null))
				{
					_roleAuditAction.Clear();
				}
				_alreadyFetchedRoleAuditAction = value;
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
		/// <summary> Retrieves all related entities of type 'RoleUserEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiRoleUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.RoleUserCollection RoleUser
		{
			get	{ return GetMultiRoleUser(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for RoleUser. When set to true, RoleUser is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time RoleUser is accessed. You can always execute/ a forced fetch by calling GetMultiRoleUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoleUser
		{
			get	{ return _alwaysFetchRoleUser; }
			set	{ _alwaysFetchRoleUser = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property RoleUser already has been fetched. Setting this property to false when RoleUser has been fetched
		/// will clear the RoleUser collection well. Setting this property to true while RoleUser hasn't been fetched disables lazy loading for RoleUser</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoleUser
		{
			get { return _alreadyFetchedRoleUser;}
			set 
			{
				if(_alreadyFetchedRoleUser && !value && (_roleUser != null))
				{
					_roleUser.Clear();
				}
				_alreadyFetchedRoleUser = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSystemDataAnonymousRole()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.SystemDataCollection SystemDataAnonymousRole
		{
			get	{ return GetMultiSystemDataAnonymousRole(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SystemDataAnonymousRole. When set to true, SystemDataAnonymousRole is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SystemDataAnonymousRole is accessed. You can always execute/ a forced fetch by calling GetMultiSystemDataAnonymousRole(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSystemDataAnonymousRole
		{
			get	{ return _alwaysFetchSystemDataAnonymousRole; }
			set	{ _alwaysFetchSystemDataAnonymousRole = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property SystemDataAnonymousRole already has been fetched. Setting this property to false when SystemDataAnonymousRole has been fetched
		/// will clear the SystemDataAnonymousRole collection well. Setting this property to true while SystemDataAnonymousRole hasn't been fetched disables lazy loading for SystemDataAnonymousRole</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSystemDataAnonymousRole
		{
			get { return _alreadyFetchedSystemDataAnonymousRole;}
			set 
			{
				if(_alreadyFetchedSystemDataAnonymousRole && !value && (_systemDataAnonymousRole != null))
				{
					_systemDataAnonymousRole.Clear();
				}
				_alreadyFetchedSystemDataAnonymousRole = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'SystemDataEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSystemDataDefaultRoleNewUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.SystemDataCollection SystemDataDefaultRoleNewUser
		{
			get	{ return GetMultiSystemDataDefaultRoleNewUser(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SystemDataDefaultRoleNewUser. When set to true, SystemDataDefaultRoleNewUser is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SystemDataDefaultRoleNewUser is accessed. You can always execute/ a forced fetch by calling GetMultiSystemDataDefaultRoleNewUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSystemDataDefaultRoleNewUser
		{
			get	{ return _alwaysFetchSystemDataDefaultRoleNewUser; }
			set	{ _alwaysFetchSystemDataDefaultRoleNewUser = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property SystemDataDefaultRoleNewUser already has been fetched. Setting this property to false when SystemDataDefaultRoleNewUser has been fetched
		/// will clear the SystemDataDefaultRoleNewUser collection well. Setting this property to true while SystemDataDefaultRoleNewUser hasn't been fetched disables lazy loading for SystemDataDefaultRoleNewUser</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSystemDataDefaultRoleNewUser
		{
			get { return _alreadyFetchedSystemDataDefaultRoleNewUser;}
			set 
			{
				if(_alreadyFetchedSystemDataDefaultRoleNewUser && !value && (_systemDataDefaultRoleNewUser != null))
				{
					_systemDataDefaultRoleNewUser.Clear();
				}
				_alreadyFetchedSystemDataDefaultRoleNewUser = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'ActionRightEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiAssignedSystemActionRights()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.ActionRightCollection AssignedSystemActionRights
		{
			get { return GetMultiAssignedSystemActionRights(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for AssignedSystemActionRights. When set to true, AssignedSystemActionRights is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time AssignedSystemActionRights is accessed. You can always execute a forced fetch by calling GetMultiAssignedSystemActionRights(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAssignedSystemActionRights
		{
			get	{ return _alwaysFetchAssignedSystemActionRights; }
			set	{ _alwaysFetchAssignedSystemActionRights = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property AssignedSystemActionRights already has been fetched. Setting this property to false when AssignedSystemActionRights has been fetched
		/// will clear the AssignedSystemActionRights collection well. Setting this property to true while AssignedSystemActionRights hasn't been fetched disables lazy loading for AssignedSystemActionRights</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAssignedSystemActionRights
		{
			get { return _alreadyFetchedAssignedSystemActionRights;}
			set 
			{
				if(_alreadyFetchedAssignedSystemActionRights && !value && (_assignedSystemActionRights != null))
				{
					_assignedSystemActionRights.Clear();
				}
				_alreadyFetchedAssignedSystemActionRights = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'AuditActionEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiAssignedAuditActions()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.AuditActionCollection AssignedAuditActions
		{
			get { return GetMultiAssignedAuditActions(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for AssignedAuditActions. When set to true, AssignedAuditActions is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time AssignedAuditActions is accessed. You can always execute a forced fetch by calling GetMultiAssignedAuditActions(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAssignedAuditActions
		{
			get	{ return _alwaysFetchAssignedAuditActions; }
			set	{ _alwaysFetchAssignedAuditActions = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property AssignedAuditActions already has been fetched. Setting this property to false when AssignedAuditActions has been fetched
		/// will clear the AssignedAuditActions collection well. Setting this property to true while AssignedAuditActions hasn't been fetched disables lazy loading for AssignedAuditActions</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAssignedAuditActions
		{
			get { return _alreadyFetchedAssignedAuditActions;}
			set 
			{
				if(_alreadyFetchedAssignedAuditActions && !value && (_assignedAuditActions != null))
				{
					_assignedAuditActions.Clear();
				}
				_alreadyFetchedAssignedAuditActions = value;
			}
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type 'm:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUsers()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual SD.HnD.DAL.CollectionClasses.UserCollection Users
		{
			get { return GetMultiUsers(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Users. When set to true, Users is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Users is accessed. You can always execute a forced fetch by calling GetMultiUsers(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUsers
		{
			get	{ return _alwaysFetchUsers; }
			set	{ _alwaysFetchUsers = value; }
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Users already has been fetched. Setting this property to false when Users has been fetched
		/// will clear the Users collection well. Setting this property to true while Users hasn't been fetched disables lazy loading for Users</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUsers
		{
			get { return _alreadyFetchedUsers;}
			set 
			{
				if(_alreadyFetchedUsers && !value && (_users != null))
				{
					_users.Clear();
				}
				_alreadyFetchedUsers = value;
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
			get { return (int)SD.HnD.DAL.EntityType.RoleEntity; }
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
