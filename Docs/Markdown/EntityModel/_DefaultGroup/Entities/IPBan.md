IPBan
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The IPBan entity is part of the following relationships 

Related Entity | Full description 
--|--
[User](../../_DefaultGroup/Entities/User.htm) | IPBan.SetByUser - User.IPBansSet (m:1) 

## Fields

The following fields are defined in the IPBan entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
IPBanID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
IPSegment1 | `byte (System.Byte)` |   |  |  |  | 0 | 0 | 0
IPSegment2 | `byte (System.Byte)` |   |  |  |  | 0 | 0 | 0
IPSegment3 | `byte (System.Byte)` |   |  |  |  | 0 | 0 | 0
IPSegment4 | `byte (System.Byte)` |   |  |  |  | 0 | 0 | 0
Range | `byte (System.Byte)` |   |  |  |  | 0 | 0 | 0
IPBanSetByUserID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
IPBanSetOn | `datetime (System.DateTime)` |   |  |  |  | 0 | 0 | 0
Reason | `string (System.String)` |   |  |  |  | 1073741823 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields

Name | Field type | Mapped onto field | Read-only
--|--
SetByUserNickName | `string (System.String)` | [User.NickName](../../_DefaultGroup/Entities/User.htm#fields) | 

## Mappings

#### [HnD.dbo.IPBan](../../../SQL_Server_SqlClient/HnD/dbo/IPBan.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
IPBanID | IPBanID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
IPBanSetByUserID | IPBanSetByUserID |  | int | 0 | 10 | 0 |  | 
IPBanSetOn | IPBanSetOn |  | datetime | 0 | 0 | 0 |  | 
IPSegment1 | IPSegment1 |  | tinyint | 0 | 3 | 0 |  | 
IPSegment2 | IPSegment2 |  | tinyint | 0 | 3 | 0 |  | 
IPSegment3 | IPSegment3 |  | tinyint | 0 | 3 | 0 |  | 
IPSegment4 | IPSegment4 |  | tinyint | 0 | 3 | 0 |  | 
Range | Range |  | tinyint | 0 | 3 | 0 |  | 
Reason | Reason |  | ntext | 1073741823 | 0 | 0 |  | 

## Code generation information

### Setting values
#### IPBan (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### IPBanID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IPBanSetByUserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IPBanSetOn (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IPSegment1 (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IPSegment2 (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IPSegment3 (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IPSegment4 (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Range (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Reason (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### SetByUser (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### IPBanID (NormalField)

* `Required`

#### IPBanSetByUserID (NormalField)

* `Required`

#### IPBanSetOn (NormalField)

* `Required`

#### IPSegment1 (NormalField)

* `Required`

#### IPSegment2 (NormalField)

* `Required`

#### IPSegment3 (NormalField)

* `Required`

#### IPSegment4 (NormalField)

* `Required`

#### Range (NormalField)

* `Required`

#### Reason (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### SetByUser (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### IPBan (Entity)

* `System.ComponentModel.DataAnnotations`

