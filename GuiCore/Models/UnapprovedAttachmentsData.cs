using System;
using System.Collections.Generic;
using System.Linq;
using SD.HnD.BL.TypedDataClasses;

namespace SD.HnD.Gui.Models
{
	public class UnapprovedAttachmentsData
	{
		public List<AggregatedUnapprovedAttachmentRow> MessageIdsWithUnapprovedAttachments { get; set; }
	}
}