SearchResult
================

## Aliased entities contained in this typed list

Entity | Alias
--|--
[Forum](../../_DefaultGroup/Entities/Forum.htm) | 
[Message](../../_DefaultGroup/Entities/Message.htm) | LastMessage
[Message](../../_DefaultGroup/Entities/Message.htm) | 
[Section](../../_DefaultGroup/Entities/Section.htm) | 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | 
[ThreadStatistics](../../_DefaultGroup/Entities/ThreadStatistics.htm) | 


## Relationships

The relationships the typed list SearchResult is based on

Full description | 
--|--
Message - Inner Join - Thread (m:1) |
Thread - Inner Join - Forum (m:1) |
Thread - Inner Join - ThreadStatistics (1:1) |
Forum - Inner Join - Section (m:1) |
ThreadStatistics - Inner Join - LastMessage (1:1) |

## Fields

The following fields are defined in the SearchResult typed list

Field alias | Caption | Mapped Field Name | Field Type
--|--
ThreadID | ThreadID | [Thread.ThreadID](../../_DefaultGroup/Entities/Thread.htm#fields) | int (System.Int32)
Subject | Subject | [Thread.Subject](../../_DefaultGroup/Entities/Thread.htm#fields) | string (System.String)
ForumName | ForumName | [Forum.ForumName](../../_DefaultGroup/Entities/Forum.htm#fields) | string (System.String)
SectionName | SectionName | [Section.SectionName](../../_DefaultGroup/Entities/Section.htm#fields) | string (System.String)
ThreadLastPostingDate | PostingDate | [LastMessage.PostingDate](../../_DefaultGroup/Entities/Message.htm#fields) | datetime (System.DateTime)

## Code generation information

### Setting values
#### SearchResult (TypedList)
Setting name | Value
--|--
Typed list row base class name | 
Output type | PocoWithQuerySpecQuery

#### ForumName (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

#### SectionName (TypedListField)
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

#### ThreadLastPostingDate (TypedListField)
Setting name | Value
--|--
Generate as nullable type | True

### Attribute definitions per element

None.

### Additional interface definitions per element

None.

### Additional namespace definitions per element

None.
