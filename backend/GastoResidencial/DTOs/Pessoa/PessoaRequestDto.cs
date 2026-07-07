namespace GastoResidencial.DTOs.Pessoa;

/// <summary>
/// Representa os dados necessários para cadastrar uma pessoa.
/// </summary>
public class PessoaRequestDto
{
    public string Nome { get; set; } = string.Empty;

    public int Idade { get; set; }
}