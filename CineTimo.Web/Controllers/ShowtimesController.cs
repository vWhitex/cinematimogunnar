using CineTimo.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CineTimo.Web.Controllers;

public class ShowtimesController : Controller
{
    private readonly IShowtimeService _showtimeService;
    private readonly IFilmService _filmService;
    private readonly ICinemaService _cinemaService;
    private readonly IRoomService _roomService;

    public ShowtimesController(
        IShowtimeService showtimeService,
        IFilmService filmService,
        ICinemaService cinemaService,
        IRoomService roomService)
    {
        _showtimeService = showtimeService;
        _filmService = filmService;
        _cinemaService = cinemaService;
        _roomService = roomService;
    }

    public IActionResult Index()
    {
        var showtimes = _showtimeService.GetAll().OrderBy(s => s.StartTime).ToList();
        var model = showtimes.Select(s => new ShowtimeViewModel
        {
            Showtime = s,
            Film = _filmService.GetById(s.FilmId),
            Room = _roomService.GetById(s.RoomId),
            Cinema = _cinemaService.GetById(_roomService.GetById(s.RoomId)?.CinemaId ?? 0)
        }).ToList();

        return View(model);
    }
}

public class ShowtimeViewModel
{
    public CineTimo.Core.Models.Showtime Showtime { get; set; } = null!;
    public CineTimo.Core.Models.Film? Film { get; set; }
    public CineTimo.Core.Models.Room? Room { get; set; }
    public CineTimo.Core.Models.Cinema? Cinema { get; set; }
}
