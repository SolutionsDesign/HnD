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
	/// Extension class which extends the typedlist MessagesInThreadTypedList and adds a scalar query expression column to the typedlist. 
	/// </summary>
	public partial class MessagesInThreadTypedList
	{
		#region Class Member Declarations
		private DataColumn _columnAmountOfAttachments;
		#endregion

		/// <summary>
		/// Called when the typedlist's resultset has been build. This is the spot to add additional columns to the typedlist in code. 
		/// We do this in code because we can't add a scalar query expression in the typedlist designer. 
		/// </summary>
		/// <param name="fields">The typedlist resultset fields.</param>
		protected override void OnResultsetBuilt(IEntityFields fields)
		{
			// expand the fields with 1 slot, so we can add our scalar query expression to that slot
			int index = fields.Count;
			fields.Expand(1);
			// add a scalar query expression to the list of fields in the typedlist. The scalar query expression 
			// performs a SELECT COUNT(AttachmentID) FROM Attachments WHERE MessageID = Message.MessageID
			// query. Pass a type to the CTor as well, as otherwise the type isn't properly determinable. 
			fields.DefineField(new EntityField("AmountOfAttachments",
								new ScalarQueryExpression(AttachmentFields.AttachmentID.SetAggregateFunction(AggregateFunction.Count),
									(AttachmentFields.MessageID == MessageFields.MessageID)), typeof(int)), index);

			// done
			base.OnResultsetBuilt(fields);
		}


		/// <summary>
		/// Called when InitClass of the typedlist ended. 
		/// </summary>
		protected override void OnInitialized()
		{
			_columnAmountOfAttachments = new DataColumn("AmountOfAttachments", typeof(int), null, MappingType.Element);
			_columnAmountOfAttachments.ReadOnly = true;
			this.Columns.Add(_columnAmountOfAttachments);
			base.OnInitialized();
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the amount of attachments column.
		/// </summary>
		/// <value>The amount of attachments column.</value>
		internal DataColumn AmountOfAttachmentsColumn
		{
			get { return _columnAmountOfAttachments; }
		}
		#endregion
	}



	/// <summary>
	/// Extension class for the row class of the MessagesInThread typedlist. 
	/// </summary>
	public partial class MessagesInThreadRow
	{
		/// <summary>Gets / sets the value of the TypedList field AmountOfAttachments<br/><br/>
		/// </summary>
		/// <remarks>Mapped on: the scalar query expression for retrieving the # of attachments for each message</remarks>
		public int AmountOfAttachments
		{
			get
			{
				if(IsAmountOfAttachmentsNull())
				{
					return 0;
				}
				else
				{
					return (int)this[_parent.AmountOfAttachmentsColumn];
				}
			}
		}

		/// <summary>Returns true if the TypedList field MessageID is NULL, false otherwise.</summary>
		public bool IsAmountOfAttachmentsNull()
		{
			return IsNull(_parent.MessageIDColumn);
		}
	}
}
