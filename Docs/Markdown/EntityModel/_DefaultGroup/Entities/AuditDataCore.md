AuditDataCore
================

## Inheritance hierarchy

--|--
Hierarchy type | Target per entity
Is abstract | False
<p>
AuditDataCore (Hierarchy root)
</p>

## Relationships

The AuditDataCore entity is part of the following relationships 

Related Entity | Full description 
--|--
[AuditAction](../../_DefaultGroup/Entities/AuditAction.htm) | AuditDataCore.AuditAction - AuditAction.AuditDataCore (m:1) 
[User](../../_DefaultGroup/Entities/User.htm) | AuditDataCore.UserAudited - User.LoggedAudits (m:1) 

## Fields

The following fields are defined in the AuditDataCore entity 

Name | Type | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
AuditDataID | `int (System.Int32)` |  Yes |  |  | Yes | 0 | 0 | 0
AuditActionID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
UserID | `int (System.Int32)` |   | Yes |  |  | 0 | 0 | 0
AuditedOn | `datetime (System.DateTime)` |   |  |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.AuditDataCore](../../../SQL_Server_SqlClient/HnD/dbo/AuditDataCore.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
AuditActionID | AuditActionID |  | int | 0 | 10 | 0 |  | 
AuditDataID | AuditDataID |  | int | 0 | 10 | 0 | SCOPE_IDENTITY() | 
AuditedOn | AuditedOn |  | datetime | 0 | 0 | 0 |  | 
UserID | UserID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### AuditDataCore (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### AuditActionID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AuditDataID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AuditedOn (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### UserID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### AuditAction (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

#### UserAudited (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### AuditActionID (NormalField)

* `Required`

#### AuditDataID (NormalField)

* `Required`

#### AuditedOn (NormalField)

* `Required`

#### UserID (NormalField)

* `Required`

#### AuditAction (NavigatorSingleValue)

* `Browsable($true)`

#### UserAudited (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### AuditDataCore (Entity)

* `System.ComponentModel.DataAnnotations`

