using GastoResidencial.Enums;

namespace GastoResidencial.DTOs.Transacao;

/// <summary>
/// Representa os dados necessários para cadastrar uma transação.
/// </summary>
public class TransacaoRequestDto
{
    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public TipoTransacao Tipo { get; set; }

    public int PessoaId { get; set; }
}