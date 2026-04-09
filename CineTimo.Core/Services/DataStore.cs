using CineTimo.Core.Models;

namespace CineTimo.Core.Services;

public static class DataStore
{
    public static List<Film> Films { get; set; } = new()
    {
        new Film { Id = 1, Title = "Oppenheimer", Description = "The story of American scientist J. Robert Oppenheimer and his role in the development of the atomic bomb.", DurationMinutes = 180, Genre = "Biography/Drama", PosterUrl = "https://placehold.co/300x450/1a1a2e/eee?text=Oppenheimer" },
        new Film { Id = 2, Title = "Barbie", Description = "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.", DurationMinutes = 114, Genre = "Comedy/Fantasy", PosterUrl = "https://placehold.co/300x450/ff69b4/eee?text=Barbie" },
        new Film { Id = 3, Title = "Dune: Part Two", Description = "Paul Atreides unites with Chani and the Fremen while on a warpath of revenge against the conspirators who destroyed his family.", DurationMinutes = 166, Genre = "Sci-Fi/Adventure", PosterUrl = "https://placehold.co/300x450/c4a574/111?text=Dune+2" },
        new Film { Id = 4, Title = "The Batman", Description = "When a sadistic serial killer begins murdering key political figures in Gotham, Batman is forced to investigate the city's hidden corruption.", DurationMinutes = 176, Genre = "Action/Crime", PosterUrl = "https://placehold.co/300x450/8b0000/eee?text=The+Batman" },
        new Film { Id = 5, Title = "Spider-Man: Across the Spider-Verse", Description = "Miles Morales catapults across the Multiverse, where he encounters a team of Spider-People charged with protecting its very existence.", DurationMinutes = 140, Genre = "Animation/Action", PosterUrl = "https://placehold.co/300x450/ff0000/eee?text=Spider-Verse" },
        new Film { Id = 6, Title = "Poor Things", Description = "The incredible tale about the fantastical evolution of Bella Baxter, a young woman brought back to life by the brilliant and unorthodox scientist Dr. Godwin Baxter.", DurationMinutes = 141, Genre = "Comedy/Drama", PosterUrl = "https://placehold.co/300x450/ff69b4/111?text=Poor+Things" },
        new Film { Id = 7, Title = "Killers of the Flower Moon", Description = "When oil is discovered in 1920s Oklahoma under Osage Nation land, the Osage people are murdered one by one - until the FBI steps in to unravel the mystery.", DurationMinutes = 206, Genre = "Crime/Drama", PosterUrl = "https://placehold.co/300x450/2f4f4f/eee?text=Flower+Moon" },
        new Film { Id = 8, Title = "The Holdovers", Description = "A curmudgeonly instructor at a New England prep school is forced to remain on campus during Christmas break to babysit a handful of students with nowhere to go.", DurationMinutes = 133, Genre = "Comedy/Drama", PosterUrl = "https://placehold.co/300x450/228b22/eee?text=Holdovers" }
    };

    public static List<Cinema> Cinemas { get; set; } = new()
    {
        new Cinema { Id = 1, Name = "Kosmos", City = "Tallinn" },
        new Cinema { Id = 2, Name = "Taevas", City = "Tallinn" },
        new Cinema { Id = 3, Name = "Athena", City = "Tartu" },
        new Cinema { Id = 4, Name = "Galerii", City = "Pärnu" },
        new Cinema { Id = 5, Name = "Kino Ilon", City = "Haapsalu" },
        new Cinema { Id = 6, Name = "Kino Narva", City = "Narva" }
    };

    public static List<Room> Rooms { get; set; } = new()
    {
        new Room { Id = 1, Name = "Hall 1", Capacity = 150, CinemaId = 1 },
        new Room { Id = 2, Name = "Hall 2", Capacity = 80, CinemaId = 1 },
        new Room { Id = 3, Name = "Large Hall", Capacity = 200, CinemaId = 2 },
        new Room { Id = 4, Name = "VIP Hall", Capacity = 50, CinemaId = 2 },
        new Room { Id = 5, Name = "Main Hall", Capacity = 180, CinemaId = 3 },
        new Room { Id = 6, Name = "Small Hall", Capacity = 60, CinemaId = 3 },
        new Room { Id = 7, Name = "Hall A", Capacity = 120, CinemaId = 4 },
        new Room { Id = 8, Name = "Hall B", Capacity = 90, CinemaId = 4 },
        new Room { Id = 9, Name = "Screen 1", Capacity = 100, CinemaId = 5 },
        new Room { Id = 10, Name = "Screen 2", Capacity = 70, CinemaId = 5 },
        new Room { Id = 11, Name = "Main Screen", Capacity = 140, CinemaId = 6 },
        new Room { Id = 12, Name = "Studio", Capacity = 45, CinemaId = 6 }
    };

    public static List<Showtime> Showtimes { get; set; } = new()
    {
        new Showtime { Id = 1, FilmId = 1, RoomId = 1, StartTime = DateTime.Today.AddDays(1).AddHours(18), Price = 12.00m },
        new Showtime { Id = 2, FilmId = 1, RoomId = 3, StartTime = DateTime.Today.AddDays(1).AddHours(20), Price = 14.00m },
        new Showtime { Id = 3, FilmId = 2, RoomId = 2, StartTime = DateTime.Today.AddDays(1).AddHours(17), Price = 10.00m },
        new Showtime { Id = 4, FilmId = 2, RoomId = 5, StartTime = DateTime.Today.AddDays(2).AddHours(16), Price = 11.00m },
        new Showtime { Id = 5, FilmId = 3, RoomId = 1, StartTime = DateTime.Today.AddDays(2).AddHours(19), Price = 15.00m },
        new Showtime { Id = 6, FilmId = 3, RoomId = 7, StartTime = DateTime.Today.AddDays(2).AddHours(21), Price = 13.00m },
        new Showtime { Id = 7, FilmId = 4, RoomId = 3, StartTime = DateTime.Today.AddDays(3).AddHours(18), Price = 14.00m },
        new Showtime { Id = 8, FilmId = 4, RoomId = 9, StartTime = DateTime.Today.AddDays(3).AddHours(20), Price = 12.00m },
        new Showtime { Id = 9, FilmId = 5, RoomId = 5, StartTime = DateTime.Today.AddDays(3).AddHours(17), Price = 11.00m },
        new Showtime { Id = 10, FilmId = 5, RoomId = 11, StartTime = DateTime.Today.AddDays(4).AddHours(15), Price = 10.00m },
        new Showtime { Id = 11, FilmId = 6, RoomId = 2, StartTime = DateTime.Today.AddDays(4).AddHours(19), Price = 12.00m },
        new Showtime { Id = 12, FilmId = 6, RoomId = 6, StartTime = DateTime.Today.AddDays(4).AddHours(21), Price = 11.00m },
        new Showtime { Id = 13, FilmId = 7, RoomId = 4, StartTime = DateTime.Today.AddDays(5).AddHours(18), Price = 16.00m },
        new Showtime { Id = 14, FilmId = 7, RoomId = 8, StartTime = DateTime.Today.AddDays(5).AddHours(20), Price = 13.00m },
        new Showtime { Id = 15, FilmId = 8, RoomId = 10, StartTime = DateTime.Today.AddDays(5).AddHours(17), Price = 10.00m },
        new Showtime { Id = 16, FilmId = 8, RoomId = 12, StartTime = DateTime.Today.AddDays(6).AddHours(19), Price = 11.00m }
    };

    private static int _nextFilmId = 100;
    private static int _nextCinemaId = 100;
    private static int _nextRoomId = 100;
    private static int _nextShowtimeId = 100;

    public static int GetNextFilmId() => Interlocked.Increment(ref _nextFilmId);
    public static int GetNextCinemaId() => Interlocked.Increment(ref _nextCinemaId);
    public static int GetNextRoomId() => Interlocked.Increment(ref _nextRoomId);
    public static int GetNextShowtimeId() => Interlocked.Increment(ref _nextShowtimeId);
}
