using CineTimo.Core.Models;

namespace CineTimo.Core.Interfaces;

public interface IFilmService
{
    IEnumerable<Film> GetAll();
    Film? GetById(int id);
    void Add(Film film);
    void Update(Film film);
    void Delete(int id);
}
