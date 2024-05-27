using Microsoft.AspNetCore.Mvc;
using MusicWebSite.DataAcess.Repositories.IRepository;

namespace MusicWebSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
