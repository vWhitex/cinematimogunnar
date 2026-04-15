using CineTimo.Core.Services;
using Xunit;

namespace CineTimo.Tests;

public class CinemaServiceTests
{
    private readonly CinemaService _cinemaService;

    public CinemaServiceTests()
    {
        _cinemaService = new CinemaService();
    }

    [Fact]
    public void GetAll_ReturnsAllCinemas()
    {
        // Act
        var cinemas = _cinemaService.GetAll().ToList();

        // Assert
        Assert.NotNull(cinemas);
        Assert.True(cinemas.Count >= 5);
    }

    [Fact]
    public void GetAllCities_ReturnsDistinctCities()
    {
        // Act
        var cities = _cinemaService.GetAllCities().ToList();

        // Assert
        Assert.NotNull(cities);
        Assert.Contains("Tallinn", cities);
        Assert.Contains("Tartu", cities);
        Assert.Contains("Pärnu", cities);
        Assert.Contains("Haapsalu", cities);
        Assert.Contains("Narva", cities);
    }

    [Fact]
    public void GetById_ReturnsCorrectCinema()
    {
        // Act
        var cinema = _cinemaService.GetById(1);

        // Assert
        Assert.NotNull(cinema);
        Assert.Equal("Kosmos", cinema.Name);
        Assert.Equal("Tallinn", cinema.City);
    }

    [Fact]
    public void GetById_ReturnsNull_ForNonExistentCinema()
    {
        // Act
        var cinema = _cinemaService.GetById(999);

        // Assert
        Assert.Null(cinema);
    }
}
