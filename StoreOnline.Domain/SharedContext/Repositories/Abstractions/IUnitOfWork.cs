namespace StoreOnline.Domain.SharedContext.Repositories.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollBackAsync();
}