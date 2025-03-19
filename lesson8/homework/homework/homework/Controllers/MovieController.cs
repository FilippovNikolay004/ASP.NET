using homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace homework.Controllers
{
    public class MovieController : Controller
    {
        MoviesContext db;
        IWebHostEnvironment _appEnvironment;

        public MovieController(MoviesContext context, IWebHostEnvironment appEnvironment) {
            db = context;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index() {
            IEnumerable<Movies> movies = await Task.Run(() => db.Movies);
            ViewBag.Movies = movies;
            return View();
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var student = await db.Movies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) {
                return NotFound();
            }

            return View(student);
        }

        // GET: Movie/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MoveName,Director,Genre,ReleaseYear,ShortDescription")] Movies movies, IFormFile uploadedFile) {
            string fileName = uploadedFile.FileName;
            string path = "/Files/";

            movies.FileName = fileName;
            movies.Path = path;

            Console.WriteLine($"TEXT OBJ: {movies.FileName} - {movies.Path}");

            if (ModelState.IsValid) {
                if (uploadedFile != null) {

                    Console.WriteLine($"TEXT: {fileName} - {path}");

                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path + fileName, FileMode.Create)) {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    // Добавляем фильм в базу данных
                    db.Movies.Add(movies);
                    await db.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(movies);
        }


        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var student = await db.Movies.FindAsync(id);
            if (student == null) {
                return NotFound();
            }
            return View(student);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MoveName,Director,Genre,ReleaseYear,ShortDescription")] Movies movies, IFormFile uploadedFile) {
            if (id != movies.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    if (uploadedFile != null) {
                        string fileName = uploadedFile.FileName;
                        string path = "/Files/";

                        movies.FileName = fileName;
                        movies.Path = path;

                        Console.WriteLine($"\n\n\nTEXT: {fileName} - {path}\n\n\n");

                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path + fileName, FileMode.Create)) {
                            await uploadedFile.CopyToAsync(fileStream);
                        }
                    }

                    db.Update(movies);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!StudentExists(movies.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movies);
        }
        private bool StudentExists(int id) {
            return db.Movies.Any(e => e.Id == id);
        }


        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var student = await db.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null) {
                return NotFound();
            }

            return View(student);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var student = await db.Movies.FindAsync(id);
            if (student != null) {
                db.Movies.Remove(student);
            }

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
