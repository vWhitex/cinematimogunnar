using CineTimo.Core.Models;
using CineTimo.Core.Services;
using Xunit;

namespace CineTimo.Tests;

public class RoomServiceTests
{
    private readonly RoomService _roomService;

    public RoomServiceTests()
    {
        _roomService = new RoomService();
    }

    [Fact]
    public void Add_ThrowsException_WhenCapacityIsZero()
    {
        // Arrange
        var room = new Room
        {
            Name = "Test Room",
            Capacity = 0,
            CinemaId = 1
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _roomService.Add(room));
        Assert.Contains("positive", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Add_ThrowsException_WhenCapacityIsNegative()
    {
        // Arrange
        var room = new Room
        {
            Name = "Test Room",
            Capacity = -10,
            CinemaId = 1
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _roomService.Add(room));
        Assert.Contains("positive", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Add_Succeeds_WhenCapacityIsPositive()
    {
        // Arrange
        var room = new Room
        {
            Name = "Valid Room",
            Capacity = 100,
            CinemaId = 1
        };

        // Act
        _roomService.Add(room);

        // Assert
        var rooms = _roomService.GetAll().ToList();
        Assert.Contains(rooms, r => r.Id == room.Id);
    }

    [Fact]
    public void Update_ThrowsException_WhenCapacityIsZero()
    {
        // Arrange - Get existing room
        var room = _roomService.GetAll().FirstOrDefault();
        Assert.NotNull(room);

        // Try to update with zero capacity
        room.Capacity = 0;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _roomService.Update(room));
        Assert.Contains("positive", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Update_ThrowsException_WhenCapacityIsNegative()
    {
        // Arrange - Get existing room
        var room = _roomService.GetAll().FirstOrDefault();
        Assert.NotNull(room);

        // Try to update with negative capacity
        room.Capacity = -50;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _roomService.Update(room));
        Assert.Contains("positive", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void GetByCinemaId_ReturnsOnlyRoomsForCinema()
    {
        // Act - Get rooms for cinema 1 (Kosmos in Tallinn)
        var rooms = _roomService.GetByCinemaId(1).ToList();

        // Assert
        Assert.NotNull(rooms);
        foreach (var room in rooms)
        {
            Assert.Equal(1, room.CinemaId);
        }
    }

    [Fact]
    public void GetAll_ReturnsAllRooms()
    {
        // Act
        var rooms = _roomService.GetAll().ToList();

        // Assert
        Assert.NotNull(rooms);
        Assert.True(rooms.Count >= 12); // We have 12 rooms seeded
    }

    [Fact]
    public void Delete_RemovesRoom()
    {
        // Arrange - Add a room first
        var room = new Room
        {
            Name = "Room to Delete",
            Capacity = 50,
            CinemaId = 1
        };
        _roomService.Add(room);
        var roomId = room.Id;

        // Act
        _roomService.Delete(roomId);

        // Assert
        var deletedRoom = _roomService.GetById(roomId);
        Assert.Null(deletedRoom);
    }
}
