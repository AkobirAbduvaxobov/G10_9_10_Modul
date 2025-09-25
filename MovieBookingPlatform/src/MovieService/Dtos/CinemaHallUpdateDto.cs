using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos;

public class CinemaHallUpdateDto
{
    public long CinemaHallId { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, Range(0, 2000)]
    public int TotalSeats { get; set; }
}
