using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterTodas;

public sealed record ObterTodasReservasSalasRequest(int Id) : IRequest<ICollection<ObterTodasReservasSalasResponse>>;
