User
============

## Fields

Field name | Ordinal | Native type | Length | Precision | Scale | Is Nullable | Is PK | Is FK | Is Identity | Is Computed  | Default value | Default sequence
--|--
UserID | 1 | int | 0 | 10 | 0 |  | Yes |  | Yes |  |  | 
NickName | 2 | nvarchar | 20 | 0 | 0 |  |  |  |  |  |  | 
Password | 3 | nvarchar | 128 | 0 | 0 |  |  |  |  |  |  | 
IsBanned | 4 | bit | 0 | 0 | 0 |  |  |  |  |  |  | 
IPNumber | 5 | varchar | 25 | 0 | 0 |  |  |  |  |  |  | 
Signature | 6 | nvarchar | 250 | 0 | 0 | Yes |  |  |  |  |  | 
IconURL | 7 | nvarchar | 250 | 0 | 0 | Yes |  |  |  |  |  | 
EmailAddress | 8 | nvarchar | 200 | 0 | 0 | Yes |  |  |  |  |  | 
UserTitleID | 9 | int | 0 | 10 | 0 |  |  | Yes |  |  |  | 
DateOfBirth | 10 | datetime | 0 | 0 | 0 | Yes |  |  |  |  |  | 
Occupation | 11 | nvarchar | 100 | 0 | 0 | Yes |  |  |  |  |  | 
Location | 12 | nvarchar | 100 | 0 | 0 | Yes |  |  |  |  |  | 
Website | 13 | nvarchar | 200 | 0 | 0 | Yes |  |  |  |  |  | 
JoinDate | 14 | datetime | 0 | 0 | 0 | Yes |  |  |  |  | (getdate()) | 
AmountOfPostings | 15 | int | 0 | 10 | 0 | Yes |  |  |  |  | (0) | 
EmailAddressIsPublic | 16 | bit | 0 | 0 | 0 | Yes |  |  |  |  | (0) | 
LastVisitedDate | 17 | datetime | 0 | 0 | 0 | Yes |  |  |  |  |  | 
AutoSubscribeToThread | 18 | bit | 0 | 0 | 0 | Yes |  |  |  |  | (1) | 
DefaultNumberOfMessagesPerPage | 19 | smallint | 0 | 5 | 0 | Yes |  |  |  |  | (25) | 

## Foreign key constraints

#### TF_UserTitle_TF_User_FK1

Aspect | Value
--|--
Primary key table | [dbo.UserTitle](../dbo/UserTitle.htm)
Delete rule | NoAction
Update rule | NoAction 

Foreign key field | Primary key field
--|--
UserTitleID | dbo.UserTitle.UserTitleID

## Unique constraints

Constraint name | Fields
--|--
TF_User_NickName_U2 | NickName


## Model elements mapped on this table

Model Element | Element type
--|--
[User](../../../EntityModel/_DefaultGroup/Entities/User.htm) | Entity
