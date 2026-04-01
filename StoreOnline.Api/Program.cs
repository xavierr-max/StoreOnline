using Microsoft.EntityFrameworkCore;
using StoreOnline.Api;
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
// Registrando os Caso de Uso
builder.Services.AddHandlers();

var app = builder.Build();

app.MapControllers();

app.Run();