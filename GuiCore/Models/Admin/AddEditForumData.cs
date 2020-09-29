/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Collections.Generic;
using System.Linq;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DTOs.DtoClasses;

namespace SD.HnD.Gui.Models.Admin
{
	public class AddEditForumData
	{
		public AddEditForumData() : this(new ForumEntity())
		{
		}


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

			this.ForumEdited.DefaultSupportQueueID = this.ForumEdited.DefaultSupportQueueID < 1 ? null : this.ForumEdited.DefaultSupportQueueID;
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