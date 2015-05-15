using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DAL.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Models
{
	/// <summary>
	/// Data for the Home / Index page. 
	/// </summary>
	public class HomeData
	{
		public string NickName { get; set; }
		public DateTime LastVisitedDateTime { get; set; }
		public EntityView<SectionEntity> SectionsFiltered { get; set; }
		public MultiValueHashtable<int, AggregatedForumRow> ForumDataPerDisplayedSection { get; set; } 
	}
}