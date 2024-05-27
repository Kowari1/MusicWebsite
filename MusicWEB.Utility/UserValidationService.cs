using MusicWEB.DataAcess.Repositories.IRepository;

namespace MusicWEB.Utility
{
    public class UserValidationService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserValidationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool IsPasswordConfirmed(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        public bool IsEmailUnique(string email)
        {
            return unitOfWork.UserRepository.Get(u => u.Email == email) == null;
        }

        public bool IsUsernameUnique(string username)
        {
            return unitOfWork.UserRepository.Get(u => u.Name == username) == null;
        }

        public bool PasswordVerification(string password) 
        {
            return unitOfWork.UserRepository.Get(u => u.Password == password) != null;
        }
    }
}
