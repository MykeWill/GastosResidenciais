using GastoResidencial.DTOs.Pessoa;
using GastoResidencial.Models;

namespace GastoResidencial.Mappings;

/// <summary>
/// Responsável por converter entre Pessoa e seus DTOs.
/// </summary>
public static class PessoaMapping
{
    /// <summary>
    /// Converte um DTO de requisição em uma entidade Pessoa.
    /// </summary>
    public static Pessoa ToEntity(PessoaRequestDto dto)
    {
        return new Pessoa
        {
            Nome = dto.Nome,
            Idade = dto.Idade
        };
    }

    /// <summary>
    /// Converte uma entidade Pessoa em um DTO de resposta.
    /// </summary>
    public static PessoaResponseDto ToResponseDto(Pessoa pessoa)
    {
        return new PessoaResponseDto
        {
            Id = pessoa.Id,
            Nome = pessoa.Nome,
            Idade = pessoa.Idade
        };
    }
}