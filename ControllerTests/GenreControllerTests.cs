using FoodBuddy.Controllers;
using FoodBuddy.Models;
using FoodBuddy.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodBuddy.UnitTests.ControllerTests
{
    public class GenreControllerTests
    {
        private readonly GenreController _controller;
        private readonly Mock<IGenreService> _genreServiceMock;

        public GenreControllerTests()
        {
            // Arrange
            _genreServiceMock = new Mock<IGenreService>();
            _controller = new GenreController(_genreServiceMock.Object);
        }

        [Fact]
        public void Add_should_return_add_view()
        {
            // Act
            var result = _controller.Add() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "Add");
            Assert.True(hasCorrectView);
        }

        [Fact]

        public void Edit_should_return_edit_view()
        {
            // Act
            var result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "Edit");
            Assert.True(hasCorrectView);
        }

        [Fact]
        public void GenreList_should_return_genre_list_view()
        {
            // Act
            var result = _controller.GenreList() as ViewResult;

            // Assert
            Assert.NotNull(result);
            var hasCorrectView = (result.ViewName == null || result.ViewName == "GenreList");
            Assert.True(hasCorrectView);
        }

        [Fact]
        public void Add_POST_InvalidModel_should_return_view_with_model()
        {
            // Arrange
            var model = new Genre();
            _controller.ModelState.AddModelError("Name", "Name is required.");

            // Act
            var result = _controller.Add(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model, result.Model); 
        }

        [Fact]
        public void Edit_GET_should_return_view_with_data()
        {
            // Arrange
            var genreId = 1;
            var genreData = new Genre();
            _genreServiceMock.Setup(s => s.GetById(genreId)).Returns(genreData);

            // Act
            var result = _controller.Edit(genreId) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(genreData, result.Model); 
        }

        [Fact]
        public void Update_POST_InvalidModel_should_return_view_with_model()
        {
            // Arrange
            var model = new Genre();
            _controller.ModelState.AddModelError("Name", "Name is required.");

            // Act
            var result = _controller.Update(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(model, result.Model); 
        }
    }
}
