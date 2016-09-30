using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SD.HnD.DALAdapter.EntityClasses;

namespace SD.HnD.Gui.Models
{
	public class MessageData
	{
		public int CurrentUserID { get; set; }
		public string SectionName { get; set; }
		public int ForumID { get; set; }
		public int ThreadID { get; set; }
		public string ForumName { get; set; }
		public string ThreadSubject { get; set; }
		public string MessageText { get; set; }
	}
}