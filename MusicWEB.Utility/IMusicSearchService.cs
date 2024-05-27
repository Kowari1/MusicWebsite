using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.Models;

namespace MusicWEB.Utility
{
    public interface IMusicSearchService
    {
        IEnumerable<Music> Search(string searchQuery);
    }

    public class MusicSearchService : IMusicSearchService
    {
        private readonly IUnitOfWork unitOfWork;

        public MusicSearchService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Music> Search(string searchQuery)
        {
            searchQuery = searchQuery.ToLower();

            var result = unitOfWork.MusicRepository.GetAll()
                .ToList()
                .Where(music => music.Title.ToLower().Contains(searchQuery) ||
                unitOfWork.GenreRepository.Get(genre => music.GenreId == genre.Id).Name
                .ToLower().
                Contains(searchQuery));
            return result.ToList();
        }
    }
}
