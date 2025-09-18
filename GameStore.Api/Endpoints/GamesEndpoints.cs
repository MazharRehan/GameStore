using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    // In-memory list of games to simulate a database
    private static readonly List<GameDto> games = [
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

        // GET /games
        group.MapGet("/", () => games); // mininal api

        // GET /games/1  --> get games by id
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();
            game.Genre = dbContext.Genres.Find(newGame.GenreId);


            dbContext.Games.Add(game);
            dbContext.SaveChanges(); // Commit the changes to the database

            return Results.CreatedAtRoute(
                GetGameEndpointName,
                new { id = game.Id },
                game.ToDto());
        });

        // PUT /games/1
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                 id,
                 updatedGame.Name,
                 updatedGame.Genre,
                 updatedGame.Price,
                 updatedGame.ReleaseDate);

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            var game = games.Find(g => g.Id == id);
            if (game is null)
            {
                return Results.NotFound();
            }

            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
