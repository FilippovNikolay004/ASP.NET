using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
