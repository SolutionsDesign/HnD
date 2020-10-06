Thread
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
ThreadID | 1 | int | 0 | 10 | 0 |  | Yes |  | Yes |  |  | 
ForumID | 2 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
Subject | 3 | nvarchar | 250 | 0 | 0 |  |  |  |  |  |  | 
StartedByUserID | 4 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
IsSticky | 5 | bit | 0 | 0 | 0 |  |  |  |  |  |  | 
IsClosed | 6 | bit | 0 | 0 | 0 |  |  |  |  |  |  | 
MarkedAsDone | 7 | bit | 0 | 0 | 0 |  |  |  |  |  | (1) | 
Memo | 8 | ntext | 1073741823 | 0 | 0 | Yes |  |  |  |  |  | 

## Foreign key constraints

#### TF_Forum_TF_Thread_FK1

Aspect | Value
--|--
Primary key table | [dbo.Forum](../dbo/Forum.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ForumID | dbo.Forum.ForumID

#### TF_User_TF_Thread_FK1

Aspect | Value
--|--
Primary key table | [dbo.User](../dbo/User.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
StartedByUserID | dbo.User.UserID

## Model elements mapped on this table

Model Element | Element type
--|--
[Thread](../../../EntityModel/_DefaultGroup/Entities/Thread.htm) | Entity
