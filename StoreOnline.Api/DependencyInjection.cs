using StoreOnline.Application.SharedContext.UseCases;

namespace StoreOnline.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        // Substitua 'Handler' por qualquer classe real que esteja no projeto Application
        var applicationAssembly = typeof(Application.SaleContext.UseCases.Product.Create.Handler).Assembly;

        var handlers = applicationAssembly.GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface && t.GetInterfaces().Any(i => 
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandler<,>)));

        foreach (var handler in handlers)
        {
            var interfaceType = handler.GetInterfaces().First(i => 
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandler<,>));
        
            services.AddTransient(interfaceType, handler);
        }

        return services;
    }
}