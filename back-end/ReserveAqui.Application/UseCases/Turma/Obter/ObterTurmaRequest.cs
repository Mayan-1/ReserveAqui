using MediatR;

namespace ReserveAqui.Application.UseCases.Turma.Obter;

public sealed record ObterTurmaRequest(int Id) : IRequest<ObterTurmaResponse>
{
}
