﻿Bookmark
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The Bookmark entity is part of the following relationships 

Related Entity | Full description 
--|--
[Thread](../../_DefaultGroup/Entities/Thread.htm) | Bookmark.Thread - Thread.PresentInBookmarks (m:1) 
[User](../../_DefaultGroup/Entities/User.htm) | Bookmark.User - User.Bookmarks (m:1) 

## Fields

The following fields are defined in the Bookmark entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
ThreadID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0
UserID | `int (System.Int32)` |  Yes | Yes |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.Bookmark](../../../SQL_Server_SqlClient/HnD/dbo/Bookmark.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
ThreadID | ThreadID |  | int | 0 | 10 | 0 |  | 
UserID | UserID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### Bookmark (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### ThreadID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### UserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Thread (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### User (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### ThreadID (NormalField)

* `Required`

#### UserID (NormalField)

* `Required`

#### Thread (NavigatorSingleValue)

* `Browsable($true)`

#### User (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### Bookmark (Entity)

* `System.ComponentModel.DataAnnotations`

