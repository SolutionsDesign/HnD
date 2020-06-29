using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SD.HnD.Gui.Models
{
	public class NewPasswordData
	{
		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		[StringLength(100)]
		[MinLength(8)]
		public string NewPassword { get; set; }
		
		[Required(ErrorMessage = "Confirm password is required")]
		[DataType(DataType.Password)]
		[StringLength(100)]
		[MinLength(8)]
		[Compare("NewPassword")]
		public string ConfirmNewPassword { get; set; }
	}
}