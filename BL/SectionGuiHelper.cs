/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.Linq;
using SD.HnD.DTOs.DtoClasses;
using SD.HnD.DTOs.Persistence;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.QuerySpec.Adapter;


namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Section Gui. 
	/// </summary>
	public static class SectionGuiHelper
	{
		public static async Task<List<SectionDto>> GetAllSectionDtosAsync()
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new LinqMetaData(adapter).Section.OrderBy(s => s.OrderNo).ProjectToSectionDto();
				return await q.ToListAsync().ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets all sections. 
		/// </summary>
		/// <returns>SectionCollection</returns>
		public static async Task<EntityCollection<SectionEntity>> GetAllSectionsAsync()
		{
			var q = new QueryFactory().Section.OrderBy(SectionFields.OrderNo.Ascending(), SectionFields.SectionName.Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(q, new EntityCollection<SectionEntity>()).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the section entity of the id passed in
		/// </summary>
		/// <param name="sectionID">The section ID.</param>
		/// <returns>loaded sectionentity or null if not found</returns>
		public static async Task<SectionEntity> GetSectionAsync(int sectionID)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().Section.Where(SectionFields.SectionID.Equal(sectionID));
				return await adapter.FetchFirstAsync(q).ConfigureAwait(false);
			}
		}
	}
}