using MediatR;

namespace ReserveAqui.Application.UseCases.Professores.Obter;

public sealed record ObterProfessorRequest(int Id) : IRequest<ObterProfessorResponse>;

