using StoreOnline.Domain.SharedContext.Repositories.Abstractions;

namespace StoreOnline.Infrastructure.SharedContext.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
        => await context.SaveChangesAsync();

    public Task RollBackAsync()
        => Task.CompletedTask;
}