///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.Common;
using SD.HnD.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.DQE.SqlServer;


namespace SD.HnD.DAL.DaoClasses
{
	/// <summary>DAO base class, used for all generated DAO classes.</summary>
	public partial class CommonDaoBase : DaoBase
	{
		#region Class Member Definitions
		/// <summary>The connection string to use in the SelfServicing code. This is a global setting and is automatically set with the value read from the config file.</summary>
		public static string ActualConnectionString = string.Empty;
		#endregion
	
		#region Constants
		private const string connectionKeyString = "Main.ConnectionString.SQL Server (SqlClient)";
		#endregion
		
		/// <summary>CTor</summary>
		/// <remarks>CTor to use for non-entity specific dao usage</remarks>
		public CommonDaoBase() : this(InheritanceHierarchyType.None, string.Empty, null)
		{
		}
	
		/// <summary>CTor</summary>
		/// <param name="typeOfInheritance">Type of inheritance the entity which owns this Dao is in.</param>
		/// <param name="entityName">Name of the entity owning this Dao</param>
		/// <param name="entityFactory">Entity factory for the entity owning this Dao.</param>
		public CommonDaoBase(InheritanceHierarchyType typeOfInheritance, string entityName, IEntityFactory entityFactory)
				: base(InheritanceInfoProviderSingleton.GetInstance(), new DynamicQueryEngine(), typeOfInheritance, entityName, entityFactory)
		{
		}
		
		/// <summary>Sets the flag to signal the SqlServer DQE to generate SET ARITHABORT ON statements prior to INSERT, DELETE and UPDATE Queries.
		/// Keep this flag to false in normal usage, but set it to true if you need to write into a table which is part of an indexed view.
		/// It will not affect normal inserts/updates that much, leaving it on is not harmful. See Books online for details on SET ARITHABORT ON.
		/// After each statement the setting is turned off if it has been turned on prior to that statement.</summary>
		/// <remarks>Setting this flag is a global change.</remarks>
		public static void SetArithAbortFlag(bool value)
		{
			DynamicQueryEngine.ArithAbortOn = value;
		}

		/// <summary>Sets the default compatibility level used by the DQE. Default is SqlServer2005. This is a global setting.
		/// Compatibility level influences the query generated for paging, sequence name (@@IDENTITY/SCOPE_IDENTITY()), and usage of newsequenceid() in inserts. 
		/// It also influences the ado.net provider to use. This way you can switch between SqlServer server client 'SqlClient' and SqlServer CE Desktop.</summary>
		/// <remarks>Setting this property will overrule a similar setting in the .config file. Don't set this property when queries are executed as
		/// it might switch factories for ADO.NET elements which could result in undefined behavior so set this property at startup of your application</remarks>
		public static void SetSqlServerCompatibilityLevel(SqlServerCompatibilityLevel compatibilityLevel)
		{
			DynamicQueryEngine.DefaultCompatibilityLevel = compatibilityLevel;
		}

		/// <summary>Gets the connection string.</summary>
		/// <returns>the connection string as set by code or in the config file.</returns>
		protected override string GetConnectionString()
		{
			if(String.IsNullOrEmpty(ActualConnectionString))
			{
				ActualConnectionString = ConfigFileHelper.ReadConnectionStringFromConfig(connectionKeyString);
			}
			return ActualConnectionString;
		}
		
		#region Included Code

		#endregion
	}
}
