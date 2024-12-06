using AutoMapper;
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.MaterialRepository;

namespace ReserveAqui.Application.UseCases.Material.Atualizar;

public class AtualizarMaterialHandler : IRequestHandler<AtualizarMaterialRequest, AtualizarMaterialResponse>
{
    private readonly IMaterialRepository _materialRepository;
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    public AtualizarMaterialHandler(IMaterialRepository materialRepository, IUnitOfWork uof, IMapper mapper)
    {
        _materialRepository = materialRepository;
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<AtualizarMaterialResponse> Handle(AtualizarMaterialRequest request, CancellationToken cancellationToken)
    {
        var material = _mapper.Map<Core.Models.Material>(request);

        _materialRepository.Atualizar(material);
        await _uof.Commit(cancellationToken);
        return new AtualizarMaterialResponse { Mensagem = "Material atualizado com sucesso" };


    }
}
