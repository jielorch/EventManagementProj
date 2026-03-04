using App.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.InfrastructureTest.EventCategories
{
    public class EventCategoryRepositoryTest
    {
        [Fact]
        public async Task GetAllAsync_ReturnsCategoriesFromDatabase()
        {
            var context = TestDbContextFactory.Create();
            var repository = new EventCategoryRepository(context);

            var result = await repository.GetAllAsync();

            Assert.NotNull(result);
            Assert.Contains(result, c => c.Name == "Test Category");
        }
    }
}
