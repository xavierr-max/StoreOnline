using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreOnline.Domain.SaleContext.Entities;

namespace StoreOnline.Infrastructure.SharedContext.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Define o nome físico da tabela no banco
        builder.ToTable("products");

        // Define a propriedade Id como chave primária e nomeia a constraint
        builder
            .HasKey(x => x.Id)
            .HasName("pk_product");

        builder
            .Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        // Ignora propriedades base do Flunt na entidade (MUITO IMPORTANTE)
        builder.Ignore(x => x.Notifications);
        builder.Ignore(x => x.IsValid);

        // Mapeamento das propriedades convencionais
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("varchar")
            .HasMaxLength(500)
            .IsRequired(false); // Nullable

        builder.Property(x => x.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("boolean")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        // Configura o Value Object 'Price' como parte desta tabela (Owned Entity)
        builder.OwnsOne(x => x.Price, price =>
        {
            // Como Price também herda do Flunt, precisamos ignorar as validações dele aqui dentro
            price.Ignore(x => x.Notifications);
            price.Ignore(x => x.IsValid);

            // Mapeia a propriedade 'Value' do VO para a coluna 'price' na tabela de produtos
            price.Property(x => x.Value)
                .HasColumnName("price")
                .HasColumnType("numeric(10,2)")
                .IsRequired();
        });

        // Configura o Value Object 'Stock' como parte desta tabela (Owned Entity)
        builder.OwnsOne(x => x.Stock, stock =>
        {
            // Ignora o Flunt do VO
            stock.Ignore(x => x.Notifications);
            stock.Ignore(x => x.IsValid);

            // Mapeia a propriedade 'Quantity' do VO para a coluna 'stock_quantity' (ou apenas 'stock')
            stock.Property(x => x.Quantity)
                .HasColumnName("stock")
                .HasColumnType("integer")
                .IsRequired();
        });
    }
}