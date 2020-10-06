RoleSystemActionRight
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
RoleID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
ActionRightID | 2 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 

## Foreign key constraints

#### TF_ActionRight_TF_RoleSystemActionRight_FK1

Aspect | Value
--|--
Primary key table | [dbo.ActionRight](../dbo/ActionRight.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ActionRightID | dbo.ActionRight.ActionRightID

#### TF_Role_TF_RoleSystemActionRight_FK1

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
[RoleSystemActionRight](../../../EntityModel/_DefaultGroup/Entities/RoleSystemActionRight.htm) | Entity
