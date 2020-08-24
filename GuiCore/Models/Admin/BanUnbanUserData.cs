namespace SD.HnD.Gui.Models.Admin
{
	public class BanUnbanUserData
	{
		public BanUnbanUserData() : this(new FindUserData() { SingleSelect = true})
		{
		}

		public BanUnbanUserData(FindUserData data)
		{
			this.FindUserData = data;
		}
		
		public FindUserData FindUserData { get; }
	}
}