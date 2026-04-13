using Microsoft.AspNetCore.Mvc;
using CineTimo.Core.Interfaces;

namespace CineTimo.Web.Controllers;

public class HomeController : Controller
{
    private readonly IFilmService _filmService;

    public HomeController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    public IActionResult Index()
    {
        var films = _filmService.GetAll();
        return View(films);
    }

    public IActionResult Details(int id)
    {
        var film = _filmService.GetById(id);
        if (film == null)
            return NotFound();
        return View(film);
    }

    public IActionResult Error()
    {
        return View();
    }
}
