namespace SD.HnD.BL
{
	/// <summary>
	/// Special exception which is thrown when a password reset action was executed but the nickname specified wasn't found.
	/// </summary>
	public class NickNameNotFoundException: System.ApplicationException
	{
		public NickNameNotFoundException(string sMessage):base(sMessage)
		{
		}
	}
}