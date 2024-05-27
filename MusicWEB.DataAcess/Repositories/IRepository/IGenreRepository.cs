using MusicWEB.Models;

namespace MusicWEB.DataAcess.Repositories.IRepository
{
    public interface IGenreRepository : IRepository<Genre>
    {
        void Update(Genre category);
    }
}
