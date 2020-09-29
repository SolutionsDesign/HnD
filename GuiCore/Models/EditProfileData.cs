/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SD.HnD.BL;

namespace SD.HnD.Gui.Models
{
	public class EditProfileData
	{
		public void Sanitize()
		{
			this.IconURL = GuiHelper.SanitizeUrl(this.IconURL);
			this.Website = GuiHelper.SanitizeUrl(this.Website);
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
			this.IconURL = GuiHelper.StripProtocolsFromUrl(this.IconURL);
			this.Website = GuiHelper.StripProtocolsFromUrl(this.Website);
		}


		public virtual string NickName { get; set; }
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
		public string EmailAddress { get; set; }
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
		[Range(2, 1000)]
		public short DefaultNumberOfMessagesPerPage { get; set; }
	}
}