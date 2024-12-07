using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterTodas;

public sealed record ObterTodasReservasSalasRequest : IRequest<ICollection<ObterTodasReservasSalasResponse>>;
