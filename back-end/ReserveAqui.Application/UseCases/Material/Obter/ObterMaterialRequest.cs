using MediatR;

namespace ReserveAqui.Application.UseCases.Material.Obter;

public sealed record ObterMaterialRequest(int Id) : IRequest<ObterMaterialResponse>;

