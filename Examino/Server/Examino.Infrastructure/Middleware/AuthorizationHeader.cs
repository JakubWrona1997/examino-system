using Examino.Domain.TokenClasses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Middleware
{
    public class AuthorizationHeader
    {
        private readonly RequestDelegate _next;

        public AuthorizationHeader(RequestDelegate next)
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
                        if (token != null)
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
