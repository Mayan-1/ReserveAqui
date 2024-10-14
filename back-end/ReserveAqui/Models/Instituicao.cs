namespace ReserveAqui.Models;

public class Instituicao
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public ICollection<Administrador>? Administradores { get; set; }
    public ICollection<Professor>? Professores { get; set; }

}
