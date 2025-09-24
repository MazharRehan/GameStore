using System;

namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }
    public required String Name { get; set; }

    public int GenreId { get; set; }

    // Genre means the category of the game, e.g., Action, Adventure, RPG
    public Genre? Genre { get; set; } // ? indicates that this property can be null
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
