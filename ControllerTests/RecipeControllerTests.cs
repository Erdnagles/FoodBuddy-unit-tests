using FoodBuddy.Controllers;
using FoodBuddy.Models;
using FoodBuddy.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodBuddy.UnitTests.ControllerTests
{
    public class RecipeControllerTests
    {
        private readonly Mock<IGenreService> _genreServiceMock;
        private readonly Mock<IRecipeService> _recipeServiceMock;
        private readonly Mock<IFileService> _fileServiceMock;
        private readonly RecipeController _controller;
        
        public RecipeControllerTests()
        {
            _genreServiceMock = new Mock<IGenreService>();
            _recipeServiceMock = new Mock<IRecipeService>();
            _fileServiceMock = new Mock<IFileService>();
            _controller = new RecipeController(_genreServiceMock.Object, 
                                               _recipeServiceMock.Object, 
                                               _fileServiceMock.Object);
        }

        [Fact]
        public void Add_returns_view_with_model()
        {
            // Act
            var result = _controller.Add() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.IsType<Recipe>(result.Model);
        }

        [Fact]
        public void Add_post_with_valid_model_redirects_to_add()
        {
            // Arrange
            var model = new Recipe();
            _controller.ModelState.AddModelError("Title", "Title is required");
            _controller.ModelState.AddModelError("Guide", "Guide is required");
            _controller.ModelState.AddModelError("Ingredients", "Ingredients is required");


            // Act
            var result = _controller.Add(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.IsType<Recipe>(result.Model);
        }

        [Fact]
        public void Edit_post_with_valid_model_redirects_to_edit()
        {
            // Arrange
            var model = new Recipe();
            _controller.ModelState.AddModelError("Title", "Title is required");
            _controller.ModelState.AddModelError("Description", "Description is required");
            _controller.ModelState.AddModelError("Guide", "Guide is required");  
            
            // Act
            var result = _controller.Edit(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.IsType<Recipe>(result.Model);
        }

        [Fact]
        public void Delete_confirmed_should_redirect()
        {
            // Arrange
            var id = 1;
            _recipeServiceMock.Setup(mock => mock.Delete(id))
                .Verifiable();

            // Act
            var result = _controller.Delete(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("RecipeList", result.ActionName);
            _recipeServiceMock.VerifyAll();
        }
    }
}
