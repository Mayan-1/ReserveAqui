using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Deletar;

public sealed record DeletarReservaMaterialRequest(int Id) : IRequest<DeletarReservaMaterialResponse>;
