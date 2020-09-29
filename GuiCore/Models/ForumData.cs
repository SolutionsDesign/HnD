using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SD.HnD.BL.TypedDataClasses;

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
		public int PageNo { get; set; }
		public int PageSize { get; set; }
		public List<AggregatedThreadRow> ThreadRows { get; set; }
		public DateTime UserLastVisitDate { get; set; }
		public bool UserCanCreateThreads { get; set; }

		public int PageNoOlderMessages
		{
			get { return this.PageNo + 1; }
		}

		public int PageNoNewerMessages
		{
			get
			{
				var toReturn = this.PageNo - 1;
				return toReturn <= 0 ? 0 : toReturn;
			}
		}
	}
}