using System;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// This static class contains extension methods for data-related operations
public static class DataExtensions
{
    // This method applies any pending migrations for the context to the database.
    // It will create the database if it does not already exist.
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }
}
