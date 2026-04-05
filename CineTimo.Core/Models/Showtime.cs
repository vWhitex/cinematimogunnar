namespace CineTimo.Core.Models;

public class Showtime
{
    public int Id { get; set; }
    public int FilmId { get; set; }
    public int RoomId { get; set; }
    public DateTime StartTime { get; set; }
    public decimal Price { get; set; }
}
