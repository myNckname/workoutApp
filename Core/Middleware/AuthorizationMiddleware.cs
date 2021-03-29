using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Core.Interfaces;
using System.Linq;

namespace Core.Middleware
{
    public static class RequestAuthorizationMiddleware
    {
        public static IApplicationBuilder UseAuthHeaderParserMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }

    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
             httpContext.Items["Email"] = httpContext.User.Claims.FirstOrDefault(c=>c.Type.Contains("email"))?.Value;
            await _next.Invoke(httpContext);
        }
    }
}
