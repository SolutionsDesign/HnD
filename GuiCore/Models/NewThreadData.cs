using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SD.HnD.DALAdapter.EntityClasses;

namespace SD.HnD.Gui.Models
{
	public class NewThreadData : MessageData
	{
		[Required]
		public override string ThreadSubject { get; set; }
		public bool UserCanAddStickyThread { get; set; }
		public string NewThreadWelcomeTextAsHTML { get; set; }
		public bool IsSticky { get; set; }
	}
}