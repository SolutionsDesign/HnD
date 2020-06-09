using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SD.HnD.DALAdapter.TypedListClasses;

namespace SD.HnD.Gui.Models
{
	public class AdvancedSearchUIData
	{
		public int NumberOfMessages { get; set; }
		public List<ForumsWithSectionNameRow> AllAccessibleForumsWithSectionName { get; set; }
	}
}