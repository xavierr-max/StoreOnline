using Microsoft.EntityFrameworkCore;
using StoreOnline.Api.Extensions;
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
// Adiciona a configuração de CORS separada
builder.Services.AddConfiguredCors();
// Registrando os Caso de Uso
builder.Services.AddHandlers();


var app = builder.Build();

// Ativa o Middleware (Importante: antes de MapControllers)
app.UseCors("StoreOnlinePolicy");
app.MapControllers();

app.Run();