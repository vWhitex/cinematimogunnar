using CineTimo.Core.Interfaces;
using CineTimo.Core.Models;

namespace CineTimo.Core.Services;

public class CinemaService : ICinemaService
{
    public IEnumerable<Cinema> GetAll() => DataStore.Cinemas.ToList();

    public Cinema? GetById(int id) => DataStore.Cinemas.FirstOrDefault(c => c.Id == id);

    public void Add(Cinema cinema)
    {
        cinema.Id = DataStore.GetNextCinemaId();
        DataStore.Cinemas.Add(cinema);
    }

    public void Update(Cinema cinema)
    {
        var existing = DataStore.Cinemas.FirstOrDefault(c => c.Id == cinema.Id);
        if (existing != null)
        {
            existing.Name = cinema.Name;
            existing.City = cinema.City;
        }
    }

    public void Delete(int id)
    {
        var cinema = DataStore.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema != null)
        {
            DataStore.Cinemas.Remove(cinema);
        }
    }

    public IEnumerable<string> GetAllCities() => DataStore.Cinemas.Select(c => c.City).Distinct().OrderBy(c => c).ToList();
}
