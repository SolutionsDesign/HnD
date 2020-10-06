AuditDataThreadRelated
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
AuditDataID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
ThreadID | 2 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 

## Foreign key constraints

#### TF_AuditDataThreadRelated_TF_AuditDataCore_FK1

Aspect | Value
--|--
Primary key table | [dbo.AuditDataCore](../dbo/AuditDataCore.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
AuditDataID | dbo.AuditDataCore.AuditDataID

#### TF_AuditDataThreadRelated_TF_Thread_FK1

Aspect | Value
--|--
Primary key table | [dbo.Thread](../dbo/Thread.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ThreadID | dbo.Thread.ThreadID

## Model elements mapped on this table

Model Element | Element type
--|--
[AuditDataThreadRelated](../../../EntityModel/_DefaultGroup/Entities/AuditDataThreadRelated.htm) | Entity
