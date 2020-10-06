SupportQueueThread
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The SupportQueueThread entity is part of the following relationships 

Related Entity | Full description 
--|--
[SupportQueue](../../_DefaultGroup/Entities/SupportQueue.htm) | SupportQueueThread.SupportQueue - SupportQueue.SupportQueueThreads (m:1) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | SupportQueueThread.Thread - Thread.SupportQueueThread (1:1) 
[User](../../_DefaultGroup/Entities/User.htm) | SupportQueueThread.ClaimedByUser - User.SupportQueueThreadsClaimed (m:1) 
[User](../../_DefaultGroup/Entities/User.htm) | SupportQueueThread.PlacedInQueueByUser - User.SupportQueueThreadsPlaced (m:1) 

## Fields

The following fields are defined in the SupportQueueThread entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
QueueID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0
ThreadID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0
PlacedInQueueByUserID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
PlacedInQueueOn | `datetime (System.DateTime)` |   |  |  |  | 0 | 0 | 0
ClaimedByUserID | `int (System.Int32)` |   | Yes | Yes |  | 0 | 0 | 0
ClaimedOn | `datetime (System.DateTime)` |   |  | Yes |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.SupportQueueThread](../../../SQL_Server_SqlClient/HnD/dbo/SupportQueueThread.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
ClaimedByUserID | ClaimedByUserID | Yes | int | 0 | 10 | 0 |  | 
ClaimedOn | ClaimedOn | Yes | datetime | 0 | 0 | 0 |  | 
PlacedInQueueByUserID | PlacedInQueueByUserID |  | int | 0 | 10 | 0 |  | 
PlacedInQueueOn | PlacedInQueueOn |  | datetime | 0 | 0 | 0 |  | 
QueueID | QueueID |  | int | 0 | 10 | 0 |  | 
ThreadID | ThreadID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### SupportQueueThread (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### ClaimedByUserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ClaimedOn (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### PlacedInQueueByUserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### PlacedInQueueOn (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### QueueID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ThreadID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ClaimedByUser (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### PlacedInQueueByUser (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### SupportQueue (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### Thread (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### PlacedInQueueByUserID (NormalField)

* `Required`

#### PlacedInQueueOn (NormalField)

* `Required`

#### QueueID (NormalField)

* `Required`

#### ThreadID (NormalField)

* `Required`

#### ClaimedByUser (NavigatorSingleValue)

* `Browsable($true)`

#### PlacedInQueueByUser (NavigatorSingleValue)

* `Browsable($true)`

#### SupportQueue (NavigatorSingleValue)

* `Browsable($true)`

#### Thread (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### SupportQueueThread (Entity)

* `System.ComponentModel.DataAnnotations`

