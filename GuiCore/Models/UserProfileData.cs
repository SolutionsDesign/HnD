/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

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

using System.Collections.Generic;
using SD.HnD.BL.TypedDataClasses;
using SD.HnD.DALAdapter.TypedListClasses;

namespace SD.HnD.Gui.Models
{
	/// <summary>
	/// Readonly data to be used to display user profile information.
	/// </summary>
	public class UserProfileData
	{
		/// <summary>
		/// The row read from the database with the user data to display in the view.
		/// </summary>
		public UserProfileInfoRow ProfileDataFromDatabase { get; set; }
		/// <summary>
		/// The last 25 threads this user participated in
		/// </summary>
		public List<AggregatedThreadRow> LastThreads { get; set; }
		/// <summary>
		/// Flag to signal whether to view the admin section.
		/// </summary>
		public bool AdminSectionIsVisible { get; set; }
		/// <summary>
		/// Flag to signal whether the current user has the system management right or not. 
		/// </summary>
		public bool UserHasSystemManagementRight { get; set; }
		/// <summary>
		/// The id of the currently logged in user
		/// </summary>
		public int CurrentlyLoggedInUserID { get; set; }
	}
}