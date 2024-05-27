using Microsoft.EntityFrameworkCore;
using MusicWebSite.Models;

namespace MusicWebSite.DataAcessData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Pop" },
                new Genre { Id = 2, Name = "Rock" },
                new Genre { Id = 3, Name = "Hip-Hop" },
                new Genre { Id = 4, Name = "Rap" },
                new Genre { Id = 5, Name = "Electronic" },
                new Genre { Id = 6, Name = "Jazz" },
                new Genre { Id = 7, Name = "Classical" },
                new Genre { Id = 8, Name = "Country" },
                new Genre { Id = 9, Name = "Reggae" },
                new Genre { Id = 10, Name = "Metall" },
                new Genre { Id = 11, Name = "Funk)" },
                new Genre { Id = 12, Name = "Blues" },
                new Genre { Id = 13, Name = "Rhythm and Blues" },
                new Genre { Id = 14, Name = "Indie" },
                new Genre { Id = 15, Name = "Latino" },
                new Genre { Id = 16, Name = "Punk" },
                new Genre { Id = 17, Name = "Soul" },
                new Genre { Id = 18, Name = "Techno" },
                new Genre { Id = 19, Name = "Punk" },
                new Genre { Id = 20, Name = "Disco" },
                new Genre { Id = 21, Name = "Alternative" }
                );
        }
    }
}
