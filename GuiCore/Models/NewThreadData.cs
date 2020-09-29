using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SD.HnD.DALAdapter.EntityClasses;

namespace SD.HnD.Gui.Models
{
	public class NewThreadData : MessageData
	{
		[Required]
		[StringLength(250)]
		[MinLength(5)]
		public override string ThreadSubject { get; set; }
		public bool UserCanAddStickyThread { get; set; }
		public bool IsSticky { get; set; }

		[BindNever]
		public string NewThreadWelcomeTextAsHTML { get; set; }
	}
}