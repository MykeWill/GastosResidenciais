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
}