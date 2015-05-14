using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.HnD.DAL.HelperClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.FactoryClasses
{
	/// <summary>
	/// Extension of the QueryFactory class.
	/// </summary>
	public partial class QueryFactory
	{
		/// <summary>Gets the query to fetch the typed list MessagesInThread, with the extended field</summary>
		/// <returns>Dynamic Query which fetches <see cref="SD.HnD.DAL.TypedListClasses.MessagesInThreadRow"/> instances </returns>
		public DynamicQuery<SD.HnD.DAL.TypedListClasses.MessagesInThreadRow> GetMessagesInThreadExtendedTypedList()
		{
			return this.Create()
						.Select(() => new SD.HnD.DAL.TypedListClasses.MessagesInThreadRow()
						{
							MessageID = MessageFields.MessageID.ToValue<System.Int32>(),
							PostingDate = MessageFields.PostingDate.ToValue<System.DateTime>(),
							MessageTextAsHTML = MessageFields.MessageTextAsHTML.ToValue<System.String>(),
							ThreadID = MessageFields.ThreadID.ToValue<System.Int32>(),
							PostedFromIP = MessageFields.PostedFromIP.ToValue<System.String>(),
							UserID = UserFields.UserID.ToValue<Nullable<System.Int32>>(),
							NickName = UserFields.NickName.ToValue<System.String>(),
							SignatureAsHTML = UserFields.SignatureAsHTML.ToValue<System.String>(),
							IconURL = UserFields.IconURL.ToValue<System.String>(),
							Location = UserFields.Location.ToValue<System.String>(),
							JoinDate = UserFields.JoinDate.ToValue<Nullable<System.DateTime>>(),
							AmountOfPostings = UserFields.AmountOfPostings.ToValue<Nullable<System.Int32>>(),
							UserTitleDescription = UserTitleFields.UserTitleDescription.ToValue<System.String>(),
							AmountOfAttachments = this.Create().Select(AttachmentFields.AttachmentID.Count())
													   		   .Where(AttachmentFields.MessageID == MessageFields.MessageID).ToScalar()
															   .ToValue<int>()
						})
						.From(this.Message
								.LeftJoin(this.User).On(MessageFields.PostedByUserID.Equal(UserFields.UserID))
								.InnerJoin(this.UserTitle).On(UserFields.UserTitleID.Equal(UserTitleFields.UserTitleID)));
		}
	}
}
