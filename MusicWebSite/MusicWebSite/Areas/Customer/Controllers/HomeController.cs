
using Microsoft.AspNetCore.Mvc;
using MusicWebSite.DataAcess.Repositories;
using MusicWebSite.DataAcess.Repositories.IRepository;
using MusicWebSite.Models;
using System.Diagnostics;

namespace MusicWebSite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {           
                var musicList = unitOfWork.MusicRepository.GetAll().Select(music => new Music
                {
                    Id = music.Id,
                    Title = music.Title,
                    Genre = unitOfWork.GenreRepository.Get(genre => music.GenreId == genre.Id),
                    ImageUrl = music.ImageUrl,
                    MusicUrl = music.MusicUrl
                }).ToList();

                return View(musicList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
