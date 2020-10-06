RoleUser
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The RoleUser entity is part of the following relationships 

Related Entity | Full description 
--|--
[Role](../../_DefaultGroup/Entities/Role.htm) | RoleUser.Role - Role.RoleUser (m:1) 
[User](../../_DefaultGroup/Entities/User.htm) | RoleUser.User - User.RoleUser (m:1) 

## Fields

The following fields are defined in the RoleUser entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
RoleID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0
UserID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.RoleUser](../../../SQL_Server_SqlClient/HnD/dbo/RoleUser.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
RoleID | RoleID |  | int | 0 | 10 | 0 |  | 
UserID | UserID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### RoleUser (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### RoleID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### UserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Role (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### User (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### RoleID (NormalField)

* `Required`

#### UserID (NormalField)

* `Required`

#### Role (NavigatorSingleValue)

* `Browsable($true)`

#### User (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### RoleUser (Entity)

* `System.ComponentModel.DataAnnotations`

