UserTitle
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The UserTitle entity is part of the following relationships 

Related Entity | Full description 
--|--
[User](../../_DefaultGroup/Entities/User.htm) | User.UserTitle - UserTitle.Users (m:1) 

## Fields

The following fields are defined in the UserTitle entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
UserTitleID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
UserTitleDescription | `string (System.String)` |   |  |  |  | 50 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.UserTitle](../../../SQL_Server_SqlClient/HnD/dbo/UserTitle.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
UserTitleDescription | UserTitleDescription |  | varchar | 50 | 0 | 0 |  | 
UserTitleID | UserTitleID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 

## Code generation information

### Setting values
#### UserTitle (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### UserTitleDescription (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### UserTitleID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Users (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### UserTitleDescription (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### UserTitleID (NormalField)

* `Required`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### UserTitle (Entity)

* `System.ComponentModel.DataAnnotations`

