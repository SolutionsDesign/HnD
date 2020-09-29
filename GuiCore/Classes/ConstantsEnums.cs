/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
    https://www.llblgen.com
	http:s//www.sd.nl

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

namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Key definitions for elements stored in the ISession object 
	/// </summary>
	public static class SessionKeys
	{
		public static readonly string UserId = "User:UserId";
		public static readonly string NickName = "User:NickName";
		public static readonly string TitleId = "User:TitleId";
		public static readonly string DefaultNumberOfMessagesPerPage = "User:DefaultNumberOfMessagesPerPage";
		public static readonly string AutoSubscribeToThread = "User:AutoSubscribeToThread";
		public static readonly string AmountOfPostings = "User:AmountOfPostings";
		public static readonly string LastVisitedDateTickValue = "User:LastVisitedDateTickValue";
		public static readonly string SystemActionRights = "User:SystemActionRights";
		public static readonly string ForumActionRights = "User:ForumActionRights";
		public static readonly string AuditActions = "User:AuditActions";
		public static readonly string SessionInitialized = "Session:Initialized";
		public static readonly string SearchResultsKey = "User:SearchResultsKey";
		public static readonly string MyThreadsRowCount = "User:MyThreadsRowCount";
	}


	/// <summary>
	/// State enum for the find user wizard code used in various admin screens. This enum specifies which step the wizard is in
	/// </summary>
	public enum AdminFindUserState
	{
		Start,
		UsersFound,
		FinalAction,
		PostAction
	}
}