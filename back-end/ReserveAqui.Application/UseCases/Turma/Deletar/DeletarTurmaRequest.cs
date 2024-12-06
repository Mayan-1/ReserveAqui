using MediatR;

namespace ReserveAqui.Application.UseCases.Turma.Deletar;

public sealed record DeletarTurmaRequest(int Id) : IRequest<DeletarTurmaResponse>;
