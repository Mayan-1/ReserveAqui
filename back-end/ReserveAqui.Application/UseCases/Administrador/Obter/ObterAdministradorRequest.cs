using MediatR;

namespace ReserveAqui.Application.UseCases.Administrador.Obter;

public sealed record ObterAdministradorRequest(int Id) : IRequest<ObterAdministradorResponse>;
