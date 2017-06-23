using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Models
{
	public class SupportQueuesData
	{
		public List<SupportQueueEntity> AvailableSupportQueues { get; set; }
		public List<AggregatedSupportQueueContentsRow> AllVisibleSupportQueueContents { get; set; }
		public DateTime UserLastVisitDate { get; set; }
	}
}