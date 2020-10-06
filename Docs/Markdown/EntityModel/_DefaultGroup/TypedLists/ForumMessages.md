ForumMessages
================

## Aliased entities contained in this typed list

Entity | Alias
--|--
[Forum](../../_DefaultGroup/Entities/Forum.htm) | 
[Message](../../_DefaultGroup/Entities/Message.htm) | 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | 
[User](../../_DefaultGroup/Entities/User.htm) | 


## Relationships

The relationships the typed list ForumMessages is based on

Full description | 
--|--
Message - Inner Join - Thread (m:1) |
Message - Inner Join - User (m:1) |
Thread - Inner Join - Forum (m:1) |

## Fields

The following fields are defined in the ForumMessages typed list

Field alias | Caption | Mapped Field Name | Field Type
--|--
MessageID | MessageID | [Message.MessageID](../../_DefaultGroup/Entities/Message.htm#fields) | int (System.Int32)
PostingDate | PostingDate | [Message.PostingDate](../../_DefaultGroup/Entities/Message.htm#fields) | datetime (System.DateTime)
MessageTextAsHTML | MessageTextAsHTML | [Message.MessageTextAsHTML](../../_DefaultGroup/Entities/Message.htm#fields) | string (System.String)
ThreadID | ThreadID | [Message.ThreadID](../../_DefaultGroup/Entities/Message.htm#fields) | int (System.Int32)
Subject | Subject | [Thread.Subject](../../_DefaultGroup/Entities/Thread.htm#fields) | string (System.String)
EmailAddress | EmailAddress | [User.EmailAddress](../../_DefaultGroup/Entities/User.htm#fields) | string (System.String)
EmailAddressIsPublic | EmailAddressIsPublic | [User.EmailAddressIsPublic](../../_DefaultGroup/Entities/User.htm#fields) | bool (System.Boolean)
NickName | NickName | [User.NickName](../../_DefaultGroup/Entities/User.htm#fields) | string (System.String)
MessageText | MessageText | [Message.MessageText](../../_DefaultGroup/Entities/Message.htm#fields) | string (System.String)

## Code generation information

### Setting values
#### ForumMessages (TypedList)
Setting name | Value
--|--
Typed list row base class name | 
Output type | PocoWithQuerySpecQuery

#### EmailAddress (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### EmailAddressIsPublic (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### MessageID (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### MessageText (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### MessageTextAsHTML (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### NickName (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### PostingDate (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### Subject (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### ThreadID (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

### Attribute definitions per element

None.

### Additional interface definitions per element

None.

### Additional namespace definitions per element

None.
