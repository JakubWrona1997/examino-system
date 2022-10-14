using System;
using System.Security.Claims;
using Examino.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Examino.Tests
{
    public class UserTests
    {
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private UserProvider objectUnderTest;

        public UserTests()
        {
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            objectUnderTest = new UserProvider(_httpContextAccessor.Object);
        }

        [Fact]
        public void UserProvider_Should_Return_Logged_UserId()
        {
            //Arrange           
            string id = Guid.NewGuid().ToString();

            _httpContextAccessor.Setup(x => x.HttpContext.User.FindFirst(It.IsAny<string>())).Returns(new Claim(ClaimTypes.NameIdentifier, id));
            //Act
            var result = objectUnderTest.GetUserId();
            //Assert
            Assert.Equal(id, result.ToString());
        }
        [Fact]
        public void UserProvider_Should_Return_Users_Role()
        {
            //Arrange           
            string role = "Doctor";

            _httpContextAccessor.Setup(x => x.HttpContext.User.FindFirst(It.IsAny<string>())).Returns(new Claim(ClaimTypes.Role, role));
            //Act
            var result = objectUnderTest.GetUserRole();
            //Assert
            Assert.Equal(role, result);
        }
        [Fact]
        public void GetUserRole_Should_Throw_BadHttpRequestException_When_ContextAccessor_Is_Not_Set()
        {
            //Arrange           
            
            //Act
            Func<string> actionToPerform = () => objectUnderTest.GetUserRole();
            //Assert
            Assert.Throws<BadHttpRequestException>(actionToPerform);
        }
        [Fact]
        public void GetToken_Should_Throw_BadHttpRequestException_When_ContextAccessor_Is_Not_Set()
        {
            //Arrange           
            
            //Act
            Func<string> actionToPerform = () => objectUnderTest.GetToken();
            //Assert
            Assert.Throws<BadHttpRequestException>(actionToPerform);
        }
        [Fact]
        public void GetUserId_Should_Throw_BadHttpRequestException_When_ContextAccessor_Is_Not_Set()
        {
            //Arrange           
            
            //Act

            //Assert
            Assert.Throws<BadHttpRequestException>(() => objectUnderTest.GetUserId());
        }
    }
}
