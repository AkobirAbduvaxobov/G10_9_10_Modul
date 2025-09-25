using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieService.Entities;

namespace MovieService.Persistense.EntityConfigurations;

public class CinemaHallConfigurations : IEntityTypeConfiguration<CinemaHall>
{
    public void Configure(EntityTypeBuilder<CinemaHall> builder)
    {
        builder.ToTable("CinemaHalls");
        builder.HasKey(m => m.CinemaHallId);
        builder.Property(t => t.Name).IsRequired(true);
        builder.Property(t => t.TotalSeats).IsRequired(true);

        builder.HasMany(m => m.Showtimes)
                .WithOne(s => s.CinemaHall)
                .HasForeignKey(s => s.CinemaHallId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Seats)
                .WithOne(s => s.CinemaHall)
                .HasForeignKey(s => s.CinemaHallId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}