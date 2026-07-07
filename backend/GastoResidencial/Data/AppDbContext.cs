using GastoResidencial.Models;
using Microsoft.EntityFrameworkCore;

namespace GastoResidencial.Data;

/// <summary>
/// Representa a sessão de comunicação entre a aplicação e o banco de dados.
/// É através dele que o Entity Framework cria tabelas e executa consultas.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Representa a tabela de pessoas no banco de dados.
    /// </summary>
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
}