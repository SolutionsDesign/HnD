namespace SD.HnD.DTOs.DtoClasses
{
	public partial class IPBanDto
	{
		/// <summary>
		/// Returns the IPBanSetOn as small date string.
		/// </summary>
		public string IPBanSetOnAsString
		{
			get { return this.IPBanSetOn.ToString("d"); }
		}
	}
}