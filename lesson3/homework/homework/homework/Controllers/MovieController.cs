using homework.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework.Controllers
{
    public class MovieController : Controller
    {
        MoviesContext db;
        public MovieController(MoviesContext context) {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Movies> movies = await Task.Run(() => db.Movies);
            ViewBag.Movies = movies;
            return View();
        }
    }
}
