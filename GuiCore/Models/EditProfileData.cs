using System;
using System.ComponentModel.DataAnnotations;

namespace SD.HnD.Gui.Models
{
	public class EditProfileData
	{
		public string NickName { get; set; }
		[DataType(DataType.Password)]
		[StringLength(100)]
		[MinLength(8)]
		public string NewPassword { get; set; }
		[DataType(DataType.Password)]
		[StringLength(100)]
		[MinLength(8)]
		[Compare("NewPassword")]
		public string ConfirmNewPassword { get; set; }
		[Required]
		[StringLength(200)]
		[MinLength(6)]
		[EmailAddress]
		public string EmailAddress { get;set; }
		[StringLength(250)]
		public string Signature { get; set; }
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }
		[StringLength(100)]
		public string Occupation { get; set; }
		[StringLength(200)]
		[Url]
		public string Website { get; set; }
		[StringLength(250)]
		[Url]
		[FileExtensions]
		public string IconURL { get; set; }
		// preferences
		public bool EmailAddressIsPublic { get; set; }
		public bool AutoSubscribeToThread { get; set; }
		public int DefaultNumberOfMessagesPerPage { get; set; }
	}
}