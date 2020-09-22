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
using System.Threading.Tasks;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DTOs.DtoClasses;
using SD.HnD.DTOs.Persistence;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace SD.HnD.BL
{
	/// <summary>
	/// General class for Section management tasks.
	/// </summary>
	public static class SectionManager
	{
		/// <summary>
		/// Adds a new section to the forum system.
		/// </summary>
		/// <param name="toInsert">The dto with the values to insert</param>
		/// <returns>
		/// the SectionID of the new section. Or Zero if failed
		/// </returns>
		public static async Task<int> AddNewSectionAsync(SectionDto toInsert)
		{
			if(toInsert == null)
			{
				return 0;
			}

			var section = new SectionEntity
						  {
							  SectionName = toInsert.SectionName, 
							  SectionDescription = toInsert.SectionDescription, 
							  OrderNo = toInsert.OrderNo
						  };

			using(var adapter = new DataAccessAdapter())
			{
				var result = await adapter.SaveEntityAsync(section).ConfigureAwait(false);
				return result ? section.SectionID : 0;
			}
		}
		
		
		/// <summary>
		/// Modifies the given section's name and description
		/// </summary>
		/// <param name="toUpdate">the dto containing the values to update the associated entity with</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static async Task<bool> ModifySectionAsync(SectionDto toUpdate)
		{
			if(toUpdate == null)
			{
				return false;
			}
			var section = await SectionGuiHelper.GetSectionAsync(toUpdate.SectionID);
			if(section == null)
			{
				return false;
			}
			section.UpdateFromSection(toUpdate);
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.SaveEntityAsync(section).ConfigureAwait(false);
			}
		}
		
		
		/// <summary>
		/// Removes the given section from the database. Returns true if succeeded. Only allows deletion if the section is empty
		/// </summary>
        /// <param name="sectionId">ID of section to delete</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static async Task<bool> DeleteSectionAsync(int sectionId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// first check if the section has any forums
				var q = new QueryFactory().Forum.Where(ForumFields.SectionID.Equal(sectionId)).Select(Functions.CountRow());
				var numberOfForums = await adapter.FetchScalarAsync<int?>(q).ConfigureAwait(false);
				if(numberOfForums.HasValue && numberOfForums > 0)
				{
					// has forums, can't delete this section.
					return false;
				}
				
				// trying to delete the entity directly from the database without first loading it.
				var numberOfDeletedRows = await adapter.DeleteEntitiesDirectlyAsync(typeof(SectionEntity), 
																					new RelationPredicateBucket(SectionFields.SectionID.Equal(sectionId)))
													   .ConfigureAwait(false);

				// there should only be one deleted row, since we are filtering by the PK.
				return numberOfDeletedRows == 1;
			}
		}
	}
}
