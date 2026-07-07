using GastoResidencial.DTOs.Transacao;

namespace GastoResidencial.Interfaces;

public interface ITransacaoService
{
    Task<TransacaoResponseDto> CriarTransacaoAsync(TransacaoRequestDto dto);

    Task<List<TransacaoResponseDto>> ListarTransacoesAsync();

    Task<TransacaoResponseDto?> BuscarPorIdAsync(int id);

    Task<TransacaoResponseDto?> AtualizarTransacaoAsync(int id, TransacaoRequestDto dto);

    Task<bool> ExcluirTransacaoAsync(int id);
}