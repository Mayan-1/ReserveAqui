using MediatR;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.Professores.Criar;

public sealed record CriarProfessorRequest :  IRequest<CriarProfessorResponse>
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public string Materia { get; set; }
    [JsonIgnore]
    public int IdInstituicao { get; set; }
} 


