using MediatR;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.Turma.Atualizar;

public sealed record AtualizarTurmaRequest : IRequest<AtualizarTurmaResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; }
    public int QuantidadeAlunos { get; set; }
    public string Turno { get; set; }
    public string Codigo { get; set; }


} 
