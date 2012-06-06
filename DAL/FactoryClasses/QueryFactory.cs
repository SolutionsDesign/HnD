///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
////////////////////////////////////////////////////////////// 
using System;
using SD.HnD.DAL.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace SD.HnD.DAL.FactoryClasses
{
	/// <summary>Factory class to produce DynamicQuery instances and EntityQuery instances</summary>
	public partial class QueryFactory
	{
		private int _aliasCounter = 0;

		/// <summary>Creates a new DynamicQuery instance with no alias set.</summary>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create()
		{
			return Create(string.Empty);
		}

		/// <summary>Creates a new DynamicQuery instance with the alias specified as the alias set.</summary>
		/// <param name="alias">The alias.</param>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create(string alias)
		{
			return new DynamicQuery(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}

		/// <summary>Creates a new EntityQuery for the entity of the type specified with no alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>()
			where TEntity : IEntityCore
		{
			return Create<TEntity>(string.Empty);
		}

		/// <summary>Creates a new EntityQuery for the entity of the type specified with the alias specified as the alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <param name="alias">The alias.</param>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>(string alias)
			where TEntity : IEntityCore
		{
			return new EntityQuery<TEntity>(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}
				
		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField Field(string fieldName)
		{
			return Field<object>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField Field(string targetAlias, string fieldName)
		{
			return Field<object>(targetAlias, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value represented by the field.</typeparam>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField Field<TValue>(string fieldName)
		{
			return Field<TValue>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField Field<TValue>(string targetAlias, string fieldName)
		{
			return new EntityField(fieldName, targetAlias, typeof(TValue));
		}
						
		/// <summary>Gets the next alias counter value to produce artifical aliases with</summary>
		private int GetNextAliasCounterValue()
		{
			_aliasCounter++;
			return _aliasCounter;
		}
		
		/// <summary>Creates and returns a new EntityQuery for the ActionRight entity</summary>
		public EntityQuery<ActionRightEntity> ActionRight
		{
			get { return Create<ActionRightEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Attachment entity</summary>
		public EntityQuery<AttachmentEntity> Attachment
		{
			get { return Create<AttachmentEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AuditAction entity</summary>
		public EntityQuery<AuditActionEntity> AuditAction
		{
			get { return Create<AuditActionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AuditDataCore entity</summary>
		public EntityQuery<AuditDataCoreEntity> AuditDataCore
		{
			get { return Create<AuditDataCoreEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AuditDataMessageRelated entity</summary>
		public EntityQuery<AuditDataMessageRelatedEntity> AuditDataMessageRelated
		{
			get { return Create<AuditDataMessageRelatedEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AuditDataThreadRelated entity</summary>
		public EntityQuery<AuditDataThreadRelatedEntity> AuditDataThreadRelated
		{
			get { return Create<AuditDataThreadRelatedEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Bookmark entity</summary>
		public EntityQuery<BookmarkEntity> Bookmark
		{
			get { return Create<BookmarkEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Forum entity</summary>
		public EntityQuery<ForumEntity> Forum
		{
			get { return Create<ForumEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ForumRoleForumActionRight entity</summary>
		public EntityQuery<ForumRoleForumActionRightEntity> ForumRoleForumActionRight
		{
			get { return Create<ForumRoleForumActionRightEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the IPBan entity</summary>
		public EntityQuery<IPBanEntity> IPBan
		{
			get { return Create<IPBanEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Message entity</summary>
		public EntityQuery<MessageEntity> Message
		{
			get { return Create<MessageEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Role entity</summary>
		public EntityQuery<RoleEntity> Role
		{
			get { return Create<RoleEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the RoleAuditAction entity</summary>
		public EntityQuery<RoleAuditActionEntity> RoleAuditAction
		{
			get { return Create<RoleAuditActionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the RoleSystemActionRight entity</summary>
		public EntityQuery<RoleSystemActionRightEntity> RoleSystemActionRight
		{
			get { return Create<RoleSystemActionRightEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the RoleUser entity</summary>
		public EntityQuery<RoleUserEntity> RoleUser
		{
			get { return Create<RoleUserEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Section entity</summary>
		public EntityQuery<SectionEntity> Section
		{
			get { return Create<SectionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the SupportQueue entity</summary>
		public EntityQuery<SupportQueueEntity> SupportQueue
		{
			get { return Create<SupportQueueEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the SupportQueueThread entity</summary>
		public EntityQuery<SupportQueueThreadEntity> SupportQueueThread
		{
			get { return Create<SupportQueueThreadEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the SystemData entity</summary>
		public EntityQuery<SystemDataEntity> SystemData
		{
			get { return Create<SystemDataEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Thread entity</summary>
		public EntityQuery<ThreadEntity> Thread
		{
			get { return Create<ThreadEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ThreadSubscription entity</summary>
		public EntityQuery<ThreadSubscriptionEntity> ThreadSubscription
		{
			get { return Create<ThreadSubscriptionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the User entity</summary>
		public EntityQuery<UserEntity> User
		{
			get { return Create<UserEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserTitle entity</summary>
		public EntityQuery<UserTitleEntity> UserTitle
		{
			get { return Create<UserTitleEntity>(); }
		}

	}
}