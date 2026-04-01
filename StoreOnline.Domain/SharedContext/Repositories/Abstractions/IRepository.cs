using StoreOnline.Domain.SharedContext.AggregateRoots.Abstractions;

namespace StoreOnline.Domain.SharedContext.Repositories.Abstractions;

public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
{
    
}