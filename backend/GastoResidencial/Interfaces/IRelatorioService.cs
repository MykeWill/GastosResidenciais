using GastoResidencial.DTOs.Relatorio;

namespace GastoResidencial.Interfaces;

/// <summary>
/// Responsável pela geração dos relatórios do sistema.
/// </summary>
public interface IRelatorioService
{
    Task<RelatorioTotaisResponseDto> ObterTotaisAsync();
}