namespace MovieService.Entities;

public class CinemaHall
{
    public long CinemaHallId { get; set; }
    public string Name { get; set; }
    public int TotalSeats { get; set; }
    public DateTime CreatedAt{ get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Seat> Seats { get; set; }
    public ICollection<Showtime> Showtimes { get; set; }
}
