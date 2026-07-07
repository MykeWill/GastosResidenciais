namespace GastoResidencial.DTOs.Pessoa;

/// <summary>
/// Representa os dados retornados pela API após operações com pessoas.
/// </summary>
public class PessoaResponseDto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public int Idade { get; set; }
}