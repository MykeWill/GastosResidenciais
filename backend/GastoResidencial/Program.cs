using GastoResidencial.Data;
using Microsoft.EntityFrameworkCore;
using GastoResidencial.Interfaces;
using GastoResidencial.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Configura a conexão da aplicação com o banco de dados SQLite.
/// </summary>
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=gastos.db"));

/// <summary>
/// Registra os serviços da aplicação no container de Injeção de Dependência.
/// Sempre que um Controller solicitar uma interface, o .NET fornecerá
/// automaticamente sua respectiva implementação.
/// </summary>
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

/// <summary>
/// Adiciona suporte aos Controllers da API.
/// </summary>
builder.Services.AddControllers();

/// <summary>
/// Configura a política de CORS, permitindo que apenas o frontend
/// em React (executando em http://localhost:5173) consuma esta API.
/// </summary>
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

/// <summary>
/// Personaliza a resposta enviada quando ocorrer erro de validação
/// dos DTOs (ModelState inválido).
/// Em vez da resposta padrão do ASP.NET, retorna um objeto mais simples
/// contendo uma mensagem e a lista de erros.
/// </summary>
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

/// <summary>
/// Habilita a documentação da API (OpenAPI/Swagger).
/// </summary>
builder.Services.AddOpenApi();

var app = builder.Build();

/// <summary>
/// Disponibiliza a documentação da API apenas em ambiente de desenvolvimento.
/// </summary>
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

/// <summary>
/// Redireciona automaticamente requisições HTTP para HTTPS.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Aplica a política de CORS configurada anteriormente,
/// permitindo que o frontend autorizado acesse a API.
/// </summary>
app.UseCors("ReactPolicy");

/// <summary>
/// Mapeia os Controllers para que seus endpoints possam receber requisições.
/// </summary>
app.MapControllers();

/// <summary>
/// Inicia a aplicação.
/// </summary>
app.Run();