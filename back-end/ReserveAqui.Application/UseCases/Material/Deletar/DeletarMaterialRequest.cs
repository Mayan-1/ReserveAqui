using MediatR;

namespace ReserveAqui.Application.UseCases.Material.Deletar;

public sealed record DeletarMaterialRequest(int Id) : IRequest<DeletarMaterialResponse>;

