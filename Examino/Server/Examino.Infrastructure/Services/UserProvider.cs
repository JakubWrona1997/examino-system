﻿using Examino.Domain.Contracts;
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

            if(_httpContextAccessor.HttpContext == null)
                throw new BadHttpRequestException("Something went wrong", StatusCodes.Status404NotFound);
                
            Guid.TryParse(_httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value, out result);
            
            return result;
        }
        public string GetUserRole()
        {
            var userRole = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Role).Value;

            if(userRole != null)
                return userRole;

            return string.Empty;
        }
        public string GetToken()
        {
            var token = _httpContextAccessor.HttpContext.Request.Cookies["tokenCookie"];

            if(token != null)
                return token;

            return string.Empty;
        }
    }
}
