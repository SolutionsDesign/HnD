/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

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

using Microsoft.AspNetCore.Mvc;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for HTTP error related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
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
				case 1337:
					data = new ErrorData()
						   {
							   ErrorCode = 1337,
							   ErrorTitle = "HnD internal error!",
							   ErrorText = "The system has been misconfigured: the user Anonymous isn't userid 0 and / or the Admin user isn't userid 1. Please reconfigure the system."
						   };
					break;
				default:
					return RedirectToAction("Index", "Home");
			}

			return View(data);
		}
	}
}