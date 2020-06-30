using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SD.HnD.Gui.Models
{
	public class EditProfileData
	{
		[StringLength(20)]
		[MinLength(2)]
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
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? DateOfBirth { get; set; }
		[StringLength(100)]
		public string Occupation { get; set; }
		[StringLength(100)]
		public string Location { get; set; }
		[StringLength(200)]
		[Url]
		public string Website { get; set; }
		[StringLength(250)]
		[Url]
		[FileExtensions(Extensions = "jpg,png,bmp")]
		public string IconURL { get; set; }
		// preferences
		[DisplayName("Email-address is public")]
		public bool EmailAddressIsPublic { get; set; }
		[DisplayName("Notify me of thread replies")]
		public bool AutoSubscribeToThread { get; set; }
		[DisplayName("Number of messages per page")]
		public short DefaultNumberOfMessagesPerPage { get; set; }


		public void Sanitize()
		{
			this.IconURL = SanitizeUrl(this.IconURL);
			this.Website = SanitizeUrl(this.Website);
			if(this.DateOfBirth.HasValue)
			{
				if(this.DateOfBirth.Value < new DateTime(1900, 1, 1) || this.DateOfBirth.Value > DateTime.Now)
				{
					this.DateOfBirth = null;
				}
			}

			if(this.DefaultNumberOfMessagesPerPage < 1 || this.DefaultNumberOfMessagesPerPage > 1000)
			{
				this.DefaultNumberOfMessagesPerPage = 25;
			}

			if(!string.IsNullOrWhiteSpace(this.NewPassword) && string.IsNullOrWhiteSpace(this.ConfirmNewPassword))
			{
				this.NewPassword = string.Empty;
			}
		}


		public void StripProtocolsFromUrls()
		{
			this.IconURL = StripProtocolsFromUrl(this.IconURL);
			this.Website = StripProtocolsFromUrl(this.Website);
		}


		private string StripProtocolsFromUrl(string url)
		{
			string toReturn = url;
			if(!string.IsNullOrEmpty(toReturn))
			{
				var urlAsUri = new Uri(url);
				toReturn = urlAsUri.Host + urlAsUri.PathAndQuery + urlAsUri.Fragment;
			}
			return toReturn;
		}


		private string SanitizeUrl(string toSanitize)
		{
			string toReturn = toSanitize;
			if(!string.IsNullOrEmpty(toReturn))
			{
				if(!(toReturn.StartsWith("http://", true, CultureInfo.InvariantCulture) ||
					 toReturn.StartsWith("https://", true, CultureInfo.InvariantCulture)))
				{
					toReturn = "https://" + toReturn;
				}
			}

			return toReturn;
		}
	}
}