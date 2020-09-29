namespace SD.HnD.BL
{
	/// <summary>
	/// Special exception which is thrown when a password reset action was executed but the email specified doesn't match the nickname specified.
	/// </summary>
	public class EmailAddressDoesntMatchException: System.ApplicationException
	{
		public EmailAddressDoesntMatchException(string sMessage):base(sMessage)
		{
		}
	}
}