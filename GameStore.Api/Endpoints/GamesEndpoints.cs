using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    // In-memory list of games to simulate a database
    private static readonly List<GameSummaryDto> games = [
        new (
        1,
        "The Legend of Zelda: Breath of the Wild",
        "Action-adventure",
        59.99M,
        new DateOnly(2017, 3, 3)),
    new (2,
         "Street Fighter V",
         "Fighting",
         39.99M,
         new DateOnly(2016, 2, 16)),
    new (
        3,
        "God of War",
        "Action-adventure",
        49.99m,
        new DateOnly(2018, 4, 20)),
    new (
        4,
        "FIFA 23",
        "Sports",
        59.99m,
        new DateOnly(2022, 9, 30)),
    new (
        5,
        "The Witcher 3: Wild Hunt",
        "Action RPG",
        29.99m,
        new DateOnly(2015, 5, 19))
    ];

    // Extension method to map game-related endpoints
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games")
                        .WithParameterValidation();

        // GET /games  --> get all games
        group.MapGet("/", (GameStoreContext dbContext) =>
            dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToGameSummaryDto())
                .AsNoTracking());

        // GET /games/1  --> get games by id
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);

            return game is null ?
                Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges(); // Commit the changes to the database

            return Results.CreatedAtRoute(
                GetGameEndpointName,
                new { id = game.Id },
                game.ToGameSummaryDto());
        });

        // PUT /games/1
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = dbContext.Games.Find(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updatedGame.ToEntity(id));

            dbContext.SaveChanges(); // Commit the changes to the database

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
        {
            dbContext.Games
                    .Where(game => game.Id == id)
                    .ExecuteDelete();

            return Results.NoContent();
        });

        return group;
    }
}
