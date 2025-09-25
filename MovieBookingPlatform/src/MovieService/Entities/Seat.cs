namespace MovieService.Entities;

public class Seat
{
    public long SeatId { get; set; }
    public string SeatNumber { get; set; }
    public string Row { get; set; }
    public bool IsVip { get; set; }

    public CinemaHall CinemaHall { get; set; }
    public long CinemaHallId { get; set; }
}
