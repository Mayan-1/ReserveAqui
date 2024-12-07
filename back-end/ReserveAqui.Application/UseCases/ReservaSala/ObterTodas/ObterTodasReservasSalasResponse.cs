using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterTodas;

public sealed record ObterTodasReservasSalasResponse
{
    public DateOnly Data { get; set; }
    public Core.Models.Turno? Turno { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public Core.Models.Sala? Sala { get; set; }
    public Professor? Professor { get; set; }
}