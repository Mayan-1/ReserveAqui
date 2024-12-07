using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaSala.Atualizar;

public sealed record AtualizarReservaSalaRequest(int Id, DateOnly Data, string Turno, string Descricao,
                                                 string Sala, string Professor) : IRequest<AtualizarReservaSalaResponse>;
