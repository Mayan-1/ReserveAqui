using MediatR;
using System.Text.Json.Serialization;


namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterComFiltro;

public sealed record ObterReservaMaterialComFiltroRequest : IRequest<ICollection<ObterReservaMaterialComFiltroResponse>>
{
    [JsonIgnore]
    public string Material { get; set; }
    [JsonIgnore]
    public string Turno { get; set; }
}

