using MusicWebSite.DataAcess.Repositories.IRepository;
using MusicWebSite.DataAcessData.Data;

namespace MusicWebSite.DataAcess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;

        public IUserRepository UserRepository { get; private set; }
        public IGenreRepository GenreRepository { get; private set; }
        public IMusicRepository MusicRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
            UserRepository = new UserRepository(db);
            GenreRepository = new GenreRepository(db);
            MusicRepository = new MusicRepository(db);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
