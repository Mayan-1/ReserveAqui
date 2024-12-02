using ReserveAqui.Core.Common;
using System.Text.Json.Serialization;

namespace ReserveAqui.Core.Models;

public class Materia : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<Professor>? Professores { get; set; }
}
