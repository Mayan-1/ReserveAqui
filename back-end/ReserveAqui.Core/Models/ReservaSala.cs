using ReserveAqui.Core.Common;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Models;

public class ReservaSala : BaseEntity
{
    public DateOnly Data { get; set; }
    public Turno? Turno { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public Sala? Sala { get; set; }
    public Professor? Professor { get; set; }

}
