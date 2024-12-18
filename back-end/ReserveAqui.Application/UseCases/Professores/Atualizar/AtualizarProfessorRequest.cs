using MediatR;
using ReserveAqui.Application.UseCases.Professores.Atualizar;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.Professores.Atualizar;

public sealed record AtualizarProfessorRequest : IRequest<AtualizarProfessorResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Materia { get; set; }
    [JsonIgnore]
    public int IdInstituicao { get; set; }
}


