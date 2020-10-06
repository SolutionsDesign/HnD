Message
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
MessageID | 1 | int | 0 | 10 | 0 |  | Yes |  | Yes |  |  | 
PostingDate | 2 | datetime | 0 | 0 | 0 |  |  |  |  |  |  | 
PostedByUserID | 3 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
ThreadID | 4 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
PostedFromIP | 5 | varchar | 25 | 0 | 0 |  |  |  |  |  | ('') | 
ChangeTrackerStamp | 6 | timestamp | 8 | 0 | 0 |  |  |  |  |  |  | 
MessageText | 7 | ntext | 1073741823 | 0 | 0 | Yes |  |  |  |  |  | 
MessageTextAsHTML | 8 | ntext | 1073741823 | 0 | 0 | Yes |  |  |  |  |  | 

## Foreign key constraints

#### TF_Thread_TF_Message_FK1

Aspect | Value
--|--
Primary key table | [dbo.Thread](../dbo/Thread.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ThreadID | dbo.Thread.ThreadID

#### TF_User_TF_Message_FK1

Aspect | Value
--|--
Primary key table | [dbo.User](../dbo/User.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
PostedByUserID | dbo.User.UserID

## Model elements mapped on this table

Model Element | Element type
--|--
[Message](../../../EntityModel/_DefaultGroup/Entities/Message.htm) | Entity
