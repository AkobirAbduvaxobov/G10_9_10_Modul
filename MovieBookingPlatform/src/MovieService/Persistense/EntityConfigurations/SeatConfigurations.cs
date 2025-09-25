using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieService.Entities;

namespace MovieService.Persistense.EntityConfigurations;

public class SeatConfigurations : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seats");
        builder.HasKey(s => s.SeatId);
        builder.Property(s => s.SeatNumber).IsRequired(true);
        builder.Property(s => s.IsVip).IsRequired(true);
    }
}
