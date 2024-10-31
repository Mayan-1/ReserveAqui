using ReserveAqui.Models;

namespace ReserveAqui.DTOs;

public class ReservaSalaDto
{
    public DateOnly Data { get; set; }
    public Turno? Turno { get; set; }
    public string? Descricao { get; set; }
    public string? SalaNome { get; set; }
    public string? ProfessorNome { get; set; }
}
