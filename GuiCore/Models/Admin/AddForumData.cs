using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.TypedListClasses;
using SD.HnD.DTOs.DtoClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.Gui.Models.Admin
{
	public class AddForumData
	{
		public List<SupportQueueDto> AllExistingSupportQueues { get; set; }
		public List<SectionDto> AllExistingSections { get; set; }
		
		[Required]
		[StringLength(50)]
		[MinLength(2)]
		public string ForumName { get; set; }
		[Required]
		[StringLength(250)]
		[MinLength(2)]
		public string ForumDescription { get; set; }
		public bool HasRSSFeed { get; set; }
		public int DefaultSupportQueueID { get; set; }
		[Required]
		public int SectionID { get; set; }
		[Required]
		public short OrderNo { get; set; }
		public int MaxAttachmentSize { get; set; }
		public short MaxNoOfAttachmentsPerMessage { get; set; }
		public string NewThreadWelcomeText { get; set; }
		
		public bool Persisted { get; set; }


		public void Sanitize()
		{
			this.DefaultSupportQueueID = this.DefaultSupportQueueID < -1 ? -1 : this.DefaultSupportQueueID;
			this.SectionID = this.SectionID <= 0 ? 1 : this.SectionID;
			if(this.MaxNoOfAttachmentsPerMessage <= 0)
			{
				this.MaxAttachmentSize = 0;
			}
		}
	}
}