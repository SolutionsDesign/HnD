RoleAuditAction
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
AuditActionID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
RoleID | 2 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 

## Foreign key constraints

#### TF_AuditAction_TF_RoleAuditAction_FK1

Aspect | Value
--|--
Primary key table | [dbo.AuditAction](../dbo/AuditAction.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
AuditActionID | dbo.AuditAction.AuditActionID

#### TF_Role_TF_RoleAuditAction_FK1

Aspect | Value
--|--
Primary key table | [dbo.Role](../dbo/Role.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
RoleID | dbo.Role.RoleID

## Model elements mapped on this table

Model Element | Element type
--|--
[RoleAuditAction](../../../EntityModel/_DefaultGroup/Entities/RoleAuditAction.htm) | Entity
