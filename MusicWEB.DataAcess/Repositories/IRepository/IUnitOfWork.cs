
namespace MusicWEB.DataAcess.Repositories.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IGenreRepository GenreRepository { get; }
        IMusicRepository MusicRepository { get; }
        IUserMusicRepository UserMusicRepository { get; }

        void Save();
    }
}
