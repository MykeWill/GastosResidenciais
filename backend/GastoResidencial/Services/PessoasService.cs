using GastoResidencial.Data;
using GastoResidencial.Interfaces;
using GastoResidencial.Models;
using Microsoft.EntityFrameworkCore;
using GastoResidencial.DTOs.Pessoa;
using GastoResidencial.Mappings;

namespace GastoResidencial.Services;

/// <summary>
/// Implementa as regras de negócio relacionadas às pessoas.
/// </summary>
public class PessoaService : IPessoaService
{
    private readonly AppDbContext _context;

    public PessoaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PessoaResponseDto> CriarPessoaAsync(PessoaRequestDto dto)
    {
        var pessoa = PessoaMapping.ToEntity(dto);

        _context.Pessoas.Add(pessoa);

        await _context.SaveChangesAsync();

        return PessoaMapping.ToResponseDto(pessoa);
    }
    
    public async Task<List<PessoaResponseDto>> ListarPessoasAsync()
    {
        var pessoas = await _context.Pessoas.ToListAsync();

        return pessoas
            .Select(PessoaMapping.ToResponseDto)
            .ToList();
    }

    public async Task<PessoaResponseDto?> BuscarPorIdAsync(int id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);

        if (pessoa == null)
        {
            return null;
        }

        return PessoaMapping.ToResponseDto(pessoa);
    }

    public async Task<PessoaResponseDto?> AtualizarPessoaAsync(int id, PessoaRequestDto dto)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);

        if (pessoa == null)
        {
            return null;
        }

       PessoaMapping.AtualizarEntity(pessoa, dto);

        await _context.SaveChangesAsync();

        return PessoaMapping.ToResponseDto(pessoa);
    }    
    public async Task<bool> ExcluirPessoaAsync(int id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);

        if (pessoa == null)
        {
            return false;
        }

        _context.Pessoas.Remove(pessoa);

        await _context.SaveChangesAsync();

        return true;
    }

}
