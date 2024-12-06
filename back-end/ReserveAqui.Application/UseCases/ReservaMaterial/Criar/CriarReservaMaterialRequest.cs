using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Criar;

public sealed record CriarReservaMaterialRequest(DateOnly Data, string Turno, string Descricao,
                                                 string Material, string Professor) : IRequest<CriarReservaMaterialResponse>;

