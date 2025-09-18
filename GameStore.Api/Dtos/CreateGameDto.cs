using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

// This record represents the data required to create a new game
public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    int GenreId, // e.g., Action, Adventure, RPG
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
