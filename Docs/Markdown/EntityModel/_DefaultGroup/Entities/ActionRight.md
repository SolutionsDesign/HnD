ActionRight
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The ActionRight entity is part of the following relationships 

Related Entity | Full description 
--|--
[ForumRoleForumActionRight](../../_DefaultGroup/Entities/ForumRoleForumActionRight.htm) | ForumRoleForumActionRight.ActionRight - ActionRight.ForumRoleForumActionRights (m:1) 
[Role](../../_DefaultGroup/Entities/Role.htm) | ActionRight.SystemRightAssignedToRoles - Role.AssignedSystemActionRights (m:n) (via RoleSystemActionRight) 
[RoleSystemActionRight](../../_DefaultGroup/Entities/RoleSystemActionRight.htm) | RoleSystemActionRight.ActionRight - ActionRight.RoleSystemActionRights (m:1) 

## Fields

The following fields are defined in the ActionRight entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
ActionRightID | `int (System.Int32)` |  Yes |  |  |  | 0 | 0 | 0
ActionRightDescription | `string (System.String)` |   |  |  |  | 50 | 0 | 0
AppliesToForum | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0
AppliesToSystem | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.ActionRight](../../../SQL_Server_SqlClient/HnD/dbo/ActionRight.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
ActionRightDescription | ActionRightDescription |  | nvarchar | 50 | 0 | 0 |  | 
ActionRightID | ActionRightID |  | int | 0 | 10 | 0 |  | 
AppliesToForum | AppliesToForum |  | bit | 0 | 0 | 0 |  | 
AppliesToSystem | AppliesToSystem |  | bit | 0 | 0 | 0 |  | 

## Code generation information

### Setting values
#### ActionRight (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### ActionRightDescription (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ActionRightID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AppliesToForum (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AppliesToSystem (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ForumRoleForumActionRights (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### RoleSystemActionRights (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### SystemRightAssignedToRoles (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### ActionRightDescription (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### ActionRightID (NormalField)

* `Required`

#### AppliesToForum (NormalField)

* `Required`

#### AppliesToSystem (NormalField)

* `Required`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### ActionRight (Entity)

* `System.ComponentModel.DataAnnotations`

