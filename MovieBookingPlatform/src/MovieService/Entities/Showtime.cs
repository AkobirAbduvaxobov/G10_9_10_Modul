namespace MovieService.Entities;

public class Showtime
{
    public long ShowtimeId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }

    public Movie Movie { get; set; }
    public long MovieId { get; set; }
    public CinemaHall CinemaHall { get; set; }
    public long CinemaHallId { get; set; }

}
