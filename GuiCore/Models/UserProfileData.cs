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