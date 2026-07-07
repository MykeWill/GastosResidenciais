using GastoResidencial.Interfaces;
using GastoResidencial.Models;
using Microsoft.AspNetCore.Mvc;
using GastoResidencial.DTOs.Transacao;

namespace GastoResidencial.Controllers;

/// <summary>
/// Responsável pelos endpoints relacionados às transações.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly ITransacaoService _transacaoService;

    public TransacoesController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    /// <summary>
    /// Cadastra uma nova transação.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CriarTransacao(TransacaoRequestDto dto)
    {
        var transacao = await _transacaoService.CriarTransacaoAsync(dto);

        return CreatedAtAction(nameof(ListarTransacoes), new { id = transacao.Id }, transacao);
    }
    /// <summary>
    /// Lista todas as transações cadastradas.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> ListarTransacoes()
    {
        return Ok(await _transacaoService.ListarTransacoesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var transacao = await _transacaoService.BuscarPorIdAsync(id);

        if (transacao == null)
        {
            return NotFound();
        }

        return Ok(transacao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTransacao(int id, TransacaoRequestDto dto)
    {
        var transacao = await _transacaoService.AtualizarTransacaoAsync(id, dto);

        if (transacao == null)
        {
            return NotFound();
        }

        return Ok(transacao);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirTransacao(int id) 
    {
        var excluiu = await _transacaoService.ExcluirTransacaoAsync(id);

        if (!excluiu)
        {
            return NotFound();
        }

        return NoContent();
    }
}