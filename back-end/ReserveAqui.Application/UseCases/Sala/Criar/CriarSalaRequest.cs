using MediatR;

namespace ReserveAqui.Application.UseCases.Sala.Criar;

public sealed record CriarSalaRequest(string Nome, string Tipo, int Capacidade) : IRequest<CriarSalaResponse>;
