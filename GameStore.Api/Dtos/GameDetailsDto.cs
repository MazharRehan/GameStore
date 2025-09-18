namespace GameStore.Api.Dtos;

// DTO(Data Transfer Object) or Contract
// This record represents the data returned for a game
public record class GameDetailsDto(
    int Id,
    string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate
);