﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.9.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;

namespace SD.HnD.DALAdapter.TypedListClasses
{
	/// <summary>Class which represents a row in the typed list 'UserProfileInfo'.</summary>
	/// <remarks>This class is a result class for a query, which is produced with the method <see cref="SD.HnD.DALAdapter.FactoryClasses.QueryFactory.GetUserProfileInfoTypedList"/>.
	/// Contains the following entity definition(s):
	/// Entity: User. <br/>
	/// Entity: UserTitle. <br/>
	/// </remarks>
	[Serializable]
	public partial class UserProfileInfoRow 
	{
		partial void OnCreated();
		
		/// <summary>Initializes a new instance of the <see cref="UserProfileInfoRow"/> class.</summary>
		public UserProfileInfoRow()
		{
			OnCreated();
		}

		/// <summary>Gets or sets the AmountOfPostings field. Mapped onto 'User.AmountOfPostings'</summary>
		public Nullable<System.Int32> AmountOfPostings { get; set; }
		/// <summary>Gets or sets the DateOfBirth field. Mapped onto 'User.DateOfBirth'</summary>
		public Nullable<System.DateTime> DateOfBirth { get; set; }
		/// <summary>Gets or sets the EmailAddress field. Mapped onto 'User.EmailAddress'</summary>
		public System.String EmailAddress { get; set; }
		/// <summary>Gets or sets the EmailAddressIsPublic field. Mapped onto 'User.EmailAddressIsPublic'</summary>
		public Nullable<System.Boolean> EmailAddressIsPublic { get; set; }
		/// <summary>Gets or sets the IconURL field. Mapped onto 'User.IconURL'</summary>
		public System.String IconURL { get; set; }
		/// <summary>Gets or sets the IPNumber field. Mapped onto 'User.IPNumber'</summary>
		public System.String IPNumber { get; set; }
		/// <summary>Gets or sets the IsBanned field. Mapped onto 'User.IsBanned'</summary>
		public System.Boolean IsBanned { get; set; }
		/// <summary>Gets or sets the JoinDate field. Mapped onto 'User.JoinDate'</summary>
		public Nullable<System.DateTime> JoinDate { get; set; }
		/// <summary>Gets or sets the LastVisitedDate field. Mapped onto 'User.LastVisitedDate'</summary>
		public Nullable<System.DateTime> LastVisitedDate { get; set; }
		/// <summary>Gets or sets the Location field. Mapped onto 'User.Location'</summary>
		public System.String Location { get; set; }
		/// <summary>Gets or sets the NickName field. Mapped onto 'User.NickName'</summary>
		public System.String NickName { get; set; }
		/// <summary>Gets or sets the Occupation field. Mapped onto 'User.Occupation'</summary>
		public System.String Occupation { get; set; }
		/// <summary>Gets or sets the Signature field. Mapped onto 'User.Signature'</summary>
		public System.String Signature { get; set; }
		/// <summary>Gets or sets the UserID field. Mapped onto 'User.UserID'</summary>
		public System.Int32 UserID { get; set; }
		/// <summary>Gets or sets the Website field. Mapped onto 'User.Website'</summary>
		public System.String Website { get; set; }
		/// <summary>Gets or sets the UserTitleDescription field. Mapped onto 'UserTitle.UserTitleDescription'</summary>
		public System.String UserTitleDescription { get; set; }
	}
}

