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
using System.Text;

namespace SD.HnD.BL.TypedDataClasses
{
	/// <summary>
	/// Simple class which contains aggregated data of a forum for display purposes.
	/// </summary>
	public class AggregatedForumRow
	{
		public int ForumID { get; set; }
		public string ForumName { get; set; }
		public string ForumDescription { get; set; }
		public DateTime? ForumLastPostingDate { get; set; }
		public int AmountThreads { get; set; }
		public int AmountMessages { get; set; }
		public bool HasRSSFeed { get; set; }
		public int SectionID { get; set; }
	}
}
