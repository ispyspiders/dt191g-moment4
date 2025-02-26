using System.ComponentModel.DataAnnotations;

namespace PlaylistApp.Models;

public class Song
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Artist måste anges.")]
    public string? Artist { get; set; }

    [Required(ErrorMessage ="Låttitel måste anges.")]
    public string? Title { get; set; }

    public int Length { get; set; } // längd i sekunder
    
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}