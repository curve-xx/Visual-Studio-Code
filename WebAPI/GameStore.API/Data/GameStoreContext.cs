using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options)
    : DbContext(options)
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Genre)
            .WithMany()
            .HasForeignKey(g => g.GenreId);

        modelBuilder.Entity<Genre>()
            .HasData(
                new Genre { Id = 1, Name = "Fighting" },
                new Genre { Id = 2, Name = "Roleplaying" },
                new Genre { Id = 3, Name = "Sports" },
                new Genre { Id = 4, Name = "Racing" },
                new Genre { Id = 5, Name = "Kids & Family" }
            );
    }
}
