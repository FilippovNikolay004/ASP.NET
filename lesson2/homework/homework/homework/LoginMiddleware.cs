using System.Threading.Tasks;
using System.Xml.Linq;
using accountManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace homework
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            AccountManager manager = new AccountManager("user.txt", @"D:\Step\3 course\ASP.NET\lesson2\homework\homework");

            if (httpContext.Request.Query.ContainsKey("login") && httpContext.Request.Query.ContainsKey("password")) {
                string? login = httpContext.Request.Query["login"];
                string? password = httpContext.Request.Query["password"];

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) {
                    httpContext.Response.StatusCode = 400; 
                    await httpContext.Response.WriteAsync("The login and password parameters are required!");
                    return;
                }

                if (manager.Login(login, password)) {
                    await httpContext.Response.WriteAsync("Authorization was successful");
                } else {
                    await httpContext.Response.WriteAsync("login or password is incorrect!");
                }

                return;
            }
            await _next(httpContext);
            return;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
