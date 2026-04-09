using CineTimo.Core.Interfaces;
using CineTimo.Core.Models;

namespace CineTimo.Core.Services;

public class ShowtimeService : IShowtimeService
{
    private readonly ICinemaService _cinemaService;
    private readonly IRoomService _roomService;

    public ShowtimeService(ICinemaService cinemaService, IRoomService roomService)
    {
        _cinemaService = cinemaService;
        _roomService = roomService;
    }

    public IEnumerable<Showtime> GetAll() => DataStore.Showtimes.ToList();

    public Showtime? GetById(int id) => DataStore.Showtimes.FirstOrDefault(s => s.Id == id);

    public IEnumerable<Showtime> GetByFilmId(int filmId) => DataStore.Showtimes.Where(s => s.FilmId == filmId).ToList();

    public IEnumerable<Showtime> GetByCity(string city)
    {
        var cinemasInCity = _cinemaService.GetAll().Where(c => c.City == city).Select(c => c.Id).ToList();
        var roomsInCity = _roomService.GetAll().Where(r => cinemasInCity.Contains(r.CinemaId)).Select(r => r.Id).ToList();
        return DataStore.Showtimes.Where(s => roomsInCity.Contains(s.RoomId)).ToList();
    }

    public void Add(Showtime showtime)
    {
        if (showtime.StartTime < DateTime.Now)
        {
            throw new ArgumentException("Cannot add a showtime with a past date.", nameof(showtime.StartTime));
        }

        showtime.Id = DataStore.GetNextShowtimeId();
        DataStore.Showtimes.Add(showtime);
    }

    public void Update(Showtime showtime)
    {
        if (showtime.StartTime < DateTime.Now)
        {
            throw new ArgumentException("Cannot update a showtime with a past date.", nameof(showtime.StartTime));
        }

        var existing = DataStore.Showtimes.FirstOrDefault(s => s.Id == showtime.Id);
        if (existing != null)
        {
            existing.FilmId = showtime.FilmId;
            existing.RoomId = showtime.RoomId;
            existing.StartTime = showtime.StartTime;
            existing.Price = showtime.Price;
        }
    }

    public void Delete(int id)
    {
        var showtime = DataStore.Showtimes.FirstOrDefault(s => s.Id == id);
        if (showtime != null)
        {
            DataStore.Showtimes.Remove(showtime);
        }
    }
}
