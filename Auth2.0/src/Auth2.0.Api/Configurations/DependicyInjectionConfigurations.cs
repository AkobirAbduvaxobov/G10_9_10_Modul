using Auth2._0.Api.Services;

namespace Auth2._0.Api.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAuthService, AuthService>();

    } 
}
