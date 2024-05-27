using MusicWebSite.DataAcess.Repositories.IRepository;
using MusicWebSite.DataAcessData.Data;
using MusicWebSite.Models;

namespace MusicWebSite.DataAcess.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        private ApplicationDbContext db;
        public MusicRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(Music music)
        {
            db.Music.Update(music);
        }
    }
}
