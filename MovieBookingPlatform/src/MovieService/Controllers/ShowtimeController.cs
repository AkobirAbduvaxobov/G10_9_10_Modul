using Microsoft.AspNetCore.Mvc;
using MovieService.Dtos;
using MovieService.Services;

namespace MovieService.Controllers;

[Route("api/showtimes")]
[ApiController]
public class ShowtimeController : ControllerBase
{
    private readonly IShowtimeService _showtimeService;

    public ShowtimeController(IShowtimeService showtimeService)
    {
        _showtimeService = showtimeService;
    }

    [HttpPost]
    public async Task<long> Add([FromBody] ShowtimeCreateDto showtimeCreateDto)
    {
        var showtimeId = await _showtimeService.AddAsync(showtimeCreateDto);
        return showtimeId;
    }

    [HttpGet]
    public async Task<List<ShowtimeDto>> GetAll()
    {
        var showtimes = await _showtimeService.GetAllAsync();
        return showtimes;
    }
}
