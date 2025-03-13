using Microsoft.AspNetCore.Mvc;

namespace StudentsMVC
{
    public class StudentController : Controller
    {
        UniversityContext db;
        public StudentController(UniversityContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = await Task.Run(() => db.Students);
            ViewBag.Students = students;
            return View();
        }
    }
}
