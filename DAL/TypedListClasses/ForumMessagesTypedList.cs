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
	/// Typed datatable for the list 'ForumMessages'.<br/><br/>
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
	public partial class ForumMessagesTypedList : TypedListBase<ForumMessagesRow>, ITypedListLgp
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
		/// <summary>The amount of fields in the resultset.</summary>
		private const int AmountOfFields = 9;
		#endregion


		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this
		/// class or derived classes is constructed. </summary>
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
		/// <param name="obeyWeakRelations">The flag to signal the collection what kind of join statements to generate in the
		/// query statement. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order.
		/// When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.
		/// </param>
		public ForumMessagesTypedList(bool obeyWeakRelations):base("ForumMessages")
		{
			InitClass(obeyWeakRelations);
		}
		
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ForumMessagesTypedList(SerializationInfo info, StreamingContext context):base(info, context)
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
			toReturn.Add(MessageEntity.Relations.ThreadEntityUsingThreadID, "", "", JoinHint.None);
			toReturn.Add(ThreadEntity.Relations.ForumEntityUsingForumID, "", "", JoinHint.None);
			toReturn.Add(MessageEntity.Relations.UserEntityUsingPostedByUserID, "", "", JoinHint.None);
			
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


		/// <summary>Gets an array of all ForumMessagesRow objects.</summary>
		/// <returns>Array with ForumMessagesRow objects</returns>
		public new ForumMessagesRow[] Select()
		{
			return (ForumMessagesRow[])base.Select();
		}


		/// <summary>Gets an array of all ForumMessagesRow objects that match the filter criteria in order of primary key (or lacking one, order of addition.) </summary>
		/// <param name="filterExpression">The criteria to use to filter the rows.</param>
		/// <returns>Array with ForumMessagesRow objects</returns>
		public new ForumMessagesRow[] Select(string filterExpression)
		{
			return (ForumMessagesRow[])base.Select(filterExpression);
		}


		/// <summary>Gets an array of all ForumMessagesRow objects that match the filter criteria, in the specified sort order</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <returns>Array with ForumMessagesRow objects</returns>
		public new ForumMessagesRow[] Select(string filterExpression, string sort)
		{
			return (ForumMessagesRow[])base.Select(filterExpression, sort);
		}


		/// <summary>Gets an array of all ForumMessagesRow objects that match the filter criteria, in the specified sort order that match the specified state</summary>
		/// <param name="filterExpression">The filter expression.</param>
		/// <param name="sort">A string specifying the column and sort direction.</param>
		/// <param name="recordStates">One of the <see cref="System.Data.DataViewRowState"/> values.</param>
		/// <returns>Array with ForumMessagesRow objects</returns>
		public new ForumMessagesRow[] Select(string filterExpression, string sort, DataViewRowState recordStates)
		{
			return (ForumMessagesRow[])base.Select(filterExpression, sort, recordStates);
		}
		

		/// <summary>Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.</summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new ForumMessagesRow(rowBuilder);
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
			
			_columnMessageID = new DataColumn("MessageID", typeof(System.Int32), null, MappingType.Element);
			_columnMessageID.ReadOnly = true;
			_columnMessageID.Caption = @"MessageID";
			this.Columns.Add(_columnMessageID);

			_columnPostingDate = new DataColumn("PostingDate", typeof(System.DateTime), null, MappingType.Element);
			_columnPostingDate.ReadOnly = true;
			_columnPostingDate.Caption = @"PostingDate";
			this.Columns.Add(_columnPostingDate);

			_columnMessageTextAsHTML = new DataColumn("MessageTextAsHTML", typeof(System.String), null, MappingType.Element);
			_columnMessageTextAsHTML.ReadOnly = true;
			_columnMessageTextAsHTML.Caption = @"MessageTextAsHTML";
			this.Columns.Add(_columnMessageTextAsHTML);

			_columnThreadID = new DataColumn("ThreadID", typeof(System.Int32), null, MappingType.Element);
			_columnThreadID.ReadOnly = true;
			_columnThreadID.Caption = @"ThreadID";
			this.Columns.Add(_columnThreadID);

			_columnSubject = new DataColumn("Subject", typeof(System.String), null, MappingType.Element);
			_columnSubject.ReadOnly = true;
			_columnSubject.Caption = @"Subject";
			this.Columns.Add(_columnSubject);

			_columnEmailAddress = new DataColumn("EmailAddress", typeof(System.String), null, MappingType.Element);
			_columnEmailAddress.ReadOnly = true;
			_columnEmailAddress.Caption = @"EmailAddress";
			this.Columns.Add(_columnEmailAddress);

			_columnEmailAddressIsPublic = new DataColumn("EmailAddressIsPublic", typeof(System.Boolean), null, MappingType.Element);
			_columnEmailAddressIsPublic.ReadOnly = true;
			_columnEmailAddressIsPublic.Caption = @"EmailAddressIsPublic";
			this.Columns.Add(_columnEmailAddressIsPublic);

			_columnNickName = new DataColumn("NickName", typeof(System.String), null, MappingType.Element);
			_columnNickName.ReadOnly = true;
			_columnNickName.Caption = @"NickName";
			this.Columns.Add(_columnNickName);

			_columnMessageText = new DataColumn("MessageText", typeof(System.String), null, MappingType.Element);
			_columnMessageText.ReadOnly = true;
			_columnMessageText.Caption = @"MessageText";
			this.Columns.Add(_columnMessageText);
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.ObeyWeakRelations = obeyWeakRelations;
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


		/// <summary>Return the type of the typed datarow</summary>
		/// <returns>returns the requested type</returns>
		protected override Type GetRowType() 
		{
			return typeof(ForumMessagesRow);
		}


		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			ForumMessagesTypedList cloneToReturn = ((ForumMessagesTypedList)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}

#if !CF
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new ForumMessagesTypedList();
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
			get { return ForumMessagesTypedList.CustomProperties;}
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
			get { return ForumMessagesTypedList.FieldsCustomProperties;}
		}

		/// <summary>Indexer of this strong typed list</summary>
		public ForumMessagesRow this[int index] 
		{
			get 
			{
				return ((ForumMessagesRow)(this.Rows[index]));
			}
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
			get 
			{
				if(IsMessageIDNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.MessageIDColumn];
				}
			}
			set 
			{
				this[_parent.MessageIDColumn] = value;
			}
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
			get 
			{
				if(IsPostingDateNull())
				{
					// return default value for this type.
					return (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime));
				}
				else
				{
					return (System.DateTime)this[_parent.PostingDateColumn];
				}
			}
			set 
			{
				this[_parent.PostingDateColumn] = value;
			}
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
			get 
			{
				if(IsMessageTextAsHTMLNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.MessageTextAsHTMLColumn];
				}
			}
			set 
			{
				this[_parent.MessageTextAsHTMLColumn] = value;
			}
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
			get 
			{
				if(IsThreadIDNull())
				{
					// return default value for this type.
					return (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32));
				}
				else
				{
					return (System.Int32)this[_parent.ThreadIDColumn];
				}
			}
			set 
			{
				this[_parent.ThreadIDColumn] = value;
			}
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
			get 
			{
				if(IsSubjectNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.SubjectColumn];
				}
			}
			set 
			{
				this[_parent.SubjectColumn] = value;
			}
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
			get 
			{
				if(IsEmailAddressNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.EmailAddressColumn];
				}
			}
			set 
			{
				this[_parent.EmailAddressColumn] = value;
			}
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
			get 
			{
				if(IsEmailAddressIsPublicNull())
				{
					// return default value for this type.
					return (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean));
				}
				else
				{
					return (System.Boolean)this[_parent.EmailAddressIsPublicColumn];
				}
			}
			set 
			{
				this[_parent.EmailAddressIsPublicColumn] = value;
			}
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
			get 
			{
				if(IsNickNameNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.NickNameColumn];
				}
			}
			set 
			{
				this[_parent.NickNameColumn] = value;
			}
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
			get 
			{
				if(IsMessageTextNull())
				{
					// return default value for this type.
					return (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String));
				}
				else
				{
					return (System.String)this[_parent.MessageTextColumn];
				}
			}
			set 
			{
				this[_parent.MessageTextColumn] = value;
			}
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
	}
}
