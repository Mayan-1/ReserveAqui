using MediatR;

namespace ReserveAqui.Application.UseCases.Turma.Criar;

public sealed record CriarTurmaRequest(string Nome, int QuantidadeAlunos, string Turno, string Codigo) : IRequest<CriarTurmaResponse>;
