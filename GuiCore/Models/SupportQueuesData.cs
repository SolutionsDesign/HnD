using System;
using System.Collections.Generic;
using System.Linq;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DALAdapter.EntityClasses;

namespace SD.HnD.Gui.Models
{
	public class SupportQueuesData
	{
		public List<SupportQueueEntity> AvailableSupportQueues { get; set; }
		public List<AggregatedSupportQueueContentsRow> AllVisibleSupportQueueContents { get; set; }
		public DateTime UserLastVisitDate { get; set; }
	}
}