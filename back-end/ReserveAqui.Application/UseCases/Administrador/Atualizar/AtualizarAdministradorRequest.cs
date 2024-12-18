using MediatR;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.Administrador.Atualizar;

public sealed record AtualizarAdministradorRequest : IRequest<AtualizarAdministradorResponse>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Cpf { get; set; }
    public string Telefone { get; set; }
} 
                                                    