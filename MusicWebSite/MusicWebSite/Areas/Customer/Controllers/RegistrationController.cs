using Microsoft.AspNetCore.Mvc;
using MusicWebSite.DataAcess.Repositories.IRepository;
using MusicWebSite.Models;
using MusicWebSite.Models.ViewModels;
using MusicWebSite.Utility;

namespace MusicWebSite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileServices fileServices;

        public RegistrationController(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            this.unitOfWork = unitOfWork;
            this.fileServices = fileServices;
        }

        public IActionResult Register()
        {
            return View(new UserVM());
        }

        public IActionResult CreateUser(UserVM userVM, bool isAddmin)
        {
            if(ModelState.IsValid)
            {
                
                if (userVM.ImageFile != null && !userVM.ImageFile.ContentType.StartsWith("image"))
                {
                    string profileImageUrl = fileServices.SaveFile(userVM.ImageFile, null, "image");
                    userVM.User.ImageUrl = profileImageUrl;
                }
                else
                {
                    return View("Register", userVM.User);
                }

                unitOfWork.UserRepository.Add(userVM.User);
                unitOfWork.Save();

                return View();
            }

            return View("Register", new User());
        }

        #region METHODS
        private bool IsValid(UserVM model)
        {
            if (model.User.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError(nameof(model.PasswordConfirm), "Password mismatch");
                return false;
            }

            if (unitOfWork.UserRepository.Get(u => u.Email == model.User.Email) != null)
            {
                ModelState.AddModelError(nameof(model.User.Email), "Email is already registered");
                return false;
            }

            if (unitOfWork.UserRepository.Get(u => u.Name == model.User.Name) != null)
            {
                ModelState.AddModelError(nameof(model.User.Name), "Username is already taken");
                return false;
            }

            return ModelState.IsValid;
        }
        #endregion
    }
}
