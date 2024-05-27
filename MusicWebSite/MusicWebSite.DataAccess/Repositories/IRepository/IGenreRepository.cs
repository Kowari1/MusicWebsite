using MusicWebSite.Models;

namespace MusicWebSite.DataAcess.Repositories.IRepository
{
    public interface IGenreRepository : IRepository<Genre>
    {
        void Update(Genre category);
    }

}
