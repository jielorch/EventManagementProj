using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace App.PresentationTest.EventCategories
{
    public class EventCategoryApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public EventCategoryApiTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsOk_WithCategories()
        {
            // Act
            var response = await _httpClient.GetAsync("/api/EventCategory/get");

            // Assert
            response.EnsureSuccessStatusCode();
            var categories = await response.Content.ReadFromJsonAsync<List<EventCategory>>();

            Assert.NotNull(categories);
            Assert.True(categories.Count > 0, "Expected at least one event category");
        }
    }
}
