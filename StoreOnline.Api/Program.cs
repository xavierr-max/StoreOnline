using Microsoft.EntityFrameworkCore;
using StoreOnline.Application.SaleContext.UseCases.Product.Create;
using StoreOnline.Application.SharedContext.UseCases;
using StoreOnline.Infrastructure.SharedContext;
using StoreOnline.Infrastructure.SharedContext.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("StoreOnline.Api")
    ));

builder.Services.AddInfrastructure();
// Registrando o Caso de Uso
builder.Services.AddTransient<IHandler<Request, Response>, Handler>();

var app = builder.Build();

app.MapControllers();

app.Run();