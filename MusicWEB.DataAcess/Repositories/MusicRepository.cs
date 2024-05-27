using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.DataAcessData.Data;
using MusicWEB.Models;

namespace MusicWEB.DataAcess.Repositories
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
