using Microsoft.AspNetCore.Mvc;
using homework.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Plugins;
using homework.Repository;
using Microsoft.Win32;

namespace homework.Controllers
{
    public class AccountController : Controller
    {
        IRepository repository;
        private readonly GuestBookContext _context;

        public AccountController(IRepository r, GuestBookContext context) {
            repository = r;
            _context = context;
        }

        public async Task<IActionResult> Index() {
            IEnumerable<Messages> messages = await Task.Run(() => _context.Messages);
            ViewBag.Messages = messages;
            return View();
        }

        // GET: Account/Register
        public IActionResult Register() {
            return View();
        }
        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model) {
            if (ModelState.IsValid) {
                byte[] saltbuf = new byte[16];

                RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                randomNumberGenerator.GetBytes(saltbuf);

                StringBuilder sb = new StringBuilder(16);
                for (int i = 0; i < 16; i++)
                    sb.Append(string.Format("{0:X2}", saltbuf[i]));
                string salt = sb.ToString();

                byte[] password = Encoding.Unicode.GetBytes(salt + model.Password);

                var md5 = MD5.Create();

                byte[] byteHash = md5.ComputeHash(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                Users user = new Users {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Login = model.Login,
                    Password = salt + hash.ToString()
                };

                Console.WriteLine($"reg: {salt + hash.ToString()}");

                await repository.Create(user);
                await repository.Save();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: Account/Login
        public IActionResult Login() {
            return View();
        }
        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model) {
            if (ModelState.IsValid) {
                var user = await repository.GetUserByLogin(model.Login);
                
                if (user == null) {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(model);
                }

                string storedHash = user.Password;
                string salt = storedHash.Substring(0, 32);
                byte[] passwordBytes = Encoding.Unicode.GetBytes(salt + model.Password);
                byte[] computedHash = MD5.Create().ComputeHash(passwordBytes);
                
                StringBuilder hashBuilder = new StringBuilder();
                foreach (var b in computedHash)
                    hashBuilder.Append(b.ToString("X2"));
                
                Console.WriteLine($"log: {hashBuilder.ToString()}");
                Console.WriteLine($"reg: {storedHash.Substring(32)}");

                if (hashBuilder.ToString() != storedHash.Substring(32)) {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(model);
                }
                
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Append("login", model.Login, option);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
