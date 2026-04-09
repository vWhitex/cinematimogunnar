using CineTimo.Core.Interfaces;
using CineTimo.Core.Models;

namespace CineTimo.Core.Services;

public class FilmService : IFilmService
{
    public IEnumerable<Film> GetAll() => DataStore.Films.ToList();

    public Film? GetById(int id) => DataStore.Films.FirstOrDefault(f => f.Id == id);

    public void Add(Film film)
    {
        film.Id = DataStore.GetNextFilmId();
        DataStore.Films.Add(film);
    }

    public void Update(Film film)
    {
        var existing = DataStore.Films.FirstOrDefault(f => f.Id == film.Id);
        if (existing != null)
        {
            existing.Title = film.Title;
            existing.Description = film.Description;
            existing.DurationMinutes = film.DurationMinutes;
            existing.Genre = film.Genre;
            existing.PosterUrl = film.PosterUrl;
        }
    }

    public void Delete(int id)
    {
        var film = DataStore.Films.FirstOrDefault(f => f.Id == id);
        if (film != null)
        {
            DataStore.Films.Remove(film);
        }
    }
}
