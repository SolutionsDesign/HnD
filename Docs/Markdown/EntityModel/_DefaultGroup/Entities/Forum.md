Forum
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The Forum entity is part of the following relationships 

Related Entity | Full description 
--|--
[ForumRoleForumActionRight](../../_DefaultGroup/Entities/ForumRoleForumActionRight.htm) | ForumRoleForumActionRight.Forum - Forum.ForumRoleForumActionRights (m:1) 
[Section](../../_DefaultGroup/Entities/Section.htm) | Forum.Section - Section.Forums (m:1) 
[SupportQueue](../../_DefaultGroup/Entities/SupportQueue.htm) | Forum.DefaultSupportQueue - SupportQueue.DefaultForForums (m:1) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | Thread.Forum - Forum.Threads (m:1) 
[User](../../_DefaultGroup/Entities/User.htm) | Forum.UsersWhoStartedThreads - User.StartedThreadsInForums (m:n) (via Thread) 

## Fields

The following fields are defined in the Forum entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
ForumID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
SectionID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
ForumName | `string (System.String)` |   |  |  |  | 50 | 0 | 0
ForumDescription | `string (System.String)` |   |  |  |  | 250 | 0 | 0
ForumLastPostingDate | `datetime (System.DateTime)` |   |  | Yes |  | 0 | 0 | 0
HasRSSFeed | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0
DefaultSupportQueueID | `int (System.Int32)` |   | Yes | Yes |  | 0 | 0 | 0
OrderNo | `short (System.Int16)` |   |  |  |  | 0 | 0 | 0
MaxAttachmentSize | `int (System.Int32)` |   |  | Yes |  | 0 | 0 | 0
MaxNoOfAttachmentsPerMessage | `short (System.Int16)` |   |  | Yes |  | 0 | 0 | 0
NewThreadWelcomeText | `string (System.String)` |   |  | Yes |  | 1073741823 | 0 | 0
NewThreadWelcomeTextAsHTML | `string (System.String)` |   |  | Yes |  | 1073741823 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.Forum](../../../SQL_Server_SqlClient/HnD/dbo/Forum.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
DefaultSupportQueueID | DefaultSupportQueueID | Yes | int | 0 | 10 | 0 |  | 
ForumDescription | ForumDescription |  | nvarchar | 250 | 0 | 0 |  | 
ForumID | ForumID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
ForumLastPostingDate | ForumLastPostingDate | Yes | datetime | 0 | 0 | 0 |  | 
ForumName | ForumName |  | nvarchar | 50 | 0 | 0 |  | 
HasRSSFeed | HasRSSFeed |  | bit | 0 | 0 | 0 |  | 
MaxAttachmentSize | MaxAttachmentSize | Yes | int | 0 | 10 | 0 |  | 
MaxNoOfAttachmentsPerMessage | MaxNoOfAttachmentsPerMessage | Yes | smallint | 0 | 5 | 0 |  | 
NewThreadWelcomeText | NewThreadWelcomeText | Yes | ntext | 1073741823 | 0 | 0 |  | 
NewThreadWelcomeTextAsHTML | NewThreadWelcomeTextAsHTML | Yes | ntext | 1073741823 | 0 | 0 |  | 
OrderNo | OrderNo |  | smallint | 0 | 5 | 0 |  | 
SectionID | SectionID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### Forum (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### DefaultSupportQueueID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ForumDescription (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ForumID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ForumLastPostingDate (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ForumName (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### HasRSSFeed (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### MaxAttachmentSize (NormalField)
Setting name | Value
--|--
Generate as nullable type | False
Field property is public | True

#### MaxNoOfAttachmentsPerMessage (NormalField)
Setting name | Value
--|--
Generate as nullable type | False
Field property is public | True

#### NewThreadWelcomeText (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### NewThreadWelcomeTextAsHTML (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### OrderNo (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### SectionID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### DefaultSupportQueue (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### ForumRoleForumActionRights (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### Section (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### Threads (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### UsersWhoStartedThreads (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### ForumDescription (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### ForumID (NormalField)

* `Required`

#### ForumName (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### HasRSSFeed (NormalField)

* `Required`

#### NewThreadWelcomeText (NormalField)

* `StringLength($length)`

#### NewThreadWelcomeTextAsHTML (NormalField)

* `StringLength($length)`

#### OrderNo (NormalField)

* `Required`

#### SectionID (NormalField)

* `Required`

#### DefaultSupportQueue (NavigatorSingleValue)

* `Browsable($true)`

#### Section (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### Forum (Entity)

* `System.ComponentModel.DataAnnotations`

