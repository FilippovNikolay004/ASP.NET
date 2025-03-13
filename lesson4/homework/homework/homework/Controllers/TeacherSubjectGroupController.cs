using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsMVC;

namespace homework.Controllers
{
    public class TeacherSubjectGroupController : Controller
    {
        UniversityContext db;

        public TeacherSubjectGroupController(UniversityContext context) {
            db = context;
        }

        public async Task<IActionResult> Index() {
            var TSG = await db.TeacherSubjectGroups
                .Include(tsg => tsg.Teacher)
                .Include(tsg => tsg.Subject)
                .Include(tsg => tsg.Group)
                .ToListAsync();
            ViewBag.TSG = TSG;
            return View();
        }
    }
}
