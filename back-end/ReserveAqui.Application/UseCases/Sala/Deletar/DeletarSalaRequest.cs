using MediatR;

namespace ReserveAqui.Application.UseCases.Sala.Deletar;

public sealed record DeletarSalaRequest(int Id) : IRequest<DeletarSalaResponse>;
