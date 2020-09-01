namespace SD.HnD.Gui.Models.Admin
{
	public class ActionWithUserSearchData
	{
		public ActionWithUserSearchData() : this(new FindUserData() { SingleSelect = true})
		{
		}

		public ActionWithUserSearchData(FindUserData data)
		{
			this.FindUserData = data;
			this.FinalActionResult = string.Empty;
		}
		
		public FindUserData FindUserData { get; }
		public string FinalActionResult { get; set; }
	}
}