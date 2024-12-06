using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Obter;

public sealed record ObterReservaMaterialRequest(int Id) : IRequest<ObterReservaMaterialResponse>;
