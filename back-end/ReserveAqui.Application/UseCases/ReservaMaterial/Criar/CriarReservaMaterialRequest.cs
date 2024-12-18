using MediatR;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Criar;

public sealed record CriarReservaMaterialRequest : IRequest<CriarReservaMaterialResponse>
{
    public DateOnly Data { get; set; }
    public string Turno { get; set; }
    public string Descricao { get; set; }
    public string Material { get; set; }
    [JsonIgnore]
    public int IdProfessor { get; set; }
} 

