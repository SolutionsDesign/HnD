using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD.HnD.BL.TypedDataClasses
{
	/// <summary>
	/// Simple class which contains aggregated data of an active thread for display purposes.
	/// </summary>
	public class AggregatedActiveThreadRow : AggregatedThreadRow
	{
		public string ForumName { get; set; }
	}
}
