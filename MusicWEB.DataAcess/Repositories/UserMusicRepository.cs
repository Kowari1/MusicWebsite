using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.DataAcessData.Data;
using MusicWEB.Models;

namespace MusicWEB.DataAcess.Repositories
{
    public class UserMusicRepository : Repository<UserMusic>, IUserMusicRepository
    {
        private ApplicationDbContext db;
        public UserMusicRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(UserMusic userMusic) 
        { 
            db.UserMusic.Update(userMusic);
        }
    }
}
