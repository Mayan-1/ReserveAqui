
using ReserveAqui.Core.Common;

namespace ReserveAqui.Core.Models;

public class ReservaMaterial : BaseEntity
{
    public DateOnly Data { get; set; }
    public Turno? Turno { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public Material? Material { get; set; }
    public Professor? Professor { get; set; }
}
