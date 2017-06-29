using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SD.HnD.Gui.Models
{
	public class AdvancedSearchModel
	{
		public string SearchParameters { get; set; }
		public string SearchTarget { get; set; }
		public List<int> TargetForums { get; set; }
		public string FirstSortClause { get; set; }
		public string SecondSortClause { get; set; }
	}
}