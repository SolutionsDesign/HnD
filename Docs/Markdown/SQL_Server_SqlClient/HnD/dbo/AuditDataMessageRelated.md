AuditDataMessageRelated
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
AuditDataID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
MessageID | 2 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 

## Foreign key constraints

#### TF_AuditDataMessageRelated_TF_AuditDataCore_FK1

Aspect | Value
--|--
Primary key table | [dbo.AuditDataCore](../dbo/AuditDataCore.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
AuditDataID | dbo.AuditDataCore.AuditDataID

#### TF_AuditDataMessageRelated_TF_Message_FK1

Aspect | Value
--|--
Primary key table | [dbo.Message](../dbo/Message.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
MessageID | dbo.Message.MessageID

## Model elements mapped on this table

Model Element | Element type
--|--
[AuditDataMessageRelated](../../../EntityModel/_DefaultGroup/Entities/AuditDataMessageRelated.htm) | Entity
