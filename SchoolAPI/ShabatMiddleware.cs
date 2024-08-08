using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace SchoolAPI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ShabatMiddleware
    {
        private readonly RequestDelegate _next;

        public ShabatMiddleware(RequestDelegate next)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
                 
                 Debug.Print(   $"****  CurrentCulture.DisplayName:  {  CultureInfo.CurrentCulture.DisplayName}"));

            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ShabatMiddlewareExtensions
    {
        public static IApplicationBuilder UseShabatMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabatMiddleware>();
          
        }
    }
}
