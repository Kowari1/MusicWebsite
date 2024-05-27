
using MusicWebSite.DataAcess.Repositories.IRepository;
using MusicWebSite.DataAcessData.Data;
using MusicWebSite.Models;

namespace MusicWebSite.DataAcess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext db;
        public UserRepository(ApplicationDbContext db) : base(db)
        { 
            this.db = db;
        }

        public void Update(User user)
        {
            db.Users.Update(user);
        }
    }
}
