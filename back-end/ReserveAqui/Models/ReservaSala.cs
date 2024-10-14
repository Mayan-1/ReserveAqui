using System.ComponentModel.DataAnnotations;

namespace ReserveAqui.Models;

public class ReservaSala
{
    public int Id { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFim { get; set; }
    public string? Descricao { get; set; }
    public Sala? Sala { get; set; }
    public Professor? Professor { get; set; }

}
