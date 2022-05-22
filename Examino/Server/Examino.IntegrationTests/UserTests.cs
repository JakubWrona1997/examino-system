using Microsoft.AspNetCore.Http;
using Examino.Infrastructure;
using Moq;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Xunit;
using Examino.Infrastructure.Services;
using Examino.Application.Controllers;
using MediatR;
using Examino.Domain.Contracts;

namespace Examino.Tests
{
    public class UserTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private UserProvider _userProvider;

        public UserTests()
        {
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _userProvider = new UserProvider(_httpContextAccessor.Object);
        }

        [Fact]
        public async Task UserProvider_Should_Return_Logged_UserId()
        {
            //Arrange
            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            string id = Guid.NewGuid().ToString();

            _httpContextAccessor.Setup(x => x.HttpContext.User.FindFirst(It.IsAny<string>())).Returns(new Claim(ClaimTypes.NameIdentifier, id));
            //Act
            var result = _userProvider.GetUserId();
            //Assert
            Assert.Equal(id, result.ToString());
        }
    }
}
