using MediatR;

namespace ReserveAqui.Application.UseCases.Administrador.Criar;

public sealed record CriarAdministradorRequest(string Nome, string Email, string Senha, 
                                               string Cpf, string Telefone, string Instituicao) : IRequest<CriarAdministradorResponse>;
