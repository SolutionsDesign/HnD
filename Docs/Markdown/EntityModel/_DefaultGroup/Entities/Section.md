Section
================

## Inheritance hierarchy

--|--
Hierarchy type | None
Is abstract | False

## Relationships

The Section entity is part of the following relationships 

Related Entity | Full description 
--|--
[Forum](../../_DefaultGroup/Entities/Forum.htm) | Forum.Section - Section.Forums (m:1) 

## Fields

The following fields are defined in the Section entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
SectionID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
SectionName | `string (System.String)` |   |  |  |  | 50 | 0 | 0
SectionDescription | `string (System.String)` |   |  |  |  | 250 | 0 | 0
OrderNo | `short (System.Int16)` |   |  |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.Section](../../../SQL_Server_SqlClient/HnD/dbo/Section.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
OrderNo | OrderNo |  | smallint | 0 | 5 | 0 |  | 
SectionDescription | SectionDescription |  | nvarchar | 250 | 0 | 0 |  | 
SectionID | SectionID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
SectionName | SectionName |  | nvarchar | 50 | 0 | 0 |  | 

## Code generation information

### Setting values
#### Section (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### OrderNo (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### SectionDescription (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### SectionID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### SectionName (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Forums (NavigatorCollection)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### OrderNo (NormalField)

* `Required`

#### SectionDescription (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`

#### SectionID (NormalField)

* `Required`

#### SectionName (NormalField)

* `Required`
* `StringLength($length)`
* `MinLength(2)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### Section (Entity)

* `System.ComponentModel.DataAnnotations`

