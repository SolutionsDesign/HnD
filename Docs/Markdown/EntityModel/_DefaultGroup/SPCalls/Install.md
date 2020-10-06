Install
================

## Parameters
The following parameters are defined for the Install stored procedure call. 

Name | Direction | Type | Optional | Max. length | Precision | Scale
--|--
AdminEmailAddress | Input | `string (System.String)` |  | 150 | 0 | 0
AdminPasswordHashed | Input | `string (System.String)` |  | 128 | 0 | 0

## Mappings

#### [HnD.dbo.pr_Install](../../../SQL_Server_SqlClient/HnD/dbo/prInstall.htm) (SQL Server (SqlClient))

Type of target: Stored procedure

Parameter | Target parameter | Nullable | Type | Length | Precision | Scale | Type converter
--|--
AdminEmailAddress | @sAdminEmailAddress |  | nvarchar | 150 | 0 | 0 | 
AdminPasswordHashed | @sAdminPasswordHashed |  | nvarchar | 128 | 0 | 0 | 

## Code generation information

### Setting values
No settings defined.
### Attribute definitions per element

None.

### Additional interface definitions per element

None.

### Additional namespace definitions per element

None.
   