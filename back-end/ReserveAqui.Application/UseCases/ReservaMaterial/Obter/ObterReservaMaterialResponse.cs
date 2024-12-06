using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Obter;

public sealed record ObterReservaMaterialResponse
{
    public DateOnly Data { get; set; }
    public Core.Models.Turno? Turno { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public Core.Models.Material? Material { get; set; }
    public Professor? Professor { get; set; }
}