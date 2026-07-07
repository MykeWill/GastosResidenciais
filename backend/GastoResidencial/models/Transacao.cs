using GastoResidencial.Enums;

namespace GastoResidencial.Models;

/// <summary>
/// Representa uma transação financeira realizada por uma pessoa.
/// Pode ser uma receita ou uma despesa.
/// </summary>
public class Transacao
{
    /// <summary>
    /// Identificador único da transação.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Descrição da transação.
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Valor monetário da transação.
    /// </summary>
    public decimal Valor { get; set; }

    /// <summary>
    /// Tipo da transação (Receita ou Despesa).
    /// </summary>
    public TipoTransacao Tipo { get; set; }

    /// <summary>
    /// Chave estrangeira da pessoa.
    /// </summary>
    public int PessoaId { get; set; }

    /// <summary>
    /// Pessoa responsável pela transação.
    /// </summary>
    public Pessoa? Pessoa { get; set; }
}