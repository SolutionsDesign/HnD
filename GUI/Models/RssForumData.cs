using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SD.HnD.DAL.TypedListClasses;

namespace SD.HnD.Gui.Models
{
	public class RssForumData
	{
		public string SiteName { get; set; }
		public string ForumUrl { get; set; }
		public string ForumName { get; set; }
		public List<ForumMessagesRow> ForumItems { get; set; }
	}
}