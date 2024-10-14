namespace ReserveAqui.Models;

public class ReservaMaterial
{
    public int Id { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFim { get; set; }
    public string? Descricao { get; set; }
    public Material? Material { get; set; }
    public Professor? Professor { get; set; }
}
