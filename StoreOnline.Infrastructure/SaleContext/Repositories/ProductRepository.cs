using StoreOnline.Domain.SaleContext.Entities;
using StoreOnline.Domain.SaleContext.Repositories;
using StoreOnline.Infrastructure.SharedContext.Data;

namespace StoreOnline.Infrastructure.SaleContext.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task CreateAsync(Product product, CancellationToken cancellation)
        => await context.Products.AddAsync(product);

    public Task UpdateAsync(Product product, Guid id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product product, Guid id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}