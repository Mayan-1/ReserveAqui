using MediatR;

namespace ReserveAqui.Application.UseCases.Turno.Criar;

public sealed record CriarTurnoRequest(string Nome) : IRequest<CriarTurnoResponse>;
