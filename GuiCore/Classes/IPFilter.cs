using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SD.HnD.BL;

namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Class which performs the IP Ban functionality 
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
				var matchingIPBan = SecurityGuiHelper.GetIPBanMatchingUserIPAddress(ipBans, ipAddress.ToString());
				if(matchingIPBan!=null)
				{
					context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
					return;
				}
			}

			await _next.Invoke(context);
		}
	}
}