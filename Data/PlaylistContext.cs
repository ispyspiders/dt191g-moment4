using Microsoft.EntityFrameworkCore;
using PlaylistApp.Models;

namespace PlaylistApp.Data;

public class PlaylistContext : DbContext
{
    public PlaylistContext(DbContextOptions<PlaylistContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Song>()
        .HasOne(s=>s.Category)
        .WithMany(c=>c.Songs)
        .HasForeignKey(s=> s.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}