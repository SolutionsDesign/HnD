AuditAction
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The AuditAction entity is part of the following relationships 

Related Entity | Full description 
--|--
[AuditDataCore](../../_DefaultGroup/Entities/AuditDataCore.htm) | AuditDataCore.AuditAction - AuditAction.AuditDataCore (m:1) 
[Role](../../_DefaultGroup/Entities/Role.htm) | Role.AssignedAuditActions - AuditAction.RolesWithAuditAction (m:n) (via RoleAuditAction) 
[RoleAuditAction](../../_DefaultGroup/Entities/RoleAuditAction.htm) | RoleAuditAction.AuditAction - AuditAction.RoleAuditActions (m:1) 

## Fields

The following fields are defined in the AuditAction entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
AuditActionID | `int (System.Int32)` |  Yes |  |  |  | 0 | 0 | 0
AuditActionDescription | `string (System.String)` |   |  |  |  | 50 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.AuditAction](../../../SQL_Server_SqlClient/HnD/dbo/AuditAction.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
AuditActionDescription | AuditActionDescription |  | nvarchar | 50 | 0 | 0 |  | 
AuditActionID | AuditActionID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### AuditAction (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### AuditActionDescription (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AuditActionID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AuditDataCore (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### RoleAuditActions (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### RolesWithAuditAction (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### AuditActionDescription (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### AuditActionID (NormalField)

* `Required`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### AuditAction (Entity)

* `System.ComponentModel.DataAnnotations`

