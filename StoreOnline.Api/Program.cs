using Microsoft.EntityFrameworkCore;
using StoreOnline.Application.SaleContext.UseCases.Product.Create;
using StoreOnline.Application.SharedContext.UseCases;
using StoreOnline.Infrastructure.SharedContext;
using StoreOnline.Infrastructure.SharedContext.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("StoreOnline.Api")
    ));

builder.Services.AddInfrastructure();
// Registrando o Caso de Uso
builder.Services.AddTransient<IHandler<Request, Response>, Handler>();

var app = builder.Build();

app.MapPost("/v1/product", async (
    Request command,
    IHandler<Request, Response> sender) =>
{
    var result = await sender.Handle(command);
    return TypedResults.Ok(result);
});

app.Run();