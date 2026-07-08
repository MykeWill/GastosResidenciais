namespace GastoResidencial.DTOs.Relatorio;

/// <summary>
/// Representa o relatório geral do sistema.
/// </summary>
public class RelatorioTotaisResponseDto
{
    public List<PessoaTotaisResponseDto> Pessoas { get; set; } = [];

    public decimal TotalReceitas { get; set; }

    public decimal TotalDespesas { get; set; }

    public decimal SaldoLiquido => TotalReceitas - TotalDespesas;
}