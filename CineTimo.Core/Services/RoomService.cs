using CineTimo.Core.Interfaces;
using CineTimo.Core.Models;

namespace CineTimo.Core.Services;

public class RoomService : IRoomService
{
    public IEnumerable<Room> GetAll() => DataStore.Rooms.ToList();

    public Room? GetById(int id) => DataStore.Rooms.FirstOrDefault(r => r.Id == id);

    public IEnumerable<Room> GetByCinemaId(int cinemaId) => DataStore.Rooms.Where(r => r.CinemaId == cinemaId).ToList();

    public void Add(Room room)
    {
        if (room.Capacity <= 0)
        {
            throw new ArgumentException("Room capacity must be a positive number.", nameof(room.Capacity));
        }

        room.Id = DataStore.GetNextRoomId();
        DataStore.Rooms.Add(room);
    }

    public void Update(Room room)
    {
        if (room.Capacity <= 0)
        {
            throw new ArgumentException("Room capacity must be a positive number.", nameof(room.Capacity));
        }

        var existing = DataStore.Rooms.FirstOrDefault(r => r.Id == room.Id);
        if (existing != null)
        {
            existing.Name = room.Name;
            existing.Capacity = room.Capacity;
            existing.CinemaId = room.CinemaId;
        }
    }

    public void Delete(int id)
    {
        var room = DataStore.Rooms.FirstOrDefault(r => r.Id == id);
        if (room != null)
        {
            DataStore.Rooms.Remove(room);
        }
    }
}
