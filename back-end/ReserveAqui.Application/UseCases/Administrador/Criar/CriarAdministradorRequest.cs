using MediatR;
using ReserveAqui.Core.Models;
using System.Text.Json.Serialization;

namespace ReserveAqui.Application.UseCases.Administrador.Criar;

public sealed record CriarAdministradorRequest : IRequest<CriarAdministradorResponse>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    [JsonIgnore]
    public int IdInstituicao { get; set; }
} 
                                               
