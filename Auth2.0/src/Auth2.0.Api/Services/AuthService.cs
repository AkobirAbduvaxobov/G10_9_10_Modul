using Auth2._0.Api.Dtos;
using Auth2._0.Api.Entites;
using Auth2._0.Api.Persistense;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Auth2._0.Api.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;

    public AuthService(AppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> GoogleLoginAsync(GoogleAuthDto dto)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(dto.IdToken, new GoogleJsonWebSignature.ValidationSettings());

        var user = await _context.Users.FirstOrDefaultAsync(u => u.GoogleId == payload.Subject);

        if (user == null)
        {
            throw new Exception("User not fount");
        }

        var userTokenDto = new UserTokenDto
        {
            UserId = user.UserId,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role
        };

        var token = _tokenService.GenerateToken(userTokenDto);

        var loginResponseDto = new LoginResponseDto
        {
            AccessToken = token,
        };

        return loginResponseDto;
    }

    public async Task<long> GoogleRegisterAsync(GoogleAuthDto dto)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(dto.IdToken, new GoogleJsonWebSignature.ValidationSettings());

        var user = await _context.Users.FirstOrDefaultAsync(u => u.GoogleId == payload.Subject);

        if (user != null)
        {
            return user.UserId;
        }

        user = new User
        {
            UserName = payload.Email.Split('@')[0],
            FirstName = payload.GivenName,
            LastName = payload.FamilyName,
            Email = payload.Email,
            EmailConfirmed = payload.EmailVerified,
            GoogleId = payload.Subject,
            GoogleProfilePicture = payload.Picture,
            Role = UserRole.User,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.UserId;
    }

    public async Task<LoginResponseDto> LoginUserAsync(LoginDto userLoginDto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == userLoginDto.EmailOrUserName 
                || u.UserName == userLoginDto.EmailOrUserName);
       
        if(user == null)
        {
            throw new Exception("UserName or password incorrect");
        }

        var checkUserPassword = PasswordHasher.Verify(userLoginDto.Password, user.PasswordHash, user.Salt);

        if (checkUserPassword == false)
        {
            throw new Exception("UserName or password incorrect");
        }

        var userTokenDto = new UserTokenDto
        {
            UserId = user.UserId,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role
        };

        var token = _tokenService.GenerateToken(userTokenDto);

        var loginResponseDto = new LoginResponseDto()
        {
            AccessToken = token,
        };

        return loginResponseDto;
    }

    public async Task<long> SignUpUserAsync(RegisterDto userCreateDto)
    {
        var tupleFromHasher = PasswordHasher.Hasher(userCreateDto.Password);
        var user = new User()
        {
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            UserName = userCreateDto.UserName,
            Email = userCreateDto.Email,
            PasswordHash = tupleFromHasher.Hash,
            Salt = tupleFromHasher.Salt,
            Role = UserRole.User,
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.UserId;
    }
}

