using FoodBuddy.Controllers;
using FoodBuddy.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodBuddy.UnitTests.ControllerTests
{
    public class HomeControllerTests
    {
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            // Arrange
            var recipeServiceMock = new Mock<IRecipeService>();
            _controller = new HomeController(recipeServiceMock.Object);
        }

        [Fact]
        public void Index_should_return_index_view()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "Index");
            Assert.True(hasCorrectView);
        }

        [Fact]
        public void About_should_return_about_view()
        {
            // Act
            var result = _controller.About() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "Privacy");
            Assert.True(hasCorrectView);
        }

        [Fact]
        public void RecipeDetail_should_return_recipe_detail_view()
        {
            // Act
            var result = _controller.RecipeDetail(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "RecipeDetail");
            Assert.True(hasCorrectView);
        }
    }
}
