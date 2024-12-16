using MediatR;
using System.Text.Json.Serialization;


namespace ReserveAqui.Application.UseCases.ReservaSala.ObterComFiltro;

public sealed record ObterComFiltroRequest : IRequest<ICollection<ObterComFiltroResponse>>
{
    [JsonIgnore]
    public string Sala { get; set; }
    [JsonIgnore]
    public string Turno { get; set; }
}
    
