﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.9.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;	

namespace SD.HnD.DTOs.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'Role'.</summary>
	public partial class RoleDto
	{
		/// <summary>Gets or sets the RoleDescription field. Derived from Entity Model Field 'Role.RoleDescription'</summary>
		[StringLength(50)]
		[Required]
		public System.String RoleDescription { get; set; }
		/// <summary>Gets or sets the RoleID field. Derived from Entity Model Field 'Role.RoleID'</summary>
		[Required]
		public System.Int32 RoleID { get; set; }
	}

}




