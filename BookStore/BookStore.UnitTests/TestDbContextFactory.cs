using System;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;

namespace BookStore.UnitTests;

public static class TestDbContextFactory
{
    // Creates a new ApplicationDbContext backed by a fresh in-memory database.
    public static ApplicationDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            // each call gets its own DB instance
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new ApplicationDbContext(options);
        // if you seed data in OnModelCreating, it runs here
        context.Database.EnsureCreated();
        return context;
    }
}