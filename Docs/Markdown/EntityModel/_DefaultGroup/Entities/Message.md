Message
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The Message entity is part of the following relationships 

Related Entity | Full description 
--|--
[Attachment](../../_DefaultGroup/Entities/Attachment.htm) | Attachment.BelongsToMessage - Message.Attachments (m:1) 
[AuditDataMessageRelated](../../_DefaultGroup/Entities/AuditDataMessageRelated.htm) | AuditDataMessageRelated.Message - Message.AuditDataMessageRelated (m:1) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | Message.Thread - Thread.Messages (m:1) 
[ThreadStatistics](../../_DefaultGroup/Entities/ThreadStatistics.htm) | ThreadStatistics.LastMessage - Message.ThreadStatistics (1:1) 
[User](../../_DefaultGroup/Entities/User.htm) | Message.PostedByUser - User.PostedMessages (m:1) 

## Fields

The following fields are defined in the Message entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
MessageID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
PostingDate | `datetime (System.DateTime)` |   |  |  |  | 0 | 0 | 0
PostedByUserID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
ThreadID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
PostedFromIP | `string (System.String)` |   |  |  |  | 25 | 0 | 0
ChangeTrackerStamp | `byte[] (System.Byte[])` |   |  |  | Yes | 8 | 0 | 0
MessageText | `string (System.String)` |   |  | Yes |  | 1073741823 | 0 | 0
MessageTextAsHTML | `string (System.String)` |   |  | Yes |  | 1073741823 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.Message](../../../SQL_Server_SqlClient/HnD/dbo/Message.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
ChangeTrackerStamp | ChangeTrackerStamp |  | timestamp | 8 | 0 | 0 |  | 
MessageID | MessageID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
MessageText | MessageText | Yes | ntext | 1073741823 | 0 | 0 |  | 
MessageTextAsHTML | MessageTextAsHTML | Yes | ntext | 1073741823 | 0 | 0 |  | 
PostedByUserID | PostedByUserID |  | int | 0 | 10 | 0 |  | 
PostedFromIP | PostedFromIP |  | varchar | 25 | 0 | 0 |  | 
PostingDate | PostingDate |  | datetime | 0 | 0 | 0 |  | 
ThreadID | ThreadID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### Message (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### ChangeTrackerStamp (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### MessageID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### MessageText (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### MessageTextAsHTML (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### PostedByUserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### PostedFromIP (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### PostingDate (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ThreadID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Attachments (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### AuditDataMessageRelated (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### PostedByUser (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### Thread (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### ThreadStatistics (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### ChangeTrackerStamp (NormalField)

* `Required`

#### MessageID (NormalField)

* `Required`

#### MessageText (NormalField)

* `StringLength($length)`

#### MessageTextAsHTML (NormalField)

* `StringLength($length)`

#### PostedByUserID (NormalField)

* `Required`

#### PostedFromIP (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### PostingDate (NormalField)

* `Required`

#### ThreadID (NormalField)

* `Required`

#### PostedByUser (NavigatorSingleValue)

* `Browsable($true)`

#### Thread (NavigatorSingleValue)

* `Browsable($true)`

#### ThreadStatistics (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### Message (Entity)

* `System.ComponentModel.DataAnnotations`

