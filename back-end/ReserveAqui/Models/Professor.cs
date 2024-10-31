using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models;

public class Professor
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(60)]
    public string Nome { get; set; } = string.Empty;
    [Required]
    [StringLength(60)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(15, MinimumLength = 8)]
    public string Senha { get; set; } = string.Empty;
    [Required]
    [StringLength(11)]
    public string Cpf { get; set; } = string.Empty;
    [Required]
    [StringLength(11)]
    public string Telefone { get; set; } = string.Empty;
    [Required]
    public string Foto { get; set; } = string.Empty;
    public ICollection<Materia> Materias { get; set; }
    [Required]
    public Instituicao? Instituicao { get; set; }
}
