SQL Server (SqlClient) General Information
===============

## General information

--|--
Database type | SQL Server
ADO.NET DbProviderFactory | System.Data.SqlClient.SqlClientFactory

## System sequences

* `SCOPE_IDENTITY()`
* `@@IDENTITY`

## Type mapping tables

### DB Type to .NET Type

DB Type | .NET Type
--|--
BigInt | System.Int64
Binary | System.Byte[]
Bit | System.Boolean
Char | System.String
DateTime | System.DateTime
Decimal | System.Decimal
Float | System.Double
Image | System.Byte[]
Int | System.Int32
Money | System.Decimal
NChar | System.String
NText | System.String
NVarChar | System.String
Numeric | System.Decimal
Real | System.Single
SmallDateTime | System.DateTime
SmallInt | System.Int16
SmallMoney | System.Decimal
Sql_Variant | System.Object
SysName | System.String
Text | System.String
TimeStamp | System.Byte[]
TinyInt | System.Byte
VarBinary | System.Byte[]
VarChar | System.String
UniqueIdentifier | System.Guid
Xml | System.String
UserDefinedType | System.Object
Date | System.DateTime
DateTime2 | System.DateTime
DateTimeOffset | System.DateTimeOffset
Time | System.TimeSpan
Geometry | SD.LLBLGen.Pro.DBDriverCore.SpatialGeometry
Geography | SD.LLBLGen.Pro.DBDriverCore.SpatialGeography

### DB Type to ADO.NET Provider Type

DB Type | ADO.NET Provider Type
--|--
BigInt | BigInt
Binary | Binary
Bit | Bit
Char | Char
DateTime | DateTime
Decimal | Decimal
Float | Float
Image | Image
Int | Int
Money | Money
NChar | NChar
NText | NText
NVarChar | NVarChar
Numeric | Decimal
Real | Real
SmallDateTime | SmallDateTime
SmallInt | SmallInt
SmallMoney | SmallMoney
Sql_Variant | Variant
SysName | VarChar
Text | Text
TimeStamp | Timestamp
TinyInt | TinyInt
VarBinary | VarBinary
VarChar | VarChar
UniqueIdentifier | UniqueIdentifier
Xml | Xml
UserDefinedType | Udt
Date | Date
DateTime2 | DateTime2
DateTimeOffset | DateTimeOffset
Time | Time
Geometry | Udt
Geography | Udt


## RDBMS aspects

* Auto generate identity fields
* Uses sequences for identity field values
* Central unit is catalog
* Supports multiple central units per project
* Supports foreign key constraints
* Supports multiple schemas per central unit
* Supports schema only resultset retrieval
* Supports natural character specific types
* Supports delete rules
* Supports update rules

