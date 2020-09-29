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

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SD.HnD.BL;
using SD.HnD.Utility;

namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Class which performs the IP Ban functionality as a middleware
	/// </summary>
	public class IPFilter
	{
		private readonly RequestDelegate _next;
		private readonly IMemoryCache _cache;


		public IPFilter(RequestDelegate next, IMemoryCache cache)
		{
			_next = next;
			_cache = cache;
		}


		public async Task Invoke(HttpContext context)
		{
			var ipAddress = context.Connection.RemoteIpAddress;
			if(_cache != null)
			{
				var ipBans = await _cache.GetAllIPBansAsync();
				var matchingIPBan = SecurityGuiHelper.GetIPBanMatchingUserIPAddress(ipBans, HnDGeneralUtils.GetRemoteIPAddressAsIP4String(ipAddress));
				if(matchingIPBan != null)
				{
					context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
					context.Response.Redirect(ApplicationAdapter.GetVirtualRoot() + "banned.html");
				}
			}

			await _next.Invoke(context);
		}
	}
}