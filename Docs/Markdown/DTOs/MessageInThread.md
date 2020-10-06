DTOs.MessageInThread General Information
================

The derived element is derived from the [Message](../EntityModel/_DefaultGroup/Entities/Message.htm) entity.

## Derived element shape

Element | Kind | Type | Source
--|--
<span style="padding-left:0px">&nbsp;</span>MessageInThread |  |  | [Message](../EntityModel/_DefaultGroup/Entities/Message.htm)
<span style="padding-left:25px">&nbsp;</span>MessageID | Field | int (System.Int32) | Message.MessageID
<span style="padding-left:25px">&nbsp;</span>MessageTextAsHTML | Field | string (System.String) | Message.MessageTextAsHTML
<span style="padding-left:25px">&nbsp;</span>PostedFromIP | Field | string (System.String) | Message.PostedFromIP
<span style="padding-left:25px">&nbsp;</span>PostingDate | Field | datetime (System.DateTime) | Message.PostingDate
<span style="padding-left:25px">&nbsp;</span>ThreadID | Field | int (System.Int32) | Message.ThreadID (FK)
<span style="padding-left:25px">&nbsp;</span>PostedByUser | Field, Single element |  | 
<span style="padding-left:50px">&nbsp;</span>PostedByUser | Embedded element |  | [User (PostedByUser)](../EntityModel/_DefaultGroup/Entities/User.htm)
<span style="padding-left:75px">&nbsp;</span>AmountOfPostings | Field | int (System.Int32) | User.AmountOfPostings
<span style="padding-left:75px">&nbsp;</span>IconURL | Field | string (System.String) | User.IconURL
<span style="padding-left:75px">&nbsp;</span>JoinDate | Field | datetime (System.DateTime) | User.JoinDate
<span style="padding-left:75px">&nbsp;</span>Location | Field | string (System.String) | User.Location
<span style="padding-left:75px">&nbsp;</span>NickName | Field | string (System.String) | User.NickName
<span style="padding-left:75px">&nbsp;</span>Signature | Field | string (System.String) | User.Signature
<span style="padding-left:75px">&nbsp;</span>UserID | Field | int (System.Int32) | User.UserID
<span style="padding-left:75px">&nbsp;</span>UserTitleDescription | Field | string (System.String) | UserTitle.UserTitleDescription (PostedByUser.UserTitle)
<span style="padding-left:25px">&nbsp;</span>Attachments | Field, Set of elements |  | 
<span style="padding-left:50px">&nbsp;</span>Attachment | Embedded element |  | [Attachment (Attachments)](../EntityModel/_DefaultGroup/Entities/Attachment.htm)
<span style="padding-left:75px">&nbsp;</span>AddedOn | Field | datetime (System.DateTime) | Attachment.AddedOn
<span style="padding-left:75px">&nbsp;</span>Approved | Field | bool (System.Boolean) | Attachment.Approved
<span style="padding-left:75px">&nbsp;</span>AttachmentID | Field | int (System.Int32) | Attachment.AttachmentID
<span style="padding-left:75px">&nbsp;</span>Filename | Field | string (System.String) | Attachment.Filename
<span style="padding-left:75px">&nbsp;</span>Filesize | Field | int (System.Int32) | Attachment.Filesize


