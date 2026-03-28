using StoreOnline.Domain.SaleContext.Entities;

namespace StoreOnline.Domain.SaleContext.Repositories;

public interface IProductRepository
{
    Task CreateAsync(Product product, CancellationToken cancellation);
    Task UpdateAsync(Product product, Guid id, CancellationToken cancellation);
    Task DeleteAsync(Product product, Guid id, CancellationToken cancellation);
}