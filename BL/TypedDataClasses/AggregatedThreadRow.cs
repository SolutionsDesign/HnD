using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD.HnD.BL.TypedDataClasses
{
	/// <summary>
	/// Simple class which contains aggregated data of a thread for display purposes.
	/// </summary>
	public class AggregatedThreadRow
	{
		public int ThreadID { get; set; }
		public int ForumID { get; set; }
		public string ForumName { get; set; }
		public string Subject { get; set; }
		public int ThreadStartedByUserID { get; set; }
		public string ThreadStartedByNickName { get; set; }
		public DateTime? ThreadLastPostingDate { get; set; }
		public bool IsSticky { get; set; }
		public bool IsClosed { get; set; }
		public bool MarkedAsDone { get; set; }
		public int NumberOfViews { get; set; }
		public int NumberOfMessages { get; set; }
		public int LastPostByUserID { get; set; }
		public string LastPostByNickName { get; set; }
		public int MessageIDLastPost { get; set; }
	}
}
