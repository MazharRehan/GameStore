using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// This static class contains extension methods for data-related operations
public static class DataExtensions
{
    // At app startup, it ensures your database exists and applies any pending EF Core migrations automatically.
    // It will create the database if it does not already exist.
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        // Create a new scope to get the required services
        using var scope = app.Services.CreateScope();
        // Get the GameStoreContext service
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        // Apply any pending migrations
        await dbContext.Database.MigrateAsync();
    }
}
