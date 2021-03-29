using Microsoft.AspNetCore.Http;
namespace Core.Utils
{
    public static class HttpContextAccessorExtension
    {
        public static string GetCurrenUserEmail(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.Items["Email"].ToString();
        }
    }
}
