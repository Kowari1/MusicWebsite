using Microsoft.AspNetCore.Mvc;
using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.Models;
using MusicWEB.Models.ViewModels;
using MusicWEB.Utility;

namespace MusicWEB.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileServices fileServices;
        private readonly UserValidationService userValidationService;

        public RegistrationController(IUnitOfWork unitOfWork, IFileServices fileServices, UserValidationService userValidationService)
        {
            this.unitOfWork = unitOfWork;
            this.fileServices = fileServices;
            this.userValidationService = userValidationService;
        }

        public IActionResult CreateUser()
        {
            return View(new RegistrationUserVM());
        }

        [HttpPost]
        public IActionResult CreateUser(RegistrationUserVM userVM)
        {
            ViewData["CurrentController"] = "Registration";
            ViewData["CurrentAction"] = "CreateUser";

            if (ModelState.IsValid && ValidUser(userVM))
            {
                try
                    {
                        string profileImageUrl = fileServices.SaveFile(userVM.ImageFile, null, "image");

                        var user = new User()
                        {
                            Name = userVM.Name,
                            isAdmin = userVM.isAdmin,
                            Email = userVM.Email,
                            Password = userVM.Password,
                            ImageUrl = profileImageUrl
                        };

                        unitOfWork.UserRepository.Add(user);
                        unitOfWork.Save();

                        return RedirectToAction("Login", "Authentication");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Error occurred while registering user. Please try again later.");
                        return View(userVM);
                    }
            }
            return View(userVM);
        }   

        #region METHODS
        private bool ValidUser(RegistrationUserVM userVM)
        {
            if (!userValidationService.IsUsernameUnique(userVM.Name))
            {
                ModelState.AddModelError(nameof(userVM.Name), "Username is already taken");
                return false;
            }
            else if (!userValidationService.IsPasswordConfirmed(userVM.PasswordConfirm, userVM.Password))
            {
                ModelState.AddModelError(nameof(userVM.PasswordConfirm), "Password mismatch");
                return false;
            }
            else if(!userValidationService.IsEmailUnique(userVM.Email))
            {
                ModelState.AddModelError(nameof(userVM.Email), "Email is already registered");
                return false;
            }         
            else if (userVM.ImageFile == null && !userVM.ImageFile.ContentType.StartsWith("image"))
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
