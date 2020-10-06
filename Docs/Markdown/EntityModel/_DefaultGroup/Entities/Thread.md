Thread
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The Thread entity is part of the following relationships 

Related Entity | Full description 
--|--
[AuditDataThreadRelated](../../_DefaultGroup/Entities/AuditDataThreadRelated.htm) | AuditDataThreadRelated.Thread - Thread.AuditDataThreadRelated (m:1) 
[Bookmark](../../_DefaultGroup/Entities/Bookmark.htm) | Bookmark.Thread - Thread.PresentInBookmarks (m:1) 
[Forum](../../_DefaultGroup/Entities/Forum.htm) | Thread.Forum - Forum.Threads (m:1) 
[Message](../../_DefaultGroup/Entities/Message.htm) | Message.Thread - Thread.Messages (m:1) 
[SupportQueueThread](../../_DefaultGroup/Entities/SupportQueueThread.htm) | SupportQueueThread.Thread - Thread.SupportQueueThread (1:1) 
[ThreadStatistics](../../_DefaultGroup/Entities/ThreadStatistics.htm) | Thread.Statistics - ThreadStatistics.Thread (1:1) 
[ThreadSubscription](../../_DefaultGroup/Entities/ThreadSubscription.htm) | ThreadSubscription.Thread - Thread.ThreadSubscription (m:1) 
[User](../../_DefaultGroup/Entities/User.htm) | Thread.UserWhoStartedThread - User.StartedThreads (m:1) 
[User](../../_DefaultGroup/Entities/User.htm) | Thread.UsersWhoBookmarkedThread - User.ThreadsInBookmarks (m:n) (via Bookmark) 
[User](../../_DefaultGroup/Entities/User.htm) | Thread.UsersWhoPostedInThread - User.PostedMessagesInThreads (m:n) (via Message) 
[User](../../_DefaultGroup/Entities/User.htm) | Thread.UsersWhoSubscribedThread - User.ThreadCollectionViaThreadSubscription (m:n) (via ThreadSubscription) 

## Fields

The following fields are defined in the Thread entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
ThreadID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
ForumID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
Subject | `string (System.String)` |   |  |  |  | 250 | 0 | 0
StartedByUserID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
IsSticky | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0
IsClosed | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0
MarkedAsDone | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0
Memo | `string (System.String)` |   |  | Yes |  | 1073741823 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.Thread](../../../SQL_Server_SqlClient/HnD/dbo/Thread.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
ForumID | ForumID |  | int | 0 | 10 | 0 |  | 
IsClosed | IsClosed |  | bit | 0 | 0 | 0 |  | 
IsSticky | IsSticky |  | bit | 0 | 0 | 0 |  | 
MarkedAsDone | MarkedAsDone |  | bit | 0 | 0 | 0 |  | 
Memo | Memo | Yes | ntext | 1073741823 | 0 | 0 |  | 
StartedByUserID | StartedByUserID |  | int | 0 | 10 | 0 |  | 
Subject | Subject |  | nvarchar | 250 | 0 | 0 |  | 
ThreadID | ThreadID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 

## Code generation information

### Setting values
#### Thread (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### ForumID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IsClosed (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IsSticky (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### MarkedAsDone (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Memo (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### StartedByUserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Subject (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ThreadID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AuditDataThreadRelated (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### Forum (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### Messages (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### PresentInBookmarks (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### Statistics (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### SupportQueueThread (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### ThreadSubscription (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### UsersWhoBookmarkedThread (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### UsersWhoPostedInThread (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### UsersWhoSubscribedThread (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### UserWhoStartedThread (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### ForumID (NormalField)

* `Required`

#### IsClosed (NormalField)

* `Required`

#### IsSticky (NormalField)

* `Required`

#### MarkedAsDone (NormalField)

* `Required`

#### Memo (NormalField)

* `StringLength($length)`

#### StartedByUserID (NormalField)

* `Required`

#### Subject (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### ThreadID (NormalField)

* `Required`

#### Forum (NavigatorSingleValue)

* `Browsable($true)`

#### Statistics (NavigatorSingleValue)

* `Browsable($true)`

#### SupportQueueThread (NavigatorSingleValue)

* `Browsable($true)`

#### UserWhoStartedThread (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### Thread (Entity)

* `System.ComponentModel.DataAnnotations`

