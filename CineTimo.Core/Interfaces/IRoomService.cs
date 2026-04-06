using CineTimo.Core.Models;

namespace CineTimo.Core.Interfaces;

public interface IRoomService
{
    IEnumerable<Room> GetAll();
    Room? GetById(int id);
    IEnumerable<Room> GetByCinemaId(int cinemaId);
    void Add(Room room);
    void Update(Room room);
    void Delete(int id);
}
