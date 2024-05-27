using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.Models;
using MusicWEB.Models.ViewModels;
using MusicWEB.Utility;
using System.Security.Claims;

namespace MusicWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMusicSearchService searchService;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor, IMusicSearchService searchService)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this.searchService = searchService;
        }

        public IActionResult Index()
        {
            ViewData["CurrentController"] = "Home";
            ViewData["CurrentAction"] = "Index";

            var musicList = unitOfWork.MusicRepository.GetAll().ToList().Select(music => new Music
            {
                Id = music.Id,
                Title = music.Title,
                Genre = unitOfWork.GenreRepository.Get(genre => music.GenreId == genre.Id),
                ImageUrl = music.ImageUrl,
                MusicUrl = music.MusicUrl
            }).ToList();

            var genersList = unitOfWork.GenreRepository.GetAll().ToList();

            Music_GenreVM music_genres = new Music_GenreVM
            {
                Music = musicList,
                Genres = genersList
            };

            return View(music_genres);
        }

        [HttpGet]
        public IActionResult Search(string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var genersList = unitOfWork.GenreRepository.GetAll().ToList();

                Music_GenreVM music_genres = new Music_GenreVM
                {
                    Music = searchService.Search(searchQuery).ToList(),
                    Genres = genersList
                };

                return View("Index", music_genres);
            }
            return Index();
        }

        [HttpPost]
        public IActionResult AddMusicPlayList(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var user = unitOfWork.UserRepository.Get(user => user.Email == httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email));

                if(unitOfWork.UserMusicRepository
                    .GetAll()
                    .Include(music => music.Music)
                    .FirstOrDefault(music => music.MusicId == id && music.UserId == user.Id) == null)
                {
                    user.UserMusic = new List<UserMusic>()
                    {
                        new UserMusic()
                        {
                            MusicId = id,
                            UserId = user.Id
                        }
                    };

                    unitOfWork.UserRepository.Update(user);
                    unitOfWork.Save();
                }
                else
                    return Json(new { success = false, message = "Музыка уже есть в плейлисте" });
            }
            else
            {
                return Json(new { success = false, message = "Создайте аккаунт для добавления музыки в плейлист" });
            }

            return Json(new { success = true, message = "Музыка успешно добавлена в плейлист." });
        }

        public IActionResult Privacy()
        {
            return View();
        }        
    }
}
