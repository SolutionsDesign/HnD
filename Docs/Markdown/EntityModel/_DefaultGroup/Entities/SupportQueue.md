SupportQueue
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The SupportQueue entity is part of the following relationships 

Related Entity | Full description 
--|--
[Forum](../../_DefaultGroup/Entities/Forum.htm) | Forum.DefaultSupportQueue - SupportQueue.DefaultForForums (m:1) 
[SupportQueueThread](../../_DefaultGroup/Entities/SupportQueueThread.htm) | SupportQueueThread.SupportQueue - SupportQueue.SupportQueueThreads (m:1) 

## Fields

The following fields are defined in the SupportQueue entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
QueueID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
QueueName | `string (System.String)` |   |  |  |  | 50 | 0 | 0
QueueDescription | `string (System.String)` |   |  |  |  | 250 | 0 | 0
OrderNo | `short (System.Int16)` |   |  |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.SupportQueue](../../../SQL_Server_SqlClient/HnD/dbo/SupportQueue.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
OrderNo | OrderNo |  | smallint | 0 | 5 | 0 |  | 
QueueDescription | QueueDescription |  | nvarchar | 250 | 0 | 0 |  | 
QueueID | QueueID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
QueueName | QueueName |  | nvarchar | 50 | 0 | 0 |  | 

## Code generation information

### Setting values
#### SupportQueue (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### OrderNo (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### QueueDescription (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### QueueID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### QueueName (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### DefaultForForums (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### SupportQueueThreads (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### OrderNo (NormalField)

* `Required`

#### QueueDescription (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### QueueID (NormalField)

* `Required`

#### QueueName (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### SupportQueue (Entity)

* `System.ComponentModel.DataAnnotations`

