using MovieService.Dtos;

namespace MovieService.Services;

public class MovieService : IMovieService
{
    public Task<long> AddAsync(MovieCreateDto movieCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long movieId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<MovieDto> GetByIdAsync(long movieId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(MovieUpdateDto movieUpdateDto)
    {
        throw new NotImplementedException();
    }
}
