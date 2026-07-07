using GastoResidencial.DTOs.Transacao;

namespace GastoResidencial.Interfaces;

public interface ITransacaoService
{
    Task<TransacaoResponseDto> CriarTransacaoAsync(TransacaoRequestDto dto);

    Task<List<TransacaoResponseDto>> ListarTransacoesAsync();
}