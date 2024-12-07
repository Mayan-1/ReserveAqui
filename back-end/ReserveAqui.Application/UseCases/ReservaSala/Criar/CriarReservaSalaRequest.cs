using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaSala.Criar;

public sealed record CriarReservaSalaRequest(DateOnly Data, string Turno, string Descricao,
                                                 string Sala, string Professor) : IRequest<CriarReservaSalaResponse>;

