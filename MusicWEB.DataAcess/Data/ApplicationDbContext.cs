
using Microsoft.EntityFrameworkCore;
using MusicWEB.Models;

namespace MusicWEB.DataAcessData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<UserMusic> UserMusic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Pop", ImageUrl= "/files\\image\\GenreImages\\Pop.jfif" },
                new Genre { Id = 2, Name = "Rock", ImageUrl = "/files\\image\\GenreImages\\Rock.png" },
                new Genre { Id = 3, Name = "Hip-Hop", ImageUrl = "/files\\image\\GenreImages\\Hip-Hop.png" },
                new Genre { Id = 4, Name = "Rap", ImageUrl = "/files\\image\\GenreImages\\Rap.png" },
                new Genre { Id = 5, Name = "Electronic", ImageUrl = "/files\\image\\GenreImages\\Electronic.png" },
                new Genre { Id = 6, Name = "Jazz", ImageUrl = "/files\\image\\GenreImages\\Jazz.png" },
                new Genre { Id = 7, Name = "Classical", ImageUrl = "/files\\image\\GenreImages\\Classical.jpg" },
                new Genre { Id = 8, Name = "Metall", ImageUrl = "/files\\image\\GenreImages\\Metall.jpg" },
                new Genre { Id = 9, Name = "Funk", ImageUrl = "/files\\image\\GenreImages\\Funk.png" },
                new Genre { Id = 10, Name = "Blues", ImageUrl = "/files\\image\\GenreImages\\Blues.png" },
                new Genre { Id = 11, Name = "Latino", ImageUrl = "/files\\image\\GenreImages\\Latino.jfif" },
                new Genre { Id = 12, Name = "Punk", ImageUrl = "/files\\image\\GenreImages\\Punk.jfif" },
                new Genre { Id = 13, Name = "Soul", ImageUrl = "/files\\image\\GenreImages\\Soul.png" },
                new Genre { Id = 14, Name = "Techno", ImageUrl = "/files\\image\\GenreImages\\Techno.jpg" },
                new Genre { Id = 15, Name = "Disco", ImageUrl = "/files\\image\\GenreImages\\Disco.png" },
                new Genre { Id = 16, Name = "Alternative", ImageUrl = "/files\\image\\GenreImages\\Alternative.png" }
                );
        }
    }
}
