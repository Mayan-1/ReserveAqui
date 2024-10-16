using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.DTOs;

public class MateriaDto
{
    [Required]
    public string? Nome { get; set; }
}
