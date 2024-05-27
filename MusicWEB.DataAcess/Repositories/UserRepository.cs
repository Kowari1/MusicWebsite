
using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.DataAcessData.Data;
using MusicWEB.Models;

namespace MusicWEB.DataAcess.Repositories
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
