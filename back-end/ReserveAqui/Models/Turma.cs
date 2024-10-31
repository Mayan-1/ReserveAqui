using ReserveAqui.Models;
using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Modelsl;

public class Turma
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; } = string.Empty;
    [Required]
    public Turno Turno { get; set; }
    [Required]
    public string Codigo { get; set; } = string.Empty;
}
