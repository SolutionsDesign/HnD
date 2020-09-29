/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
    https://www.llblgen.com
	http:s//www.sd.nl

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

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SD.HnD.BL;
using SD.HnD.Gui.Models;

namespace SD.HnD.Gui.Controllers
{
	/// <summary>
	/// Controller for Section related actions. 
	/// </summary>
	/// <remarks>The async methods don't use an Async suffix. This is by design, due to: https://github.com/dotnet/aspnetcore/issues/8998</remarks>
	public class SectionController : Controller
	{
		[Authorize]
		[HttpGet]
		public async Task<ActionResult> Forums(int id = 0)
		{
			if(this.HttpContext.Session.IsAnonymousUser())
			{
				return RedirectToAction("Index", "Home");
			}

			if(!(this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemWideThreadManagement) ||
				 this.HttpContext.Session.HasSystemActionRight(ActionRights.SystemManagement)))
			{
				return RedirectToAction("Index", "Home");
			}

			var modelData = new ForumSelectorData {Forums = await ForumGuiHelper.GetAllForumsInSectionAsync(id)};
			return PartialView("ForumSelector", modelData);
		}
	}
}