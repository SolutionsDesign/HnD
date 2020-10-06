AuditDataCore
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
AuditDataID | 1 | int | 0 | 10 | 0 |  | Yes |  | Yes |  |  | 
AuditActionID | 2 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
UserID | 3 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
AuditedOn | 4 | datetime | 0 | 0 | 0 |  |  |  |  |  |  | 

## Foreign key constraints

#### TF_AuditDataCore_TF_AuditAction_FK1

Aspect | Value
--|--
Primary key table | [dbo.AuditAction](../dbo/AuditAction.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
AuditActionID | dbo.AuditAction.AuditActionID

#### TF_User_TF_AuditDataCore_FK1

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
[AuditDataCore](../../../EntityModel/_DefaultGroup/Entities/AuditDataCore.htm) | Entity
