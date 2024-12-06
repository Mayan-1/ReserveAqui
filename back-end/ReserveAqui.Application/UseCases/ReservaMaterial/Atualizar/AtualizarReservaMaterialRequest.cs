using MediatR;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Atualizar;
public sealed record AtualizarReservaMaterialRequest(int Id, DateOnly Data, string Turno, 
                                                   string Descricao, string Material, string Professor) : IRequest<AtualizarReservaMaterialResponse>;
