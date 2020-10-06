RoleSystemActionRight
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The RoleSystemActionRight entity is part of the following relationships 

Related Entity | Full description 
--|--
[ActionRight](../../_DefaultGroup/Entities/ActionRight.htm) | RoleSystemActionRight.ActionRight - ActionRight.RoleSystemActionRights (m:1) 
[Role](../../_DefaultGroup/Entities/Role.htm) | RoleSystemActionRight.Role - Role.RoleSystemActionRights (m:1) 

## Fields

The following fields are defined in the RoleSystemActionRight entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
RoleID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0
ActionRightID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.RoleSystemActionRight](../../../SQL_Server_SqlClient/HnD/dbo/RoleSystemActionRight.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
ActionRightID | ActionRightID |  | int | 0 | 10 | 0 |  | 
RoleID | RoleID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### RoleSystemActionRight (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### ActionRightID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### RoleID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ActionRight (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### Role (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### ActionRightID (NormalField)

* `Required`

#### RoleID (NormalField)

* `Required`

#### ActionRight (NavigatorSingleValue)

* `Browsable($true)`

#### Role (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### RoleSystemActionRight (Entity)

* `System.ComponentModel.DataAnnotations`

