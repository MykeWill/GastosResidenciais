using GastoResidencial.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GastoResidencial.DTOs.Pessoa;

namespace GastoResidencial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoasController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoasController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    /// <summary>
    /// Cadastra uma nova pessoa.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CriarPessoa(PessoaRequestDto dto)
    {
        var pessoa = await _pessoaService.CriarPessoaAsync(dto);

        return CreatedAtAction(nameof(ListarPessoas), new { id = pessoa.Id }, pessoa);
    }

    /// <summary>
    /// Lista todas as pessoas cadastradas.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> ListarPessoas()
    {
        return Ok(await _pessoaService.ListarPessoasAsync());
    }
}