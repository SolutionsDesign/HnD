Attachment
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The Attachment entity is part of the following relationships 

Related Entity | Full description 
--|--
[Message](../../_DefaultGroup/Entities/Message.htm) | Attachment.BelongsToMessage - Message.Attachments (m:1) 

## Fields

The following fields are defined in the Attachment entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
AttachmentID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
MessageID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
Filename | `string (System.String)` |   |  |  |  | 255 | 0 | 0
Approved | `bool (System.Boolean)` |   |  |  |  | 0 | 0 | 0
Filecontents | `byte[] (System.Byte[])` |   |  |  |  | 2147483647 | 0 | 0
Filesize | `int (System.Int32)` |   |  |  |  | 0 | 0 | 0
AddedOn | `datetime (System.DateTime)` |   |  |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.Attachment](../../../SQL_Server_SqlClient/HnD/dbo/Attachment.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
AddedOn | AddedOn |  | datetime | 0 | 0 | 0 |  | 
Approved | Approved |  | bit | 0 | 0 | 0 |  | 
AttachmentID | AttachmentID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
Filecontents | Filecontents |  | image | 2147483647 | 0 | 0 |  | 
Filename | Filename |  | nvarchar | 255 | 0 | 0 |  | 
Filesize | Filesize |  | int | 0 | 10 | 0 |  | 
MessageID | MessageID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### Attachment (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### AddedOn (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Approved (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AttachmentID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Filecontents (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Filename (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Filesize (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### MessageID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### BelongsToMessage (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### AddedOn (NormalField)

* `Required`

#### Approved (NormalField)

* `Required`

#### AttachmentID (NormalField)

* `Required`

#### Filecontents (NormalField)

* `Required`

#### Filename (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### Filesize (NormalField)

* `Required`

#### MessageID (NormalField)

* `Required`

#### BelongsToMessage (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### Attachment (Entity)

* `System.ComponentModel.DataAnnotations`

