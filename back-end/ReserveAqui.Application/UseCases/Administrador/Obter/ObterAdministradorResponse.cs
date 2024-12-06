using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Administrador.Obter;

public sealed record ObterAdministradorResponse
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Instituicao? Instituicao { get; set; }
}