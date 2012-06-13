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

using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.HelperClasses;

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
		/// <param name="name">The name.</param>
		/// <param name="description">The description.</param>
		/// <param name="orderNo">The order no for the section. Sections are sorted ascending on orderno.</param>
		/// <returns>
		/// the SectionID of the new section. Or Zero if failed
		/// </returns>
        public static int AddNewSection(string name, string description, short orderNo)
		{
            SectionEntity section = new SectionEntity();

            // fill the entity fields with data
            section.SectionName = name;
            section.SectionDescription = description;
			section.OrderNo = orderNo;
            
            // try to save the entity
            bool saveResult = section.Save();
			
			// if succeeds return the new ID, else return Zero.
			if(saveResult == true)
			{
				return section.SectionID;
			}
			else
			{
				return 0;
			}
		}
		
		
		/// <summary>
		/// Modifies the given section's name and description
		/// </summary>
        /// <param name="ID">ID of section to modify</param>
        /// <param name="name">New name of section</param>
        /// <param name="description">Description of section</param>
		/// <param name="orderNo">The order no for the section. Sections are sorted ascending on orderno.</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static bool ModifySection(int ID, string name, string description, short orderNo)
		{
            // load the entity from the database
            SectionEntity section = new SectionEntity(ID);

            //check if the entity is new (not found in the database), then return false.
			if(section.IsNew == true)
			{
				return false;
			}

            // update the fields with new values
            section.SectionName = name;
            section.SectionDescription = description;
			section.OrderNo = orderNo;
          
            //try to save the changes
            return section.Save();
		}
		
		
		/// <summary>
		/// Removes the given section from the database. Returns true if succeeded.
		/// </summary>
        /// <param name="ID">ID of section to delete</param>
		/// <returns>True if succeeded, false otherwise</returns>
		public static bool DeleteSection(int ID)
		{
			// trying to delete the entity directly from the database without first loading it.
			// for that we use an entity collection and use the DeleteMulti method with a filter on the PK.
			SectionCollection sections = new SectionCollection();
            // try to delete the entity
			int deletedRows = sections.DeleteMulti(SectionFields.SectionID == ID);

			// there should only be one deleted row, since we are filtering by the PK.
			// return true if there's 1, otherwise false.
			return (deletedRows == 1); 
		}
		
	}
}
