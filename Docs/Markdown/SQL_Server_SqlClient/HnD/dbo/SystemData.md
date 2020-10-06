SystemData
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
ID | 1 | int | 0 | 10 | 0 |  | Yes |  | Yes |  |  | 
DefaultRoleNewUser | 2 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
AnonymousRole | 3 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
DefaultUserTitleNewUser | 4 | int | 0 | 10 | 0 |  |  |  |  |  | (0) | 
HoursThresholdForActiveThreads | 5 | smallint | 0 | 5 | 0 |  |  |  |  |  | (48) | 
PageSizeSearchResults | 6 | smallint | 0 | 5 | 0 |  |  |  |  |  | (50) | 
MinNumberOfThreadsToFetch | 7 | smallint | 0 | 5 | 0 |  |  |  |  |  | (25) | 
MinNumberOfNonStickyVisibleThreads | 8 | smallint | 0 | 5 | 0 |  |  |  |  |  | (5) | 
SendReplyNotifications | 9 | bit | 0 | 0 | 0 |  |  |  |  |  | (1) | 

## Foreign key constraints

#### FK_TF_SystemData_TF_Role

Aspect | Value
--|--
Primary key table | [dbo.Role](../dbo/Role.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
DefaultRoleNewUser | dbo.Role.RoleID

#### FK_TF_SystemData_TF_Role1

Aspect | Value
--|--
Primary key table | [dbo.Role](../dbo/Role.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
AnonymousRole | dbo.Role.RoleID

## Model elements mapped on this table

Model Element | Element type
--|--
[SystemData](../../../EntityModel/_DefaultGroup/Entities/SystemData.htm) | Entity
