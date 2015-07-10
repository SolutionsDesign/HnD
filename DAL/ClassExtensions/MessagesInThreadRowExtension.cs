/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

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
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.HelperClasses;
using System.Data;

namespace SD.HnD.DAL.TypedListClasses
{
	/// <summary>
	/// Extension class which extends the typedlist row class MessagesInThreadRow
	/// </summary>
	public partial class MessagesInThreadRow
	{
		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the amount of attachments column.
		/// </summary>
		public int NumberOfAttachments { get; set; }
		#endregion
	}
}
