using System.ComponentModel.DataAnnotations;

namespace PlaylistApp.Models;
public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Kategorinamn måste anges.")]
    public string? Name { get; set; }
    public ICollection<Song>? Songs { get; set; }
}