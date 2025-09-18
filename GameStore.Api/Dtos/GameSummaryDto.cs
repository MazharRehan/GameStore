namespace GameStore.Api.Dtos;

// DTO(Data Transfer Object) or Contract
// This record represents the data returned for a game
public record class GameSummaryDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);