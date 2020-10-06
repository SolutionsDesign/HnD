Bookmark
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
ThreadID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
UserID | 2 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 

## Foreign key constraints

#### TF_Thread_TF_Bookmark_FK

Aspect | Value
--|--
Primary key table | [dbo.Thread](../dbo/Thread.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ThreadID | dbo.Thread.ThreadID

#### TF_User_TF_Bookmark_FK

Aspect | Value
--|--
Primary key table | [dbo.User](../dbo/User.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
UserID | dbo.User.UserID

## Model elements mapped on this table

Model Element | Element type
--|--
[Bookmark](../../../EntityModel/_DefaultGroup/Entities/Bookmark.htm) | Entity
