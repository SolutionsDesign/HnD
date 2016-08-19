///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.0
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Linq;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.RelationClasses;

namespace SD.HnD.DALAdapter.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData: ILinqMetaData
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapterToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null)
		{
		}

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			_adapterToUse = adapterToUse;
			_customFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((SD.HnD.DALAdapter.EntityType)typeOfEntity)
			{
				case SD.HnD.DALAdapter.EntityType.ActionRightEntity:
					toReturn = this.ActionRight;
					break;
				case SD.HnD.DALAdapter.EntityType.AttachmentEntity:
					toReturn = this.Attachment;
					break;
				case SD.HnD.DALAdapter.EntityType.AuditActionEntity:
					toReturn = this.AuditAction;
					break;
				case SD.HnD.DALAdapter.EntityType.AuditDataCoreEntity:
					toReturn = this.AuditDataCore;
					break;
				case SD.HnD.DALAdapter.EntityType.AuditDataMessageRelatedEntity:
					toReturn = this.AuditDataMessageRelated;
					break;
				case SD.HnD.DALAdapter.EntityType.AuditDataThreadRelatedEntity:
					toReturn = this.AuditDataThreadRelated;
					break;
				case SD.HnD.DALAdapter.EntityType.BookmarkEntity:
					toReturn = this.Bookmark;
					break;
				case SD.HnD.DALAdapter.EntityType.ForumEntity:
					toReturn = this.Forum;
					break;
				case SD.HnD.DALAdapter.EntityType.ForumRoleForumActionRightEntity:
					toReturn = this.ForumRoleForumActionRight;
					break;
				case SD.HnD.DALAdapter.EntityType.IPBanEntity:
					toReturn = this.IPBan;
					break;
				case SD.HnD.DALAdapter.EntityType.MessageEntity:
					toReturn = this.Message;
					break;
				case SD.HnD.DALAdapter.EntityType.RoleEntity:
					toReturn = this.Role;
					break;
				case SD.HnD.DALAdapter.EntityType.RoleAuditActionEntity:
					toReturn = this.RoleAuditAction;
					break;
				case SD.HnD.DALAdapter.EntityType.RoleSystemActionRightEntity:
					toReturn = this.RoleSystemActionRight;
					break;
				case SD.HnD.DALAdapter.EntityType.RoleUserEntity:
					toReturn = this.RoleUser;
					break;
				case SD.HnD.DALAdapter.EntityType.SectionEntity:
					toReturn = this.Section;
					break;
				case SD.HnD.DALAdapter.EntityType.SupportQueueEntity:
					toReturn = this.SupportQueue;
					break;
				case SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity:
					toReturn = this.SupportQueueThread;
					break;
				case SD.HnD.DALAdapter.EntityType.SystemDataEntity:
					toReturn = this.SystemData;
					break;
				case SD.HnD.DALAdapter.EntityType.ThreadEntity:
					toReturn = this.Thread;
					break;
				case SD.HnD.DALAdapter.EntityType.ThreadSubscriptionEntity:
					toReturn = this.ThreadSubscription;
					break;
				case SD.HnD.DALAdapter.EntityType.UserEntity:
					toReturn = this.User;
					break;
				case SD.HnD.DALAdapter.EntityType.UserTitleEntity:
					toReturn = this.UserTitle;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <typeparam name="TEntity">the type of the entity to get the datasource for</typeparam>
		/// <returns>the requested datasource</returns>
		public DataSource2<TEntity> GetQueryableForEntity<TEntity>()
			    where TEntity : class
		{
    		return new DataSource2<TEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse);
		}

		/// <summary>returns the datasource to use in a Linq query when targeting ActionRightEntity instances in the database.</summary>
		public DataSource2<ActionRightEntity> ActionRight
		{
			get { return new DataSource2<ActionRightEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AttachmentEntity instances in the database.</summary>
		public DataSource2<AttachmentEntity> Attachment
		{
			get { return new DataSource2<AttachmentEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AuditActionEntity instances in the database.</summary>
		public DataSource2<AuditActionEntity> AuditAction
		{
			get { return new DataSource2<AuditActionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AuditDataCoreEntity instances in the database.</summary>
		public DataSource2<AuditDataCoreEntity> AuditDataCore
		{
			get { return new DataSource2<AuditDataCoreEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AuditDataMessageRelatedEntity instances in the database.</summary>
		public DataSource2<AuditDataMessageRelatedEntity> AuditDataMessageRelated
		{
			get { return new DataSource2<AuditDataMessageRelatedEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting AuditDataThreadRelatedEntity instances in the database.</summary>
		public DataSource2<AuditDataThreadRelatedEntity> AuditDataThreadRelated
		{
			get { return new DataSource2<AuditDataThreadRelatedEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting BookmarkEntity instances in the database.</summary>
		public DataSource2<BookmarkEntity> Bookmark
		{
			get { return new DataSource2<BookmarkEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ForumEntity instances in the database.</summary>
		public DataSource2<ForumEntity> Forum
		{
			get { return new DataSource2<ForumEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ForumRoleForumActionRightEntity instances in the database.</summary>
		public DataSource2<ForumRoleForumActionRightEntity> ForumRoleForumActionRight
		{
			get { return new DataSource2<ForumRoleForumActionRightEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting IPBanEntity instances in the database.</summary>
		public DataSource2<IPBanEntity> IPBan
		{
			get { return new DataSource2<IPBanEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MessageEntity instances in the database.</summary>
		public DataSource2<MessageEntity> Message
		{
			get { return new DataSource2<MessageEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleEntity instances in the database.</summary>
		public DataSource2<RoleEntity> Role
		{
			get { return new DataSource2<RoleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleAuditActionEntity instances in the database.</summary>
		public DataSource2<RoleAuditActionEntity> RoleAuditAction
		{
			get { return new DataSource2<RoleAuditActionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleSystemActionRightEntity instances in the database.</summary>
		public DataSource2<RoleSystemActionRightEntity> RoleSystemActionRight
		{
			get { return new DataSource2<RoleSystemActionRightEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting RoleUserEntity instances in the database.</summary>
		public DataSource2<RoleUserEntity> RoleUser
		{
			get { return new DataSource2<RoleUserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SectionEntity instances in the database.</summary>
		public DataSource2<SectionEntity> Section
		{
			get { return new DataSource2<SectionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SupportQueueEntity instances in the database.</summary>
		public DataSource2<SupportQueueEntity> SupportQueue
		{
			get { return new DataSource2<SupportQueueEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SupportQueueThreadEntity instances in the database.</summary>
		public DataSource2<SupportQueueThreadEntity> SupportQueueThread
		{
			get { return new DataSource2<SupportQueueThreadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting SystemDataEntity instances in the database.</summary>
		public DataSource2<SystemDataEntity> SystemData
		{
			get { return new DataSource2<SystemDataEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ThreadEntity instances in the database.</summary>
		public DataSource2<ThreadEntity> Thread
		{
			get { return new DataSource2<ThreadEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting ThreadSubscriptionEntity instances in the database.</summary>
		public DataSource2<ThreadSubscriptionEntity> ThreadSubscription
		{
			get { return new DataSource2<ThreadSubscriptionEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource2<UserEntity> User
		{
			get { return new DataSource2<UserEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting UserTitleEntity instances in the database.</summary>
		public DataSource2<UserTitleEntity> UserTitle
		{
			get { return new DataSource2<UserTitleEntity>(_adapterToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		

		#region Class Property Declarations
		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse
		{
			get { return _adapterToUse;}
			set { _adapterToUse = value;}
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