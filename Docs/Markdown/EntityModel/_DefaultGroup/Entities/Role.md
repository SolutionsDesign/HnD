Role
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The Role entity is part of the following relationships 

Related Entity | Full description 
--|--
[ActionRight](../../_DefaultGroup/Entities/ActionRight.htm) | ActionRight.SystemRightAssignedToRoles - Role.AssignedSystemActionRights (m:n) (via RoleSystemActionRight) 
[AuditAction](../../_DefaultGroup/Entities/AuditAction.htm) | Role.AssignedAuditActions - AuditAction.RolesWithAuditAction (m:n) (via RoleAuditAction) 
[ForumRoleForumActionRight](../../_DefaultGroup/Entities/ForumRoleForumActionRight.htm) | ForumRoleForumActionRight.Role - Role.ForumRoleForumActionRights (m:1) 
[RoleAuditAction](../../_DefaultGroup/Entities/RoleAuditAction.htm) | RoleAuditAction.Role - Role.RoleAuditAction (m:1) 
[RoleSystemActionRight](../../_DefaultGroup/Entities/RoleSystemActionRight.htm) | RoleSystemActionRight.Role - Role.RoleSystemActionRights (m:1) 
[RoleUser](../../_DefaultGroup/Entities/RoleUser.htm) | RoleUser.Role - Role.RoleUser (m:1) 
[SystemData](../../_DefaultGroup/Entities/SystemData.htm) | SystemData.RoleForAnonymous - Role.SystemDataAnonymousRole (m:1) 
[SystemData](../../_DefaultGroup/Entities/SystemData.htm) | SystemData.RoleForNewUser - Role.SystemDataDefaultRoleNewUser (m:1) 
[User](../../_DefaultGroup/Entities/User.htm) | Role.Users - User.Roles (m:n) (via RoleUser) 

## Fields

The following fields are defined in the Role entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
RoleID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
RoleDescription | `string (System.String)` |   |  |  |  | 50 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.Role](../../../SQL_Server_SqlClient/HnD/dbo/Role.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
RoleDescription | RoleDescription |  | nvarchar | 50 | 0 | 0 |  | 
RoleID | RoleID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 

## Code generation information

### Setting values
#### Role (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### RoleDescription (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### RoleID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AssignedAuditActions (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### AssignedSystemActionRights (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### ForumRoleForumActionRights (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### RoleAuditAction (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### RoleSystemActionRights (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### RoleUser (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### SystemDataAnonymousRole (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### SystemDataDefaultRoleNewUser (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### Users (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### RoleDescription (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### RoleID (NormalField)

* `Required`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### Role (Entity)

* `System.ComponentModel.DataAnnotations`

