using System.ComponentModel.DataAnnotations;
using GastoResidencial.Enums;

namespace GastoResidencial.DTOs.Transacao;

/// <summary>
/// Dados necessários para cadastrar uma transação.
/// </summary>
public class TransacaoRequestDto
{
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(150, ErrorMessage = "A descrição pode ter no máximo 150 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "O tipo da transação é obrigatório.")]
    public TipoTransacao Tipo { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "PessoaId deve ser maior que zero.")]
    public int PessoaId { get; set; }
}