using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Genre is required.")]
    public required string GenreId { get; set; }

    [Range(1, 100, ErrorMessage = "Price must be between 1 and 100.")]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
