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
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;
using SD.HnD.DAL.FactoryClasses;


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
			// join with a derived table, which calculates the number of forums per section. This allows us to re-use the
			// scalar values in multiple places (projection and where clause), without re-calculating the scalar per row.

			var qf = new QueryFactory();
			var q = qf.Create()
							.Select(SectionFields.SectionID,
									SectionFields.SectionName,
									SectionFields.SectionDescription,
									SectionFields.OrderNo,
									qf.Field("ForumCountList", "ForumCount").As("AmountForums"))
							.From(qf.Section.InnerJoin(
										qf.Create()
											.Select(ForumFields.ForumID.Count().As("ForumCount"), 
													ForumFields.SectionID)
											.GroupBy(ForumFields.SectionID)
											.As("ForumCountList"))
										.On(ForumFields.SectionID.Source("ForumCountList")==SectionFields.SectionID))
							.OrderBy(SectionFields.OrderNo.Ascending(), SectionFields.SectionName.Ascending());

			if(excludeEmptySections)
			{
				q.AndWhere(qf.Field("ForumCountList", "ForumCount")!=0);
			}
			TypedListDAO dao = new TypedListDAO();
			var results = dao.FetchAsDataTable(q);
			return results.DefaultView;
		}


        /// <summary>
        /// Gets all sections. 
        /// </summary>
        /// <returns>SectionCollection</returns>
        public static SectionCollection GetAllSections()
        {
			var q = new QueryFactory().Section.OrderBy(SectionFields.OrderNo.Ascending(), SectionFields.SectionName.Ascending());
			SectionCollection sections = new SectionCollection();
			sections.GetMulti(q);
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
