using MediatR;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Atualizar;
public sealed record AtualizarReservaMaterialRequest : IRequest<AtualizarReservaMaterialResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public DateOnly Data { get; set; }
    public string Turno { get; set; }
    public string Descricao { get; set; }
    public string Material { get; set; }
    [JsonIgnore]
    public int IdProfessor { get; set; }
}    
     
