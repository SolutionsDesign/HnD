namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Key definitions for elements stored in the ISession object 
	/// </summary>
	public static class SessionKeys
	{
		public static readonly string UserId = "User:UserId";
		public static readonly string NickName= "User:NickName";
		public static readonly string TitleId= "User:TitleId";
		public static readonly string DefaultNumberOfMessagesPerPage= "User:DefaultNumberOfMessagesPerPage";
		public static readonly string AutoSubscribeToThread= "User:AutoSubscribeToThread";
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