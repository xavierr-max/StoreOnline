using StoreOnline.Application.SharedContext.UseCases;

namespace StoreOnline.Api.Extensions;

public static class BuilderExtension
{
    public static IServiceCollection AddConfiguredCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("StoreOnlinePolicy",
                policy => policy.WithOrigins("http://localhost:5173") // Porta padrão do Vite/React
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        return services;
    }
    
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