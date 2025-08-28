using BookGRPC.Server.Contracts;
using BookGRPC.Server.Implementations;

namespace BookGRPC.Server.Configurations;

public static class DIConfiguration
{
    public static IServiceCollection ConfigureDI(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        return services;
    }
}
