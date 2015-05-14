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
		//protected override void OnResultsetBuilt(IEntityFields fields)
		//{
		//	// expand the fields with 1 slot, so we can add our scalar query expression to that slot
		//	int index = fields.Count;
		//	fields.Expand(1);
		//	// add a scalar query expression to the list of fields in the typedlist. The scalar query expression 
		//	// performs a SELECT COUNT(AttachmentID) FROM Attachments WHERE MessageID = Message.MessageID
		//	// query. Pass a type to the CTor as well, as otherwise the type isn't properly determinable. 
		//	fields.DefineField(new EntityField("AmountOfAttachments",
		//						new ScalarQueryExpression(AttachmentFields.AttachmentID.SetAggregateFunction(AggregateFunction.Count),
		//							(AttachmentFields.MessageID == MessageFields.MessageID)), typeof(int)), index);

		//	// done
		//	base.OnResultsetBuilt(fields);
		//}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the amount of attachments column.
		/// </summary>
		public int AmountOfAttachments { get; set; }
		#endregion
	}
}
