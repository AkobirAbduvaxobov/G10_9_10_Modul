namespace BookingService.Entities;

public class Booking
{
    public long BookingId { get; set; }            
    public long UserId { get; set; }        
    public long ShowtimeId { get; set; }
    public long SeatId { get; set; }

    public DateTime BookingDate { get; set; }

    public PaymentStatus PaymentStatus { get; set; }
    public BookingStatus BookingStatus { get; set; }
}


public enum PaymentStatus
{
    Pending = 0,
    Paid = 1,
    Failed = 2
}


public enum BookingStatus
{
    Pending = 0,
    Confirmed = 1,
    Cancelled = 2
}