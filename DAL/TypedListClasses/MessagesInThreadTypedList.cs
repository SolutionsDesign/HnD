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
using System.Data;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.DaoClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.TypedListClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Typed datatable for the list 'MessagesInThread'.<br/><br/></summary>
#if !CF	
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
#endif
	public partial class MessagesInThreadTypedList : TypedListBase<MessagesInThreadRow>
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesList
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnMessageID;
		private DataColumn _columnPostingDate;
		private DataColumn _columnMessageTextAsHTML;
		private DataColumn _columnThreadID;
		private DataColumn _columnPostedFromIP;
		private DataColumn _columnUserID;
		private DataColumn _columnNickName;
		private DataColumn _columnSignatureAsHTML;
		private DataColumn _columnIconURL;
		private DataColumn _columnLocation;
		private DataColumn _columnJoinDate;
		private DataColumn _columnAmountOfPostings;
		private DataColumn _columnUserTitleDescription;
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		#endregion

		#region Class Constants
		private const int AmountOfFields = 13;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static MessagesInThreadTypedList()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary>CTor</summary>
		public MessagesInThreadTypedList():base("MessagesInThread")
		{
			InitClass(false);
		}
		
		/// <summary>CTor</summary>
		/// <param name="obeyWeakRelations">The flag to signal the typed list what kind of join statements to generate in the query statement. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order. When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.</param>
		public MessagesInThreadTypedList(bool obeyWeakRelations):base("MessagesInThread")
		{
			InitClass(obeyWeakRelations);
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MessagesInThreadTypedList(SerializationInfo info, StreamingContext context):base(info, context)
		{
			InitMembers();
		}
#endif		

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			MessagesInThreadTypedList cloneToReturn = ((MessagesInThreadTypedList)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
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
			return new MessagesInThreadRow(rowBuilder);
		}

		/// <summary>Builds the relation set for this typed list.</summary>
		/// <returns>ready to use relation set</returns>
		protected override IRelationCollection BuildRelationSet()
		{
			IRelationCollection toReturn = new RelationCollection();
			toReturn.ObeyWeakRelations = this.ObeyWeakRelations;
			toReturn.Add(UserEntity.Relations.MessageEntityUsingPostedByUserID, "", "", JoinHint.Right);
			toReturn.Add(UserTitleEntity.Relations.UserEntityUsingUserTitleID, "", "", JoinHint.Inner);
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
			toReturn.DefineField(MessageFields.PostedFromIP, 4, "PostedFromIP", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.UserID, 5, "UserID", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.NickName, 6, "NickName", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.SignatureAsHTML, 7, "SignatureAsHTML", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.IconURL, 8, "IconURL", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.Location, 9, "Location", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.JoinDate, 10, "JoinDate", "", AggregateFunction.None);
			toReturn.DefineField(UserFields.AmountOfPostings, 11, "AmountOfPostings", "", AggregateFunction.None);
			toReturn.DefineField(UserTitleFields.UserTitleDescription, 12, "UserTitleDescription", "", AggregateFunction.None);
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
			_fieldsCustomProperties.Add("PostedFromIP", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("UserID", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("NickName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("SignatureAsHTML", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("IconURL", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Location", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("JoinDate", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("AmountOfPostings", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("UserTitleDescription", fieldHashtable);
		}

		/// <summary>Initialize the datastructures.</summary>
		/// <param name="obeyWeakRelations">flag for the internal used relations object</param>
		protected override void InitClass(bool obeyWeakRelations)
		{
			_columnMessageID = GeneralUtils.CreateTypedDataTableColumn("MessageID", @"MessageID", typeof(System.Int32), this.Columns);
			_columnPostingDate = GeneralUtils.CreateTypedDataTableColumn("PostingDate", @"PostingDate", typeof(System.DateTime), this.Columns);
			_columnMessageTextAsHTML = GeneralUtils.CreateTypedDataTableColumn("MessageTextAsHTML", @"MessageTextAsHTML", typeof(System.String), this.Columns);
			_columnThreadID = GeneralUtils.CreateTypedDataTableColumn("ThreadID", @"ThreadID", typeof(System.Int32), this.Columns);
			_columnPostedFromIP = GeneralUtils.CreateTypedDataTableColumn("PostedFromIP", @"PostedFromIP", typeof(System.String), this.Columns);
			_columnUserID = GeneralUtils.CreateTypedDataTableColumn("UserID", @"UserID", typeof(System.Int32), this.Columns);
			_columnNickName = GeneralUtils.CreateTypedDataTableColumn("NickName", @"NickName", typeof(System.String), this.Columns);
			_columnSignatureAsHTML = GeneralUtils.CreateTypedDataTableColumn("SignatureAsHTML", @"SignatureAsHTML", typeof(System.String), this.Columns);
			_columnIconURL = GeneralUtils.CreateTypedDataTableColumn("IconURL", @"IconURL", typeof(System.String), this.Columns);
			_columnLocation = GeneralUtils.CreateTypedDataTableColumn("Location", @"Location", typeof(System.String), this.Columns);
			_columnJoinDate = GeneralUtils.CreateTypedDataTableColumn("JoinDate", @"JoinDate", typeof(System.DateTime), this.Columns);
			_columnAmountOfPostings = GeneralUtils.CreateTypedDataTableColumn("AmountOfPostings", @"AmountOfPostings", typeof(System.Int32), this.Columns);
			_columnUserTitleDescription = GeneralUtils.CreateTypedDataTableColumn("UserTitleDescription", @"UserTitleDescription", typeof(System.String), this.Columns);

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
			_columnPostedFromIP = this.Columns["PostedFromIP"];
			_columnUserID = this.Columns["UserID"];
			_columnNickName = this.Columns["NickName"];
			_columnSignatureAsHTML = this.Columns["SignatureAsHTML"];
			_columnIconURL = this.Columns["IconURL"];
			_columnLocation = this.Columns["Location"];
			_columnJoinDate = this.Columns["JoinDate"];
			_columnAmountOfPostings = this.Columns["AmountOfPostings"];
			_columnUserTitleDescription = this.Columns["UserTitleDescription"];

			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}
#if !CF
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new MessagesInThreadTypedList();
		}
#endif
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
			get { return MessagesInThreadTypedList.CustomProperties;}
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
			get { return MessagesInThreadTypedList.FieldsCustomProperties;}
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

		/// <summary>Returns the column object belonging to the TypedList field PostedFromIP</summary>
		internal DataColumn PostedFromIPColumn 
		{
			get { return _columnPostedFromIP; }
		}

		/// <summary>Returns the column object belonging to the TypedList field UserID</summary>
		internal DataColumn UserIDColumn 
		{
			get { return _columnUserID; }
		}

		/// <summary>Returns the column object belonging to the TypedList field NickName</summary>
		internal DataColumn NickNameColumn 
		{
			get { return _columnNickName; }
		}

		/// <summary>Returns the column object belonging to the TypedList field SignatureAsHTML</summary>
		internal DataColumn SignatureAsHTMLColumn 
		{
			get { return _columnSignatureAsHTML; }
		}

		/// <summary>Returns the column object belonging to the TypedList field IconURL</summary>
		internal DataColumn IconURLColumn 
		{
			get { return _columnIconURL; }
		}

		/// <summary>Returns the column object belonging to the TypedList field Location</summary>
		internal DataColumn LocationColumn 
		{
			get { return _columnLocation; }
		}

		/// <summary>Returns the column object belonging to the TypedList field JoinDate</summary>
		internal DataColumn JoinDateColumn 
		{
			get { return _columnJoinDate; }
		}

		/// <summary>Returns the column object belonging to the TypedList field AmountOfPostings</summary>
		internal DataColumn AmountOfPostingsColumn 
		{
			get { return _columnAmountOfPostings; }
		}

		/// <summary>Returns the column object belonging to the TypedList field UserTitleDescription</summary>
		internal DataColumn UserTitleDescriptionColumn 
		{
			get { return _columnUserTitleDescription; }
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

	/// <summary>Typed datarow for the typed datatable MessagesInThread</summary>
	public partial class MessagesInThreadRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private MessagesInThreadTypedList	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal MessagesInThreadRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((MessagesInThreadTypedList)(this.Table));
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
		/// <summary>Gets / sets the value of the TypedList field PostedFromIP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Message.PostedFromIP</remarks>
		public System.String PostedFromIP 
		{
			get { return IsPostedFromIPNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.PostedFromIPColumn]; }
			set { this[_parent.PostedFromIPColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field PostedFromIP is NULL, false otherwise.</summary>
		public bool IsPostedFromIPNull() 
		{
			return IsNull(_parent.PostedFromIPColumn);
		}

		/// <summary>Sets the TypedList field PostedFromIP to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetPostedFromIPNull() 
		{
			this[_parent.PostedFromIPColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field UserID<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.UserID</remarks>
		public System.Int32 UserID 
		{
			get { return IsUserIDNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.UserIDColumn]; }
			set { this[_parent.UserIDColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field UserID is NULL, false otherwise.</summary>
		public bool IsUserIDNull() 
		{
			return IsNull(_parent.UserIDColumn);
		}

		/// <summary>Sets the TypedList field UserID to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetUserIDNull() 
		{
			this[_parent.UserIDColumn] = System.Convert.DBNull;
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
		/// <summary>Gets / sets the value of the TypedList field SignatureAsHTML<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.SignatureAsHTML</remarks>
		public System.String SignatureAsHTML 
		{
			get { return IsSignatureAsHTMLNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.SignatureAsHTMLColumn]; }
			set { this[_parent.SignatureAsHTMLColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field SignatureAsHTML is NULL, false otherwise.</summary>
		public bool IsSignatureAsHTMLNull() 
		{
			return IsNull(_parent.SignatureAsHTMLColumn);
		}

		/// <summary>Sets the TypedList field SignatureAsHTML to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetSignatureAsHTMLNull() 
		{
			this[_parent.SignatureAsHTMLColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field IconURL<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.IconURL</remarks>
		public System.String IconURL 
		{
			get { return IsIconURLNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.IconURLColumn]; }
			set { this[_parent.IconURLColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field IconURL is NULL, false otherwise.</summary>
		public bool IsIconURLNull() 
		{
			return IsNull(_parent.IconURLColumn);
		}

		/// <summary>Sets the TypedList field IconURL to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetIconURLNull() 
		{
			this[_parent.IconURLColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field Location<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.Location</remarks>
		public System.String Location 
		{
			get { return IsLocationNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.LocationColumn]; }
			set { this[_parent.LocationColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field Location is NULL, false otherwise.</summary>
		public bool IsLocationNull() 
		{
			return IsNull(_parent.LocationColumn);
		}

		/// <summary>Sets the TypedList field Location to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetLocationNull() 
		{
			this[_parent.LocationColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field JoinDate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.JoinDate</remarks>
		public System.DateTime JoinDate 
		{
			get { return IsJoinDateNull() ? (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)) : (System.DateTime)this[_parent.JoinDateColumn]; }
			set { this[_parent.JoinDateColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field JoinDate is NULL, false otherwise.</summary>
		public bool IsJoinDateNull() 
		{
			return IsNull(_parent.JoinDateColumn);
		}

		/// <summary>Sets the TypedList field JoinDate to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetJoinDateNull() 
		{
			this[_parent.JoinDateColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field AmountOfPostings<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: User.AmountOfPostings</remarks>
		public System.Int32 AmountOfPostings 
		{
			get { return IsAmountOfPostingsNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.AmountOfPostingsColumn]; }
			set { this[_parent.AmountOfPostingsColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field AmountOfPostings is NULL, false otherwise.</summary>
		public bool IsAmountOfPostingsNull() 
		{
			return IsNull(_parent.AmountOfPostingsColumn);
		}

		/// <summary>Sets the TypedList field AmountOfPostings to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetAmountOfPostingsNull() 
		{
			this[_parent.AmountOfPostingsColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field UserTitleDescription<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: UserTitle.UserTitleDescription</remarks>
		public System.String UserTitleDescription 
		{
			get { return IsUserTitleDescriptionNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.UserTitleDescriptionColumn]; }
			set { this[_parent.UserTitleDescriptionColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field UserTitleDescription is NULL, false otherwise.</summary>
		public bool IsUserTitleDescriptionNull() 
		{
			return IsNull(_parent.UserTitleDescriptionColumn);
		}

		/// <summary>Sets the TypedList field UserTitleDescription to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetUserTitleDescriptionNull() 
		{
			this[_parent.UserTitleDescriptionColumn] = System.Convert.DBNull;
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
