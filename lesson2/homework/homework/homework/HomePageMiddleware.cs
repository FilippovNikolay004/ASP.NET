using System.Threading.Tasks;
using accountManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace homework
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HomePageMiddleware
    {
        private readonly RequestDelegate _next;
        
        public HomePageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext) {
            AccountManager manager = new AccountManager("user.txt", @"D:\Step\3 course\ASP.NET\lesson2\homework\homework");

            if (httpContext.Request.Path == "/home") {
                await httpContext.Response.WriteAsync($"{manager.PrintData()}");
                return;
            }

            await _next(httpContext);
            return;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HomePageMiddlewareExtensions
    {
        public static IApplicationBuilder UseHomePageMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HomePageMiddleware>();
        }
    }
}
