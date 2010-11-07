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
	/// <summary>Typed datatable for the list 'SearchResult'.<br/><br/></summary>
#if !CF	
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
#endif
	public partial class SearchResultTypedList : TypedListBase<SearchResultRow>
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesList
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnThreadID;
		private DataColumn _columnSubject;
		private DataColumn _columnForumName;
		private DataColumn _columnSectionName;
		private DataColumn _columnThreadLastPostingDate;
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		#endregion

		#region Class Constants
		private const int AmountOfFields = 5;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static SearchResultTypedList()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary>CTor</summary>
		public SearchResultTypedList():base("SearchResult")
		{
			InitClass(false);
		}
		
		/// <summary>CTor</summary>
		/// <param name="obeyWeakRelations">The flag to signal the typed list what kind of join statements to generate in the query statement. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order. When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.</param>
		public SearchResultTypedList(bool obeyWeakRelations):base("SearchResult")
		{
			InitClass(obeyWeakRelations);
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SearchResultTypedList(SerializationInfo info, StreamingContext context):base(info, context)
		{
			InitMembers();
		}
#endif		

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			SearchResultTypedList cloneToReturn = ((SearchResultTypedList)(base.Clone()));
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
			return new SearchResultRow(rowBuilder);
		}

		/// <summary>Builds the relation set for this typed list.</summary>
		/// <returns>ready to use relation set</returns>
		protected override IRelationCollection BuildRelationSet()
		{
			IRelationCollection toReturn = new RelationCollection();
			toReturn.ObeyWeakRelations = this.ObeyWeakRelations;
			toReturn.Add(ThreadEntity.Relations.MessageEntityUsingThreadID, "", "", JoinHint.Inner);
			toReturn.Add(ForumEntity.Relations.ThreadEntityUsingForumID, "", "", JoinHint.Inner);
			toReturn.Add(SectionEntity.Relations.ForumEntityUsingSectionID, "", "", JoinHint.Inner);
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
			toReturn.DefineField(ThreadFields.ThreadID, 0, "ThreadID", "", AggregateFunction.None);
			toReturn.DefineField(ThreadFields.Subject, 1, "Subject", "", AggregateFunction.None);
			toReturn.DefineField(ForumFields.ForumName, 2, "ForumName", "", AggregateFunction.None);
			toReturn.DefineField(SectionFields.SectionName, 3, "SectionName", "", AggregateFunction.None);
			toReturn.DefineField(ThreadFields.ThreadLastPostingDate, 4, "ThreadLastPostingDate", "", AggregateFunction.None);
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
			_fieldsCustomProperties.Add("ThreadID", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Subject", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ForumName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("SectionName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ThreadLastPostingDate", fieldHashtable);
		}

		/// <summary>Initialize the datastructures.</summary>
		/// <param name="obeyWeakRelations">flag for the internal used relations object</param>
		protected override void InitClass(bool obeyWeakRelations)
		{
			_columnThreadID = GeneralUtils.CreateTypedDataTableColumn("ThreadID", @"ThreadID", typeof(System.Int32), this.Columns);
			_columnSubject = GeneralUtils.CreateTypedDataTableColumn("Subject", @"Subject", typeof(System.String), this.Columns);
			_columnForumName = GeneralUtils.CreateTypedDataTableColumn("ForumName", @"ForumName", typeof(System.String), this.Columns);
			_columnSectionName = GeneralUtils.CreateTypedDataTableColumn("SectionName", @"SectionName", typeof(System.String), this.Columns);
			_columnThreadLastPostingDate = GeneralUtils.CreateTypedDataTableColumn("ThreadLastPostingDate", @"ThreadLastPostingDate", typeof(System.DateTime), this.Columns);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
			this.ObeyWeakRelations = obeyWeakRelations;
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnThreadID = this.Columns["ThreadID"];
			_columnSubject = this.Columns["Subject"];
			_columnForumName = this.Columns["ForumName"];
			_columnSectionName = this.Columns["SectionName"];
			_columnThreadLastPostingDate = this.Columns["ThreadLastPostingDate"];

			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}
#if !CF
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new SearchResultTypedList();
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
			get { return SearchResultTypedList.CustomProperties;}
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
			get { return SearchResultTypedList.FieldsCustomProperties;}
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

		/// <summary>Returns the column object belonging to the TypedList field ForumName</summary>
		internal DataColumn ForumNameColumn 
		{
			get { return _columnForumName; }
		}

		/// <summary>Returns the column object belonging to the TypedList field SectionName</summary>
		internal DataColumn SectionNameColumn 
		{
			get { return _columnSectionName; }
		}

		/// <summary>Returns the column object belonging to the TypedList field ThreadLastPostingDate</summary>
		internal DataColumn ThreadLastPostingDateColumn 
		{
			get { return _columnThreadLastPostingDate; }
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

	/// <summary>Typed datarow for the typed datatable SearchResult</summary>
	public partial class SearchResultRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SearchResultTypedList	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal SearchResultRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((SearchResultTypedList)(this.Table));
		}

		#region Class Property Declarations
		/// <summary>Gets / sets the value of the TypedList field ThreadID<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Thread.ThreadID</remarks>
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
		/// <summary>Gets / sets the value of the TypedList field ForumName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Forum.ForumName</remarks>
		public System.String ForumName 
		{
			get { return IsForumNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ForumNameColumn]; }
			set { this[_parent.ForumNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field ForumName is NULL, false otherwise.</summary>
		public bool IsForumNameNull() 
		{
			return IsNull(_parent.ForumNameColumn);
		}

		/// <summary>Sets the TypedList field ForumName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetForumNameNull() 
		{
			this[_parent.ForumNameColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field SectionName<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Section.SectionName</remarks>
		public System.String SectionName 
		{
			get { return IsSectionNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.SectionNameColumn]; }
			set { this[_parent.SectionNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field SectionName is NULL, false otherwise.</summary>
		public bool IsSectionNameNull() 
		{
			return IsNull(_parent.SectionNameColumn);
		}

		/// <summary>Sets the TypedList field SectionName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetSectionNameNull() 
		{
			this[_parent.SectionNameColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field ThreadLastPostingDate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Thread.ThreadLastPostingDate</remarks>
		public System.DateTime ThreadLastPostingDate 
		{
			get { return IsThreadLastPostingDateNull() ? (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)) : (System.DateTime)this[_parent.ThreadLastPostingDateColumn]; }
			set { this[_parent.ThreadLastPostingDateColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field ThreadLastPostingDate is NULL, false otherwise.</summary>
		public bool IsThreadLastPostingDateNull() 
		{
			return IsNull(_parent.ThreadLastPostingDateColumn);
		}

		/// <summary>Sets the TypedList field ThreadLastPostingDate to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetThreadLastPostingDateNull() 
		{
			this[_parent.ThreadLastPostingDateColumn] = System.Convert.DBNull;
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
