
namespace MusicWebSite.DataAcess.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IGenreRepository GenreRepository { get; }
        IMusicRepository MusicRepository { get; }

        void Save();
    }
}
