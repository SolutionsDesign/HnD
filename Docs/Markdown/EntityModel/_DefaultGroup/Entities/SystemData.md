SystemData
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The SystemData entity is part of the following relationships 

Related Entity | Full description 
--|--
[Role](../../_DefaultGroup/Entities/Role.htm) | SystemData.RoleForAnonymous - Role.SystemDataAnonymousRole (m:1) 
[Role](../../_DefaultGroup/Entities/Role.htm) | SystemData.RoleForNewUser - Role.SystemDataDefaultRoleNewUser (m:1) 

## Fields

The following fields are defined in the SystemData entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
ID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
DefaultRoleNewUser | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
AnonymousRole | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
DefaultUserTitleNewUser | `int (System.Int32)` |   |  |  |  | 0 | 0 | 0
HoursThresholdForActiveThreads | `short (System.Int16)` |   |  |  |  | 0 | 0 | 0
PageSizeSearchResults | `short (System.Int16)` |   |  |  |  | 0 | 0 | 0
MinNumberOfThreadsToFetch | `short (System.Int16)` |   |  |  |  | 0 | 0 | 0
MinNumberOfNonStickyVisibleThreads | `short (System.Int16)` |   |  |  |  | 0 | 0 | 0
SendReplyNotifications | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.SystemData](../../../SQL_Server_SqlClient/HnD/dbo/SystemData.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
AnonymousRole | AnonymousRole |  | int | 0 | 10 | 0 |  | 
DefaultRoleNewUser | DefaultRoleNewUser |  | int | 0 | 10 | 0 |  | 
DefaultUserTitleNewUser | DefaultUserTitleNewUser |  | int | 0 | 10 | 0 |  | 
HoursThresholdForActiveThreads | HoursThresholdForActiveThreads |  | smallint | 0 | 5 | 0 |  | 
ID | ID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
MinNumberOfNonStickyVisibleThreads | MinNumberOfNonStickyVisibleThreads |  | smallint | 0 | 5 | 0 |  | 
MinNumberOfThreadsToFetch | MinNumberOfThreadsToFetch |  | smallint | 0 | 5 | 0 |  | 
PageSizeSearchResults | PageSizeSearchResults |  | smallint | 0 | 5 | 0 |  | 
SendReplyNotifications | SendReplyNotifications |  | bit | 0 | 0 | 0 |  | 

## Code generation information

### Setting values
#### SystemData (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### AnonymousRole (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### DefaultRoleNewUser (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### DefaultUserTitleNewUser (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### HoursThresholdForActiveThreads (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### MinNumberOfNonStickyVisibleThreads (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### MinNumberOfThreadsToFetch (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### PageSizeSearchResults (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### SendReplyNotifications (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### RoleForAnonymous (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### RoleForNewUser (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### AnonymousRole (NormalField)

* `Required`

#### DefaultRoleNewUser (NormalField)

* `Required`

#### DefaultUserTitleNewUser (NormalField)

* `Required`

#### HoursThresholdForActiveThreads (NormalField)

* `Required`
* `Range(1, 1000)`

#### ID (NormalField)

* `Required`

#### MinNumberOfNonStickyVisibleThreads (NormalField)

* `Required`
* `Range(1, 1000)`

#### MinNumberOfThreadsToFetch (NormalField)

* `Required`
* `Range(1, 1000)`

#### PageSizeSearchResults (NormalField)

* `Required`
* `Range(2, 1000)`

#### SendReplyNotifications (NormalField)

* `Required`

#### RoleForAnonymous (NavigatorSingleValue)

* `Browsable($true)`

#### RoleForNewUser (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### SystemData (Entity)

* `System.ComponentModel.DataAnnotations`

