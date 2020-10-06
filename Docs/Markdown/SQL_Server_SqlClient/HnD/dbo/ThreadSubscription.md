ThreadSubscription
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
UserID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
ThreadID | 2 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 

## Foreign key constraints

#### FK_ThreadSubscription_Thread

Aspect | Value
--|--
Primary key table | [dbo.Thread](../dbo/Thread.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ThreadID | dbo.Thread.ThreadID

#### FK_ThreadSubscription_User

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
[ThreadSubscription](../../../EntityModel/_DefaultGroup/Entities/ThreadSubscription.htm) | Entity
