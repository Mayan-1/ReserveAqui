using MediatR;

namespace ReserveAqui.Application.UseCases.Turma.ObterTodos;
public sealed record ObterTodasTurmasRequest : IRequest<ICollection<ObterTodasTurmasResponse>>;
