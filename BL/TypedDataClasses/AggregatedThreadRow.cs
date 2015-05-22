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
		public string Subject { get; set; }
		public int StartedByUserID { get; set; }
		public DateTime? DateLastPost { get; set; }
		public bool IsSticky { get; set; }
		public bool IsClosed { get; set; }
		public bool MarkedAsDone { get; set; }
		public int NumberOfViews { get; set; }
		public string StartedByNickName { get; set; }
		public int AmountMessages { get; set; }
		public int UserIDLastPost { get; set; }
		public string NickNameLastPost { get; set; }
		public int MessageIDLastPost { get; set; }
	}
}
