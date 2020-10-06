Forum
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
ForumID | 1 | int | 0 | 10 | 0 |  | Yes |  | Yes |  |  | 
SectionID | 2 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
ForumName | 3 | nvarchar | 50 | 0 | 0 |  |  |  |  |  |  | 
ForumDescription | 4 | nvarchar | 250 | 0 | 0 |  |  |  |  |  |  | 
ForumLastPostingDate | 5 | datetime | 0 | 0 | 0 | Yes |  |  |  |  |  | 
HasRSSFeed | 6 | bit | 0 | 0 | 0 |  |  |  |  |  | (1) | 
DefaultSupportQueueID | 7 | int | 0 | 10 | 0 | Yes |  | Yes |  |  |  | 
OrderNo | 8 | smallint | 0 | 5 | 0 |  |  |  |  |  | (0) | 
MaxAttachmentSize | 9 | int | 0 | 10 | 0 | Yes |  |  |  |  | (512) | 
MaxNoOfAttachmentsPerMessage | 10 | smallint | 0 | 5 | 0 | Yes |  |  |  |  | (1) | 
NewThreadWelcomeText | 11 | ntext | 1073741823 | 0 | 0 | Yes |  |  |  |  |  | 
NewThreadWelcomeTextAsHTML | 12 | ntext | 1073741823 | 0 | 0 | Yes |  |  |  |  |  | 

## Foreign key constraints

#### FK_Forum_SupportQueue

Aspect | Value
--|--
Primary key table | [dbo.SupportQueue](../dbo/SupportQueue.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
DefaultSupportQueueID | dbo.SupportQueue.QueueID

#### TF_Section_TF_Forum_FK1

Aspect | Value
--|--
Primary key table | [dbo.Section](../dbo/Section.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
SectionID | dbo.Section.SectionID

## Model elements mapped on this table

Model Element | Element type
--|--
[Forum](../../../EntityModel/_DefaultGroup/Entities/Forum.htm) | Entity
