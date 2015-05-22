using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SD.HnD.Gui.Models
{
	/// <summary>
	/// Data for the Forum page, which lists the active threads of a forum.
	/// </summary>
	public class ForumData
	{
		public string ForumName { get; set; }
		public string ForumDescription { get; set; }
		public string SectionName { get; set; }
		public int ForumID { get; set; }
		public bool HasRSSFeed { get; set; } 
	}
}