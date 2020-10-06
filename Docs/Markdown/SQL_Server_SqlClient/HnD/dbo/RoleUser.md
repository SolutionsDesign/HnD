RoleUser
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
RoleID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
UserID | 2 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 

## Foreign key constraints

#### TF_Role_TF_RoleUser_FK1

Aspect | Value
--|--
Primary key table | [dbo.Role](../dbo/Role.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
RoleID | dbo.Role.RoleID

#### TF_User_TF_RoleUser_FK1

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
[RoleUser](../../../EntityModel/_DefaultGroup/Entities/RoleUser.htm) | Entity
