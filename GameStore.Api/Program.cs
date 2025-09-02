using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
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

// GET /games
app.MapGet("games", () => games); // mininal api

// GET /games/1  --> get games by id
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
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

app.Run();
