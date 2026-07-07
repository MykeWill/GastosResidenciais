namespace GastoResidencial.Models;

/// <summary>
/// Representa uma pessoa cadastrada no sistema.
/// </summary>
public class Pessoa
{
    /// <summary>
    /// Identificador único da pessoa.
    /// O valor será gerado automaticamente pelo banco de dados.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome da pessoa.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Idade da pessoa.
    /// </summary>
    public int Idade { get; set; }

    /// <summary>
    /// Lista de transações associadas à pessoa.
    /// </summary>
    public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
}