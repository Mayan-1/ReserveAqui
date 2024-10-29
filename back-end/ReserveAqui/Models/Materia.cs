using System.Text.Json.Serialization;

namespace ReserveAqui.Models;

public class Materia
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    [JsonIgnore]
    public ICollection<Professor>? Professores { get; set; }
}
