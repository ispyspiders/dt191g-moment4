using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlaylistApp.Models;
public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Kategorinamn måste anges.")]
    public string? Name { get; set; }
    public List<Song>? Songs { get; set; }
}