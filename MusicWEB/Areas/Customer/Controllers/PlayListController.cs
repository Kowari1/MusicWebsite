using Microsoft.AspNetCore.Mvc;
using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using MusicWEB.Utility;

namespace MusicWEB.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class PlaylistController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public PlaylistController(IUnitOfWork unitOfWork)
        { 
            this.unitOfWork = unitOfWork;
        }

        public IActionResult PlayList()
        {
            ViewData["CurrentController"] = "PlayList";
            ViewData["CurrentAction"] = "PlayList";

            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                var musicList = unitOfWork.UserMusicRepository.GetAll()
                    .Include(music => music.Music)
                    .ToList()
                    .Where(music => music.UserId == userId)
                    .Select(music => new Music
                {
                    Id = music.Music.Id,
                    Title = music.Music.Title,
                    Genre = unitOfWork.GenreRepository.Get(genre => music.Music.GenreId == genre.Id),
                    ImageUrl = music.Music.ImageUrl,
                    MusicUrl = music.Music.MusicUrl
                }).ToList();

                return View(musicList);
            }

            return View("Создайте аккаунт");
        }

        [HttpPost]
        public IActionResult DeleteMusic(int? id)
        {
            var music = unitOfWork.UserMusicRepository.Get(music => music.MusicId == id);
            unitOfWork.UserMusicRepository.Remove(music);
            unitOfWork.Save();
            return Ok();
        }
    }
}
