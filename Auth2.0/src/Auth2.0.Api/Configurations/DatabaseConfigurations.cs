using Auth2._0.Api.Configurations.Settings;
using Auth2._0.Api.Persistense;
using Microsoft.EntityFrameworkCore;

namespace Auth2._0.Api.Configurations;

public static class DatabaseConfigurations
{
    public static void ConfigureDB(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

        builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(connectionString));

        builder.Services.AddSingleton(jwtSettings);
    }
}
