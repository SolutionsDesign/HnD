namespace SD.HnD.Gui.Models.Admin
{
	public class DeleteUserData
	{
		public DeleteUserData() : this(new FindUserData() { SingleSelect = true})
		{
		}

		public DeleteUserData(FindUserData data)
		{
			this.FindUserData = data;
			this.FinalActionResult = string.Empty;
		}
		
		public FindUserData FindUserData { get; }
		public string FinalActionResult { get; set; }
	}
}