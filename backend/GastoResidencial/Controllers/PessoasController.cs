using GastoResidencial.Data;
using GastoResidencial.Models;
using Microsoft.AspNetCore.Mvc;

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
}