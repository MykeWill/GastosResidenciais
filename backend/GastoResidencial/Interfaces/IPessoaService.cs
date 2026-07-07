using GastoResidencial.DTOs.Pessoa;

namespace GastoResidencial.Interfaces;

public interface IPessoaService
{
    Task<PessoaResponseDto> CriarPessoaAsync(PessoaRequestDto dto);

    Task<List<PessoaResponseDto>> ListarPessoasAsync();

    Task<PessoaResponseDto?> BuscarPorIdAsync(int id);

    Task<PessoaResponseDto?> AtualizarPessoaAsync(int id, PessoaRequestDto dto);

    Task<bool> ExcluirPessoaAsync(int id);
}