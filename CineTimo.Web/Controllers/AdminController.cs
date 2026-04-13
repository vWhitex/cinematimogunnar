using CineTimo.Core.Interfaces;
using CineTimo.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineTimo.Web.Controllers;

public class AdminController : Controller
{
    private readonly IFilmService _filmService;
    private readonly ICinemaService _cinemaService;
    private readonly IRoomService _roomService;
    private readonly IShowtimeService _showtimeService;

    public AdminController(
        IFilmService filmService,
        ICinemaService cinemaService,
        IRoomService roomService,
        IShowtimeService showtimeService)
    {
        _filmService = filmService;
        _cinemaService = cinemaService;
        _roomService = roomService;
        _showtimeService = showtimeService;
    }

    public IActionResult Index()
    {
        ViewBag.FilmCount = _filmService.GetAll().Count();
        ViewBag.CinemaCount = _cinemaService.GetAll().Count();
        ViewBag.RoomCount = _roomService.GetAll().Count();
        ViewBag.ShowtimeCount = _showtimeService.GetAll().Count();
        return View();
    }

    #region Films
    public IActionResult Films() => View(_filmService.GetAll().ToList());

    public IActionResult CreateFilm() => View();

    [HttpPost]
    public IActionResult CreateFilm(Film film)
    {
        if (ModelState.IsValid)
        {
            _filmService.Add(film);
            return RedirectToAction(nameof(Films));
        }
        return View(film);
    }

    public IActionResult EditFilm(int id)
    {
        var film = _filmService.GetById(id);
        if (film == null) return NotFound();
        return View(film);
    }

    [HttpPost]
    public IActionResult EditFilm(int id, Film film)
    {
        if (ModelState.IsValid)
        {
            _filmService.Update(film);
            return RedirectToAction(nameof(Films));
        }
        return View(film);
    }

    public IActionResult DeleteFilm(int id)
    {
        _filmService.Delete(id);
        return RedirectToAction(nameof(Films));
    }
    #endregion

    #region Cinemas
    public IActionResult Cinemas() => View(_cinemaService.GetAll().ToList());

    public IActionResult CreateCinema() => View();

    [HttpPost]
    public IActionResult CreateCinema(Cinema cinema)
    {
        if (ModelState.IsValid)
        {
            _cinemaService.Add(cinema);
            return RedirectToAction(nameof(Cinemas));
        }
        return View(cinema);
    }

    public IActionResult EditCinema(int id)
    {
        var cinema = _cinemaService.GetById(id);
        if (cinema == null) return NotFound();
        return View(cinema);
    }

    [HttpPost]
    public IActionResult EditCinema(int id, Cinema cinema)
    {
        if (ModelState.IsValid)
        {
            _cinemaService.Update(cinema);
            return RedirectToAction(nameof(Cinemas));
        }
        return View(cinema);
    }

    public IActionResult DeleteCinema(int id)
    {
        _cinemaService.Delete(id);
        return RedirectToAction(nameof(Cinemas));
    }
    #endregion

    #region Rooms
    public IActionResult Rooms()
    {
        var rooms = _roomService.GetAll().ToList();
        var model = rooms.Select(r => new RoomViewModel
        {
            Room = r,
            Cinema = _cinemaService.GetById(r.CinemaId)
        }).ToList();
        return View(model);
    }

    public IActionResult CreateRoom()
    {
        ViewBag.Cinemas = _cinemaService.GetAll().ToList();
        return View();
    }

    [HttpPost]
    public IActionResult CreateRoom(Room room)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _roomService.Add(room);
                return RedirectToAction(nameof(Rooms));
            }
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(nameof(room.Capacity), ex.Message);
        }
        ViewBag.Cinemas = _cinemaService.GetAll().ToList();
        return View(room);
    }

    public IActionResult EditRoom(int id)
    {
        var room = _roomService.GetById(id);
        if (room == null) return NotFound();
        ViewBag.Cinemas = _cinemaService.GetAll().ToList();
        return View(room);
    }

    [HttpPost]
    public IActionResult EditRoom(int id, Room room)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _roomService.Update(room);
                return RedirectToAction(nameof(Rooms));
            }
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(nameof(room.Capacity), ex.Message);
        }
        ViewBag.Cinemas = _cinemaService.GetAll().ToList();
        return View(room);
    }

    public IActionResult DeleteRoom(int id)
    {
        _roomService.Delete(id);
        return RedirectToAction(nameof(Rooms));
    }
    #endregion

    #region Showtimes
    public IActionResult Showtimes()
    {
        var showtimes = _showtimeService.GetAll().OrderBy(s => s.StartTime).ToList();
        var model = showtimes.Select(s => new AdminShowtimeViewModel
        {
            Showtime = s,
            Film = _filmService.GetById(s.FilmId),
            Room = _roomService.GetById(s.RoomId),
            Cinema = _cinemaService.GetById(_roomService.GetById(s.RoomId)?.CinemaId ?? 0)
        }).ToList();
        return View(model);
    }

    public IActionResult CreateShowtime()
    {
        ViewBag.Films = _filmService.GetAll().ToList();
        ViewBag.Rooms = _roomService.GetAll().ToList();
        return View();
    }

    [HttpPost]
    public IActionResult CreateShowtime(Showtime showtime)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _showtimeService.Add(showtime);
                return RedirectToAction(nameof(Showtimes));
            }
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(nameof(showtime.StartTime), ex.Message);
        }
        ViewBag.Films = _filmService.GetAll().ToList();
        ViewBag.Rooms = _roomService.GetAll().ToList();
        return View(showtime);
    }

    public IActionResult EditShowtime(int id)
    {
        var showtime = _showtimeService.GetById(id);
        if (showtime == null) return NotFound();
        ViewBag.Films = _filmService.GetAll().ToList();
        ViewBag.Rooms = _roomService.GetAll().ToList();
        return View(showtime);
    }

    [HttpPost]
    public IActionResult EditShowtime(int id, Showtime showtime)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _showtimeService.Update(showtime);
                return RedirectToAction(nameof(Showtimes));
            }
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(nameof(showtime.StartTime), ex.Message);
        }
        ViewBag.Films = _filmService.GetAll().ToList();
        ViewBag.Rooms = _roomService.GetAll().ToList();
        return View(showtime);
    }

    public IActionResult DeleteShowtime(int id)
    {
        _showtimeService.Delete(id);
        return RedirectToAction(nameof(Showtimes));
    }
    #endregion
}

public class RoomViewModel
{
    public Room Room { get; set; } = null!;
    public Cinema? Cinema { get; set; }
}

public class AdminShowtimeViewModel
{
    public Showtime Showtime { get; set; } = null!;
    public Film? Film { get; set; }
    public Room? Room { get; set; }
    public Cinema? Cinema { get; set; }
}
