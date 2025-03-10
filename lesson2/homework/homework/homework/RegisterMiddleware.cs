using System.Threading.Tasks;
using accountManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace homework
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RegisterMiddleware
    {
        private readonly RequestDelegate _next;
        private AccountManager manager = new AccountManager("user.txt", @"D:\Step\3 course\ASP.NET\lesson2\homework\homework");

        public RegisterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("name") && httpContext.Request.Query.ContainsKey("login") && httpContext.Request.Query.ContainsKey("password")) {
                string? name = httpContext.Request.Query["name"];
                string? login = httpContext.Request.Query["login"];
                string? password = httpContext.Request.Query["password"];

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("The name, login and password parameters are required!");
                    return;
                }

                if (manager.Register(login, password, name)) {
                    await httpContext.Response.WriteAsync("Registration was successful");
                } else {
                    await httpContext.Response.WriteAsync("A user with this login already exists");
                }
                   
                return;
            }
            await _next(httpContext);
            return;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RegisterMiddlewareExtensions
    {
        public static IApplicationBuilder UseRegisterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RegisterMiddleware>();
        }
    }
}
