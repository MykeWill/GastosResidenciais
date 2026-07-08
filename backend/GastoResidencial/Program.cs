using GastoResidencial.Data;
using Microsoft.EntityFrameworkCore;
using GastoResidencial.Interfaces;
using GastoResidencial.Services;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Configura a conexão com o banco SQLite.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=gastos.db"));

// Registra os serviços da aplicação no container de Injeção de Dependência.
// Sempre que um Controller solicitar uma interface, o .NET fornecerá
// automaticamente sua respectiva implementação.
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();
// Adiciona suporte aos Controllers.
builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var erros = context.ModelState
            .Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        return new BadRequestObjectResult(new
        {
            mensagem = "Dados inválidos.",
            erros
        });
    };
});

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