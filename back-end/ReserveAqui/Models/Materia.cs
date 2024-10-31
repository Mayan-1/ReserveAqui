using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReserveAqui.Models;

public class Materia
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<Professor>? Professores { get; set; }
}
