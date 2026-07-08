using GastoResidencial.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GastoResidencial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RelatoriosController : ControllerBase
{
    private readonly IRelatorioService _relatorioService;

    public RelatoriosController(IRelatorioService relatorioService)
    {
        _relatorioService = relatorioService;
    }

    [HttpGet("totais")]
    public async Task<IActionResult> ObterTotais()
    {
        var relatorio = await _relatorioService.ObterTotaisAsync();

        return Ok(relatorio);
    }
}