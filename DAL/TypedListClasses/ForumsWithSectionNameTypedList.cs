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
	/// <summary>Typed datatable for the list 'ForumsWithSectionName'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class ForumsWithSectionNameTypedList : TypedListBase<ForumsWithSectionNameRow>
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesList
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnForumID;
		private DataColumn _columnForumName;
		private DataColumn _columnSectionName;
		private DataColumn _columnForumDescription;
		private DataColumn _columnSectionID;
		private DataColumn _columnForumOrderNo;
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		#endregion

		#region Class Constants
		private const int AmountOfFields = 6;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static ForumsWithSectionNameTypedList()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary>CTor</summary>
		public ForumsWithSectionNameTypedList():base("ForumsWithSectionName")
		{
			InitClass(false);
		}
		
		/// <summary>CTor</summary>
		/// <param name="obeyWeakRelations">The flag to signal the typed list what kind of join statements to generate in the query statement. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order. When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.</param>
		public ForumsWithSectionNameTypedList(bool obeyWeakRelations):base("ForumsWithSectionName")
		{
			InitClass(obeyWeakRelations);
		}

		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ForumsWithSectionNameTypedList(SerializationInfo info, StreamingContext context):base(info, context)
		{
			InitMembers();
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			ForumsWithSectionNameTypedList cloneToReturn = ((ForumsWithSectionNameTypedList)(base.Clone()));
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
			return new ForumsWithSectionNameRow(rowBuilder);
		}

		/// <summary>Builds the relation set for this typed list.</summary>
		/// <returns>ready to use relation set</returns>
		protected override IRelationCollection BuildRelationSet()
		{
			IRelationCollection toReturn = new RelationCollection();
			toReturn.ObeyWeakRelations = this.ObeyWeakRelations;
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
			toReturn.DefineField(ForumFields.ForumID, 0, "ForumID", "", AggregateFunction.None);
			toReturn.DefineField(ForumFields.ForumName, 1, "ForumName", "", AggregateFunction.None);
			toReturn.DefineField(SectionFields.SectionName, 2, "SectionName", "", AggregateFunction.None);
			toReturn.DefineField(ForumFields.ForumDescription, 3, "ForumDescription", "", AggregateFunction.None);
			toReturn.DefineField(SectionFields.SectionID, 4, "SectionID", "", AggregateFunction.None);
			toReturn.DefineField(ForumFields.OrderNo, 5, "ForumOrderNo", "", AggregateFunction.None);
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
			_fieldsCustomProperties.Add("ForumID", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ForumName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("SectionName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ForumDescription", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("SectionID", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ForumOrderNo", fieldHashtable);
		}

		/// <summary>Initialize the datastructures.</summary>
		/// <param name="obeyWeakRelations">flag for the internal used relations object</param>
		protected override void InitClass(bool obeyWeakRelations)
		{
			_columnForumID = GeneralUtils.CreateTypedDataTableColumn("ForumID", @"ForumID", typeof(System.Int32), this.Columns);
			_columnForumName = GeneralUtils.CreateTypedDataTableColumn("ForumName", @"ForumName", typeof(System.String), this.Columns);
			_columnSectionName = GeneralUtils.CreateTypedDataTableColumn("SectionName", @"SectionName", typeof(System.String), this.Columns);
			_columnForumDescription = GeneralUtils.CreateTypedDataTableColumn("ForumDescription", @"ForumDescription", typeof(System.String), this.Columns);
			_columnSectionID = GeneralUtils.CreateTypedDataTableColumn("SectionID", @"SectionID", typeof(System.Int32), this.Columns);
			_columnForumOrderNo = GeneralUtils.CreateTypedDataTableColumn("ForumOrderNo", @"ForumOrderNo", typeof(System.Int16), this.Columns);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
			this.ObeyWeakRelations = obeyWeakRelations;
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnForumID = this.Columns["ForumID"];
			_columnForumName = this.Columns["ForumName"];
			_columnSectionName = this.Columns["SectionName"];
			_columnForumDescription = this.Columns["ForumDescription"];
			_columnSectionID = this.Columns["SectionID"];
			_columnForumOrderNo = this.Columns["ForumOrderNo"];

			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new ForumsWithSectionNameTypedList();
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
			get { return ForumsWithSectionNameTypedList.CustomProperties;}
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
			get { return ForumsWithSectionNameTypedList.FieldsCustomProperties;}
		}

		/// <summary>Returns the column object belonging to the TypedList field ForumID</summary>
		internal DataColumn ForumIDColumn 
		{
			get { return _columnForumID; }
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

		/// <summary>Returns the column object belonging to the TypedList field ForumDescription</summary>
		internal DataColumn ForumDescriptionColumn 
		{
			get { return _columnForumDescription; }
		}

		/// <summary>Returns the column object belonging to the TypedList field SectionID</summary>
		internal DataColumn SectionIDColumn 
		{
			get { return _columnSectionID; }
		}

		/// <summary>Returns the column object belonging to the TypedList field ForumOrderNo</summary>
		internal DataColumn ForumOrderNoColumn 
		{
			get { return _columnForumOrderNo; }
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

	/// <summary>Typed datarow for the typed datatable ForumsWithSectionName</summary>
	public partial class ForumsWithSectionNameRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private ForumsWithSectionNameTypedList	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal ForumsWithSectionNameRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((ForumsWithSectionNameTypedList)(this.Table));
		}

		#region Class Property Declarations
		/// <summary>Gets / sets the value of the TypedList field ForumID<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Forum.ForumID</remarks>
		public System.Int32 ForumID 
		{
			get { return IsForumIDNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.ForumIDColumn]; }
			set { this[_parent.ForumIDColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field ForumID is NULL, false otherwise.</summary>
		public bool IsForumIDNull() 
		{
			return IsNull(_parent.ForumIDColumn);
		}

		/// <summary>Sets the TypedList field ForumID to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetForumIDNull() 
		{
			this[_parent.ForumIDColumn] = System.Convert.DBNull;
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
		/// <summary>Gets / sets the value of the TypedList field ForumDescription<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Forum.ForumDescription</remarks>
		public System.String ForumDescription 
		{
			get { return IsForumDescriptionNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ForumDescriptionColumn]; }
			set { this[_parent.ForumDescriptionColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field ForumDescription is NULL, false otherwise.</summary>
		public bool IsForumDescriptionNull() 
		{
			return IsNull(_parent.ForumDescriptionColumn);
		}

		/// <summary>Sets the TypedList field ForumDescription to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetForumDescriptionNull() 
		{
			this[_parent.ForumDescriptionColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field SectionID<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Section.SectionID</remarks>
		public System.Int32 SectionID 
		{
			get { return IsSectionIDNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.SectionIDColumn]; }
			set { this[_parent.SectionIDColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field SectionID is NULL, false otherwise.</summary>
		public bool IsSectionIDNull() 
		{
			return IsNull(_parent.SectionIDColumn);
		}

		/// <summary>Sets the TypedList field SectionID to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetSectionIDNull() 
		{
			this[_parent.SectionIDColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field ForumOrderNo<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: Forum.OrderNo</remarks>
		public System.Int16 ForumOrderNo 
		{
			get { return IsForumOrderNoNull() ? (System.Int16)TypeDefaultValue.GetDefaultValue(typeof(System.Int16)) : (System.Int16)this[_parent.ForumOrderNoColumn]; }
			set { this[_parent.ForumOrderNoColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field ForumOrderNo is NULL, false otherwise.</summary>
		public bool IsForumOrderNoNull() 
		{
			return IsNull(_parent.ForumOrderNoColumn);
		}

		/// <summary>Sets the TypedList field ForumOrderNo to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetForumOrderNoNull() 
		{
			this[_parent.ForumOrderNoColumn] = System.Convert.DBNull;
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
