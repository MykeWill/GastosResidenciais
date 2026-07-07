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
    
    //Exclui uma pessoa e todas as suas transações
    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirPessoa(int id)
    {
        var excluiu = await _pessoaService.ExcluirPessoaAsync(id);

        if (!excluiu)
        {
            return NotFound();
        }

        return NoContent();
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

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var pessoa = await _pessoaService.BuscarPorIdAsync(id);

        if (pessoa == null)
        {
            return NotFound();
        }

        return Ok(pessoa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPessoa(int id, PessoaRequestDto dto)
    {
        var pessoa = await _pessoaService.AtualizarPessoaAsync(id, dto);

        if (pessoa == null)
        {
            return NotFound();
        }

        return Ok(pessoa);
    }   
}