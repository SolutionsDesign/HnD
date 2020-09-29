using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SD.HnD.Gui.Models
{
	public class LoginData
	{
		[Required]
		[StringLength(20)]
		public string NickName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100)]
		[MinLength(1)]
		public string Password { get; set; }

		[Display(Name="Remember me")]
		public bool RememberMe { get; set; }
	}
}