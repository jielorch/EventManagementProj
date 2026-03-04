using App.Application.EventCategories.Queries.GetAllEventCategories;
using App.Domain.Entities;
using App.Web.ApiControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.PresentationTest.EventCategories
{
 
    public class EventCategoryControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult_WithCategoriesWhenMediatorSucceeds()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<GetAllEventCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
            [
                new() { Id = 1, Name = "Category 1" },
                new() { Id = 2, Name = "Category 2" }
            ]);


            var controller = new EventCategoryController(mockMediator.Object);

            // Act
            var result = await controller.Get();

            // Assert 
            var okResult = Assert.IsType<OkObjectResult>(result);
            var categories = Assert.IsType<IEnumerable<EventCategory>>(okResult.Value, exactMatch: false);
            Assert.Equal(2, categories.Count());
        }

        [Fact]
        public async Task Get_ReturnsInternalServerError_WhenMediatorThrows()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<GetAllEventCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            var controller = new EventCategoryController(mockMediator.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("An error occurred while processing the request please try again later", objectResult.Value);
        }
    }
}
