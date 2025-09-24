using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

// Record types are immutable and provide built-in value-based equality.
// This record represents the data required to create a new game
public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    int GenreId, // e.g., Action, Adventure, RPG
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
