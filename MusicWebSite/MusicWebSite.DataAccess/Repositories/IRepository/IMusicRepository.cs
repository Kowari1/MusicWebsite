using MusicWebSite.Models;

namespace MusicWebSite.DataAcess.Repositories.IRepository
{
    public interface IMusicRepository : IRepository<Music>
    {
        void Update(Music music);
    }

}