using Microsoft.AspNetCore.Builder;

namespace SD.HnD.Gui.Classes
{
	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder UseIPFilter(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<IPFilter>();
		}
	}
}