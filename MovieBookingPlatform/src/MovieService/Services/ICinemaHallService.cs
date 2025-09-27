using MovieService.Dtos;

namespace MovieService.Services;

public interface ICinemaHallService
{
    public Task<long> AddAsync(CinemaHallCreateDto cinemaHallCreateDto);
    public Task UpdateAsync(CinemaHallUpdateDto cinemaHallUpdateDto);
    public Task<CinemaHallDto> GetByIdAsync(long id);
    public Task<List<CinemaHallDto>> GetAllAsync();
    public Task DeleteAsync(long id);
}