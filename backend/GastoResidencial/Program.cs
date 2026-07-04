using GastoResidencial.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura a conexão com o banco SQLite.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=gastos.db"));

// Adiciona suporte aos Controllers.
builder.Services.AddControllers();

// Configuração do OpenAPI (.NET 10)
builder.Services.AddOpenApi();

var app = builder.Build();

// Habilita o OpenAPI em ambiente de desenvolvimento.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();