using GastoResidencial.Data;
using GastoResidencial.DTOs.Relatorio;
using GastoResidencial.Enums;
using GastoResidencial.Interfaces;
using GastoResidencial.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GastoResidencial.Services;

/// <summary>
/// Implementa a geração de relatórios financeiros.
/// </summary>
public class RelatorioService : IRelatorioService
{
    private readonly AppDbContext _context;

    public RelatorioService(AppDbContext context)
    {
        _context = context;
    }

   public async Task<RelatorioTotaisResponseDto> ObterTotaisAsync()
{
    var pessoas = await _context.Pessoas
        .Include(p => p.Transacoes)
        .ToListAsync();

    var pessoasDto = new List<PessoaTotaisResponseDto>();

    foreach (var pessoa in pessoas)
    {
        var totalReceitas = pessoa.Transacoes
            .Where(t => t.Tipo == TipoTransacao.Receita)
            .Sum(t => t.Valor);

        var totalDespesas = pessoa.Transacoes
            .Where(t => t.Tipo == TipoTransacao.Despesa)
            .Sum(t => t.Valor);

        pessoasDto.Add(
            RelatorioMapping.ToPessoaTotaisDto(
                pessoa,
                totalReceitas,
                totalDespesas));
    }

    var totalReceitasGeral = pessoasDto.Sum(p => p.TotalReceitas);
    var totalDespesasGeral = pessoasDto.Sum(p => p.TotalDespesas);

    return RelatorioMapping.ToRelatorioDto(
        pessoasDto,
        totalReceitasGeral,
        totalDespesasGeral);
}
}