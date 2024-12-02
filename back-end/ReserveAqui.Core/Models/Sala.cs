using ReserveAqui.Core.Common;

namespace ReserveAqui.Core.Models;

public class Sala : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public int Capacidade { get; set; }
}
