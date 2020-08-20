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
	public class AddEditForumData
	{
		public AddEditForumData() : this(new ForumEntity())
		{}


		public AddEditForumData(ForumEntity toEdit)
		{
			this.ForumEdited = toEdit;
		}

		public void Sanitize()
		{
			if(this.ForumEdited == null)
			{
				return;
			}
			
			this.ForumEdited.DefaultSupportQueueID = this.ForumEdited.DefaultSupportQueueID <1 ? null : this.ForumEdited.DefaultSupportQueueID;
			this.ForumEdited.SectionID = this.ForumEdited.SectionID <= 0 ? 1 : this.ForumEdited.SectionID;
			if(this.ForumEdited.MaxNoOfAttachmentsPerMessage <= 0)
			{
				this.ForumEdited.MaxAttachmentSize = 0;
			}

			if(this.ForumEdited.ForumID <= 0)
			{
				this.ForumEdited.ForumID = 0;
			}
		}

		
		public List<SupportQueueDto> AllExistingSupportQueues { get; set; }
		public List<SectionDto> AllExistingSections { get; set; }
		public ForumEntity ForumEdited { get; }
	}
}