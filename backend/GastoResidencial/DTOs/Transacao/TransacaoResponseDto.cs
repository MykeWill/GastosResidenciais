using GastoResidencial.Enums;

namespace GastoResidencial.DTOs.Transacao;

/// <summary>
/// Representa os dados retornados pela API após operações com transações.
/// </summary>
public class TransacaoResponseDto
{
    public int Id { get; set; }

    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    public int PessoaId { get; set; }
}