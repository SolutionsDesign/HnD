IPBan
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
IPBanID | 1 | int | 0 | 10 | 0 |  | Yes |  | Yes |  |  | 
IPSegment1 | 2 | tinyint | 0 | 3 | 0 |  |  |  |  |  | (0) | 
IPSegment2 | 3 | tinyint | 0 | 3 | 0 |  |  |  |  |  | (0) | 
IPSegment3 | 4 | tinyint | 0 | 3 | 0 |  |  |  |  |  | (0) | 
IPSegment4 | 5 | tinyint | 0 | 3 | 0 |  |  |  |  |  | (0) | 
Range | 6 | tinyint | 0 | 3 | 0 |  |  |  |  |  |  | 
IPBanSetByUserID | 7 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
IPBanSetOn | 8 | datetime | 0 | 0 | 0 |  |  |  |  |  | (getdate()) | 
Reason | 9 | ntext | 1073741823 | 0 | 0 |  |  |  |  |  |  | 

## Foreign key constraints

#### FK_TF_IPBan_TF_User

Aspect | Value
--|--
Primary key table | [dbo.User](../dbo/User.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
IPBanSetByUserID | dbo.User.UserID

## Model elements mapped on this table

Model Element | Element type
--|--
[IPBan](../../../EntityModel/_DefaultGroup/Entities/IPBan.htm) | Entity
