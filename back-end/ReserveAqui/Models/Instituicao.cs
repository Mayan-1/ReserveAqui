using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReserveAqui.Models;

public class Instituicao
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; } = string.Empty;
    [JsonIgnore]
    public ICollection<Administrador>? Administradores { get; set; }
    [JsonIgnore]
    public ICollection<Professor>? Professores { get; set; }

}
