using MusicWebSite.DataAcess.Repositories.IRepository;
using MusicWebSite.DataAcessData.Data;
using MusicWebSite.Models;

namespace MusicWebSite.DataAcess.Repositories
{
    internal class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private ApplicationDbContext db;
        public GenreRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(Genre category)
        {
            db.Genre.Update(category);
        }
    }
}
