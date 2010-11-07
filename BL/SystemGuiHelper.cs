/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Data;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;


namespace SD.HnD.BL
{
	/// <summary>
	/// General gui helper class for the system data
	/// </summary>
	public static class SystemGuiHelper
	{
		/// <summary>
		/// Retrieves the current system settings, which is 1 row. 
		/// </summary>
		/// <returns>DataTable with 1 row with the system settings. See TF_SystemData.</returns>
		public static SystemDataEntity GetSystemSettings()
		{
			SystemDataCollection systemData = new SystemDataCollection();
			// get all entities, there's just 1
			systemData.GetMulti(null);

			// if the system is setup correctly, there's one entity
			return systemData[0];
		}
	}
}
