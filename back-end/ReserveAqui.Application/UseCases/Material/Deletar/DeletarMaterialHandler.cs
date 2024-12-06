
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;

namespace ReserveAqui.Application.UseCases.Material.Deletar;

public class DeletarMaterialHandler : IRequestHandler<DeletarMaterialRequest, DeletarMaterialResponse>
{
    private readonly IMaterialRepository _materialRepository;
    private readonly IUnitOfWork _uof;

    public DeletarMaterialHandler(IMaterialRepository materialRepository, IUnitOfWork uof)
    {
        _materialRepository = materialRepository;
        _uof = uof;
    }

    public async Task<DeletarMaterialResponse> Handle(DeletarMaterialRequest request, CancellationToken cancellationToken)
    {
        var material = await _materialRepository.Obter(request.Id, cancellationToken);
        if (material == null)
            return new DeletarMaterialResponse { Mensagem = "Material não encontrado" };

        _materialRepository.Deletar(material);
        await _uof.Commit(cancellationToken);

        return new DeletarMaterialResponse { Mensagem = "Material deletado com sucesso" };
    }
}
