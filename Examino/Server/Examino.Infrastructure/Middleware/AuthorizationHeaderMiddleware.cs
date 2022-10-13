using Microsoft.AspNetCore.Http;

namespace Examino.Infrastructure.Middleware
{
    public class AuthorizationHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var authenticationCookieName = "tokenCookie";
            var token = context.Request.Cookies[authenticationCookieName];
            if (token != null)
            {
                if (!context.Request.Path.ToString().ToLower().Contains("/api/user/logout"))
                {
                    if (!string.IsNullOrEmpty(token))
                    {
                        var headerValue = "Bearer " + token;
                        if (context.Request.Headers.ContainsKey("Authorization"))
                        {
                            context.Request.Headers["Authorization"] = headerValue;
                        }
                        else
                        {
                            context.Request.Headers.Append("Authorization", headerValue);
                        }
                    }

                    await _next.Invoke(context);
                }
                else
                {
                    // this is a logout request, clear the cookie by making it expire now
                    context.Response.Cookies.Append(authenticationCookieName,
                        "",
                        new CookieOptions()
                        {
                            Path = "/",
                            HttpOnly = true,
                            Secure = false,
                            Expires = DateTime.UtcNow.AddHours(-1)
                        });
                    context.Response.Redirect("/");
                    return;
                }
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}