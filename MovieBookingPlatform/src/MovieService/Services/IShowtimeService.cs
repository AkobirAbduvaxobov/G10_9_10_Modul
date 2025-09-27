using MovieService.Dtos;

namespace MovieService.Services;

public interface IShowtimeService
{
    public Task<long> AddAsync(ShowtimeCreateDto showtimeCreateDto);
    public Task UpdateAsync(ShowtimeUpdateDto showtimeUpdateDto);
    public Task<ShowtimeDto> GetByIdAsync(long id);
    public Task<List<ShowtimeDto>> GetAllAsync();
    public Task DeleteAsync(long id);
}