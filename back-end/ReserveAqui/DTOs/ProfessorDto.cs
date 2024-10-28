using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.DTOs;

public class ProfessorDto
{
    [Required]
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public ICollection<string> MateriasNomes { get; set; }

}
