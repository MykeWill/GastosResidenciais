using GastoResidencial.DTOs.Relatorio;
using GastoResidencial.Models;

namespace GastoResidencial.Mappings;

/// <summary>
/// Responsável por converter os resultados do relatório em DTOs.
/// </summary>
public static class RelatorioMapping
{
    /// <summary>
    /// Converte uma pessoa e seus totais em DTO.
    /// </summary>
    public static PessoaTotaisResponseDto ToPessoaTotaisDto(
        Pessoa pessoa,
        decimal totalReceitas,
        decimal totalDespesas)
    {
        return new PessoaTotaisResponseDto
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome,
            TotalReceitas = totalReceitas,
            TotalDespesas = totalDespesas
        };
    }

    /// <summary>
    /// Converte os totais gerais em DTO.
    /// </summary>
    public static RelatorioTotaisResponseDto ToRelatorioDto(
        List<PessoaTotaisResponseDto> pessoas,
        decimal totalReceitas,
        decimal totalDespesas)
    {
        return new RelatorioTotaisResponseDto
        {
            Pessoas = pessoas,
            TotalReceitas = totalReceitas,
            TotalDespesas = totalDespesas
        };
    }
}