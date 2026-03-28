using Microsoft.Extensions.DependencyInjection;
using StoreOnline.Domain.SaleContext.Repositories;
using StoreOnline.Infrastructure.SaleContext;

namespace StoreOnline.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IProductRepository, ProductRepository>();
        return services;
    }
}