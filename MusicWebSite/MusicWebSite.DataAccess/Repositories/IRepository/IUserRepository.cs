using MusicWebSite.Models;

namespace MusicWebSite.DataAcess.Repositories.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
