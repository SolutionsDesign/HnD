using System;
using System.Collections.Generic;
using System.Linq;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.Gui.Models
{
	public class ForumSelectorData
	{
		public EntityCollection<ForumEntity> Forums { get; set; } 
	}
}