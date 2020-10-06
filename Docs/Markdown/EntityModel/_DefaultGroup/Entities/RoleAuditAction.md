RoleAuditAction
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The RoleAuditAction entity is part of the following relationships 

Related Entity | Full description 
--|--
[AuditAction](../../_DefaultGroup/Entities/AuditAction.htm) | RoleAuditAction.AuditAction - AuditAction.RoleAuditActions (m:1) 
[Role](../../_DefaultGroup/Entities/Role.htm) | RoleAuditAction.Role - Role.RoleAuditAction (m:1) 

## Fields

The following fields are defined in the RoleAuditAction entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
AuditActionID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0
RoleID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.RoleAuditAction](../../../SQL_Server_SqlClient/HnD/dbo/RoleAuditAction.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
AuditActionID | AuditActionID |  | int | 0 | 10 | 0 |  | 
RoleID | RoleID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### RoleAuditAction (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### AuditActionID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### RoleID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AuditAction (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### Role (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### AuditActionID (NormalField)

* `Required`

#### RoleID (NormalField)

* `Required`

#### AuditAction (NavigatorSingleValue)

* `Browsable($true)`

#### Role (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### RoleAuditAction (Entity)

* `System.ComponentModel.DataAnnotations`

