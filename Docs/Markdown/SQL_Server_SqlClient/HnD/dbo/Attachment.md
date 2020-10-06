Attachment
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
AttachmentID | 1 | int | 0 | 10 | 0 |  | Yes |  | Yes |  |  | 
MessageID | 2 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
Filename | 3 | nvarchar | 255 | 0 | 0 |  |  |  |  |  |  | 
Approved | 4 | bit | 0 | 0 | 0 |  |  |  |  |  |  | 
Filecontents | 5 | image | 2147483647 | 0 | 0 |  |  |  |  |  |  | 
Filesize | 6 | int | 0 | 10 | 0 |  |  |  |  |  |  | 
AddedOn | 7 | datetime | 0 | 0 | 0 |  |  |  |  |  |  | 

## Foreign key constraints

#### FK_Attachment_Message

Aspect | Value
--|--
Primary key table | [dbo.Message](../dbo/Message.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
MessageID | dbo.Message.MessageID

## Model elements mapped on this table

Model Element | Element type
--|--
[Attachment](../../../EntityModel/_DefaultGroup/Entities/Attachment.htm) | Entity
