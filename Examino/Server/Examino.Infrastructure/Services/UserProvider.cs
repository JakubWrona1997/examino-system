using Examino.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Services
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid GetUserId()
        {
            var result = Guid.Empty;

            try
            {
                Guid.TryParse(_httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value, out result);
            }
            catch (Exception e)
            {
                throw new BadHttpRequestException("Something went wrong", StatusCodes.Status404NotFound);
            }
            
            return result;
        }
        public string GetUserRole()
        {
            try
            {
                var userRole = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Role).Value;
                if(userRole != null)
                    return userRole;
            }
            catch (Exception e)
            {
                throw new BadHttpRequestException("Something went wrong", StatusCodes.Status404NotFound);
            }
            return string.Empty;
        }
        public string GetToken()
        {
            try
            {
                var token = _httpContextAccessor.HttpContext.Request.Cookies["tokenCookie"];
                if (token != null)
                    return token;
            }
            catch (Exception e)
            {
                throw new BadHttpRequestException("Something went wrong", StatusCodes.Status404NotFound);
            }
            return string.Empty;
        }
    }
}
