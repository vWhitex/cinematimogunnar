using CineTimo.Core.Models;

namespace CineTimo.Core.Interfaces;

public interface ICinemaService
{
    IEnumerable<Cinema> GetAll();
    Cinema? GetById(int id);
    void Add(Cinema cinema);
    void Update(Cinema cinema);
    void Delete(int id);
    IEnumerable<string> GetAllCities();
}
