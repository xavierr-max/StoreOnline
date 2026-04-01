using StoreOnline.Domain.SaleContext.Entities;
using StoreOnline.Domain.SharedContext.Repositories.Abstractions;

namespace StoreOnline.Domain.SaleContext.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task CreateAsync(Product product, CancellationToken cancellation);
    Task UpdateAsync(Product product, Guid id, CancellationToken cancellation);
    Task DeleteAsync(Product product, Guid id, CancellationToken cancellation);
}