using Auth2._0.Api.Dtos;

namespace Auth2._0.Api.Services;

public interface ITokenService
{
    public string GenerateToken(UserTokenDto tokenDto);
}
