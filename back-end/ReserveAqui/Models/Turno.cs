using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models;

public class Turno
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; } = string.Empty;
}
