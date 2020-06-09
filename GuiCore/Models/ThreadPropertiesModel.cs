using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SD.HnD.Gui.Models
{
	public class ThreadPropertiesModel
	{
		[Required]
		[MaxLength(250)]
		public string Subject { get; set; }
		public bool IsSticky { get; set; }
		public bool IsClosed { get; set; }
	}
}