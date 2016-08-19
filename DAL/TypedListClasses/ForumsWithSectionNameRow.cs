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
	/// <summary>Class which represents a row in the typed list 'ForumsWithSectionName'.</summary>
	/// <remarks>This class is a result class for a query, which is produced with the method <see cref="SD.HnD.DAL.FactoryClasses.QueryFactory.GetForumsWithSectionNameTypedList"/>.
	/// Contains the following entity definition(s):
	/// Entity: Forum. <br/>
	/// Entity: Section. <br/>
	/// Custom Properties: <br/>
	/// </remarks>
	[Serializable]
	public partial class ForumsWithSectionNameRow 
	{
		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion
		
		/// <summary>Initializes a new instance of the <see cref="ForumsWithSectionNameRow"/> class.</summary>
		public ForumsWithSectionNameRow()
		{
			OnCreated();
		}

		#region Class Property Declarations
		/// <summary>Gets or sets the ForumID field. Mapped onto 'Forum.ForumID'</summary>
		public System.Int32 ForumID { get; set; }
		/// <summary>Gets or sets the ForumName field. Mapped onto 'Forum.ForumName'</summary>
		public System.String ForumName { get; set; }
		/// <summary>Gets or sets the SectionName field. Mapped onto 'Section.SectionName'</summary>
		public System.String SectionName { get; set; }
		/// <summary>Gets or sets the ForumDescription field. Mapped onto 'Forum.ForumDescription'</summary>
		public System.String ForumDescription { get; set; }
		/// <summary>Gets or sets the SectionID field. Mapped onto 'Section.SectionID'</summary>
		public System.Int32 SectionID { get; set; }
		/// <summary>Gets or sets the ForumOrderNo field. Mapped onto 'Forum.OrderNo'</summary>
		public System.Int16 ForumOrderNo { get; set; }
		#endregion
	}
}

