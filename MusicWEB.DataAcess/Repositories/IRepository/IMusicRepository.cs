using MusicWEB.Models;

namespace MusicWEB.DataAcess.Repositories.IRepository
{
    public interface IMusicRepository : IRepository<Music>
    {
        void Update(Music music);
    }

}