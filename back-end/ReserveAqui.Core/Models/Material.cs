using ReserveAqui.Core.Common;

namespace ReserveAqui.Core.Models;

public class Material : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public string Tipo { get; set; } = string.Empty;

}
