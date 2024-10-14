namespace ReserveAqui.Models;

public class Materia
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public ICollection<Professor>? Professores { get; set; }
}
