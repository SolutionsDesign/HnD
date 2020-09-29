using System.ComponentModel.DataAnnotations;

namespace SD.HnD.Gui.Models
{
	public class InitData
	{
		[DataType(DataType.Password)]
		[StringLength(100)]
		[MinLength(8)]
		public string NewPassword { get; set; }
		[DataType(DataType.Password)]
		[StringLength(100)]
		[MinLength(8)]
		[Compare("NewPassword")]
		public string ConfirmNewPassword { get; set; }
		[Required]
		[StringLength(200)]
		[MinLength(6)]
		[EmailAddress]
		public string EmailAddress { get;set; }
	}
}