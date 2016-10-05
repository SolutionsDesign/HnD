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
using System.Linq;
using System.Text;
using SD.HnD.DALAdapter.HelperClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.FactoryClasses
{
	/// <summary>
	/// Extension of the QueryFactory class.
	/// </summary>
	public partial class QueryFactory
	{
		/// <summary>Gets the query to fetch the typed list MessagesInThread, with the extended field</summary>
		/// <returns>Dynamic Query which fetches <see cref="SD.HnD.DALAdapter.TypedListClasses.MessagesInThreadRow"/> instances </returns>
		public DynamicQuery<SD.HnD.DALAdapter.TypedListClasses.MessagesInThreadRow> GetMessagesInThreadExtendedTypedList()
		{
			return this.Create()
						.Select(() => new SD.HnD.DALAdapter.TypedListClasses.MessagesInThreadRow()
						{
							MessageID = MessageFields.MessageID.ToValue<System.Int32>(),
							PostingDate = MessageFields.PostingDate.ToValue<System.DateTime>(),
							MessageTextAsHTML = MessageFields.MessageTextAsHTML.ToValue<System.String>(),
							ThreadID = MessageFields.ThreadID.ToValue<System.Int32>(),
							PostedFromIP = MessageFields.PostedFromIP.ToValue<System.String>(),
							UserID = UserFields.UserID.ToValue<Nullable<System.Int32>>(),
							NickName = UserFields.NickName.ToValue<System.String>(),
							IconURL = UserFields.IconURL.ToValue<System.String>(),
							Location = UserFields.Location.ToValue<System.String>(),
							JoinDate = UserFields.JoinDate.ToValue<Nullable<System.DateTime>>(),
							AmountOfPostings = UserFields.AmountOfPostings.ToValue<Nullable<System.Int32>>(),
							UserTitleDescription = UserTitleFields.UserTitleDescription.ToValue<System.String>(),
							Signature = UserFields.Signature.ToValue<string>(),
							NumberOfAttachments = this.Create().Select(AttachmentFields.AttachmentID.Count())
													   		   .Where(AttachmentFields.MessageID == MessageFields.MessageID).ToScalar()
															   .ToValue<int>()
						})
						.From(this.Message
								.LeftJoin(this.User).On(MessageFields.PostedByUserID.Equal(UserFields.UserID))
								.InnerJoin(this.UserTitle).On(UserFields.UserTitleID.Equal(UserTitleFields.UserTitleID)));
		}
	}
}
