using Microsoft.AspNetCore.Mvc;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	public class ErrorController : Controller
	{
		[HttpGet]
		public ActionResult HandleErrorCode(int errorCode)
		{
			ErrorData data = null;
			switch(errorCode)
			{
				case 404:
					data = new ErrorData()
						   {
							   ErrorCode = 404,
							   ErrorTitle = "Oops, This Page Could Not Be Found!",
							   ErrorText = "Unfortunately, the page you were looking for could not be found. It may be temporarily unavailable, moved or no longer exist. Please check the URL you entered for any mistakes and try again. Alternatively, you could take a look around the rest of our site."
						   };
					break;
				case 500:
					data = new ErrorData()
						   {
							   ErrorCode = 500,
							   ErrorTitle = "Internal error!",
							   ErrorText = "The system experienced an internal error. Please retry."
						   };
					break;
				default:
					return RedirectToAction("Index", "Home");
			}

			return View(data);
		}
	}
}