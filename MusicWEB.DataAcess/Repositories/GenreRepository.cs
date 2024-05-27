using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.DataAcessData.Data;
using MusicWEB.Models;

namespace MusicWEB.DataAcess.Repositories
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
