using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieService.Dtos;
using MovieService.Services;

namespace MovieService.Controllers;

[Route("api/movies")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public async Task<long> Add([FromBody] MovieCreateDto movieCreateDto)
    {
        var movieId = await _movieService.AddAsync(movieCreateDto);
        return movieId;
    }


    [HttpGet]
    public async Task<IEnumerable<MovieDto>> GetAll()
    {
        var movies = await _movieService.GetAllAsync();
        return movies;
    }
}
