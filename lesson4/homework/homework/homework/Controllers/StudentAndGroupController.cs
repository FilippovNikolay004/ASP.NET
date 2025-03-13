using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsMVC;

namespace homework.Controllers
{
    public class StudentAndGroupController : Controller
    {
        UniversityContext db;

        public StudentAndGroupController(UniversityContext context) {
            db = context;
        }

        public async Task<IActionResult> Index() {
            var students = await db.Students.Include(s => s.Groups).ToListAsync();
            ViewBag.Students = students;
            return View();
        }
    }
}
