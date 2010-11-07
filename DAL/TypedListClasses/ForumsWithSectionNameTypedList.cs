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

	/// <summary>
	/// Typed datatable for the list 'ForumsWithSectionName'.<br/><br/>
	/// </summary>
	/// <remarks>
	/// It embeds a fill method which accepts a filter.
	/// The code doesn't support any changing of data. Users who do that are on their own.
	/// It also doesn't support any event throwing. This list should be used as a base for readonly databinding
	/// or dataview construction.
	/// </remarks>
#if !CF	
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
#endif	
	public partial class ForumsWithSectionNameTypedList : TypedListBase<ForumsWithSectionNameRow>, ITypedListLgp
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
		/// <summary>The amount of fields in the resultset.</summary>
		private const int AmountOfFields = 6;
		#endregion


		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. </summary>
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
		/// <param name="obeyWeakRelations">The flag to signal the collection what kind of join statements to generate in the
		/// query statement. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order.
		/// When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.
		/// </param>
		public ForumsWithSectionNameTypedList(bool obeyWeakRelations):base("ForumsWithSectionName")
		{
			InitClass(obeyWeakRelations);
		}
		
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ForumsWithSectionNameTypedList(SerializationInfo info, StreamingContext context):base(info, context)
		{
			InitMembers();
		}
#endif		
		
		/// <summary>Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will use no sort filter, no select filter, will allow duplicate rows and will not limit the amount of rows returned</summary>
		/// <returns>true if fill succeeded, false otherwise</returns>
		public bool Fill()
		{
			return Fill(0, null, true, null, null, null, 0, 0);
		}


		/// <summary>Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will not use a filter, will allow duplicate rows.</summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		public bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			return Fill(maxNumberOfItemsToReturn, sortClauses, true, null, null, null, 0, 0);
		}


		/// <summary>Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will not use a filter.</summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		public bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates)
		{
			return Fill(maxNumberOfItemsToReturn, sortClauses, allowDuplicates, null, null, null, 0, 0);
		}


		/// <summary>Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter</summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate which is used to filter the rows to insert in this Typed List instance</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		public virtual bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter)
		{
			return Fill(maxNumberOfItemsToReturn, sortClauses, allowDuplicates, selectFilter, null, null, 0, 0);
		}


		/// <summary>Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter</summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate which is used to filter the rows to insert in this Typed List instance</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		public bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse)
		{
			return Fill(maxNumberOfItemsToReturn, sortClauses, allowDuplicates, selectFilter, transactionToUse, null, 0, 0);
		}


		/// <summary>Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter</summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate which is used to filter the rows to insert in this Typed List instance</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		public bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse, 
			IGroupByCollection groupByClause)
		{
			return Fill(maxNumberOfItemsToReturn, sortClauses, allowDuplicates, selectFilter, transactionToUse, groupByClause, 0, 0);
		}


		/// <summary>Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter</summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate which is used to filter the rows to insert in this Typed List instance</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		public virtual bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse, 
			IGroupByCollection groupByClause, int pageNumber, int pageSize)
		{
			IEntityFields fieldsInResultset = BuildResultset();
			IRelationCollection relations = BuildRelationSet();

			TypedListDAO dao = DAOFactory.CreateTypedListDAO();
			return dao.GetMultiAsDataTable(fieldsInResultset, this, maxNumberOfItemsToReturn, sortClauses, selectFilter, relations, allowDuplicates, groupByClause, transactionToUse, pageNumber, pageSize);
		}


		/// <summary>Gets the amount of rows in the database for this typed list, not skipping duplicates</summary>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		public int GetDbCount()
		{
			return GetDbCount(true, null, null);
		}
		
		
		/// <summary>Gets the amount of rows in the database for this typed list.</summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		public int GetDbCount(bool allowDuplicates)
		{
			return GetDbCount(allowDuplicates, null, null);
		}


		/// <summary>Gets the amount of rows in the database for this typed list.</summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="filter">The filter to apply for the count retrieval</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		public int GetDbCount(bool allowDuplicates, IPredicateExpression filter)
		{
			return GetDbCount(allowDuplicates, filter, null);
		}

		
		/// <summary>Gets the amount of rows in the database for this typed list.</summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="filter">The filter to apply for the count retrieval</param>
		/// <param name="relations">The relations for the filter to apply</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		public int GetDbCount(bool allowDuplicates, IPredicateExpression filter, IRelationCollection relations)
		{
			return GetDbCount(allowDuplicates, filter, relations, null);
		}


		/// <summary>Gets the amount of rows in the database for this typed list.</summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="filter">The filter to apply for the count retrieval</param>
		/// <param name="relations">The relations for the filter to apply</param>
		/// <param name="groupByClause">group by clause to embed in the query</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		public virtual int GetDbCount(bool allowDuplicates, IPredicateExpression filter, IRelationCollection relations, GroupByCollection groupByClause)
		{
			IEntityFields fieldsInResultset = BuildResultset();
			IRelationCollection relationsToUse = BuildRelationSet();
			if(relations!=null)
			{
				for (int i = 0; i < relations.Count; i++)
				{
					relationsToUse.Add(relations[i]);
				}
			}

			TypedListDAO dao = DAOFactory.CreateTypedListDAO();
			return dao.GetDbCount(fieldsInResultset, null, filter, relationsToUse, groupByClause, allowDuplicates);
		}


		/// <summary>Builds the relation set for this typed list.</summary>
		/// <returns>ready to use relation set</returns>
		public virtual IRelationCollection BuildRelationSet()
		{
			IRelationCollection toReturn = new RelationCollection();
			toReturn.ObeyWeakRelations = base.ObeyWeakRelations;
			toReturn.Add(ForumEntity.Relations.SectionEntityUsingSectionID, "", "", JoinHint.None);
			
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalRelations
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnRelationSetBuilt(toReturn);
			return toReturn;
		}


		/// <summary>Builds the resultset fields.</summary>
		/// <returns>ready to use resultset</returns>
		public virtual IEntityFields BuildResultset()
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


		/// <summary>Gets an array of all ForumsWithSectionNameRow objects.</summary>
		/// <returns>Array with ForumsWithSectionNameRow objects</returns>
		public new ForumsWithSectionNameRow[] Select()
		{
			return (ForumsWithSectionNameRow[])base.Select();
		}


		/// <summary>Gets an array of all ForumsWithSectionNameRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with ForumsWithSectionNameRow objects</returns>
		public new ForumsWithSectionNameRow[] Select(string filterExpression)
		{
			return (ForumsWithSectionNameRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all ForumsWithSectionNameRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with ForumsWithSectionNameRow objects</returns>
		public new ForumsWithSectionNameRow[] Select(string filterExpression, string sort)
		{
			return (ForumsWithSectionNameRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all ForumsWithSectionNameRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with ForumsWithSectionNameRow objects</returns>
		public new ForumsWithSectionNameRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (ForumsWithSectionNameRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.</summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new ForumsWithSectionNameRow(rowBuilder);
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
			
			_columnForumID = new DataColumn("ForumID", typeof(System.Int32), null, MappingType.Element);
			_columnForumID.ReadOnly = true;
			_columnForumID.Caption = @"ForumID";
			this.Columns.Add(_columnForumID);

			_columnForumName = new DataColumn("ForumName", typeof(System.String), null, MappingType.Element);
			_columnForumName.ReadOnly = true;
			_columnForumName.Caption = @"ForumName";
			this.Columns.Add(_columnForumName);

			_columnSectionName = new DataColumn("SectionName", typeof(System.String), null, MappingType.Element);
			_columnSectionName.ReadOnly = true;
			_columnSectionName.Caption = @"SectionName";
			this.Columns.Add(_columnSectionName);

			_columnForumDescription = new DataColumn("ForumDescription", typeof(System.String), null, MappingType.Element);
			_columnForumDescription.ReadOnly = true;
			_columnForumDescription.Caption = @"ForumDescription";
			this.Columns.Add(_columnForumDescription);

			_columnSectionID = new DataColumn("SectionID", typeof(System.Int32), null, MappingType.Element);
			_columnSectionID.ReadOnly = true;
			_columnSectionID.Caption = @"SectionID";
			this.Columns.Add(_columnSectionID);

			_columnForumOrderNo = new DataColumn("ForumOrderNo", typeof(System.Int16), null, MappingType.Element);
			_columnForumOrderNo.ReadOnly = true;
			_columnForumOrderNo.Caption = @"OrderNo";
			this.Columns.Add(_columnForumOrderNo);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.ObeyWeakRelations = obeyWeakRelations;
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


		/// <summary>Return the type of the typed datarow</summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(ForumsWithSectionNameRow);
		}


		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			ForumsWithSectionNameTypedList cloneToReturn = ((ForumsWithSectionNameTypedList)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}

#if !CF
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new ForumsWithSectionNameTypedList();
		}
#endif

		#region Class Property Declarations
		/// <summary>Returns the amount of rows in this typed list.</summary>
		[System.ComponentModel.Browsable(false)]
		public override int Count 
		{
			get 
			{
				return this.Rows.Count;
			}
		}
		
		/// <summary>The custom properties for this TypedList type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary>The custom properties for the type of this TypedList instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[System.ComponentModel.Browsable(false)]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return ForumsWithSectionNameTypedList.CustomProperties;}
		}

		/// <summary>The custom properties for the fields of this TypedList type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary>The custom properties for the fields of the type of this TypedList instance. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[System.ComponentModel.Browsable(false)]
		public virtual Hashtable FieldsCustomPropertiesOfType
		{
			get { return ForumsWithSectionNameTypedList.FieldsCustomProperties;}
		}

		/// <summary>Indexer of this strong typed list</summary>
		public ForumsWithSectionNameRow this[int index] 
		{
			get 
			{
				return ((ForumsWithSectionNameRow)(this.Rows[index]));
			}
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
			get 
			{
				if(IsForumIDNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.ForumIDColumn];
				}
			}
			set 
			{
				this[_parent.ForumIDColumn] = value;
			}
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
			get 
			{
				if(IsForumNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.ForumNameColumn];
				}
			}
			set 
			{
				this[_parent.ForumNameColumn] = value;
			}
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
			get 
			{
				if(IsSectionNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.SectionNameColumn];
				}
			}
			set 
			{
				this[_parent.SectionNameColumn] = value;
			}
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
			get 
			{
				if(IsForumDescriptionNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.ForumDescriptionColumn];
				}
			}
			set 
			{
				this[_parent.ForumDescriptionColumn] = value;
			}
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
			get 
			{
				if(IsSectionIDNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.SectionIDColumn];
				}
			}
			set 
			{
				this[_parent.SectionIDColumn] = value;
			}
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
			get 
			{
				if(IsForumOrderNoNull())
				{
					// return default value for this type.
					return (System.Int16)TypeDefaultValue.GetDefaultValue(typeof(System.Int16));
				}
				else
				{
					return (System.Int16)this[_parent.ForumOrderNoColumn];
				}
			}
			set 
			{
				this[_parent.ForumOrderNoColumn] = value;
			}
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
	}
}
