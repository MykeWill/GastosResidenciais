using GastoResidencial.DTOs.Pessoa;

namespace GastoResidencial.Interfaces;

public interface IPessoaService
{
    Task<PessoaResponseDto> CriarPessoaAsync(PessoaRequestDto dto);

    Task<List<PessoaResponseDto>> ListarPessoasAsync();
}