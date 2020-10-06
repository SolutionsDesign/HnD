AuditDataThreadRelated
================

## Inheritance hierarchy

--|--
Hierarchy type | Target per entity
Is abstract | False
<p>
<a href="../../_DefaultGroup/Entities/AuditDataCore.htm">AuditDataCore</a> (Hierarchy root)<br/>
&nbsp;&nbsp;&nbsp;<i class="fa fa-arrow-up"></i><br/>
AuditDataThreadRelated
</p>

## Relationships

The AuditDataThreadRelated entity is part of the following relationships 

Related Entity | Full description  | Inherited from
--|--
[AuditAction](../../_DefaultGroup/Entities/AuditAction.htm) | AuditDataCore.AuditAction - AuditAction.AuditDataCore (m:1)|  [AuditDataCore](../../_DefaultGroup/Entities/AuditDataCore.htm) 
[User](../../_DefaultGroup/Entities/User.htm) | AuditDataCore.UserAudited - User.LoggedAudits (m:1)|  [AuditDataCore](../../_DefaultGroup/Entities/AuditDataCore.htm) 
[Thread](../../_DefaultGroup/Entities/Thread.htm) | AuditDataThreadRelated.Thread - Thread.AuditDataThreadRelated (m:1)| 

## Fields

The following fields are defined in the AuditDataThreadRelated entity 

Name | Type | Inherited from | Is PK | Is FK | Optional | Read-only | Max. length | Precision | Scale
--|--
AuditDataID | `int (System.Int32)` | [AuditDataCore](../../_DefaultGroup/Entities/AuditDataCore.htm)  | Yes |  |  | Yes | 0 | 0 | 0
AuditActionID | `int (System.Int32)` | [AuditDataCore](../../_DefaultGroup/Entities/AuditDataCore.htm)  |  | Yes |  |  | 0 | 0 | 0
UserID | `int (System.Int32)` | [AuditDataCore](../../_DefaultGroup/Entities/AuditDataCore.htm)  |  | Yes |  |  | 0 | 0 | 0
AuditedOn | `datetime (System.DateTime)` | [AuditDataCore](../../_DefaultGroup/Entities/AuditDataCore.htm)  |  |  |  |  | 0 | 0 | 0
ThreadID | `int (System.Int32)` |   |  | Yes |  |  | 0 | 0 | 0

### Unique Constraints
None.

### Fields mapped onto related fields
None.

## Mappings

#### [HnD.dbo.AuditDataThreadRelated](../../../SQL_Server_SqlClient/HnD/dbo/AuditDataThreadRelated.htm) (SQL Server (SqlClient))

Aspect | Value
--|--
Type of target | Table
Actions allowed | Create / Retrieve / Update / Delete

Entity Field | Target field | Nullable | Type | Length | Precision | Scale | Sequence | Type converter
--|--
ThreadID | ThreadID |  | int | 0 | 10 | 0 |  | 
AuditDataID | AuditDataID |  | int | 0 | 10 | 0 |  | 

## Code generation information

### Setting values
#### AuditDataThreadRelated (Entity)
Setting name | Value
--|--
Entity base class name | `CommonEntityBase`

#### AuditDataID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### ThreadID (NormalField)
Setting name | Value
--|--
Generate as nullable type | True
Field property is public | True

#### Thread (NavigatorSingleValue)
Setting name | Value
--|--
Navigator property is public | True

### Attribute definitions per element

#### AuditDataID (NormalField)

* `Required`

#### ThreadID (NormalField)

* `Required`

#### Thread (NavigatorSingleValue)

* `Browsable($true)`


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### AuditDataThreadRelated (Entity)

* `System.ComponentModel.DataAnnotations`

