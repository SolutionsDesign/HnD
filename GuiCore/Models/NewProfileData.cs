using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SD.HnD.Gui.Models
{
	public class NewProfileData: EditProfileData
	{
		[Required]
		[StringLength(20)]
		[MinLength(2)]
		public override string NickName { get; set; }
	}
}