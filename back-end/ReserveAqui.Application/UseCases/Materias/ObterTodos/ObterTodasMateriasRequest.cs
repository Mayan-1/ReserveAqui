using MediatR;

namespace ReserveAqui.Application.UseCases.Materias.ObterTodos;

public sealed record ObterTodasMateriasRequest : IRequest<ICollection<ObterTodasMateriasResponse>>;

