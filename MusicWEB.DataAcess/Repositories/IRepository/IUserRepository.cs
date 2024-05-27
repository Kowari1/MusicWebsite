using MusicWEB.Models;

namespace MusicWEB.DataAcess.Repositories.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
