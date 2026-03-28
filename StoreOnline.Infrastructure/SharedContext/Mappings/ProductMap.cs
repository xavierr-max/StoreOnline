using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreOnline.Domain.SaleContext.Entities;

namespace StoreOnline.Infrastructure.SharedContext.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnType("uniqueidentifier")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnType("nvarchar(500)")
            .IsRequired(false);

        builder.Property(p => p.IsActive)
            .HasColumnType("bit")
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        // Configure ValueObject properties directly
        builder.Property(p => p.Price.Value)
            .HasColumnName("Price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.Stock.Quantity)
            .HasColumnName("StockQuantity")
            .HasColumnType("int")
            .IsRequired();
    }
}