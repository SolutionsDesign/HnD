PasswordResetToken
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The PasswordResetToken entity is part of the following relationships 

Related Entity | Full description 
--|--
[User](../../_DefaultGroup/Entities/User.htm) | User.PasswordResetToken - PasswordResetToken.User (1:1) 

## Fields

The following fields are defined in the PasswordResetToken entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
UserID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0
PasswordResetToken | `guid (System.Guid)` |   |  |  |  | 0 | 0 | 0
PasswordResetRequestedOn | `datetime (System.DateTime)` |   |  |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.PasswordResetToken](../../../SQL_Server_SqlClient/HnD/dbo/PasswordResetToken.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
PasswordResetRequestedOn | PasswordResetRequestedOn |  | datetime | 0 | 0 | 0 |  | 
PasswordResetToken | PasswordResetToken |  | uniqueidentifier | 0 | 0 | 0 |  | 
UserID | UserID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### PasswordResetToken (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### PasswordResetRequestedOn (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### PasswordResetToken (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### UserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### User (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### PasswordResetRequestedOn (NormalField)

* `Required`

#### PasswordResetToken (NormalField)

* `Required`

#### UserID (NormalField)

* `Required`

#### User (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### PasswordResetToken (Entity)

* `System.ComponentModel.DataAnnotations`

