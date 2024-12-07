using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaSala.Deletar;

public sealed record DeletarReservaSalaRequest(int Id) : IRequest<DeletarReservaSalaResponse>;
