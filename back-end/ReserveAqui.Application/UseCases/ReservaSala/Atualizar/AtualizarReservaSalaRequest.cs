using MediatR;
using ReserveAqui.Application.UseCases.ReservaSala.Atualizar;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.ReservaSala.Atualizar;

public sealed record AtualizarReservaSalaRequest : IRequest<AtualizarReservaSalaResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public DateOnly Data { get; set; }
    public string Turno { get; set; }
    public string Descricao { get; set; }
    public string Sala { get; set; }
    [JsonIgnore]
    public int IdProfessor { get; set; }
}




