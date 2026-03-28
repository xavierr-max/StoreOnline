using Microsoft.EntityFrameworkCore;
using StoreOnline.Domain.SaleContext.Entities;

namespace StoreOnline.Infrastructure.SharedContext.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly();
    }
}