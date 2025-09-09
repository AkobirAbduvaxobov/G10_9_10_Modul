using Auth2._0.Api.Entites;
using Auth2._0.Api.Persistense.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Auth2._0.Api.Persistense;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfigurations());
    }
}

