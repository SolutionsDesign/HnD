using System;
using System.Collections.Generic;
using System.Linq;
using SD.HnD.DALAdapter.TypedListClasses;

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