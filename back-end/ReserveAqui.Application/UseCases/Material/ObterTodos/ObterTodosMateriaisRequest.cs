
using MediatR;

namespace ReserveAqui.Application.UseCases.Material.ObterTodos;

public sealed record ObterTodosMateriaisRequest : IRequest<ICollection<ObterTodosMateriaisResponse>>;

