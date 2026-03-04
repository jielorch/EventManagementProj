using App.Domain.Entities;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.InfrastructureTest
{
    public static class TestDbContextFactory
    {
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Filename=:memory:") // Use in-memory SQLite database
                .Options;

            var context = new AppDbContext(options);
            context.Database.OpenConnection(); // Open the connection to the in-memory database
            context.Database.EnsureCreated(); // Ensure the database schema is created


            context.EventCategories.Add(new EventCategory { Id = 1, Name = "Test Category" });
            context.SaveChanges();

            return context;
        }

    }
}
