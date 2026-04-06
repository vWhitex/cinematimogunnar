using CineTimo.Core.Models;

namespace CineTimo.Core.Interfaces;

public interface IShowtimeService
{
    IEnumerable<Showtime> GetAll();
    Showtime? GetById(int id);
    IEnumerable<Showtime> GetByFilmId(int filmId);
    IEnumerable<Showtime> GetByCity(string city);
    void Add(Showtime showtime);
    void Update(Showtime showtime);
    void Delete(int id);
}
