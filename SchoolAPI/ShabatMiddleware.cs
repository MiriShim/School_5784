using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
              _next = next;
        }

        public async Task  Invoke(HttpContext httpContext)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
                Debug.Print($"****  CurrentCulture.DisplayName:  {CultureInfo.CurrentCulture.DisplayName}");
                Console.Write($"****  CurrentCulture.DisplayName:  {CultureInfo.CurrentCulture.DisplayName}");

                await httpContext.Response.WriteAsync("****  CurrentCulture.DisplayName:  {CultureInfo.CurrentCulture.DisplayName}");
                return  ;
            }
            await _next(httpContext); 

            //כאן אפשר לכתוב קוד שיתבצע בדרך חזור מהשרת ללקוח
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
