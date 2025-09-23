using GatewayApi.Dtos;

namespace GatewayApi.Services;

public interface IUserApiService
{
    Task<long> RegisterUserAsync(RegisterDto registerDto);
    Task<LoginResponseDto> LoginUserAsync(LoginDto login);
}
