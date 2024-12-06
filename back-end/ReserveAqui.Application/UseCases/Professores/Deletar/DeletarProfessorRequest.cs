using MediatR;

namespace ReserveAqui.Application.UseCases.Professores.Deletar;

public sealed record DeletarProfessorRequest(int Id) : IRequest<DeletarProfessorResponse>;
