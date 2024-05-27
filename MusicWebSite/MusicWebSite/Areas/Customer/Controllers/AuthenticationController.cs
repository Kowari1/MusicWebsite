using Microsoft.AspNetCore.Mvc;
using MusicWebSite.Models;

namespace MusicWebSite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View(new User());
        }
    }
}
