using MediatR;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.ReservaSala.Criar;

public sealed record CriarReservaSalaRequest : IRequest<CriarReservaSalaResponse>
{
    public DateOnly Data { get; set; }
    public string Turno { get; set; }
    public string Descricao { get; set; }
    public string Sala { get; set; }
    [JsonIgnore]
    public int IdProfessor { get; set; }
}
    
    
    

