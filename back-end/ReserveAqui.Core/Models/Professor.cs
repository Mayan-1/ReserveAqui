using ReserveAqui.Core.Common;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Core.Models;

public class Professor : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Materia? Materia { get; set; }
    public Instituicao? Instituicao { get; set; }
}
