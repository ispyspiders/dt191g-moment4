namespace PlaylistApp.Models
{
    public class SongDto
    {
        public int Id { get; set; }
        public string? Artist { get; set; }
        public string? Title { get; set; }
        public int Length { get; set; }
        public int CategoryId { get; set; } 
        public CategoryDto? Category { get; set; } 
    }
}