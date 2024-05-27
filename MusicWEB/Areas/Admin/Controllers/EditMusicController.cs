using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.Models;
using MusicWEB.Models.ViewModels;
using MusicWEB.Utility;

namespace MusicWEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EditMusicController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileServices fileServices;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMusicSearchService musicSearchService;

        public EditMusicController(IUnitOfWork unitOfWork, IFileServices fileServices,
            IWebHostEnvironment webHostEnvironment, IMusicSearchService searchService)
        { 
            this.unitOfWork = unitOfWork;
            this.fileServices = fileServices;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult MusicList()
        {
            var musicList = unitOfWork.MusicRepository.GetAll().ToList().Select(music => new Music
            {
                Id = music.Id,
                Title = music.Title,
                Genre = unitOfWork.GenreRepository.Get(genre => music.GenreId == genre.Id),
                ImageUrl = music.ImageUrl,
                MusicUrl = music.MusicUrl
            });

            return View(musicList);
        }

        [HttpGet]
        public IActionResult Search(string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                return View("Index", musicSearchService.Search(searchQuery));
            }
            return View("Index", unitOfWork.MusicRepository.GetAll().ToList());
        }

        [HttpPost]
        public IActionResult DeleteMusic(int? id)
        {
            Music music = unitOfWork.MusicRepository.Get(item => item.Id == id);
            unitOfWork.MusicRepository.Remove(music);
            fileServices.DeleteFile(Path.Combine(webHostEnvironment.WebRootPath, music.ImageUrl.TrimStart('/')));
            fileServices.DeleteFile(Path.Combine(webHostEnvironment.WebRootPath, music.MusicUrl.TrimStart('/')));
            unitOfWork.Save();
            return Ok();
        }

        public IActionResult Add_EditMusic(int? id = null)
        {
            return View(CategoriMusic(id));
        }

        [HttpPost]
        public IActionResult Create(MusicVM obj, IFormFile? imageFile, IFormFile? audioFile)
        {
            string imageError = null;
            string audioError = null;

            if (!ModelState.IsValid)
            {
                obj.CategoryList = unitOfWork.GenreRepository.GetAll()
                        .Select(item => new SelectListItem()
                        {
                            Text = item.Name,
                            Value = item.Id.ToString()
                        });

                return View("Add_EditMusic", obj);
            }

            if (!IsValidFile(audioFile, imageFile, obj.Music, out imageError,out audioError))
            {
                obj.ErrorMessageForImage = imageError;
                obj.ErrorMessageForAudio = audioError;
                obj.CategoryList = unitOfWork.GenreRepository.GetAll()
                        .Select(item => new SelectListItem()
                        {
                            Text = item.Name,
                            Value = item.Id.ToString()
                        });

                return View("Add_EditMusic", obj);
            }

            obj.Music.ImageUrl = fileServices.SaveFile(imageFile, obj.Music.ImageUrl, "image");
            obj.Music.MusicUrl = fileServices.SaveFile(audioFile, obj.Music.MusicUrl, "audio");
            unitOfWork.MusicRepository.Update(obj.Music);
            unitOfWork.Save();
            return RedirectToAction("MusicList");
        }

        #region METHODS

        private bool IsValidFile(IFormFile? audioFile, IFormFile? imageFile, Music music, out string errorImageMessage, out string errorAudioMessage)
        {
            errorImageMessage = null;
            errorAudioMessage = null;

            if(audioFile != null && !audioFile.ContentType.StartsWith("audio") || music.Id == 0 && audioFile == null) 
            {
                errorAudioMessage = "Please upload a valid audio file.";
                return false;
            }

            if (imageFile != null && !imageFile.ContentType.StartsWith("image") || music.Id == 0 && imageFile == null)
            {
                errorImageMessage = "Please upload a valid image file.";
                return false;
            }

            return true;
        }


        private MusicVM CategoriMusic(int? id)
        {
            MusicVM musicVM = new MusicVM()
            {
                CategoryList =
                unitOfWork.GenreRepository.GetAll().Select(item => new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }),
                Music = id == null ? new Music() : unitOfWork.MusicRepository.Get(item => item.Id == id)
            };
            return musicVM;
        }
        #endregion
    }
}
