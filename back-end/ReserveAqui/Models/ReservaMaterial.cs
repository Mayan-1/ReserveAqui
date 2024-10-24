namespace ReserveAqui.Models;

public class ReservaMaterial
{
    public int Id { get; set; }
    public string? Turno { get; set; }
    public string? Descricao { get; set; }
    public Material? Material { get; set; }
    public Professor? Professor { get; set; }
}
