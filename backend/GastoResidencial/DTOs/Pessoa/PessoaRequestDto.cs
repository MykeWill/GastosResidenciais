using System.ComponentModel.DataAnnotations;

namespace GastoResidencial.DTOs.Pessoa;

/// <summary>
/// Dados necessários para cadastrar uma pessoa.
/// </summary>
public class PessoaRequestDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Range(0, 120, ErrorMessage = "A idade deve estar entre 0 e 120 anos.")]
    public int Idade { get; set; }
}