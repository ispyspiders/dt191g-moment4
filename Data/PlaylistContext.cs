using Microsoft.EntityFrameworkCore;
using PlaylistApp.Models;

namespace PlaylistApp.Data;

public class PlaylistContext : DbContext
{
    public PlaylistContext(DbContextOptions<PlaylistContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Song> Songs { get; set; }
}