using StoreOnline.Domain.SaleContext.Entities;
using StoreOnline.Domain.SaleContext.Repositories;
using StoreOnline.Infrastructure.SharedContext.Data;

namespace StoreOnline.Infrastructure.SaleContext;

public class ProductRepository(AppDbContext context): IProductRepository
{
    public async Task CreateAsync(Product product, CancellationToken cancellation)
    {
        await context.Products.AddAsync(product, cancellation);
        await context.SaveChangesAsync(cancellation);
    }

    public async Task UpdateAsync(Product product, Guid id, CancellationToken cancellation)
    {
        var existingProduct = await context.Products.FindAsync([id], cancellation);
        if (existingProduct != null)
        {
            context.Entry(existingProduct).CurrentValues.SetValues(product);
            await context.SaveChangesAsync(cancellation);
        }
    }

    public async Task DeleteAsync(Product product, Guid id, CancellationToken cancellation)
    {
        var productToDelete = await context.Products.FindAsync([id], cancellation);
        if (productToDelete != null)
        {
            context.Products.Remove(productToDelete);
            await context.SaveChangesAsync(cancellation);
        }
    }
}