using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SD.HnD.Gui.Models
{
	public class ResetPasswordData
	{
		[Required]
		[StringLength(20)]
		public string NickName { get; set; }

		/// <summary>
		/// Set to true when the reset email was sent successfully.
		/// </summary>
		public bool EmailSent { get; set; }
	}
}