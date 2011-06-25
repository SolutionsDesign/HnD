///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using SD.HnD.DAL;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.RelationClasses;

namespace SD.HnD.DAL.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData : ILinqMetaData
	{
		#region Class Member Declarations
		private ITransaction _transactionToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the transaction object to use empty. This is ok if you're not executing queries created with this
		/// meta data inside a transaction. If you're executing the queries created with this meta-data inside a transaction, either set the Transaction property
		/// on the IQueryable.Provider instance of the created LLBLGenProQuery object prior to execution or use the ctor which accepts a transaction object.</summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor. If you're executing the queries created with this meta-data inside a transaction, pass a live ITransaction object to this ctor.</summary>
		/// <param name="transactionToUse">the transaction to use in queries created with this meta-data</param>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(ITransaction transactionToUse) : this(transactionToUse, null)
		{
		}
		
		/// <summary>CTor. If you're executing the queries created with this meta-data inside a transaction, pass a live ITransaction object to this ctor.</summary>
		/// <param name="transactionToUse">the transaction to use in queries created with this meta-data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(ITransaction transactionToUse, FunctionMappingStore customFunctionMappings)
		{
			_transactionToUse = transactionToUse;
			_customFunctionMappings = customFunctionMappings;
		}
		
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((SD.HnD.DAL.EntityType)typeOfEntity)
			{
				case SD.HnD.DAL.EntityType.ActionRightEntity:
					toReturn = this.ActionRight;
					break;
				case SD.HnD.DAL.EntityType.AttachmentEntity:
					toReturn = this.Attachment;
					break;
				case SD.HnD.DAL.EntityType.AuditActionEntity:
					toReturn = this.AuditAction;
					break;
				case SD.HnD.DAL.EntityType.AuditDataCoreEntity:
					toReturn = this.AuditDataCore;
					break;
				case SD.HnD.DAL.EntityType.AuditDataMessageRelatedEntity:
					toReturn = this.AuditDataMessageRelated;
					break;
				case SD.HnD.DAL.EntityType.AuditDataThreadRelatedEntity:
					toReturn = this.AuditDataThreadRelated;
					break;
				case SD.HnD.DAL.EntityType.BookmarkEntity:
					toReturn = this.Bookmark;
					break;
				case SD.HnD.DAL.EntityType.ForumEntity:
					toReturn = this.Forum;
					break;
				case SD.HnD.DAL.EntityType.ForumRoleForumActionRightEntity:
					toReturn = this.ForumRoleForumActionRight;
					break;
				case SD.HnD.DAL.EntityType.IPBanEntity:
					toReturn = this.IPBan;
					break;
				case SD.HnD.DAL.EntityType.MessageEntity:
					toReturn = this.Message;
					break;
				case SD.HnD.DAL.EntityType.RoleEntity:
					toReturn = this.Role;
					break;
				case SD.HnD.DAL.EntityType.RoleAuditActionEntity:
					toReturn = this.RoleAuditAction;
					break;
				case SD.HnD.DAL.EntityType.RoleSystemActionRightEntity:
					toReturn = this.RoleSystemActionRight;
					break;
				case SD.HnD.DAL.EntityType.RoleUserEntity:
					toReturn = this.RoleUser;
					break;
				case SD.HnD.DAL.EntityType.SectionEntity:
					toReturn = this.Section;
					break;
				case SD.HnD.DAL.EntityType.SupportQueueEntity:
					toReturn = this.SupportQueue;
					break;
				case SD.HnD.DAL.EntityType.SupportQueueThreadEntity:
					toReturn = this.SupportQueueThread;
					break;
				case SD.HnD.DAL.EntityType.SystemDataEntity:
					toReturn = this.SystemData;
					break;
				case SD.HnD.DAL.EntityType.ThreadEntity:
					toReturn = this.Thread;
					break;
				case SD.HnD.DAL.EntityType.ThreadSubscriptionEntity:
					toReturn = this.ThreadSubscription;
					break;
				case SD.HnD.DAL.EntityType.UserEntity:
					toReturn = this.User;
					break;
				case SD.HnD.DAL.EntityType.UserTitleEntity:
					toReturn = this.UserTitle;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting ActionRightEntity instances in the database.</summary>
		public DataSource<ActionRightEntity> ActionRight
		{
			get { return new DataSource<ActionRightEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting AttachmentEntity instances in the database.</summary>
		public DataSource<AttachmentEntity> Attachment
		{
			get { return new DataSource<AttachmentEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting AuditActionEntity instances in the database.</summary>
		public DataSource<AuditActionEntity> AuditAction
		{
			get { return new DataSource<AuditActionEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting AuditDataCoreEntity instances in the database.</summary>
		public DataSource<AuditDataCoreEntity> AuditDataCore
		{
			get { return new DataSource<AuditDataCoreEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting AuditDataMessageRelatedEntity instances in the database.</summary>
		public DataSource<AuditDataMessageRelatedEntity> AuditDataMessageRelated
		{
			get { return new DataSource<AuditDataMessageRelatedEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting AuditDataThreadRelatedEntity instances in the database.</summary>
		public DataSource<AuditDataThreadRelatedEntity> AuditDataThreadRelated
		{
			get { return new DataSource<AuditDataThreadRelatedEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting BookmarkEntity instances in the database.</summary>
		public DataSource<BookmarkEntity> Bookmark
		{
			get { return new DataSource<BookmarkEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ForumEntity instances in the database.</summary>
		public DataSource<ForumEntity> Forum
		{
			get { return new DataSource<ForumEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ForumRoleForumActionRightEntity instances in the database.</summary>
		public DataSource<ForumRoleForumActionRightEntity> ForumRoleForumActionRight
		{
			get { return new DataSource<ForumRoleForumActionRightEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting IPBanEntity instances in the database.</summary>
		public DataSource<IPBanEntity> IPBan
		{
			get { return new DataSource<IPBanEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting MessageEntity instances in the database.</summary>
		public DataSource<MessageEntity> Message
		{
			get { return new DataSource<MessageEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting RoleEntity instances in the database.</summary>
		public DataSource<RoleEntity> Role
		{
			get { return new DataSource<RoleEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting RoleAuditActionEntity instances in the database.</summary>
		public DataSource<RoleAuditActionEntity> RoleAuditAction
		{
			get { return new DataSource<RoleAuditActionEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting RoleSystemActionRightEntity instances in the database.</summary>
		public DataSource<RoleSystemActionRightEntity> RoleSystemActionRight
		{
			get { return new DataSource<RoleSystemActionRightEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting RoleUserEntity instances in the database.</summary>
		public DataSource<RoleUserEntity> RoleUser
		{
			get { return new DataSource<RoleUserEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SectionEntity instances in the database.</summary>
		public DataSource<SectionEntity> Section
		{
			get { return new DataSource<SectionEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SupportQueueEntity instances in the database.</summary>
		public DataSource<SupportQueueEntity> SupportQueue
		{
			get { return new DataSource<SupportQueueEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SupportQueueThreadEntity instances in the database.</summary>
		public DataSource<SupportQueueThreadEntity> SupportQueueThread
		{
			get { return new DataSource<SupportQueueThreadEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SystemDataEntity instances in the database.</summary>
		public DataSource<SystemDataEntity> SystemData
		{
			get { return new DataSource<SystemDataEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ThreadEntity instances in the database.</summary>
		public DataSource<ThreadEntity> Thread
		{
			get { return new DataSource<ThreadEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ThreadSubscriptionEntity instances in the database.</summary>
		public DataSource<ThreadSubscriptionEntity> ThreadSubscription
		{
			get { return new DataSource<ThreadSubscriptionEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource<UserEntity> User
		{
			get { return new DataSource<UserEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserTitleEntity instances in the database.</summary>
		public DataSource<UserTitleEntity> UserTitle
		{
			get { return new DataSource<UserTitleEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		#region Class Property Declarations
		/// <summary> Gets / sets the ITransaction to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public ITransaction TransactionToUse
		{
			get { return _transactionToUse;}
			set { _transactionToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}