using ReserveAqui.Core.Common;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Models;

public class Turma : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public int QuantidadeAlunos{ get; set; }
    public Turno? Turno { get; set; }
    public string Codigo { get; set; } = string.Empty;
}
