using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos;

public sealed record ObterTodasReservasMateriaisRequest : IRequest<ICollection<ObterTodasReservasMateriaisResponse>>;
