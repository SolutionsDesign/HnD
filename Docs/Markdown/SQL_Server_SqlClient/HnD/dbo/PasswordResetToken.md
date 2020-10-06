PasswordResetToken
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
UserID | 1 | int | 0 | 10 | 0 |  | Yes | Yes |  |  |  | 
PasswordResetToken | 2 | uniqueidentifier | 0 | 0 | 0 |  |  |  |  |  |  | 
PasswordResetRequestedOn | 3 | datetime | 0 | 0 | 0 |  |  |  |  |  |  | 

## Foreign key constraints

#### FK_9f1eaa94f1fb774bb77aad91f5d

Aspect | Value
--|--
Primary key table | [dbo.User](../dbo/User.htm)
Delete rule | Cascade
Update rule | NoAction 

Foreign key field | Primary key field
--|--
UserID | dbo.User.UserID

## Model elements mapped on this table

Model Element | Element type
--|--
[PasswordResetToken](../../../EntityModel/_DefaultGroup/Entities/PasswordResetToken.htm) | Entity
