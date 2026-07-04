using GastoResidencial.Data;
using GastoResidencial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GastoResidencial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoasController : ControllerBase
{
    private readonly AppDbContext _context;

    public PessoasController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Cadastra uma nova pessoa.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CriarPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(CriarPessoa),
            new { id = pessoa.Id },
            pessoa
        );
    }

    /// <summary>
    /// Lista todas as pessoas cadastradas.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> ListarPessoas()
    {
        var pessoas = await _context.Pessoas.ToListAsync();
        return Ok(pessoas);
    }
}