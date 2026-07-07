using GastoResidencial.Data;
using GastoResidencial.Interfaces;
using GastoResidencial.Models;
using Microsoft.EntityFrameworkCore;
using GastoResidencial.Enums;
using GastoResidencial.DTOs.Transacao;
using GastoResidencial.Mappings;

namespace GastoResidencial.Services;

/// <summary>
/// Implementa as regras de negócio relacionadas às transações.
/// </summary>
public class TransacaoService : ITransacaoService
{
    private readonly AppDbContext _context;

    public TransacaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TransacaoResponseDto> CriarTransacaoAsync(TransacaoRequestDto dto)
    {
        var transacao = TransacaoMapping.ToEntity(dto);

        var pessoa = await _context.Pessoas.FindAsync(transacao.PessoaId);

        if (pessoa == null)
        {
            throw new Exception("A pessoa informada não foi encontrada.");
        }

        if (pessoa.Idade < 18 &&
            transacao.Tipo == Enums.TipoTransacao.Receita)
        {
            throw new Exception("Pessoas menores de idade só podem cadastrar receitas.");
        }

        _context.Transacoes.Add(transacao);

        await _context.SaveChangesAsync();

        return TransacaoMapping.ToResponseDto(transacao);
    }
    public async Task<List<TransacaoResponseDto>> ListarTransacoesAsync()
    {
        var transacoes = await _context.Transacoes.ToListAsync();

        return transacoes
            .Select(TransacaoMapping.ToResponseDto)
            .ToList();
    }   
}