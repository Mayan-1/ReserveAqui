using MediatR;

namespace ReserveAqui.Application.UseCases.Administrador.Deletar;

public sealed record DeletarAdministradorRequest(int Id) : IRequest<DeletarAdministradorResponse>;
