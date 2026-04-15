using CineTimo.Core.Interfaces;
using CineTimo.Core.Models;
using CineTimo.Core.Services;
using Xunit;

namespace CineTimo.Tests;

public class FilmServiceTests
{
    private readonly FilmService _filmService;

    public FilmServiceTests()
    {
        _filmService = new FilmService();
    }

    [Fact]
    public void GetAll_ReturnsAllFilms()
    {
        // Act
        var films = _filmService.GetAll().ToList();

        // Assert
        Assert.NotNull(films);
        Assert.True(films.Count >= 8, $"Expected at least 8 films, got {films.Count}");
    }

    [Fact]
    public void GetById_ReturnsCorrectFilm()
    {
        // Act
        var film = _filmService.GetById(1);

        // Assert
        Assert.NotNull(film);
        Assert.Equal("Oppenheimer", film.Title);
    }

    [Fact]
    public void GetById_ReturnsNull_ForNonExistentFilm()
    {
        // Act
        var film = _filmService.GetById(999);

        // Assert
        Assert.Null(film);
    }

    [Fact]
    public void Add_AddsNewFilm()
    {
        // Arrange
        var newFilm = new Film
        {
            Title = "Test Film",
            Description = "Test Description",
            DurationMinutes = 120,
            Genre = "Test"
        };

        // Act
        _filmService.Add(newFilm);

        // Assert
        var films = _filmService.GetAll().ToList();
        Assert.Equal(9, films.Count);
        var addedFilm = films.FirstOrDefault(f => f.Title == "Test Film");
        Assert.NotNull(addedFilm);
    }

    [Fact]
    public void Update_UpdatesExistingFilm()
    {
        // Arrange
        var film = _filmService.GetById(1);
        Assert.NotNull(film);
        var originalTitle = film.Title;

        // Act
        film.Title = "Updated Title";
        _filmService.Update(film);

        // Assert
        var updatedFilm = _filmService.GetById(1);
        Assert.NotNull(updatedFilm);
        Assert.Equal("Updated Title", updatedFilm.Title);

        // Cleanup - restore original
        film.Title = originalTitle;
        _filmService.Update(film);
    }

    [Fact]
    public void Delete_RemovesFilm()
    {
        // Arrange
        var newFilm = new Film
        {
            Title = "Film To Delete",
            Description = "Will be deleted",
            DurationMinutes = 100,
            Genre = "Test"
        };
        _filmService.Add(newFilm);
        var filmId = newFilm.Id;

        // Act
        _filmService.Delete(filmId);

        // Assert
        var deletedFilm = _filmService.GetById(filmId);
        Assert.Null(deletedFilm);
    }
}
