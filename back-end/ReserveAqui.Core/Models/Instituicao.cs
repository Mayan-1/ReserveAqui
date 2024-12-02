using ReserveAqui.Core.Common;
using System.Text.Json.Serialization;

namespace ReserveAqui.Core.Models;

public class Instituicao : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<Administrador>? Administradores { get; set; }
    [JsonIgnore]
    public ICollection<Professor>? Professores { get; set; }

}
