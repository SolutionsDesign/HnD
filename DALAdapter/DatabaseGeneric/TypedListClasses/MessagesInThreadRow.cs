///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.2
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;

namespace SD.HnD.DALAdapter.TypedListClasses
{
	/// <summary>Class which represents a row in the typed list 'MessagesInThread'.</summary>
	/// <remarks>This class is a result class for a query, which is produced with the method <see cref="SD.HnD.DALAdapter.FactoryClasses.QueryFactory.GetMessagesInThreadTypedList"/>.
	/// Contains the following entity definition(s):
	/// Entity: Message. <br/>
	/// Entity: User. <br/>
	/// Entity: UserTitle. <br/>
	/// Custom Properties: <br/>
	/// </remarks>
	[Serializable]
	public partial class MessagesInThreadRow 
	{
		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion
		
		/// <summary>Initializes a new instance of the <see cref="MessagesInThreadRow"/> class.</summary>
		public MessagesInThreadRow()
		{
			OnCreated();
		}

		#region Class Property Declarations
		/// <summary>Gets or sets the MessageID field. Mapped onto 'Message.MessageID'</summary>
		public System.Int32 MessageID { get; set; }
		/// <summary>Gets or sets the PostingDate field. Mapped onto 'Message.PostingDate'</summary>
		public System.DateTime PostingDate { get; set; }
		/// <summary>Gets or sets the MessageTextAsHTML field. Mapped onto 'Message.MessageTextAsHTML'</summary>
		public System.String MessageTextAsHTML { get; set; }
		/// <summary>Gets or sets the ThreadID field. Mapped onto 'Message.ThreadID'</summary>
		public System.Int32 ThreadID { get; set; }
		/// <summary>Gets or sets the PostedFromIP field. Mapped onto 'Message.PostedFromIP'</summary>
		public System.String PostedFromIP { get; set; }
		/// <summary>Gets or sets the UserID field. Mapped onto 'User.UserID'</summary>
		public Nullable<System.Int32> UserID { get; set; }
		/// <summary>Gets or sets the NickName field. Mapped onto 'User.NickName'</summary>
		public System.String NickName { get; set; }
		/// <summary>Gets or sets the IconURL field. Mapped onto 'User.IconURL'</summary>
		public System.String IconURL { get; set; }
		/// <summary>Gets or sets the Location field. Mapped onto 'User.Location'</summary>
		public System.String Location { get; set; }
		/// <summary>Gets or sets the JoinDate field. Mapped onto 'User.JoinDate'</summary>
		public Nullable<System.DateTime> JoinDate { get; set; }
		/// <summary>Gets or sets the AmountOfPostings field. Mapped onto 'User.AmountOfPostings'</summary>
		public Nullable<System.Int32> AmountOfPostings { get; set; }
		/// <summary>Gets or sets the UserTitleDescription field. Mapped onto 'UserTitle.UserTitleDescription'</summary>
		public System.String UserTitleDescription { get; set; }
		/// <summary>Gets or sets the Signature field. Mapped onto 'User.Signature'</summary>
		public System.String Signature { get; set; }
		#endregion
	}
}

