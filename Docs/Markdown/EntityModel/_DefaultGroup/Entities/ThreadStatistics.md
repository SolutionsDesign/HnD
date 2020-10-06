ThreadStatistics
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The ThreadStatistics entity is part of the following relationships 

Related Entity | Full description 
--|--
[Message](../../_DefaultGroup/Entities/Message.htm) | ThreadStatistics.LastMessage - Message.ThreadStatistics (1:1) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | Thread.Statistics - ThreadStatistics.Thread (1:1) 

## Fields

The following fields are defined in the ThreadStatistics entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
ThreadID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0
LastMessageID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
NumberOfMessages | `int (System.Int32)` |   |  |  |  | 0 | 0 | 0
NumberOfViews | `int (System.Int32)` |   |  |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.ThreadStatistics](../../../SQL_Server_SqlClient/HnD/dbo/ThreadStatistics.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
LastMessageID | LastMessageID |  | int | 0 | 10 | 0 |  | 
NumberOfMessages | NumberOfMessages |  | int | 0 | 10 | 0 |  | 
NumberOfViews | NumberOfViews |  | int | 0 | 10 | 0 |  | 
ThreadID | ThreadID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### ThreadStatistics (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### LastMessageID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### NumberOfMessages (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### NumberOfViews (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ThreadID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### LastMessage (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### Thread (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### LastMessageID (NormalField)

* `Required`

#### NumberOfMessages (NormalField)

* `Required`

#### NumberOfViews (NormalField)

* `Required`

#### ThreadID (NormalField)

* `Required`

#### LastMessage (NavigatorSingleValue)

* `Browsable($true)`

#### Thread (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### ThreadStatistics (Entity)

* `System.ComponentModel.DataAnnotations`

