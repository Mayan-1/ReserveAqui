using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models;

public class ReservaMaterial
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateOnly Data { get; set; }
    [Required]
    public Turno Turno { get; set; }
    [Required]
    [StringLength(100)]
    public string Descricao { get; set; } = string.Empty;
    [Required]
    public Material Material { get; set; }
    [Required]
    public Professor Professor { get; set; }
}
