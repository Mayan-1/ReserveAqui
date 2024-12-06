using MediatR;

namespace ReserveAqui.Application.UseCases.Administrador.Atualizar;

public sealed record AtualizarAdministradorRequest(int Id, string Nome, string Email, 
                                                    string Cpf, string Telefone, string Instituicao) : IRequest<AtualizarAdministradorResponse>;
