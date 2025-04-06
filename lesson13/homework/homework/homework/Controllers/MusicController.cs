using Microsoft.AspNetCore.Mvc;
using MusicPortal.BLL.Interfaces;

namespace homework.Controllers
{
    public class MusicController : Controller {
        private readonly IGenreService _genreService;
        private readonly IMusicService _musicService;
        private readonly IUserService _userService;

        public MusicController(IGenreService genreService, IMusicService musicService, IUserService userService) {
            _genreService = genreService;
            _musicService = musicService;
            _userService = userService;
        }

        // GET: Music
        public async Task<IActionResult> Index() {
            return View(await _musicService.GetAllMusics());
        }
    }
}
