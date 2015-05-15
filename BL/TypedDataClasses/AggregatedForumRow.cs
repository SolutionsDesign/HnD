using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD.HnD.BL.TypedDataClasses
{
	/// <summary>
	/// Simple class which contains aggregated data of a forum for display purposes.
	/// </summary>
	public class AggregatedForumRow
	{
		public int ForumID { get; set; }
		public string ForumName { get; set; }
		public string ForumDescription { get; set; }
		public DateTime? ForumLastPostingDate { get; set; }
		public int AmountThreads { get; set; }
		public int AmountMessages { get; set; }
		public bool HasRSSFeed { get; set; }
		public int SectionID { get; set; }
	}
}
