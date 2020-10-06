DTOs General Information
==================

## General information

--|--
Target framework | DTO Class Model
Number of root derived elements | 6

## DTO Class Model setting values

#### Defaults

Setting name | Value
--|--
Root derived element base class name default | 
Embedded derived element base class name default | 

## Last used code generation settings

--|--
Target language | C#
Target platform | .NET Standard 2.0
Root namespace | SD.HnD.DTOs
Template group | General
Selected preset | SD.DTOClasses.ReadWriteDTOs
Destination root folder | `..\DTOs`

## Code generation related project settings

### Attribute definitions per element

#### DerivedElementFieldScalar

Attribute|Rule
--|--
`StringLength($length)` | SourceFieldType Equal string (System.String) And SourceFieldLength LesserEqual 1024 
`Required` | SourceFieldIsOptional IsFalse  


### Additional interface definitions per element

None.

### Additional namespace definitions per element

#### RootDerivedElement

Namespace|Rule
--|--
`System.ComponentModel.DataAnnotations` | None


 