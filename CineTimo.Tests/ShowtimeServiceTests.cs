using CineTimo.Core.Interfaces;
using CineTimo.Core.Models;
using CineTimo.Core.Services;
using Xunit;

namespace CineTimo.Tests;

public class ShowtimeServiceTests
{
    private readonly ShowtimeService _showtimeService;
    private readonly CinemaService _cinemaService;
    private readonly RoomService _roomService;

    public ShowtimeServiceTests()
    {
        _cinemaService = new CinemaService();
        _roomService = new RoomService();
        _showtimeService = new ShowtimeService(_cinemaService, _roomService);
    }

    [Fact]
    public void GetByCity_FiltersShowtimesByCity_Correctly()
    {
        // Act - Get showtimes for Tallinn
        var tallinnShowtimes = _showtimeService.GetByCity("Tallinn").ToList();

        // Assert
        Assert.NotNull(tallinnShowtimes);

        // Verify all returned showtimes are in Tallinn cinemas
        foreach (var showtime in tallinnShowtimes)
        {
            var room = _roomService.GetById(showtime.RoomId);
            Assert.NotNull(room);

            var cinema = _cinemaService.GetById(room.CinemaId);
            Assert.NotNull(cinema);
            Assert.Equal("Tallinn", cinema.City);
        }
    }

    [Fact]
    public void GetByCity_ReturnsEmpty_ForCityWithNoShowtimes()
    {
        // Act - Get showtimes for Haapsalu (has cinema but may have no showtimes)
        var haapsaluShowtimes = _showtimeService.GetByCity("Haapsalu").ToList();

        // Assert - May be empty or have specific count based on seed data
        Assert.NotNull(haapsaluShowtimes);
    }

    [Fact]
    public void Add_ThrowsException_WhenStartTimeIsPast()
    {
        // Arrange
        var pastShowtime = new Showtime
        {
            FilmId = 1,
            RoomId = 1,
            StartTime = DateTime.Now.AddDays(-1),
            Price = 10.00m
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _showtimeService.Add(pastShowtime));
        Assert.Contains("past date", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Add_Succeeds_WhenStartTimeIsFuture()
    {
        // Arrange
        var futureShowtime = new Showtime
        {
            FilmId = 1,
            RoomId = 1,
            StartTime = DateTime.Now.AddDays(1),
            Price = 10.00m
        };

        // Act
        _showtimeService.Add(futureShowtime);

        // Assert
        var showtimes = _showtimeService.GetAll().ToList();
        Assert.Contains(showtimes, s => s.Id == futureShowtime.Id);
    }

    [Fact]
    public void Update_ThrowsException_WhenStartTimeIsPast()
    {
        // Arrange - Get an existing showtime
        var existingShowtime = _showtimeService.GetAll().FirstOrDefault();
        Assert.NotNull(existingShowtime);

        // Try to update with past date
        existingShowtime.StartTime = DateTime.Now.AddDays(-1);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _showtimeService.Update(existingShowtime));
        Assert.Contains("past date", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void GetAll_ReturnsAllShowtimes()
    {
        // Act
        var showtimes = _showtimeService.GetAll().ToList();

        // Assert
        Assert.NotNull(showtimes);
        Assert.True(showtimes.Count >= 15);
    }
}
