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
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.LLBLGen.Pro.QuerySpec.Adapter;


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
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchFirst(new QueryFactory().SystemData);
			}
		}
	}
}
