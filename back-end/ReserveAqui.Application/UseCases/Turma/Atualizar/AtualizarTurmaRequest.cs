using MediatR;

namespace ReserveAqui.Application.UseCases.Turma.Atualizar;

public sealed record AtualizarTurmaRequest(int Id, string Nome, int QuantidadeAlunos, 
                                           string Turno, string Codigo) : IRequest<AtualizarTurmaResponse>;
