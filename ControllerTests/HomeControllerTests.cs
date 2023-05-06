using FoodBuddy.Controllers;
using FoodBuddy.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodBuddy.UnitTests.ControllerTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_should_return_index_view()
        {
            // Arrange
            var recipeServiceMock = new Mock<IRecipeService>();
            var controller = new HomeController(recipeServiceMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "Index");
            Assert.True(hasCorrectView);
        }

        [Fact]
        public void About_should_return_about_view()
        {
            // Arrange
            var recipeServiceMock = new Mock<IRecipeService>();
            var controller = new HomeController(recipeServiceMock.Object);

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "Privacy");
            Assert.True(hasCorrectView);
        }

        [Fact]
        public void RecipeDetail_should_return_recipe_detail_view()
        {
            // Arrange
            var recipeServiceMock = new Mock<IRecipeService>();
            var controller = new HomeController(recipeServiceMock.Object);

            // Act
            var result = controller.RecipeDetail(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "RecipeDetail");
            Assert.True(hasCorrectView);
        }
    }
}
