using StoreOnline.Domain.SaleContext.Entities;

namespace StoreOnline.Domain.SaleContext.Repositories;

public interface IProductRepository
{
    Task Create(Product product, CancellationToken cancellation);
    Task Update(Product product, Guid id, CancellationToken cancellation);
    Task Delete(Product product, Guid id, CancellationToken cancellation);
}