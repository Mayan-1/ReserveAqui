using MediatR;

namespace ReserveAqui.Application.UseCases.Sala.Atualizar;

public sealed record AtualizarSalaRequest(int Id, string Nome, string Tipo, int Capacidade) : IRequest<AtualizarSalaResponse>;
