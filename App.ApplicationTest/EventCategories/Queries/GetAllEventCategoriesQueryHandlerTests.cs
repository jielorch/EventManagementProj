using App.Application.EventCategories.Queries.GetAllEventCategories;
using App.Application.Interfaces;
using App.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.ApplicationTest.EventCategories.Queries
{
    public class GetAllEventCategoriesQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsEventCategories()
        {
            // Arrange
            var mockRepo = new Mock<IEventCategoryRepository>();
            mockRepo.Setup(r => r.GetAllAsync())
                .ReturnsAsync(
            [
                new() { Id = 1, Name = "Category 1" },
                new() { Id = 2, Name = "Category 2" }
            ]);

            var handler = new GetAllEventCategoriesQueryHandler(mockRepo.Object);

            // Act
            var result = await handler.Handle(new GetAllEventCategoriesQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, e => e.Name == "Category 1");
        }
    }
}
