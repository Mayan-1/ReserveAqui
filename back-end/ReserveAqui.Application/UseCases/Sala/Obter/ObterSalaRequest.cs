using MediatR;

namespace ReserveAqui.Application.UseCases.Sala.Obter;

public sealed record ObterSalaRequest(int Id) : IRequest<ObterSalaResponse>;
