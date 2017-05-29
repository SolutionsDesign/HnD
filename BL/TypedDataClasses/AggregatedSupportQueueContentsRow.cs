using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD.HnD.BL.TypedDataClasses
{
	/// <summary>
	/// Simple class which represents an aggregated data row for a thread in a support queue
	/// </summary>
	/// <seealso cref="SD.HnD.BL.TypedDataClasses.AggregatedThreadRow" />
	public class AggregatedSupportQueueContentsRow : AggregatedThreadRow
	{
		public int QueueID { get; set; }
		public string ForumName { get; set; }
		public string PlacedInQueueByNickName { get; set; }
		public int PlacedInQueueByUserID { get; set; }
		public DateTime PlacedInQueueOn { get; set; }
		public string ClaimedByNickName { get; set; }
		public int? ClaimedByUserID { get; set; }
		public DateTime? ClaimedOn { get; set; }
	}
}
