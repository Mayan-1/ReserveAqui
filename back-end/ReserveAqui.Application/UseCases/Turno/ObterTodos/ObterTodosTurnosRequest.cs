using MediatR;

namespace ReserveAqui.Application.UseCases.Turno.ObterTodos;

public sealed record ObterTodosTurnosRequest : IRequest<ICollection<ObterTodosTurnosResponse>>;
