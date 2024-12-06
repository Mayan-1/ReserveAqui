using MediatR;

namespace ReserveAqui.Application.UseCases.Administrador.ObterTodos;

public sealed record ObterTodosAdministradoresRequest() : IRequest<ICollection<ObterTodosAdministradoresResponse>>;
