using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieService.Entities;

namespace MovieService.Persistense.EntityConfigurations;

public class ShowtimeConfiguration : IEntityTypeConfiguration<Showtime>
{
    public void Configure(EntityTypeBuilder<Showtime> builder)
    {
        builder.ToTable("Showtimes");
        builder.HasKey(s => s.ShowtimeId);
        builder.Property(s => s.MinPrice).IsRequired(true);
        builder.Property(s => s.MaxPrice).IsRequired(true);

        
    }
}