using MediatR;

namespace ReserveAqui.Application.UseCases.Professores.ObterTodos;

public sealed record ObterTodosProfessoresRequest : IRequest<ICollection<ObterTodosProfessoresResponse>>;
    
