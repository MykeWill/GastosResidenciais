namespace GastoResidencial.DTOs.Relatorio;

/// <summary>
/// Representa o resumo financeiro de uma pessoa.
/// </summary>
public class PessoaTotaisResponseDto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public decimal TotalReceitas { get; set; }

    public decimal TotalDespesas { get; set; }

    public decimal Saldo => TotalReceitas - TotalDespesas;
}