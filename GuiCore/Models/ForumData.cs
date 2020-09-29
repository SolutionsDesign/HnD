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
using System.Web;
using SD.HnD.BL.TypedDataClasses;

namespace SD.HnD.Gui.Models
{
	/// <summary>
	/// Data for the Forum page, which lists the active threads of a forum.
	/// </summary>
	public class ForumData
	{
		public string ForumName { get; set; }
		public string ForumDescription { get; set; }
		public string SectionName { get; set; }
		public int ForumID { get; set; }
		public bool HasRSSFeed { get; set; }
		public int PageNo { get; set; }
		public int PageSize { get; set; }
		public List<AggregatedThreadRow> ThreadRows { get; set; }
		public DateTime UserLastVisitDate { get; set; }
		public bool UserCanCreateThreads { get; set; }

		public int PageNoOlderMessages
		{
			get { return this.PageNo + 1; }
		}

		public int PageNoNewerMessages
		{
			get
			{
				var toReturn = this.PageNo - 1;
				return toReturn <= 0 ? 0 : toReturn;
			}
		}
	}
}