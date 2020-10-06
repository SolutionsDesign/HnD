Entity Model General Information
==================

## General information

--|--
Target framework | LLBLGen Pro Runtime Framework
Group usage | As visual grouping mechanism
Number of groups | 1
Number of entities | 25
Number of value types | 0
Number of typed lists | 4
Number of typed views | 0
Number of stored procedure calls | 1
Number of table values function calls | 0

## LLBLGen Pro Runtime Framework setting values

#### General

Setting name | Value
--|--
Convert nulled reference types to default value | True
Tdl emit time date in output files | False
Inline value typed fields | True

#### Template group specific, Self-servicing

Setting name | Value
--|--
Lazy loading without result returns new | True

#### Template group specific, Adapter

Setting name | Value
--|--
Adapter db generic project file suffix | 
Adapter db generic sub folder name | `DatabaseGeneric`
Adapter db specific namespace suffix | DatabaseSpecific
Adapter db specific project file suffix | DBSpecific
Adapter db specific sub folder name | `DatabaseSpecific`

#### Generated code, Adapter, backwards compatibility

Setting name | Value
--|--
Generate entity field factory | False
Generate entity fields factory | False

#### Defaults

Setting name | Value
--|--
Entity base class name default | `CommonEntityBase`
Field property is public default | True
Navigator property is public default | True
Generate as nullable type default | True
Typed list row base class name default | 
Typed list output type default | PocoWithQuerySpecQuery
Typed view row base class name default | 
Typed view output type default | PocoWithQuerySpecQuery

## Last used code generation settings

--|--
Target language | C#
Target platform | .NET Standard 2.0
Root namespace | SD.HnD.DALAdapter
Template group | Adapter
Selected preset | SD.Presets.Adapter.General.Netstandard
Destination root folder | `..\DALAdapter`

## Code generation related project settings

### General
Connection string key pattern: `Main.ConnectionString.{$ProviderName}`

### Attribute definitions per element

#### NormalField

Attribute|Rule
--|--
`Required` | IsOptional IsFalse  
`StringLength($length)` | FieldType Equal string (System.String) 
`MinLength(2)` | IsOptional IsFalse  And FieldType Equal string (System.String) 

#### NavigatorSingleValue

Attribute|Rule
--|--
`Browsable($true)` | None


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### Entity

Namespace|Rule
--|--
`System.ComponentModel.DataAnnotations` | None


