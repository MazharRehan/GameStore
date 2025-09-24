using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

// This static class contains extension methods for mapping between different game-related models
public static class GameMapping
{
    // Converts a CreateGameDto to a Game entity
    public static Game ToEntity(this CreateGameDto game)
    {
        return new Game()
        {
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    // Converts an UpdateGameDto to a Game entity, including the game ID
    public static Game ToEntity(this UpdateGameDto game, int id)
    {
        return new Game()
        {
            Id = id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    // Converts a Game entity to a GameSummaryDto
    /*
     * The null-coalescing operator (??) is used here to provide a default value when 'Genre' is null.
     * If 'game.Genre?.Name' has a value, it will be returned; otherwise, "Unknown" will be returned.
     */
    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.Genre?.Name ?? "Unknown",
            game.Price,
            game.ReleaseDate
        );
    }

    // Converts a Game entity to a GameDetailsDto
    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new(
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate
        );
    }
}
