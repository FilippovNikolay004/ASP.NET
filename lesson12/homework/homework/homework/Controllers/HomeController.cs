using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using homework.Models;
using homework.Services;

namespace homework.Controllers;

public class HomeController : Controller
{
    INoteService _noteService;
    public HomeController(INoteService noteService) {
        _noteService = noteService;
    }

    // GET: Home
    public async Task<IActionResult> Index() {
        return View(_noteService.LoadAll());
    }

    // GET: Home/Create
    public async Task<IActionResult> Create() {
        return View();
    }
    // POST: Home
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Note note) {
        _noteService.Save(note);
        return RedirectToAction("Index");
    }
}
