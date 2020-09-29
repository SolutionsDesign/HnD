using Microsoft.AspNetCore.Builder;

namespace SD.HnD.Gui.Classes
{
	/// <summary>
	/// Extension methods for enabling custom middleware in Configuration.
	/// </summary>
	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder UseIPFilter(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<IPFilter>();
		}
	}
}