///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.0
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;

namespace SD.HnD.DAL.TypedListClasses
{
	/// <summary>Class which represents a row in the typed list 'SearchResult'.</summary>
	/// <remarks>This class is a result class for a query, which is produced with the method <see cref="SD.HnD.DAL.FactoryClasses.QueryFactory.GetSearchResultTypedList"/>.
	/// Contains the following entity definition(s):
	/// Entity: Forum. <br/>
	/// Entity: Message. <br/>
	/// Entity: Section. <br/>
	/// Entity: Thread. <br/>
	/// Custom Properties: <br/>
	/// </remarks>
	[Serializable]
	public partial class SearchResultRow 
	{
		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion
		
		/// <summary>Initializes a new instance of the <see cref="SearchResultRow"/> class.</summary>
		public SearchResultRow()
		{
			OnCreated();
		}

		#region Class Property Declarations
		/// <summary>Gets or sets the ThreadID field. Mapped onto 'Thread.ThreadID'</summary>
		public System.Int32 ThreadID { get; set; }
		/// <summary>Gets or sets the Subject field. Mapped onto 'Thread.Subject'</summary>
		public System.String Subject { get; set; }
		/// <summary>Gets or sets the ForumName field. Mapped onto 'Forum.ForumName'</summary>
		public System.String ForumName { get; set; }
		/// <summary>Gets or sets the SectionName field. Mapped onto 'Section.SectionName'</summary>
		public System.String SectionName { get; set; }
		/// <summary>Gets or sets the ThreadLastPostingDate field. Mapped onto 'Thread.ThreadLastPostingDate'</summary>
		public Nullable<System.DateTime> ThreadLastPostingDate { get; set; }
		#endregion
	}
}

