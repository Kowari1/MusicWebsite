using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MusicWEB.Models;
using MusicWEB.Utility;
using System.Security.Claims;
using MusicWEB.Models.ViewModels;
using MusicWEB.DataAcess.Repositories.IRepository;

namespace MusicWEB.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserValidationService userValidationService;
        private readonly IUnitOfWork unitOfWork;

        public AuthenticationController(UserValidationService userValidationService, IUnitOfWork unitOfWork)
        {
            this.userValidationService = userValidationService;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Login()
        {
            ViewData["CurrentController"] = "Authentication";
            ViewData["CurrentAction"] = "Login";
            return View(new LoginUserVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM loginUser)
        {
            if (ModelState.IsValid && ValidUser(loginUser))
            {
                ViewData["CurrentController"] = "Authentication";
                ViewData["CurrentAction"] = "Login";

                var user = unitOfWork.UserRepository.Get(u => loginUser.Email == u.Email);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.isAdmin ? "Admin" : "User"),
                    new Claim("UserImage", user.ImageUrl),
                    new Claim("UserId", user.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(30),
                    RedirectUri = "/Home/Index",
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            }

            return View(loginUser);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        #region METHODS
        private bool ValidUser(LoginUserVM user)
        {
            if (userValidationService.IsEmailUnique(user.Email))
            {
                ModelState.AddModelError(nameof(user.Email), "There is no user with this email");
                return false;
            }
            else if (!userValidationService.PasswordVerification(user.Password))
            {
                ModelState.AddModelError(nameof(user.Password), "Password mismatch");
                return false;
            }
            return true;
        }
        #endregion
    }
}
