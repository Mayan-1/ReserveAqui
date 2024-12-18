using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos;

public sealed record ObterTodasReservasMateriaisRequest(int Id) : IRequest<ICollection<ObterTodasReservasMateriaisResponse>>;
