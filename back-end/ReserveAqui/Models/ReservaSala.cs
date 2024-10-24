using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models;

public class ReservaSala
{
    public int Id { get; set; }
    public string? Turno { get; set; }
    public string? Descricao { get; set; }
    public Sala? Sala { get; set; }
    public Professor? Professor { get; set; }

}
