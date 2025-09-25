using MovieService.Persistense.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using MovieService.Entities;

namespace MovieService.Persistense;

public class AppDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<CinemaHall> CinemaHalls { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Showtime> Showtimes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

