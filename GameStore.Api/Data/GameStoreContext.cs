using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// 'DbContext' is a class that manages the database connection and is used to query and save data
public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>(); // DbSet represents a table in the database
    public DbSet<Genre> Genres => Set<Genre>();

    // Seed(populate) initial genres - this will only run when the database is created for the first time
    // 'Seed' means to populate initial data into the database
    // 'Genres' are static data that don't change often, so we can seed them here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Fighting" },
            new { Id = 2, Name = "Roleplaying" },
            new { Id = 3, Name = "Sports" },
            new { Id = 4, Name = "Racing" },
            new { Id = 5, Name = "Kids and Family" }
        );
    }
}
