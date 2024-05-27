using MusicWEB.Models;

namespace MusicWEB.DataAcess.Repositories.IRepository
{
   public interface IUserMusicRepository : IRepository<UserMusic>
   {
      void Update(UserMusic userMusic);
   }
}


