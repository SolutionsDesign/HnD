ForumRoleForumActionRight
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
ForumID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
RoleID | 2 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
ActionRightID | 3 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 

## Foreign key constraints

#### TF_ActionRight_TF_ForumRoleForumActionRight_FK1

Aspect | Value
--|--
Primary key table | [dbo.ActionRight](../dbo/ActionRight.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ActionRightID | dbo.ActionRight.ActionRightID

#### TF_Forum_TF_ForumRoleActionRight_FK1

Aspect | Value
--|--
Primary key table | [dbo.Forum](../dbo/Forum.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
ForumID | dbo.Forum.ForumID

#### TF_Role_TF_ForumRoleActionRight_FK1

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
[ForumRoleForumActionRight](../../../EntityModel/_DefaultGroup/Entities/ForumRoleForumActionRight.htm) | Entity
