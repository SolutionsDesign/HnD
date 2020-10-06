SupportQueueThread
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
QueueID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
ThreadID | 2 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
PlacedInQueueByUserID | 3 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
PlacedInQueueOn | 4 | datetime | 0 | 0 | 0 |  |  |  |  |  |  | 
ClaimedByUserID | 5 | int | 0 | 10 | 0 | Yes |  | Yes |  |  |  | 
ClaimedOn | 6 | datetime | 0 | 0 | 0 | Yes |  |  |  |  |  | 

## Foreign key constraints

#### FK_SupportQueueThread_SupportQueue

Aspect | Value
--|--
Primary key table | [dbo.SupportQueue](../dbo/SupportQueue.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
QueueID | dbo.SupportQueue.QueueID

#### FK_SupportQueueThread_Thread

Aspect | Value
--|--
Primary key table | [dbo.Thread](../dbo/Thread.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ThreadID | dbo.Thread.ThreadID

#### FK_SupportQueueThread_User

Aspect | Value
--|--
Primary key table | [dbo.User](../dbo/User.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
PlacedInQueueByUserID | dbo.User.UserID

#### FK_SupportQueueThread_User1

Aspect | Value
--|--
Primary key table | [dbo.User](../dbo/User.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ClaimedByUserID | dbo.User.UserID

## Unique constraints

Constraint name | Fields
--|--
UC_SupportQueueThread_ThreadID | ThreadID


## Model elements mapped on this table

Model Element | Element type
--|--
[SupportQueueThread](../../../EntityModel/_DefaultGroup/Entities/SupportQueueThread.htm) | Entity
