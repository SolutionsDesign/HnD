using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD.HnD.BL.TypedDataClasses
{
	public class AggregatedUnapprovedAttachmentRow
	{
		public string Subject { get; set; }
		public string ForumName { get; set; }
		public int MessageID { get; set; }
		public DateTime AddedOn { get; set; }
	}
}
