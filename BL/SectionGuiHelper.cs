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
using System.Collections;

using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.DaoClasses;


namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Section Gui. 
	/// </summary>
	public static class SectionGuiHelper
	{
		/// <summary>
		/// Constructs a DataView from the datatable which contains all sections available, plus the # of forums in the section.
		/// Sections and forums are sorted on OrderNo ascending, then on Name  ascending.
		/// </summary>
		/// <param name="excludeEmptySections">If set to true, empty sections are ignored.</param>
		/// <returns>
		/// DataView with all the sections available, including statistics, directly bindable to webcontrols
		/// </returns>
		public static DataView GetAllSectionsWStatisticsAsDataView(bool excludeEmptySections)
		{
			ResultsetFields fields = new ResultsetFields(5);
			fields.DefineField(SectionFields.SectionID, 0);
			fields.DefineField(SectionFields.SectionName, 1);
			fields.DefineField(SectionFields.SectionDescription, 2);
			fields.DefineField(SectionFields.OrderNo, 3);
			// as fifth field, we'll add a scalarquery expression. This scalar query expression will simply do a count on the # of forumIDs in
			// the forum table for the current section. This will result in the query:
			// (
			//    SELECT 	COUNT(ForumID)
			//    FROM	Forum
			//    WHERE Forum.SectionID = Section.SectionID
			// ) AS AmountForums
			fields.DefineField(new EntityField("AmountForums",
					new ScalarQueryExpression(ForumFields.ForumID.SetAggregateFunction(AggregateFunction.Count),
						(ForumFields.SectionID == SectionFields.SectionID))), 4);

            // Sort sections alphabitacally
            SortExpression sorter = new SortExpression(SectionFields.OrderNo | SortOperator.Ascending);
			sorter.Add(SectionFields.SectionName | SortOperator.Ascending);

			IPredicate filter = null;
			if(excludeEmptySections)
			{
				// filter on sections which don't have a forum
				filter = ((EntityField)fields[4] != 0);
			}

			TypedListDAO dao = new TypedListDAO();
			DataTable results = new DataTable();
			dao.GetMultiAsDataTable(fields, results, 0, sorter, filter, null, true, null, null, 0, 0);
			return results.DefaultView;
		}


        /// <summary>
        /// Gets all sections. 
        /// </summary>
        /// <returns>SectionCollection</returns>
        public static SectionCollection GetAllSections()
        {
            // Sort sections on orderno first then on name alphabetically
			SortExpression sorter = new SortExpression(SectionFields.OrderNo | SortOperator.Ascending);
			sorter.Add(SectionFields.SectionName | SortOperator.Ascending);

            SectionCollection sections = new SectionCollection();
            //Retrieves all Entity objects into this Collection object.
            sections.GetMulti(null, 0, sorter);

            return sections;
        }


		/// <summary>
		/// Gets the section entity of the id passed in
		/// </summary>
		/// <param name="sectionID">The section ID.</param>
		/// <returns>loaded sectionentity or null if not found</returns>
		public static SectionEntity GetSection(int sectionID)
		{
			SectionEntity toReturn = new SectionEntity(sectionID);
			if(toReturn.IsNew)
			{
				// not found
				return null;
			}
			return toReturn;
		}
	}
}
