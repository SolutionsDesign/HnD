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

namespace SD.HnD.BL
{
	/// <summary>
	/// Global values for HnD
	/// </summary>
	public static class Globals
	{
		/// <summary>
		/// Version of HnD
		/// </summary>
		public static readonly string Version = "3.0.2";
		/// <summary>
		/// Build of HnD
		/// </summary>
		public static readonly string Build = "03-may-2021";
		/// <summary>
		/// Release type of this version
		/// </summary>
		public static readonly string ReleaseType = "RTM";
		/// <summary>
		/// The UserID to deny login rights, since this is the Anonymous Coward user, which is
		/// used for non-logged in users.
		/// </summary>
		public static readonly int UserIDToDenyLogin = 0;
		/// <summary>
		/// Returns a representable string which displays the version in full in textual format: vVersion (Build, ReleaseType).
		/// </summary>
		public static readonly string VersionFull = string.Format("v{0} ({1} {2})", Version, Build, ReleaseType);
		/// <summary>
		/// The default max number of messages per page if it's not configured for a forum.
		/// </summary>
		public static readonly int DefaultMaxNumberOfMessagesPerPage = 25;
		/// <summary>
		/// Used in fetches of resultsets which can be cached. 
		/// </summary>
		public static readonly int DefaultCacheDurationOfResultsets = 30;
	}


	/// <summary>
	/// Class with solely readonly static strings for cache keys used with the ASP.NET cache of the forum system.
	/// </summary>
	public static class CacheKeys
	{
		/// <summary>
		/// The key to use to obtain and store the cached sections
		/// </summary>
		public static readonly string AllSections = "AllSections";
		/// <summary>
		///  The key to use to obtain and store a cached forum entity
		/// </summary>
		public static readonly string SingleForum = "SingleForum";
		/// <summary>
		/// The key to use to obtain and store the cached IP Bans structure (dictionary with per range the ip addresses for the ip bans). 
		/// </summary>
		public static readonly string AllIPBans = "AllIPBans";
		/// <summary>
		/// The key to use to obtain and store the cached support queue entities.
		/// </summary>
		public static readonly string AllSupportQueues = "AllSupportQueues";
		/// <summary>
		/// The key to use to obtain and store the cached system data entity.
		/// </summary>
		public static readonly string SystemData = "SystemData";
		/// <summary>
		/// Cache key for the resultset for when querying for the anonymous user. 
		/// </summary>
		public static readonly string AnonymousUserQueryResultset = "AnonymousUserQuery";
	}


	// enums
	/// <summary>
	/// Enum for specifying the ordering of the search results.
	/// </summary>
	public enum SearchResultsOrderSetting
	{
		LastPostDateDescending,
		LastPostDateAscending,
		ForumAscending,
		ForumDescending,
		ThreadSubjectAscending,
		ThreadSubjectDescending
	}


	/// <summary>
	/// Enum for defining the search target for a search. 
	/// </summary>
	public enum SearchTarget
	{
		MessageText,
		ThreadSubject,
		MessageTextAndThreadSubject
	}


	/// <summary>
	/// Audit actions
	/// </summary>
	public enum AuditActions
	{
		AuditLogin = 1,
		AuditNewMessage = 2,
		AuditNewThread = 3,
		AuditAlteredMessage = 4,
		AuditEditMemo = 5,
		AuditApproveAttachment = 6
	}


	/// <summary>
	/// ActionRights constants. The Application object will hold a cached hashtable with the actionrights definitions from the database. These are
	/// defined system wide, and are not mutated at runtime. 
	/// </summary>
	public enum ActionRights
	{
		AddAndEditMessage = 1,
		AccessForum,
		UserManagement,
		SecurityManagement,
		EditDeleteOtherUsersMessages,
		ForumSpecificThreadManagement,
		SystemManagement,
		AddAndEditMessageInSticky,
		SystemWideThreadManagement,
		AddNormalThread, // 10
		AddStickyThread,
		EditThreadMemo,
		FlagThreadAsDone,
		QueueContentManagement,
		ViewNormalThreadsStartedByOthers, // 15
		ManageOtherUsersAttachments,
		AddAttachment,
		GetsAttachmentsApprovedAutomatically,
		ApproveAttachment

		// Add more here. Check the comma!
	}

	/// <summary>
	/// MailTemplate constants. The generated emails supported by the application. A dedicated helper 
	/// will get the corresponding template file path
	/// </summary>
	public enum EmailTemplate
	{
		Undefined = 0,
		RegistrationReply = 1,
		ThreadUpdatedNotification = 2,
		ResetPasswordLink = 3,
	}
}