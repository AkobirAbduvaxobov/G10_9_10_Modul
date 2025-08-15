using CQRSBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSBook.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}