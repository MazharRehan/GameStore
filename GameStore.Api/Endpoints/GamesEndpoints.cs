using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

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

    public static WebApplication MapGamesEndpoints(this WebApplication app)
    {

        // GET /games
        app.MapGet("games", () => games); // mininal api

        // GET /games/1  --> get games by id
        app.MapGet("games/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games
        app.MapPost("games", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate);

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        // PUT /games/1
        app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
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
        app.MapDelete("games/{id}", (int id) =>
        {
            var game = games.Find(g => g.Id == id);
            if (game is null)
            {
                return Results.NotFound();
            }

            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return app;
    }
}
