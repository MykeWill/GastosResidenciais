using GastoResidencial.DTOs.Transacao;
using GastoResidencial.Models;

namespace GastoResidencial.Mappings;

/// <summary>
/// Responsável por converter entre Transacao e seus DTOs.
/// </summary>
public static class TransacaoMapping
{
    /// <summary>
    /// Converte um DTO de requisição em uma entidade Transacao.
    /// </summary>
    public static Transacao ToEntity(TransacaoRequestDto dto)
    {
        return new Transacao
        {
            Descricao = dto.Descricao,
            Valor = dto.Valor,
            Tipo = dto.Tipo,
            PessoaId = dto.PessoaId
        };
    }

    /// <summary>
    /// Converte uma entidade Transacao em um DTO de resposta.
    /// </summary>
    public static TransacaoResponseDto ToResponseDto(Transacao transacao)
    {
        return new TransacaoResponseDto
        {
            Id = transacao.Id,
            Descricao = transacao.Descricao,
            Valor = transacao.Valor,
            Tipo = transacao.Tipo,
            PessoaId = transacao.PessoaId
        };
    }
}