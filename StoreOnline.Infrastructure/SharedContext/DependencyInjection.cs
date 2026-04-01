using Microsoft.Extensions.DependencyInjection;
using StoreOnline.Domain.SaleContext.Repositories;
using StoreOnline.Domain.SharedContext.Repositories.Abstractions;
using StoreOnline.Infrastructure.SaleContext.Repositories;
using StoreOnline.Infrastructure.SharedContext.Data;

namespace StoreOnline.Infrastructure.SharedContext;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IProductRepository, ProductRepository>();

        return services;
    }
}