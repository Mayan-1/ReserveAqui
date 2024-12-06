using MediatR;

namespace ReserveAqui.Application.UseCases.Material.Criar;

public sealed record CriarMaterialRequest(string Nome, int Quantidade, string Tipo) : IRequest<CriarMaterialResponse>;

