ThreadStatistics
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
ThreadID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
LastMessageID | 2 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
NumberOfMessages | 3 | int | 0 | 10 | 0 |  |  |  |  |  |  | 
NumberOfViews | 4 | int | 0 | 10 | 0 |  |  |  |  |  |  | 

## Foreign key constraints

#### FK_15e6b0a402d80d4e4b0df3453c5

Aspect | Value
--|--
Primary key table | [dbo.Thread](../dbo/Thread.htm)
Delete rule | Cascade
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ThreadID | dbo.Thread.ThreadID

#### FK_2033ff74285bde08311a5a99ae1

Aspect | Value
--|--
Primary key table | [dbo.Message](../dbo/Message.htm)
Delete rule | Cascade
Update rule | NoAction 

Foreign key field | Primary key field
--|--
LastMessageID | dbo.Message.MessageID

## Unique constraints

Constraint name | Fields
--|--
UC_19c59ce41b5be7a6d2c358322d4 | LastMessageID


## Model elements mapped on this table

Model Element | Element type
--|--
[ThreadStatistics](../../../EntityModel/_DefaultGroup/Entities/ThreadStatistics.htm) | Entity
