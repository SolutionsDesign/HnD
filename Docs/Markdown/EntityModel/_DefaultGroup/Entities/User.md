User
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The User entity is part of the following relationships 

Related Entity | Full description 
--|--
[AuditDataCore](../../_DefaultGroup/Entities/AuditDataCore.htm) | AuditDataCore.UserAudited - User.LoggedAudits (m:1) 
[Bookmark](../../_DefaultGroup/Entities/Bookmark.htm) | Bookmark.User - User.Bookmarks (m:1) 
[Forum](../../_DefaultGroup/Entities/Forum.htm) | Forum.UsersWhoStartedThreads - User.StartedThreadsInForums (m:n) (via Thread) 
[IPBan](../../_DefaultGroup/Entities/IPBan.htm) | IPBan.SetByUser - User.IPBansSet (m:1) 
[Message](../../_DefaultGroup/Entities/Message.htm) | Message.PostedByUser - User.PostedMessages (m:1) 
[PasswordResetToken](../../_DefaultGroup/Entities/PasswordResetToken.htm) | User.PasswordResetToken - PasswordResetToken.User (1:1) 
[Role](../../_DefaultGroup/Entities/Role.htm) | Role.Users - User.Roles (m:n) (via RoleUser) 
[RoleUser](../../_DefaultGroup/Entities/RoleUser.htm) | RoleUser.User - User.RoleUser (m:1) 
[SupportQueueThread](../../_DefaultGroup/Entities/SupportQueueThread.htm) | SupportQueueThread.ClaimedByUser - User.SupportQueueThreadsClaimed (m:1) 
[SupportQueueThread](../../_DefaultGroup/Entities/SupportQueueThread.htm) | SupportQueueThread.PlacedInQueueByUser - User.SupportQueueThreadsPlaced (m:1) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | Thread.UserWhoStartedThread - User.StartedThreads (m:1) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | Thread.UsersWhoBookmarkedThread - User.ThreadsInBookmarks (m:n) (via Bookmark) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | Thread.UsersWhoPostedInThread - User.PostedMessagesInThreads (m:n) (via Message) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | Thread.UsersWhoSubscribedThread - User.ThreadCollectionViaThreadSubscription (m:n) (via ThreadSubscription) 
[ThreadSubscription](../../_DefaultGroup/Entities/ThreadSubscription.htm) | ThreadSubscription.User - User.ThreadSubscription (m:1) 
[UserTitle](../../_DefaultGroup/Entities/UserTitle.htm) | User.UserTitle - UserTitle.Users (m:1) 

## Fields

The following fields are defined in the User entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
UserID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
NickName | `string (System.String)` |   |  |  |  | 20 | 0 | 0
Password | `string (System.String)` |   |  |  |  | 128 | 0 | 0
IsBanned | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0
IPNumber | `string (System.String)` |   |  |  |  | 25 | 0 | 0
Signature | `string (System.String)` |   |  | Yes |  | 250 | 0 | 0
IconURL | `string (System.String)` |   |  | Yes |  | 250 | 0 | 0
EmailAddress | `string (System.String)` |   |  | Yes |  | 200 | 0 | 0
UserTitleID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
DateOfBirth | `datetime (System.DateTime)` |   |  | Yes |  | 0 | 0 | 0
Occupation | `string (System.String)` |   |  | Yes |  | 100 | 0 | 0
Location | `string (System.String)` |   |  | Yes |  | 100 | 0 | 0
Website | `string (System.String)` |   |  | Yes |  | 200 | 0 | 0
JoinDate | `datetime (System.DateTime)` |   |  | Yes |  | 0 | 0 | 0
AmountOfPostings | `int (System.Int32)` |   |  | Yes |  | 0 | 0 | 0
EmailAddressIsPublic | `bool (System.Boolean)` |   |  | Yes |  | 0 | 0 | 0
LastVisitedDate | `datetime (System.DateTime)` |   |  | Yes |  | 0 | 0 | 0
AutoSubscribeToThread | `bool (System.Boolean)` |   |  | Yes |  | 0 | 0 | 0
DefaultNumberOfMessagesPerPage | `short (System.Int16)` |   |  | Yes |  | 0 | 0 | 0

### Unique Constraints

The following unique constraints are defined at the entity level

Name | Fields 
--|--
TFUserNickNameU2 | NickName

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.User](../../../SQL_Server_SqlClient/HnD/dbo/User.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
AmountOfPostings | AmountOfPostings | Yes | int | 0 | 10 | 0 |  | 
AutoSubscribeToThread | AutoSubscribeToThread | Yes | bit | 0 | 0 | 0 |  | 
DateOfBirth | DateOfBirth | Yes | datetime | 0 | 0 | 0 |  | 
DefaultNumberOfMessagesPerPage | DefaultNumberOfMessagesPerPage | Yes | smallint | 0 | 5 | 0 |  | 
EmailAddress | EmailAddress | Yes | nvarchar | 200 | 0 | 0 |  | 
EmailAddressIsPublic | EmailAddressIsPublic | Yes | bit | 0 | 0 | 0 |  | 
IconURL | IconURL | Yes | nvarchar | 250 | 0 | 0 |  | 
IPNumber | IPNumber |  | varchar | 25 | 0 | 0 |  | 
IsBanned | IsBanned |  | bit | 0 | 0 | 0 |  | 
JoinDate | JoinDate | Yes | datetime | 0 | 0 | 0 |  | 
LastVisitedDate | LastVisitedDate | Yes | datetime | 0 | 0 | 0 |  | 
Location | Location | Yes | nvarchar | 100 | 0 | 0 |  | 
NickName | NickName |  | nvarchar | 20 | 0 | 0 |  | 
Occupation | Occupation | Yes | nvarchar | 100 | 0 | 0 |  | 
Password | Password |  | nvarchar | 128 | 0 | 0 |  | 
Signature | Signature | Yes | nvarchar | 250 | 0 | 0 |  | 
UserID | UserID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
UserTitleID | UserTitleID |  | int | 0 | 10 | 0 |  | 
Website | Website | Yes | nvarchar | 200 | 0 | 0 |  | 

## Code generation information

### Setting values
#### User (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### AmountOfPostings (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AutoSubscribeToThread (NormalField)
Setting name | Value
--|--
Generate as nullable type | False
Field property is public | True

#### DateOfBirth (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### DefaultNumberOfMessagesPerPage (NormalField)
Setting name | Value
--|--
Generate as nullable type | False
Field property is public | True

#### EmailAddress (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### EmailAddressIsPublic (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IconURL (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IPNumber (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### IsBanned (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### JoinDate (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### LastVisitedDate (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Location (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### NickName (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Occupation (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Password (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Signature (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### UserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### UserTitleID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Website (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Bookmarks (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### IPBansSet (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### LoggedAudits (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### PasswordResetToken (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### PostedMessages (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### PostedMessagesInThreads (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### Roles (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### RoleUser (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### StartedThreads (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### StartedThreadsInForums (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### SupportQueueThreadsClaimed (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### SupportQueueThreadsPlaced (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### ThreadCollectionViaThreadSubscription (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### ThreadsInBookmarks (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### ThreadSubscription (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

#### UserTitle (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### EmailAddress (NormalField)

* `StringLength($length)`

#### IconURL (NormalField)

* `StringLength($length)`

#### IPNumber (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### IsBanned (NormalField)

* `Required`

#### Location (NormalField)

* `StringLength($length)`

#### NickName (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### Occupation (NormalField)

* `StringLength($length)`

#### Password (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### Signature (NormalField)

* `StringLength($length)`

#### UserID (NormalField)

* `Required`

#### UserTitleID (NormalField)

* `Required`

#### Website (NormalField)

* `StringLength($length)`

#### PasswordResetToken (NavigatorSingleValue)

* `Browsable($true)`

#### UserTitle (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### User (Entity)

* `System.ComponentModel.DataAnnotations`

