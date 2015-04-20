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
using System.Data;
using System.Collections;
using System.Runtime.Serialization;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;


namespace SD.HnD.DAL.TypedListClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Typed datatable for the list 'ForumMessages'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class ForumMessagesTypedList : TypedListBase<ForumMessagesRow>
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesList
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnMessageID;
		private DataColumn _columnPostingDate;
		private DataColumn _columnMessageTextAsHTML;
		private DataColumn _columnThreadID;
		private DataColumn _columnSubject;
		private DataColumn _columnEmailAddress;
		private DataColumn _columnEmailAddressIsPublic;
		private DataColumn _columnNickName;
		private DataColumn _columnMessageText;
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		#endregion

		#region Class Constants
		private const int AmountOfFields = 9;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static ForumMessagesTypedList()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary>CTor</summary>
		public ForumMessagesTypedList():base("ForumMessages")
		{
			InitClass(false);
		}
		
		/// <summary>CTor</summary>
		/// <param name="obeyWeakRelations">The flag to signal the typed list what kind of join statements to generate in the query statement. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order. When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.</param>
		public ForumMessagesTypedList(bool obeyWeakRelations):base("ForumMessages")
		{
			InitClass(obeyWeakRelations);
		}

		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ForumMessagesTypedList(SerializationInfo info, StreamingContext context):base(info, context)
		{
			InitMembers();
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			ForumMessagesTypedList cloneToReturn = ((ForumMessagesTypedList)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}
				
		/// <summary>Gets the QuerySpec query which fetches this typed list.</summary>
		/// <param name="qf">The queryfactory.</param>
		/// <returns>ready to use DynamicQuery instance to be used with FetchAsDataTable in the QuerySpec API</returns>
		public DynamicQuery GetQuerySpecQuery(QueryFactory qf)
		{
			return qf.Create().Select(this.BuildResultset().GetAsEntityFieldCoreArray()).From(this.BuildRelationSet());
		}

		/// <summary>Creates a new TypedList dao instance</summary>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateTypedListDAO();
		}

		/// <summary>Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.</summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new ForumMessagesRow(rowBuilder);
		}

		/// <summary>Builds the relation set for this typed list.</summary>
		/// <returns>ready to use relation set</returns>
		protected override IRelationCollection BuildRelationSet()
		{
			IRelationCollection toReturn = new RelationCollection();
			toReturn.ObeyWeakRelations = this.ObeyWeakRelations;
			toReturn.Add(ThreadEntity.Relations.MessageEntityUsingThreadID, "", "", JoinHint.Inner);
			toReturn.Add(UserEntity.Relations.MessageEntityUsingPostedByUserID, "", "", JoinHint.Inner);
			toReturn.Add(ForumEntity.Relations.ThreadEntityUsingForumID, "", "", JoinHint.Inner);
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalRelations
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnRelationSetBuilt(toReturn);
			return toReturn;
		}

		/// <summary>Builds the resultset fields.</summary>
		/// <returns>ready to use resultset</returns>
		protected override IEntityFields BuildResultset()
		{
			ResultsetFields toReturn = new ResultsetFields(AmountOfFields);
			toReturn.DefineField(MessageFields.MessageID, 0, "MessageID", "", AggregateFunction.None);
			toReturn.DefineField(MessageFields.PostingDate, 1, "PostingDate", "", AggregateFunction.None);
			toReturn.DefineField(MessageFields.MessageTextAsHTML, 2, "MessageTextAsHTML", "", AggregateFunction.None);
			toReturn.DefineField(MessageFields.ThreadID, 3, "ThreadID", "", AggregateFunction.None);
			toReturn.DefineField(ThreadFields.Subject, 4, "Subject", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.EmailAddress, 5, "EmailAddress", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.EmailAddressIsPublic, 6, "EmailAddressIsPublic", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.NickName, 7, "NickName", "", AggregateFunction.None);
			toReturn.DefineField(MessageFields.MessageText, 8, "MessageText", "", AggregateFunction.None);
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call toReturn.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnResultsetBuilt(toReturn);
			return toReturn;
		}

		/// <summary>Initializes the hashtables for the typed list type and typed list field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Hashtable();
			_fieldsCustomProperties = new Hashtable();
			Hashtable fieldHashtable = null;
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("MessageID", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("PostingDate", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("MessageTextAsHTML", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Subject", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmailAddress", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmailAddressIsPublic", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("NickName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("MessageText", fieldHashtable);
		}

		/// <summary>Initialize the datastructures.</summary>
		/// <param name="obeyWeakRelations">flag for the internal used relations object</param>
		protected override void InitClass(bool obeyWeakRelations)
		{
			_columnMessageID = GeneralUtils.CreateTypedDataTableColumn("MessageID", @"MessageID", typeof(System.Int32), this.Columns);
			_columnPostingDate = GeneralUtils.CreateTypedDataTableColumn("PostingDate", @"PostingDate", typeof(System.DateTime), this.Columns);
			_columnMessageTextAsHTML = GeneralUtils.CreateTypedDataTableColumn("MessageTextAsHTML", @"MessageTextAsHTML", typeof(System.String), this.Columns);
			_columnThreadID = GeneralUtils.CreateTypedDataTableColumn("ThreadID", @"ThreadID", typeof(System.Int32), this.Columns);
			_columnSubject = GeneralUtils.CreateTypedDataTableColumn("Subject", @"Subject", typeof(System.String), this.Columns);
			_columnEmailAddress = GeneralUtils.CreateTypedDataTableColumn("EmailAddress", @"EmailAddress", typeof(System.String), this.Columns);
			_columnEmailAddressIsPublic = GeneralUtils.CreateTypedDataTableColumn("EmailAddressIsPublic", @"EmailAddressIsPublic", typeof(System.Boolean), this.Columns);
			_columnNickName = GeneralUtils.CreateTypedDataTableColumn("NickName", @"NickName", typeof(System.String), this.Columns);
			_columnMessageText = GeneralUtils.CreateTypedDataTableColumn("MessageText", @"MessageText", typeof(System.String), this.Columns);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
			this.ObeyWeakRelations = obeyWeakRelations;
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnMessageID = this.Columns["MessageID"];
			_columnPostingDate = this.Columns["PostingDate"];
			_columnMessageTextAsHTML = this.Columns["MessageTextAsHTML"];
			_columnThreadID = this.Columns["ThreadID"];
			_columnSubject = this.Columns["Subject"];
			_columnEmailAddress = this.Columns["EmailAddress"];
			_columnEmailAddressIsPublic = this.Columns["EmailAddressIsPublic"];
			_columnNickName = this.Columns["NickName"];
			_columnMessageText = this.Columns["MessageText"];

			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new ForumMessagesTypedList();
		}

		#region Class Property Declarations
		/// <summary>The custom properties for this TypedList type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary>The custom properties for the type of this TypedList instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false)]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return ForumMessagesTypedList.CustomProperties;}
		}

		/// <summary>The custom properties for the fields of this TypedList type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary>The custom properties for the fields of the type of this TypedList instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false)]
		public virtual Hashtable FieldsCustomPropertiesOfType
		{
			get { return ForumMessagesTypedList.FieldsCustomProperties;}
		}

		/// <summary>Returns the column object belonging to the TypedList field MessageID</summary>
		internal DataColumn MessageIDColumn 
		{
			get { return _columnMessageID; }
		}

		/// <summary>Returns the column object belonging to the TypedList field PostingDate</summary>
		internal DataColumn PostingDateColumn 
		{
			get { return _columnPostingDate; }
		}

		/// <summary>Returns the column object belonging to the TypedList field MessageTextAsHTML</summary>
		internal DataColumn MessageTextAsHTMLColumn 
		{
			get { return _columnMessageTextAsHTML; }
		}

		/// <summary>Returns the column object belonging to the TypedList field ThreadID</summary>
		internal DataColumn ThreadIDColumn 
		{
			get { return _columnThreadID; }
		}

		/// <summary>Returns the column object belonging to the TypedList field Subject</summary>
		internal DataColumn SubjectColumn 
		{
			get { return _columnSubject; }
		}

		/// <summary>Returns the column object belonging to the TypedList field EmailAddress</summary>
		internal DataColumn EmailAddressColumn 
		{
			get { return _columnEmailAddress; }
		}

		/// <summary>Returns the column object belonging to the TypedList field EmailAddressIsPublic</summary>
		internal DataColumn EmailAddressIsPublicColumn 
		{
			get { return _columnEmailAddressIsPublic; }
		}

		/// <summary>Returns the column object belonging to the TypedList field NickName</summary>
		internal DataColumn NickNameColumn 
		{
			get { return _columnNickName; }
		}

		/// <summary>Returns the column object belonging to the TypedList field MessageText</summary>
		internal DataColumn MessageTextColumn 
		{
			get { return _columnMessageText; }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalColumnProperties
		// __LLBLGENPRO_USER_CODE_REGION_END
 		#endregion
		
		#region Custom TypedList code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedListCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included Code

		#endregion
	}

	/// <summary>Typed datarow for the typed datatable ForumMessages</summary>
	public partial class ForumMessagesRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private ForumMessagesTypedList	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal ForumMessagesRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((ForumMessagesTypedList)(this.Table));
		}

		#region Class Property Declarations
		/// <summary>Gets / sets the value of the TypedList field MessageID<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Message.MessageID</remarks>
		public System.Int32 MessageID 
		{
			get { return IsMessageIDNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.MessageIDColumn]; }
			set { this[_parent.MessageIDColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field MessageID is NULL, false otherwise.</summary>
		public bool IsMessageIDNull() 
		{
			return IsNull(_parent.MessageIDColumn);
		}

		/// <summary>Sets the TypedList field MessageID to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetMessageIDNull() 
		{
			this[_parent.MessageIDColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field PostingDate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Message.PostingDate</remarks>
		public System.DateTime PostingDate 
		{
			get { return IsPostingDateNull() ? (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)) : (System.DateTime)this[_parent.PostingDateColumn]; }
			set { this[_parent.PostingDateColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field PostingDate is NULL, false otherwise.</summary>
		public bool IsPostingDateNull() 
		{
			return IsNull(_parent.PostingDateColumn);
		}

		/// <summary>Sets the TypedList field PostingDate to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetPostingDateNull() 
		{
			this[_parent.PostingDateColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field MessageTextAsHTML<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Message.MessageTextAsHTML</remarks>
		public System.String MessageTextAsHTML 
		{
			get { return IsMessageTextAsHTMLNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.MessageTextAsHTMLColumn]; }
			set { this[_parent.MessageTextAsHTMLColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field MessageTextAsHTML is NULL, false otherwise.</summary>
		public bool IsMessageTextAsHTMLNull() 
		{
			return IsNull(_parent.MessageTextAsHTMLColumn);
		}

		/// <summary>Sets the TypedList field MessageTextAsHTML to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetMessageTextAsHTMLNull() 
		{
			this[_parent.MessageTextAsHTMLColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field ThreadID<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Message.ThreadID</remarks>
		public System.Int32 ThreadID 
		{
			get { return IsThreadIDNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.ThreadIDColumn]; }
			set { this[_parent.ThreadIDColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field ThreadID is NULL, false otherwise.</summary>
		public bool IsThreadIDNull() 
		{
			return IsNull(_parent.ThreadIDColumn);
		}

		/// <summary>Sets the TypedList field ThreadID to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetThreadIDNull() 
		{
			this[_parent.ThreadIDColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field Subject<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Thread.Subject</remarks>
		public System.String Subject 
		{
			get { return IsSubjectNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.SubjectColumn]; }
			set { this[_parent.SubjectColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field Subject is NULL, false otherwise.</summary>
		public bool IsSubjectNull() 
		{
			return IsNull(_parent.SubjectColumn);
		}

		/// <summary>Sets the TypedList field Subject to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetSubjectNull() 
		{
			this[_parent.SubjectColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field EmailAddress<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.EmailAddress</remarks>
		public System.String EmailAddress 
		{
			get { return IsEmailAddressNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.EmailAddressColumn]; }
			set { this[_parent.EmailAddressColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field EmailAddress is NULL, false otherwise.</summary>
		public bool IsEmailAddressNull() 
		{
			return IsNull(_parent.EmailAddressColumn);
		}

		/// <summary>Sets the TypedList field EmailAddress to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmailAddressNull() 
		{
			this[_parent.EmailAddressColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field EmailAddressIsPublic<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.EmailAddressIsPublic</remarks>
		public System.Boolean EmailAddressIsPublic 
		{
			get { return IsEmailAddressIsPublicNull() ? (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean)) : (System.Boolean)this[_parent.EmailAddressIsPublicColumn]; }
			set { this[_parent.EmailAddressIsPublicColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field EmailAddressIsPublic is NULL, false otherwise.</summary>
		public bool IsEmailAddressIsPublicNull() 
		{
			return IsNull(_parent.EmailAddressIsPublicColumn);
		}

		/// <summary>Sets the TypedList field EmailAddressIsPublic to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmailAddressIsPublicNull() 
		{
			this[_parent.EmailAddressIsPublicColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field NickName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.NickName</remarks>
		public System.String NickName 
		{
			get { return IsNickNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.NickNameColumn]; }
			set { this[_parent.NickNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field NickName is NULL, false otherwise.</summary>
		public bool IsNickNameNull() 
		{
			return IsNull(_parent.NickNameColumn);
		}

		/// <summary>Sets the TypedList field NickName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetNickNameNull() 
		{
			this[_parent.NickNameColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field MessageText<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Message.MessageText</remarks>
		public System.String MessageText 
		{
			get { return IsMessageTextNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.MessageTextColumn]; }
			set { this[_parent.MessageTextColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field MessageText is NULL, false otherwise.</summary>
		public bool IsMessageTextNull() 
		{
			return IsNull(_parent.MessageTextColumn);
		}

		/// <summary>Sets the TypedList field MessageText to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetMessageTextNull() 
		{
			this[_parent.MessageTextColumn] = System.Convert.DBNull;
		}
		#endregion

		#region Custom Typed List Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedListRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Included Row Code

		#endregion	
	}
}
