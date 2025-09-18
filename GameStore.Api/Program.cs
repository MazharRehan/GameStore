using GameStore.Api.Endpoints;
using GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

await app.MigrateDbAsync(); // Extension method to apply migrations and seed data

app.Run();
