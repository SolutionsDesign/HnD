using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SD.HnD.DTOs.DtoClasses;

namespace SD.HnD.Gui.Models
{
	public class MessageData
	{
		public int CurrentUserID { get; set; }
		public string SectionName { get; set; }
		public int ForumID { get; set; }
		public int ThreadID { get; set; }
		public int PageNo { get; set; }
		public string ForumName { get; set; }
		public virtual string ThreadSubject { get; set; }
		[Required]
		public string MessageText { get; set; }
		public bool Subscribe { get; set; }
		public MessageInThreadDto LastMessageInThread { get; set; }
	}
}