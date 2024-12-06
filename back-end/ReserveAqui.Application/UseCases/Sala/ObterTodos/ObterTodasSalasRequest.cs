using MediatR;

namespace ReserveAqui.Application.UseCases.Sala.ObterTodos;

public sealed record ObterTodasSalasRequest : IRequest<ICollection<ObterTodasSalasResponse>>;

