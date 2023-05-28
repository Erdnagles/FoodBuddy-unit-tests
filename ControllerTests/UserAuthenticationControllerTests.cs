using FoodBuddy.Controllers;
using FoodBuddy.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodBuddy.UnitTests.ControllerTests
{
    public class UserAuthenticationControllerTests
    {
        private readonly UserAuthenticationController _controller;
        private readonly Mock<IUserAuthenticationService> _authServiceMock;

        public UserAuthenticationControllerTests()
        {
            // Arrange
            _authServiceMock = new Mock<IUserAuthenticationService>();
            _controller = new UserAuthenticationController(_authServiceMock.Object);
        }

        [Fact]
        public async Task Login_should_return_view_result()
        {
            // Act
            var result = await _controller.Login() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Logout_should_redirect_to_login()
        {
            // Act
            var result = await _controller.Logout() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Login", result.ActionName);
            Assert.Null(result.ControllerName);
        }
    }
}