using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaSala.Obter;

public sealed record ObterReservaSalaRequest(int Id) : IRequest<ObterReservaSalaResponse>;
