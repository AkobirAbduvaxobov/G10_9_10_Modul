namespace MovieService.Entities;

public class Seat
{
    public long SeatId { get; set; }
    public int SeatNumber { get; set; }
    public string Row { get; set; }
    public bool IsAvailable { get; set; }

    public CinemaHall CinemaHall { get; set; }
    public long CinemaHallId { get; set; }

    public Showtime Showtime { get; set; }
    public long ShowtimeId { get; set; }
}
